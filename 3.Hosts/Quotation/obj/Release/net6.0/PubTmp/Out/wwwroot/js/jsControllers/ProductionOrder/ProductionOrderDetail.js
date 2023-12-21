$(document).ready(function () {
    var stage = $('#numberOfStage').text();
    //alert( stage);
    //if(stage == 1)
    //{

    //}
});

function show(id) {
    var url = "/ProductionOrderDetail/ProductionOrderDetailResult/" + id;

    $.ajax({
        type: "GET",
        url: url,
        async: true,
        //data: data,
        // async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (mess) {
            console.log(mess);
            $('#view_producionOrderDetailResultId').val(mess.productionOrderDetailResultId);
            //$('#productionCode').val(mess.productionCode);
            //$('#customerName').val(mess.customerName);
            //$('#customerCode').val(mess.customerCode);
            //$('#poCode').val(mess.poCode);
            //$('#orderDate').val(mess.orderDate);
            //$('#deliveryDate').val(mess.deliveryDate);
            //$('#productType').val(mess.productType);
            //$('#knifeSpec').val(mess.knifeSpec);
            //$('#contentView').text(mess.content);
            //$('#numberOfStage').val(mess.numberOfStage);
            $('#view_productCode').val(mess.productCode);
            $('#view_layoutCode').val(mess.layoutCode);
            $('#view_layoutName').val(mess.layoutName);
            $('#view_quantity').val(mess.quantity);
            $('#view_unit').val(mess.unit);
            $('#view_productedMetter').val(mess.productedMetter);

            $('#view_result').val(0);
            $('#view_productStage').val(mess.stage);
            $('#view_productStageName').val(mess.stageName);
            $('#view_productMachine').val(mess.machine);

        },
        error: function (err) {
            alert("Error: " + err);
        }

    });
}

function myFunction(e) {
    if (confirm('Lệnh sản xuất sẽ thay đổi, bạn có chắc chắn muốn lưu?')) {
        //$(e.element).closest('form').submit();
        $('#view_producionOrderDetailResultId').val();
        $('#view_productMachine').val();
        $('#view_result').val();

        var url = "/ProductionOrderDetail/UpdateProductionOrderDetailResult";

        var data = new FormData();
        data.append("ID", $('#view_producionOrderDetailResultId').val());
        data.append("machine", $('#view_productMachine').val());
        data.append("result", $('#view_result').val());
        data.append("stage", $('#view_productStage').val());
        data.append("resultDate", $('#view_resultDate').val());
        data.append("startTime", $('#view_startTime').val());
        data.append("endTime", $('#view_endTime').val());
        data.append("startDelayMachineTime", $('#view_startDelayMachineTime').val());
        data.append("endDelayMachineTime", $('#view_endDelayMachineTime').val());
        data.append("startDelayPaperTime", $('#view_startDelayPaperTime').val());
        data.append("endDelayPaperTime", $('#view_endDelayPaperTime').val());
        data.append("startDelayKnifeTime", $('#view_startDelayKnifeTime').val());
        data.append("endDelayKnifeTime", $('#view_endDelayKnifeTime').val());
        data.append("startDelayTableTime", $('#view_startDelayTableTime').val());
        data.append("endDelayTableTime", $('#view_endDelayTableTime').val());
        data.append("startDelayOtherTime", $('#view_startDelayOtherTime').val());
        data.append("endDelayOtherTime", $('#view_endDelayOtherTime').val());

        $.ajax({
            type: "POST",
            url: url,
            contentType: false,
            processData: false,
            data: data,
            async: true,
            success: function (mess) {
                if (mess.isSuccessResult == false) {
                    $("#msg").removeClass("text-success");
                    $("#msg").addClass("text-danger");
                    $("#msg").html(mess.result);
                    alert(mess.result);
                }
                else {
                    $("#msg").removeClass("text-danger");
                    $("#msg").addClass("text-success");
                    $("#msg").html(mess.result);
                    alert(mess.result);

                }
                location.reload();
                //setTimeout(function () {// wait for 5 secs(2)
                //    location.reload(); // then reload the page.(3)
                //}, 5000);

            },
            error: function (err) {

                $("#msg").removeClass("text-success");
                $("#msg").addClass("text-danger");
                $("#msg").html("Error: " + err);
                alert(err.responseText);
                //setTimeout(function () {// wait for 5 secs(2)
                //    location.reload(); // then reload the page.(3)
                //}, 5000);
            }

        });
    }
}

