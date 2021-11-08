$(function () {
    activateDatePicker();
});

function activateDatePicker() {
    console.log('activate date picker');
    $('input[data-datepicker=true').datepicker();
}