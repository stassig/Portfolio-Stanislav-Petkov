var priceFilter = "";
var brand = "";

var url = window.location.pathname;
var res = url.split("/");
console.log(res[1]);
brand = $("#brand").val();
priceFilter = $("#price").val();

$(document).ready(function() {

    $.post("http://localhost:8080/" + res[1] + "/autoload/fetchData.php", {
        price: priceFilter,
        brand: brand
    }).done(function(data) {

        $(".wrapper-flex").html(data);
    })
})

$("#brand").change(function(e) {
    e.preventDefault();
    brand = e.target.value;
    
    $.post("http://localhost:8080/" + res[1] + "/autoload/fetchData.php", {
        price: priceFilter,
        brand: brand
    }).done(function(data) {

        $(".wrapper-flex").html(data);
    })
})

$("#price").change(function(e) {
    e.preventDefault();
    priceFilter = e.target.value;

    $.post("http://localhost:8080/" + res[1] + "/autoload/fetchData.php", {
        price: priceFilter,
        brand: brand
    }).done(function(data) {
        console.log(data);
        $(".wrapper-flex").html(data);
    })
})