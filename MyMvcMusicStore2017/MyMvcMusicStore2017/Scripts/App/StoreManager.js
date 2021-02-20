$(function () {
    initializeBounceEffect();

    initializeAutoComplete();
});

function searchFailure() {
    $("#searchresults").html("Sorry, an error has occurred. Please try again.");
}

function initializeBounceEffect() {
    $('#album-list img')
        .mouseover(function () { $(this).effect('bounce', { time: 1, distance: 10 }); });
}

function initializeAutoComplete() {
    $('input[data-autocomplete-source]').each(function () {
        var target = $(this);
        target.autocomplete({ source: target.attr('data-autocomplete-source') });
    });
}