$(function () {
    //Image Preview
    $('#new-imageUpload').change(function () {

        const file = this.files[0];
        console.log(file);
        if (file) {
            let reader = new FileReader();
            reader.onload = function (event) {
                $('#previewImg')
                    .attr('src', event.target.result)
                    .width('150px')
                    .height('150px');
            }
            reader.readAsDataURL(file);
        }
    });

    $('#btnSubmitProduct').click(function (event) {

        event.preventDefault();

        var file = $('#new-imageUpload').val();
        var fileType = file.split('.').pop();
        var validImageTypes = ["gif", "jpeg", "png", "jpg"];

        if (!$('#new-product-name').val()) {
            alert('Please fill in a name.');
        }
        else if (!$('#new-product-price').val()) {
            alert('Please fill in a price.');
        }
        else if (isNaN($('#new-product-price').val())) {
            alert('Price should be a numberic value.');
        }
        else if (!$('#new-product-manufacturer').val()) {
            alert('Please fill in a manufacturer.');
        }
        else if (!$('#new-product-screen').val()) {
            alert('Please fill in screen size.');
        }
        else if (isNaN($('#new-product-screen').val())) {
            alert('Screen size should be a numberic value.');
        }
        else if (!$('#new-product-cpu').val()) {
            alert('Please fill in a CPU.');
        }
        else if (!$('#new-product-gpu').val()) {
            alert('Please fill in a GPU.');
        }
        else if (!$('#new-product-ram').val()) {
            alert('Please fill in a RAM.');
        }
        else if (!$('#new-product-hdd').val() && !$('#new-product-ssd').val()) {
            alert('You must fill in at least one of the two: HDD or SSD.');
        }
        else if (!$('#new-product-battery').val()) {
            alert('Please fill in a battery.');
        }
        else if ($('#new-imageUpload').get(0).files.length === 0) {
            alert('Please select an image for the product.');
        }
        else if ($.inArray(fileType, validImageTypes) < 0) {
            alert('Please select a file of type image.');
        }
        else {

            var form = $('#addProductForm')[0];
            var data = new FormData(form);

            $.ajax({
                type: "POST",
                enctype: 'multipart/form-data',
                url: $('#addProductForm').attr('action'),
                data: data,
                processData: false,
                contentType: false,
                cache: false,
                timeout: 800000,
                success: function (data) {
                    if (data === 'success') {
                        window.location = "http://localhost:8080" + window.location.pathname + "?page=catalog";
                    } else {
                        alert(data);
                    }
                },
                error: function (e) {
                    alert('Something went wrong');
                }
            });

        }
    });
});