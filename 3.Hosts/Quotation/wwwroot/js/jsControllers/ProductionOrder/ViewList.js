// function exportExcel()
//{

//    var selectDate = $('#date').val();
//    alert(selectDate);
//    var url = "/ProductionOrder/ExportExcel?date=" +selectDate ;

//    $.ajax({
//        type: "GET",
//        url: url,
//        async: true,
//        success: function (mess) {

//        },
//        error: function (err) {
//            $("#alertMesss").removeClass("text-success");
//            $("#alertMesss").addClass("text-danger");
//            $("#alertMesss").html("Error: " + err);
//        }

//    });

//}

function exportExcel() {

    //confirm("Bạn có chắc chắn muốn xóa?");
    var selectDate = $('#date').val();
    alert(selectDate);
    var url = "/ProductionOrder/ExportExcel?date=" + selectDate;


    $.ajax({
        type: "GET",
        url: url,
        async: true,
        success: function (mess) {

            if (mess.isSuccessResult == false) {
                //$("#alertMesss").removeClass("text-success");
                //$("#alertMesss").addClass("text-danger");
                //$("#alertMesss").removeClass("d-none");
                //$("#alertMesss").html(mess.result);
                debugger;
                var bytes = new Uint8Array(mess.FileContents);
                var blob = new Blob([bytes], { type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" });
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(blob);
                link.download = "myFileName.xlsx";
                link.click();
            }
            //else {
            //    //$("#alertMesss").removeClass("text-danger");
            //    //$("#alertMesss").removeClass("d-none");
            //    //$("#alertMesss").addClass("text-success");
            //    //$("#alertMesss").html(mess.result);
            //    //alert(mess.result);
            //}
            location.reload();

        },
        error: function (err) {
            //$("#alertMesss").removeClass("text-success");
            //$("#alertMesss").addClass("text-danger");
            //$("#alertMesss").html("Error: " + err);
            alert("Error: " + err);
        }

    });
    setTimeout(function () {// wait for 5 secs(2)
        $("#alertMesss").fadeTo(7000, 500).slideUp(500, function () {
            $("#alertMesss").slideUp(500);
        });
    }, 3000);

    //$("#alertMesss").addClass("d-none");

}

//$("#btnExport").on('click',function(){
//    $('#btnExport').prop("href", "/ProductionOrder/ExportExcel?date=2023-03-24");
//      });
//if (confirm('Lệnh sản xuất sẽ thay đổi, bạn có chắc chắn muốn lưu?'))
//{
//  $(e.element).closest('form').submit();
//}
//https://localhost:7264/ProductionOrder/ExportExcel?date=2023-03-24

$(function () {
    $("#btnExport").click(function () {
        $('#table_id').table2excel({
            filename: "HTSX_" + new Date().toISOString().slice(0, 10) + ".xls"
        });
    });
});
