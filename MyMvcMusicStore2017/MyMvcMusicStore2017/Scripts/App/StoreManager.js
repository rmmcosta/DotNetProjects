$(function () {
    $('#album-list img')
        .mouseover(function () { $(this).animate({ width: '+=25', height: '+=25' }); })
        .mouseout(function () { $(this).animate({ width: '-=25', height: '-=25' }); });
});