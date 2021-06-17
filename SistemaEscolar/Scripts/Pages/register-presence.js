$(document).ready(function () {

    $('#save').on('click', function (e) {
        debugger;
        $(".animate-position-modal").show();
        $(".p-presence").css("opacity", "0.7");
    });

    let isNew = $("#Id").val() == 0;

    if (isNew) {
        let date = new Date();
        $("#DateRegister").val(FormatDateAndTime(date));
    }
    else {
        let dateRegister = $("#Date").val();
        let dateSplit = dateRegister.split('/');
        let year = dateSplit[2].split(' ')[0];
        let month = dateSplit[1];
        let day = dateSplit[0];
        let hours = dateSplit[2].split(' ')[1];
        let dateFinal = new Date(year + '-' + month + '-' + day + "T" + hours);
        $("#DateRegister").val(FormatDateAndTime(dateFinal));
    }
});

FormatDateAndTime = function (date) {
    let day = date.getDate();
    let month = date.getMonth() + 1;
    let year = date.getFullYear();
    let hour = date.getHours();
    let minute = date.getMinutes();

    if (day < 10) {
        day = '0' + day
    }

    if (month < 10) {
        month = '0' + month
    }

    if (hour < 10) {
        hour = '0' + hour
    }

    if (minute < 10) {
        minute = '0' + minute
    }

    return year + '-' + month + '-' + day + "T" + hour + ":" + minute;
}