$('#btnComplete').click(function () {
    if (confirm('Lệnh sản xuất sẽ thay đổi, bạn có chắc chắn muốn lưu?')) {

        var url = "/ProductionOrderDetail/UpdateProductionOrderDetailStatus";

        var data = new FormData();
        data.append("ID", $('#productionOrderId').val());
        data.append("status", true);

        $.ajax({
            type: "POST",
            url: url,
            contentType: false,
            processData: false,
            data: data,
            async: true,
            success: function (mess) {
                if (mess.isSuccessResult == false) {
                    $("#msg").removeClass("text-success");
                    $("#msg").addClass("text-danger");
                    $("#msg").html(mess.result);
                    alert(mess.result);
                }
                else {
                    $("#msg").removeClass("text-danger");
                    $("#msg").addClass("text-success");
                    $("#msg").html(mess.result);
                    alert(mess.result);

                }
                window.location.href = '/ProductionOrder/ViewProductionOrderList';
                //setTimeout(function () {// wait for 5 secs(2)
                //    location.reload(); // then reload the page.(3)
                //}, 5000);

            },
            error: function (err) {

                $("#msg").removeClass("text-success");
                $("#msg").addClass("text-danger");
                $("#msg").html("Error: " + err);
                alert(err.responseText);
                //setTimeout(function () {// wait for 5 secs(2)
                //    location.reload(); // then reload the page.(3)
                //}, 5000);
            }

        });
    }
});

$('#btnNotComplete').click(function () {
    if (confirm('Lệnh sản xuất sẽ thay đổi, bạn có chắc chắn muốn lưu?')) {

        var url = "/ProductionOrderDetail/UpdateProductionOrderDetailStatus";

        var data = new FormData();
        data.append("ID", $('#productionOrderId').val());
        data.append("status", false);

        $.ajax({
            type: "POST",
            url: url,
            contentType: false,
            processData: false,
            data: data,
            async: true,
            success: function (mess) {
                if (mess.isSuccessResult == false) {
                    $("#msg").removeClass("text-success");
                    $("#msg").addClass("text-danger");
                    $("#msg").html(mess.result);
                    alert(mess.result);
                }
                else {
                    $("#msg").removeClass("text-danger");
                    $("#msg").addClass("text-success");
                    $("#msg").html(mess.result);
                    alert(mess.result);

                }
                window.location.href = '/ProductionOrder/ViewProductionOrderList';
                //setTimeout(function () {// wait for 5 secs(2)
                //    location.reload(); // then reload the page.(3)
                //}, 5000);

            },
            error: function (err) {

                $("#msg").removeClass("text-success");
                $("#msg").addClass("text-danger");
                $("#msg").html("Error: " + err);
                alert(err.responseText);
                //setTimeout(function () {// wait for 5 secs(2)
                //    location.reload(); // then reload the page.(3)
                //}, 5000);
            }

        });
    }
});

function completeProduction(isComplete) {
    if (confirm('Lệnh sản xuất sẽ thay đổi, bạn có chắc chắn muốn lưu?')) {

        var url = "/ProductionOrderDetail/UpdateProductionOrderDetailStatus";

        var data = new FormData();
        data.append("ID", $('#productionOrderId').val());
        data.append("status", $('#inputUrl').val());
        //data.append("status", isComplete);

        $.ajax({
            type: "POST",
            url: url,
            contentType: false,
            processData: false,
            data: data,
            async: true,
            success: function (mess) {
                if (mess.isSuccessResult == false) {
                    $("#msg").removeClass("text-success");
                    $("#msg").addClass("text-danger");
                    $("#msg").html(mess.result);
                    alert(mess.result);
                }
                else {
                    $("#msg").removeClass("text-danger");
                    $("#msg").addClass("text-success");
                    $("#msg").html(mess.result);
                    alert(mess.result);

                }
                window.location.href = '/ProductionOrder/ViewProductionOrderList';
                //setTimeout(function () {// wait for 5 secs(2)
                //    location.reload(); // then reload the page.(3)
                //}, 5000);

            },
            error: function (err) {

                $("#msg").removeClass("text-success");
                $("#msg").addClass("text-danger");
                $("#msg").html("Error: " + err);
                alert(err.responseText);
                //setTimeout(function () {// wait for 5 secs(2)
                //    location.reload(); // then reload the page.(3)
                //}, 5000);
            }

        });
    }
}
