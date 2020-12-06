$.validator.methods.range = function (value, element, param) {
    var globalizedValue = value.replace(",", ".");
    return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
}
$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
};
$.validator.methods.date = function (value, element) {
    return this.optional(element) || new Date(value) !== "Invalid Date";
}
$.validator.addMethod("notEqual", function (value, element, param) {
    return this.optional(element) || $(param).not(element).get().every(function (item) {
        return $(item).val() != value;
    });
}, "Lütfen farklı bir değer belirtin.");

$.validator.setDefaults({ ignore: ":hidden:not(.chosen-select)" });



function resetValidation() {
    //Removes validation from input-fields 
    $('.input-validation-error').addClass('input-validation-valid');
    $('.input-validation-error').removeClass('input-validation-error');
    //Removes validation message after input-fields
    $('.field-validation-error').html("");
    $('.field-validation-error').addClass('field-validation-valid');
    $('.field-validation-error').removeClass('field-validation-error');
    //Removes validation message after input-fields
    $('.error').html("");
    $('.error').addClass('valid');
    $('.error').removeClass('error');
    //Removes validation summary 
    $('.validation-summary-errors').html("");
    $('.validation-summary-errors').addClass('validation-summary-valid');
    $('.validation-summary-errors').removeClass('validation-summary-errors');

}

function resetFormControl(ModalID) {
    $('input, textarea, select', ModalID).val("");
}