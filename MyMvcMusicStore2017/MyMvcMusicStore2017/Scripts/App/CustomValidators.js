/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.validate.unobtrusive.js" />

$.validator.unobtrusive.adapters.addSingleVal("maxwords", "maxwords");
$.validator.addMethod("maxwords", function (value, element, maxwords) {
    return value.split(' ').length <= maxwords;
});