$(function () {
    $('#album-list img')
        .mouseover(function () { $(this).effect('bounce', { time: 1, distance: 10 }); });
});

function searchFailure() {
    $("#searchresults").html("Sorry, an error has occurred. Please try again.");
}