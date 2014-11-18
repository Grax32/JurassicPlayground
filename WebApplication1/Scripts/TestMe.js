
function FormatDate(date) {
    var mm = date.getMonth() + 1;
    var dd = date.getDate();
    var yyyy = date.getFullYear();
    mm = (mm < 10) ? '0' + mm : mm;
    dd = (dd < 10) ? '0' + dd : dd;
    return mm + "/" + dd + "/" + yyyy;
}

function OnCurrencyKeyPress(e) {
    var textbox = $('#' + e.target.id).data('tTextBox');
    var amount = e.target.value.toString();
    textbox.digits = GetDecimalDigits(amount);
}

function GetDecimalDigits(amount) {
    /// <summary>Return number of digits after the decimal point</summary>
    var parts = String(amount).split('.');

    if (parts[1]) {
        return parts[1].length;
    } else {
        return 0;
    }
}