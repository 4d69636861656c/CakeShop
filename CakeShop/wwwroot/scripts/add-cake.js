// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

const cakeControllerUri = "/api/cake";


$(document).ready(function () {
});


function addCake() {
    const cake = {
        name: $("#name").val()
    };

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: cakeControllerUri,
        contentType: "application/json",
        data: JSON.stringify(cake),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            alert("cake was added successfully!");
        }
    });
}

$(".add-cake-form").on("submit", function () {
    addCake();

    return false;
});
