$(function() {
    $('#loginForm').submit(function(event) {

        event.preventDefault();        
        
        if (!$('#email').val()) {
            alert('Please fill in your email address.');
        } else if (!$('#password').val()) {
            alert('Please fill in your password.');
        } else {
            
            $.post($('#loginForm').attr('action'), $(this).serialize(), function (data, status) {
                if (status === 'success') {
                    if (data == 1) {
                        window.location = "http://localhost:8080" + window.location.pathname;                       
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