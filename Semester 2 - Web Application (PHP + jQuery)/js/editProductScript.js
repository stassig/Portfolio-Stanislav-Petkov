$(function () {
    //Image Preview
    $('#imageUpload').change(function () {

        const file = this.files[0];
        if (file) {
            let reader = new FileReader();
            reader.onload = function (event) {
                $('#edit-image').attr('src', event.target.result);
            }
            reader.readAsDataURL(file);
        }
    });

    $('#btnEditProduct').click(function (event) {

        event.preventDefault();

        if (!$('#new-manufacturer').val()) {
            alert('Please fill in a manufacturer.');
            return;
        }
        else if (!$('#new-screen-size').val()) {
            alert('Please fill in screen size.');
            return;
        }
        else if (isNaN($('#new-screen-size').val())) {
            alert('Screen size should be a numberic value.');
            return;
        }
        else if (!$('#new-cpu').val()) {
            alert('Please fill in a CPU.');
            return;
        }
        else if (!$('#new-gpu').val()) {
            alert('Please fill in a GPU.');
            return;
        }
        else if (!$('#new-ram').val()) {
            alert('Please fill in a RAM.');
            return;
        }
        else if (!$('#new-hdd').val() && !$('#new-product-ssd').val()) {
            alert('You must fill in at least one of the two: HDD or SSD.');
            return;
        }
        else if (!$('#new-battery').val()) {
            alert('Please fill in a battery.');
            return;
        }
        else if ($('#imageUpload').val()) {
            var file = $('#imageUpload').val();
            var fileType = file.split('.').pop();
            var validImageTypes = ["gif", "jpeg", "png", "jpg"];
            if ($.inArray(fileType, validImageTypes) < 0) {
                alert('Please select a file of type image.');
                return;
            }
        }

        var form = $('#editProductForm')[0];
        var data = new FormData(form);

        $.ajax({
            type: "POST",
            enctype: 'multipart/form-data',
            url: $('#editProductForm').attr('action'),
            data: data,
            processData: false,
            contentType: false,
            cache: false,
            timeout: 800000,
            success: function (data) {
                if (!isNaN(data)) {
                    window.location = "http://localhost:8080" + window.location.pathname + "?page=selectedProduct&id=" + data;
                } else {
                    alert(data);
                }
            },
            error: function (e) {
                alert('Something went wrong');
            }
        });


    });
});