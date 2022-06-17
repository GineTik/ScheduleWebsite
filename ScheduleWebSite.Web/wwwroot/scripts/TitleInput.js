export default function setTitleInput($elem, callback) {
    $elem.keypress(function (e) {

        var maxlength = Number($(this).attr("data-maxlength"));
        if ($(this).text().length > maxlength)
            e.preventDefault();

        if (e.keyCode == 13) {
            e.preventDefault();
            $(this).blur();
        }
    });
    $elem.focusout(callback);
}