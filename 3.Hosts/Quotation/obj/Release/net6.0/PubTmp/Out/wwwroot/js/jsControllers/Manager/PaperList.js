$(document).ready(function () {
    $('#table_id').DataTable({
        paging: false,
        select: true,
        searching: false,
        ordering: false,
        columnDefs: [
            { "width": "150px", "targets": [0, 1] },
            { "width": "40px", "targets": [4] }
        ],
        fixedColumns: true,
        //scrollY: 400,
        //lengthChange: false,
        info: false,
    });

});
$("#alertMesss").fadeTo(7000, 500).slideUp(500, function () {
    $("#alertMesss").slideUp(500);
});

function deleteOrderDetail(id) {

    //confirm("Bạn có chắc chắn muốn xóa?");
    if (confirm("Bạn có chắc chắn muốn xóa?") == true) {
        var url = "/Order/DeleteOrderDetail/" + id;

        $.ajax({
            type: "DELETE",
            url: url,
            async: true,
            success: function (mess) {

                if (mess.isSuccessResult == false) {
                    //$("#alertMesss").removeClass("text-success");
                    //$("#alertMesss").addClass("text-danger");
                    //$("#alertMesss").html(mess.result);
                    alert(mess.result);
                }
                else {
                    //$("#alertMesss").removeClass("text-danger");
                    //$("#alertMesss").addClass("text-success");
                    //$("#alertMesss").html(mess.result);
                    alert(mess.result);
                }
                location.reload();

            },
            error: function (err) {
                $("#alertMesss").removeClass("text-success");
                $("#alertMesss").addClass("text-danger");
                $("#alertMesss").html("Error: " + err);
            }

        });
        setTimeout(function () {// wait for 5 secs(2)
            $("#alertMesss").fadeTo(7000, 500).slideUp(500, function () {
                $("#alertMesss").slideUp(500);
            });
        }, 3000);
    }

}


$(function () {
    $("#btnExport").click(function () {
        $('#table_id').table2excel({
            filename: "KHSX_" + new Date().toISOString().slice(0, 10) + ".xls"
        });
    });
});
