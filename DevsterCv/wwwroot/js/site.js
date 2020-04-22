$(document).ready(function () {
    $('.checkbox').change(function () {     
        if (this.checked) {
            $(this).closest(".assignmentin").removeClass("filter");

        }
        else {
            $(this).closest(".assignmentin").addClass("filter");
        }
    });

    $('.checkboxteknik').change(function () {
        if (this.checked) {
            $(this).closest(".filtercheckteknik").removeClass("filter");

        }
        else {
            $(this).closest(".filtercheckteknik").addClass("filter");
        }
    });

    $("#c").change(function () {
        if ($(this).val() !== '') {
            $('#TheForm').submit();
        }
    });
});



