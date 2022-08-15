
$(function () {

    $.get("https://restcountries.eu/rest/v2/all", function (data, status) {
        if (status === "success") {
            var countries = [];
            for (let country of data) {
                let countryName = country.name;
                countries.push(countryName);
            }

            $("#country").autocomplete({
                source: countries,
                minLength: 3
            });
        }
    });

    $("#birthDate").datepicker({
        changeYear: true,
        changeMonth: true,
        yearRange: "1921:2021",
        dateFormat: "dd/mm/yy"
    })


    $('#registerForm').submit(function (event) {

        event.preventDefault();

        if (!$('#email').val()) {
            alert('Please fill in your email address.');
        }
        else if (!$('#username').val()) {
            alert('Please fill in your username.');
        }
        else if ($('#username').val().length < 5) {
            alert('Your username should be at least 5 characters.');
        }
        else if (!$('#password').val()) {
            alert('Please fill in your password.');
        }
        else if ($('#password').val().length < 5) {
            alert('Your password should be at least 5 characters.');
        }
        else if (!$('#country').val()) {
            alert('Please fill in your country.');
        }
        else if (!$('#birthDate').val()) {
            alert('Please fill in your date of birth.');
        } else {
            $.post($('#registerForm').attr('action'), $(this).serialize(), function (data, status) {
                if (status === 'success') {
                    if (data.includes('Welcome')) {

                        window.location = "http://localhost:8080" + window.location.pathname + "?message=" + data;
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