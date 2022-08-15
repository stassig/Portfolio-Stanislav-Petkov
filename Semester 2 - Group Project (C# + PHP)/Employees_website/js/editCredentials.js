$(function () {
    //Image Preview
    $('#imageUpload').change(function () {

        const file = this.files[0];
        if (file) {
            let reader = new FileReader();
            reader.onload = function (event) {
                $('#photo').attr('src', event.target.result);
            }
            reader.readAsDataURL(file);
        }
    });
    $('#btnSubmitDetails').click(function (event) {

         if ($('#imageUpload').val()) {
            var file = $('#imageUpload').val();
            var fileType = file.split('.').pop();
            var validImageTypes = ["gif", "jpeg", "png", "jpg"];
            if ($.inArray(fileType, validImageTypes) < 0) {
                event.preventDefault();
                alert('Please select a file of type image.');                
                return;
            }
        }     
    });
});