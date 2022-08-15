$(function() {
    $("#contact-info").hide();
    $("#contacts").on("click", function() {
        $("#contact-info").slideToggle();
        $(".footer-container").css("background-color", "rgb(41, 36, 42)");
    });
})