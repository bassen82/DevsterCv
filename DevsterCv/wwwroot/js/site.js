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

    $('i.edithidden').click(function () {
        $(this).parent().next(".editinfo").addClass('show')
        $(this).parent().addClass('dontdisplay')
    })

    $('i.editcontacthidden').click(function () {
        $(this).parent().parent().next(".editinfo").addClass('show')
        $(this).parent().parent().addClass('dontdisplay')
    })

    $('i.editassignmenthidden').click(function () {
        $(this).parent().parent().parent().nextAll(".editinfo:first").toggle().addClass('show')
        $(this).parent().parent().parent(".assignmentin:first").addClass('dontdisplay')
    })

    $('.editcreateassignment').click(function () {
        $(this).parent().next(".editinfo").addClass('show')
        $(this).parent().addClass('dontdisplay')
    })

    $('.checkboxfocus').change(function () {

        if (this.checked) {
            $(this).closest(".bananer").removeClass("filter");

        }
        else {
            $(this).closest(".bananer").addClass("filter");
        }
    });

    $("#Employeelist").change(function () {
            if ($(this).val() !== '') {
                $('#TheForm').submit();
            }         
    });

});



