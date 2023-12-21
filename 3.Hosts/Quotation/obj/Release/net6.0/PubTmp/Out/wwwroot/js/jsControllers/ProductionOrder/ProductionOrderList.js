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

function deleteOrder(id) {

    //confirm("Bạn có chắc chắn muốn xóa?");
    if (confirm("Bạn có chắc chắn muốn xóa?") == true) {
        var url = "/ProductionOrder/DeleteOrder/" + id;

        $.ajax({
            type: "DELETE",
            url: url,
            async: true,
            success: function (mess) {

                if (mess.isSuccessResult == false) {
                    $("#alertMesss").removeClass("text-success");
                    $("#alertMesss").addClass("text-danger");
                    $("#alertMesss").html(mess.result);
                }
                else {
                    $("#alertMesss").removeClass("text-danger");
                    $("#alertMesss").addClass("text-success");
                    $("#alertMesss").html(mess.result);
                }
                alert(mess.result);
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

function show(id) {

    var url = "/Order/OrderDetail/" + id;

    $.ajax({
        type: "GET",
        url: url,
        async: true,
        //data: data,
        // async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (mess) {
            console.log(mess);
            $('#orderMasterDetailId').val(mess.orderMasterDetailId);
            $('#productionCode').val(mess.productionCode);
            $('#customerName').val(mess.customerName);
            $('#customerCode').val(mess.customerCode);
            $('#poCode').val(mess.poCode);
            $('#orderDate').val(mess.orderDate);
            $('#deliveryDate').val(mess.deliveryDate);
            $('#productType').val(mess.productType);
            $('#knifeSpec').val(mess.knifeSpec);
            $('#contentView').text(mess.content);
            $('#numberOfStage').val(mess.numberOfStage);
            $('#numberOfCode').val(mess.productNumber);
            $('#laminationCode').val(mess.laminationCode);
            $('#laminationSize').val(mess.laminationSize);
            $('#paperCode').val(mess.paperCode);
            $('#paperSize').val(mess.paperSize);
            $('#metterPerRoll').val(mess.metterPerRoll);
            $('#stampPerRoll').val(mess.stampPerRoll);
            $('#numberOfCode').val(mess.numberOfCode);
            $('#note').text(mess.note);

            if (mess.numberOfStage == 1) {
                $('#stage_1').val(mess.stage_1);
                $('#machine_1').prop('disabled', false);

            } else if (mess.numberOfStage == 2) {
                $('#stage_1').val(mess.stage_1);
                $('#stage_2').val(mess.stage_2);
                $('#machine_1').prop('disabled', false);
                $('#machine_2').prop('disabled', false);

            } else if (mess.numberOfStage == 3) {
                $('#stage_1').val(mess.stage_1);
                $('#stage_2').val(mess.stage_2);
                $('#stage_3').val(mess.stage_3);
                $('#machine_1').prop('disabled', false);
                $('#machine_2').prop('disabled', false);
                $('#machine_3').prop('disabled', false);

            } else if (mess.numberOfStage == 4) {
                $('#stage_1').val(mess.stage_1);
                $('#stage_2').val(mess.stage_2);
                $('#stage_3').val(mess.stage_3);
                $('#stage_4').val(mess.stage_4);
                $('#machine_1').prop('disabled', false);
                $('#machine_2').prop('disabled', false);
                $('#machine_3').prop('disabled', false);
                $('#machine_4').prop('disabled', false);

            } else if (mess.numberOfStage == 5) {
                $('#stage_1').val(mess.stage_1);
                $('#stage_2').val(mess.stage_2);
                $('#stage_3').val(mess.stage_3);
                $('#stage_4').val(mess.stage_4);
                $('#stage_5').val(mess.stage_5);
                $('#machine_1').prop('disabled', false);
                $('#machine_2').prop('disabled', false);
                $('#machine_3').prop('disabled', false);
                $('#machine_4').prop('disabled', false);
                $('#machine_5').prop('disabled', false);

            }

            $('#quantity').val(mess.quantity);
            $('#unit').val(mess.unit);
            $('#corePerSheet').val(mess.corePerSheet);
            $('#metterPerOrder').val(mess.metterPerOrder);
            $('#productedMetter').val(mess.productedMetter);
            $('#layoutCode').val(mess.layoutCode);

        },
        error: function (err) {
            alert("Error: " + err);
        }

    });
}

$('#btnSave').click(function () {

    if (confirm("Bạn có chắc chắn tạo KHSX?") == true) {
        var data = new FormData();
        //var fileUpload = $("#attachment").get(0);
        //var countFile = $("#attachment")[0].files.length;
        //var files = fileUpload.files;

        var url = "/ProductionPlan/CreateProductionPlan";
        //$("#productId").val(0);
        var orderMasterDetailId = $("#orderMasterDetailId").val();
        var productionCode = $("#productionCode").val();
        var customerName = $("#customerName").val();
        var customerCode = $("#customerCode").val();
        var poCode = $("#poCode").val();
        var orderDate = $("#orderDate").val();
        var deliveryDate = $("#deliveryDate").val();
        var planDate = $("#planDate").val();

        var productType = $("#productType").val();
        var knifeSpec = $("#knifeSpec").val();
        var content = $("#contentView").text();
        var note = $("#note").text();
        var numberOfStage = $("#numberOfStage").val();
        var machine = $("#machine").val();
        //var layoutId = $("#layoutList option:selected").val();
        var numberOfCode = $("#numberOfCode").val();
        var laminationCode = $("#laminationCode").val();
        var laminationSize = $("#laminationSize").val();
        var paperCode = $("#paperCode").val();
        var paperSize = $("#paperSize").val();
        var metterPerRoll = $("#metterPerRoll").val();
        var stampPerRoll = $("#stampPerRoll").val();
        var quantity = $("#quantity").val();
        var unit = $("#unit").val();
        var corePerSheet = $("#corePerSheet").val();
        var metterPerOrder = $("#metterPerOrder").val();
        var productedMetter = $("#productedMetter").val();
        var layoutCode = $("#layoutCode").val();
        var machine_1 = $("#machine_1").val();
        var machine_2 = $("#machine_2").val();
        var machine_3 = $("#machine_3").val();
        var machine_4 = $("#machine_4").val();
        var machine_5 = $("#machine_5").val();
        var stage_1 = $("#stage_1").val();
        var stage_2 = $("#stage_2").val();
        var stage_3 = $("#stage_3").val();
        var stage_4 = $("#stage_4").val();
        var stage_5 = $("#stage_5").val();

        var model = { OrderMasterDetailID: orderMasterDetailId, ProductionCode: productionCode, CustomerCode: customerCode, CustomerName: customerName, POCode: poCode, OrderDate: orderDate, DeliveryDate: deliveryDate, ProductType: productType, KnifeSpec: knifeSpec, Content: content, Note: note, NumberOfStage: numberOfStage, NumberOfCode: numberOfCode, LaminationCode: laminationCode, LaminationSize: laminationSize, PaperCode: paperCode, PaperSize: paperSize, MetterPerRoll: metterPerRoll, StampPerRoll: stampPerRoll, Quantity: quantity, Unit: unit, CorePerSheet: corePerSheet, MetterPerOrder: metterPerOrder, ProductedMetter: productedMetter, LayoutCode: layoutCode, PlanDate: planDate, Machine: machine, Stage_1: stage_1, Stage_2: stage_2, Stage_3: stage_3, Stage_4: stage_4, Stage_5: stage_5, Stage_1_Machine: machine_1, Stage_2_Machine: machine_2, Stage_3_Machine: machine_3, Stage_4_Machine: machine_4, Stage_5_Machine: machine_5 };
        console.log(model);
        $.ajax({
            type: "POST",
            url: url,
            dataType: 'JSON',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(model),
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
                    location.reload();
                }

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

function showProductionOrder(id) {
    var url = "/Order/GetMachineListForProductNew?orderMasterDetailId=" + id;
    //alert(this.value);
    // $("#productId").val(this.value);//<tr style='display:none;'><td>1</td><td>2</td><td>3</td><td>4</td><td>5</td><td>6</td><td>7</td><td>8</td><td>9</td><td>10</td><td>11</td><td>12</td><td>13</td><td>14</td><td>15</td><td>16</td><td>17</td><td>18</td><td>19</td><td>20</td><td>21</td><td>22</td></tr>
    var select = $("#productArea");
    //select.empty();
    //select.append($("<tr class='normal-background text-center'><td>No</td><td colspan='2'>Mã SP</td><td colspan='2'>Mã Layout</td><td colspan='3'>Layout name</td><td>Số lượng</td><td>ĐVT</td><td>Số m</td><td colspan='3'>Số máy</td<td colspan='6'>Công đoạn</td><td>Kết quả</td></tr>"));

    $.ajax({
        type: "GET",
        url: url,
        //data: data,
        async: true,
        contentType: 'application/json; charset=utf-8',
        success: function (mess) {
            console.log(mess);
            $.each(mess.productList, function (index, mess) {
                //console.log(mess.machineList);
                select.append($("<tr class='non-background text-center'><td>" + (index + 1) + "</td><td colspan='2' id='productionOrder_ProductCode'>" + mess.productCode + "</td><td colspan='2' id='productionOrder_LayoutCode'>" + mess.layoutCode + "</td><td colspan='3' id='productionOrder_LayoutName'>" + mess.layoutName + "</td><td id='productionOrder_Quantitys'>" + mess.quantity + "</td><td id='productionOrder_Unit'>" + mess.unit + "</td><td></td><td colspan='3' id='productionOrder_Machine'>" + 1 + "</td><td colspan='6' id='productionOrder_Stage_1'>" + mess.stage_1 + "</td><td></td></tr>"));

            });
            $('#productionOrder_ProductionCode').text(mess.plan.productionCode);
            $('#productionOrder_CustomerName').text(mess.plan.customerName);
            $('#productionOrder_Note').text(mess.plan.note);
            $('#productionOrder_POCode').text(mess.plan.poCode);
            $('#productionOrder_OrderDate').text(mess.plan.orderDate);
            $('#productionOrder_DeliveryDate').text(mess.plan.deliveryDate);
            $('#productionOrder_ProductType').text(mess.plan.productType);
            $('#productionOrder_KnifeSpec').text(mess.plan.knifeSpec);
            $('#productionOrder_MetterPerRoll').text(mess.plan.metterPerRoll);
            $('#productionOrder_StampPerRoll').text(mess.plan.stampPerRoll);
            $('#productionOrder_Quantity').text(mess.plan.quantity);
            $('#productionOrder_Unit').text(mess.plan.unit);
            $('#productionOrder_CorePerSheet').text(mess.plan.corePerSheet);
            $('#productionOrder_ProductNumber').text(mess.plan.productNumber);
            $('#productionOrder_ColorNumber').text(mess.plan.colornumber);
            $('#productionOrder_NumberTiningColor').text(mess.plan.numberTiningColor);
            $('#productionOrder_NumberStackColor').text(mess.plan.numberStackColor);
            $('#productionOrder_NumberRootColor').text(mess.plan.numberRootColor);
            $('#productionOrder_Content').text(mess.plan.content);
            $('#productionOrder_KnifeSpec').text(mess.plan.knifeSpec);
            $('#productionOrder_KnifeCode').text(mess.plan.knifeCode);
            $('#productionOrder_SpliteLine').text(mess.plan.spliteLine);
            $('#productionOrder_Border').text(mess.plan.border);
            $('#productionOrder_KnifeStep').text(mess.plan.knifeStep);
            $('#productionOrder_KnifeContent').text(mess.plan.knifeContent);
            $('#productionOrder_LayoutMainCode').text(mess.plan.layoutMainCode);
            $('#productionOrder_PaperCode').text(mess.plan.paperCode);
            $('#productionOrder_PaperSize').text(mess.plan.paperSize);
            $('#productionOrder_MetterPerOder').text(mess.plan.metterPerOrder);
            $('#productionOrder_LossTotal').text(mess.plan.lossTotal);
            $('#productionOrder_ChangeLaminationLoss').text(mess.plan.changeLaminationLoss);
            $('#productionOrder_TotalMetter').text(mess.plan.totalMetter);
            $('#productionOrder_PaperSupply').text(mess.plan.paperSupply);
            $('#productionOrder_LaminationFilm').text(mess.plan.laminationCode);
            $('#productionOrder_LaminationSize').text(mess.plan.laminationSize);
            $('#productionOrder_LaminationSize').text(mess.plan.laminationSize);
            $('#productionOrder_Stage_1').text(mess.plan.stage_1);
            $('#productionOrder_Stage_1_Loss').text(mess.plan.stage_1_Loss);
            $('#productionOrder_Stage_2').text(mess.plan.stage_1);
            $('#productionOrder_Stage_2_Loss').text(mess.plan.stage_1_Loss);
            $('#productionOrder_Stage_3').text(mess.plan.stage_1);
            $('#productionOrder_Stage_3_Loss').text(mess.plan.stage_1_Loss);
            $('#productionOrder_Stage_4').text(mess.plan.stage_1);
            $('#productionOrder_Stage_4_Loss').text(mess.plan.stage_1_Loss);
            $('#productionOrder_Stage_5').text(mess.plan.stage_1);
            $('#productionOrder_Stage_5_Loss').text(mess.plan.stage_1_Loss);
            $('#productionOrder_Stage_5_Loss').text(mess.plan.stage_1_Loss);
            //$('#decalCode').val(mess.decalCode);
            //$('#productThumbnail').val(mess.productThumbnail);
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }

    });

}

function showProductionPlan(id) {

    var url = "/ProductionPlan/PlanDetail/" + id;

    $.ajax({
        type: "GET",
        url: url,
        async: true,
        //data: data,
        // async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (mess) {
            console.log(mess);
            $('#orderMasterDetailId_Edit').val(mess.orderMasterDetailId);
            $('#productionPlanId_Edit').val(mess.productionPlanId);
            $('#productionCode_Edit').val(mess.productionCode);
            $('#customerName_Edit').val(mess.customerName);
            $('#customerCode_Edit').val(mess.customerCode);
            $('#poCode_Edit').val(mess.poCode);
            $('#orderDate_Edit').val(mess.orderDate);
            $('#planDate_Edit').val(mess.planDate);
            $('#deliveryDate_Edit').val(mess.deliveryDate);
            $('#planDate_Edit').val(mess.planDate);
            $('#productType_Edit').val(mess.productType);
            $('#knifeSpec_Edit').val(mess.knifeSpec);
            $('#contentView_Edit').text(mess.content);
            $('#numberOfStage_Edit').val(mess.numberOfStage);
            $('#numberOfCode_Edit').val(mess.numberOfCode);
            $('#laminationCode_Edit').val(mess.laminationCode);
            $('#laminationSize_Edit').val(mess.laminationSize);
            $('#paperCode_Edit').val(mess.paperCode);
            $('#paperSize_Edit').val(mess.paperSize);
            $('#metterPerRoll_Edit').val(mess.metterPerRoll);
            $('#stampPerRoll_Edit').val(mess.stampPerRoll);
            $('#numberOfCode_Edit').val(mess.numberOfCode);
            $('#note_Edit').text(mess.note);

            $('#stage_1_Edit').val(mess.stage_1);
            $('#stage_2_Edit').val(mess.stage_2);
            $('#stage_3_Edit').val(mess.stage_3);
            $('#stage_4_Edit').val(mess.stage_4);
            $('#stage_5_Edit').val(mess.stage_5);
            $('#machine_1_Edit').val(mess.machine_1);
            $('#machine_2_Edit').val(mess.machine_2);
            $('#machine_3_Edit').val(mess.machine_3);
            $('#machine_4_Edit').val(mess.machine_4);
            $('#machine_5_Edit').val(mess.machine_5);

            if (mess.numberOfStage == 1) {
                //$('#stage_1_Edit').prop('disabled', false);
                $('#machine_1_Edit').prop('disabled', false);

            } else if (mess.numberOfStage == 2) {
                //$('#stage_1_Edit').prop('disabled', false);
                //$('#stage_2_Edit').prop('disabled', false);
                $('#machine_1_Edit').prop('disabled', false);
                $('#machine_2_Edit').prop('disabled', false);

            } else if (mess.numberOfStage == 3) {
                //$('#stage_1_Edit').prop('disabled', false);
                //$('#stage_2_Edit').prop('disabled', false);
                //$('#stage_3_Edit').prop('disabled', false);
                $('#machine_1_Edit').prop('disabled', false);
                $('#machine_2_Edit').prop('disabled', false);
                $('#machine_3_Edit').prop('disabled', false);

            } else if (mess.numberOfStage == 4) {
                //$('#stage_1_Edit').prop('disabled', false);
                //$('#stage_2_Edit').prop('disabled', false);
                //$('#stage_3_Edit').prop('disabled', false);
                //$('#stage_4_Edit').prop('disabled', false);
                $('#machine_1_Edit').prop('disabled', false);
                $('#machine_2_Edit').prop('disabled', false);
                $('#machine_3_Edit').prop('disabled', false);
                $('#machine_4_Edit').prop('disabled', false);

            } else if (mess.numberOfStage == 5) {
                //$('#stage_1_Edit').prop('disabled', false);
                //$('#stage_2_Edit').prop('disabled', false);
                //$('#stage_3_Edit').prop('disabled', false);
                //$('#stage_4_Edit').prop('disabled', false);
                //$('#stage_5_Edit').prop('disabled', false);
                $('#machine_1_Edit').prop('disabled', false);
                $('#machine_2_Edit').prop('disabled', false);
                $('#machine_3_Edit').prop('disabled', false);
                $('#machine_4_Edit').prop('disabled', false);
                $('#machine_5_Edit').prop('disabled', false);

            }

            $('#quantity').val(mess.quantity);
            $('#unit').val(mess.unit);
            $('#corePerSheet').val(mess.corePerSheet);
            $('#metterPerOrder').val(mess.metterPerOrder);
            $('#productedMetter').val(mess.productedMetter);
            $('#layoutCode').val(mess.layoutCode);

        },
        error: function (err) {
            alert("Error: " + err);
        }

    });
}

$('#btnSave_Edit').click(function () {

    if (confirm("Bạn có chắc chắn cập nhật KHSX?") == true) {
        var data = new FormData();
        //var fileUpload = $("#attachment").get(0);
        //var countFile = $("#attachment")[0].files.length;
        //var files = fileUpload.files;

        var url = "/ProductionPlan/UpdateProductionPlan";
        //$("#productId").val(0);
        //var orderMasterDetailId = $("#orderMasterDetailId").val();
        var productionPlanId = $("#productionPlanId_Edit").val();
        //var productionCode = $("#productionCode").val();
        //var customerName = $("#customerName").val();
        //var customerCode = $("#customerCode").val();
        //var poCode = $("#poCode").val();
        //var oplanDate = $("#orderDate").val();
        //var deliveryDate = $("#deliveryDate").val();
        var planDate = $("#planDate_Edit").val();

        //var productType = $("#productType").val();
        //var knifeSpec = $("#knifeSpec").val();
        //var content = $("#content").val();
        //var numberOfStage = $("#numberOfStage").val();
        //var machine = $("#machine").val();
        //var layoutId = $("#layoutList option:selected").val();
        var numberOfCode = $("#numberOfCode_Edit").val();
        //ar laminationCode = $("#laminationCode").val();
        //ar laminationSize = $("#laminationSize").val();
        //ar paperCode = $("#paperCode").val();
        //ar paperSize = $("#paperSize").val();
        //ar metterPerRoll = $("#metterPerRoll").val();
        //ar stampPerRoll = $("#stampPerRoll").val();
        //ar quantity = $("#quantity").val();
        //ar unit = $("#unit").val();
        //ar corePerSheet = $("#corePerSheet").val();
        //ar metterPerOrder = $("#metterPerOrder").val();
        //ar productedMetter = $("#productedMetter").val();
        //ar layoutCode = $("#layoutCode").val();
        var machine_1 = $("#machine_1_Edit").val();
        var machine_2 = $("#machine_2_Edit").val();
        var machine_3 = $("#machine_3_Edit").val();
        var machine_4 = $("#machine_4_Edit").val();
        var machine_5 = $("#machine_5_Edit").val();
        //var stage_1 = $("#stage_1_Edit").val();
        //var stage_2 = $("#stage_2_Edit").val();
        //var stage_3 = $("#stage_3_Edit").val();
        //var stage_4 = $("#stage_4_Edit").val();
        //var stage_5 = $("#stage_5_Edit").val();

        var model = { ProductionPlanID: productionPlanId, NumberOfCode: numberOfCode, PlanDate: planDate, Stage_1_Machine: machine_1, Stage_2_Machine: machine_2, Stage_3_Machine: machine_3, Stage_4_Machine: machine_4, Stage_5_Machine: machine_5 };
        console.log(model);
        $.ajax({
            type: "POST",
            url: url,
            dataType: 'JSON',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(model),
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
                    location.reload();
                }

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
