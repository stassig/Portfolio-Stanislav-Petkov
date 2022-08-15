$(function () {

    $.get("https://restcountries.eu/rest/v2/all", function (data, status) {
        if (status === "success") {
            var countries = [];
            for (let country of data) {
                let countryName = country.name;
                countries.push(countryName);
            }

            //console.log(countries);

            $("#new-country").autocomplete({
                source: countries,
                minLength: 3
            });
        }
    });

    $("#new-birthDate").datepicker({
        changeYear: true,
        changeMonth: true,
        yearRange: "1921:2021",
        dateFormat: "dd/mm/yy"
    })

    $('#editProfileForm').submit(function (event) {

        event.preventDefault();

        if (!$('#new-email').val()) {
            alert('Please fill in your email address.');
        } else if (!$('#new-username').val()) {
            alert('Please fill in your username.');
        }
        else if ($('#new-username').val().length < 5) {
            alert('Your username should be at least 5 characters.');
        }
        else if (!$('#new-password').val()) {
            alert('Please fill in your password.');
        }
        else if ($('#new-password').val().length < 5) {
            alert('Your password should be at least 5 characters.');
        }
        else if (!$('#new-country').val()) {
            alert('Please fill in your country.');
        }
        else if (!$('#new-birthDate').val()) {
            alert('Please fill in your date of birth.');
        } else {
            $.post($('#editProfileForm').attr('action'), $(this).serialize(), function (data, status) {
                if (status === 'success') {
                    if (data == 'success') {
                        window.location = "http://localhost:8080" + window.location.pathname + "?page=profile";
                    } else {
                        alert(data);
                    }
                } else {
                    alert('Something went wrong');
                }
            });
        }
    });
});