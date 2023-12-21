$("#usingKnife").click(function () {
    var isUseKnife = $('#usingKnifeValue').is(':checked');

    if (isUseKnife == true) {
        $('#knifeList').prop("disabled", true);
        $('#KnifeSpec').prop("disabled", false);
        $('#KnifeContent').prop("disabled", false);
        $('#ProductName').prop("disabled", false);
        $('#ProductContent').prop("disabled", false);
        $('#Border').prop("disabled", false);
        $('#LaminatingFilm').prop("disabled", false);
        $('#LaminatingSize').prop("disabled", false);
        $('#PaperCode').prop("disabled", false);
        $('#PaperSupply').prop("disabled", false);
        $('#PaperSize').prop("disabled", false);
    }
    else if (isUseKnife == false) {
        $('#knifeList').prop("disabled", true);
        $('#knifeList').prop("type", 'text');
        //$('#KnifeSpec').prop( "disabled", true );
        //$('#KnifeContent').prop( "disabled", true );
        //$('#ProductName').prop( "disabled", true );
        //$('#ProductContent').prop( "disabled", true );
        //$('#Border').prop( "disabled", true );
        //$('#LaminatingFilm').prop( "disabled", true );
        //$('#LaminatingSize').prop( "disabled", true );
        //$('#PaperCode').prop( "disabled", true );
        //$('#PaperSupply').prop( "disabled", true );
        //$('#PaperSize').prop( "disabled", true );
    }
});

//Hiển thị mã đơn hàng theo selector
$('#orderType').on('change', function () {
    var a = $(this).val();
    //alert(a);
    $('#orderTypeCode > option').each(function () {
        //alert($(this).val());
        if (a == $(this).val()) {
            $('#OrderTypeCode').val($(this).text()).addClass('text-danger');
        }
    });
});

function calculateMetterPerOrder() {
    var unit = $('#unit :selected').val();
    var quantity = $('#Quantity').val();
    var config = $('#MetterPerRoll').val();
    var split = $('#SplitLine').val();
    var knifeStep = $('#KnifeStep').val();
    var stampPerStep = $('#StampPerStep').val();
    var total;
    if (unit == 1)//M/Cuộn
    {
        if (config > 30) { config = config - 1; }
        total = (quantity * config) / split; //(Số lượng * số m/cuộn) / xẻ line
    }
    else if (unit == 2)//Tem/Cuộn
    {
        total = (config * (knifeStep / 1000)) / stampPerStep; //(Tem/cuộn * bước dao/1000) / (Tem/nhịp)
    }
    else if (unit == 3)//Tem
    {
        total = (quantity * (knifeStep / 1000)) / stampPerStep; //(Số lượng * bước dao/1000) / (Tem/nhịp)
    }
    $('#MetterPerOrder').val(total).addClass('text-danger');
    alert(total);
}

$('#unit').on('change', function () {
    calculateMetterPerOrder()

});



$('#knifeList').searchBox({
    //mode: 2
});

$('#cusList').amsifySelect({
    searchable: true,
    type: 'bootstrap'
});

$('#cusList').on('change', function () {
    //alert($(this).val());
    var productList = $("#productList");
    productList.empty();

    var url = "/Manager/CustomerForOrder/" + $(this).val();

    $.ajax({
        type: "GET",
        url: url,
        async: true,
        //data: data,
        // async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (mess) {

            console.log(mess);
            $('#CustomerCode').val(mess.customerCodeForProduct).addClass('text-success');
            $('#CustomerName').val(mess.customerName).addClass('text-success');
            //$('#Border').val(mess.border).addClass('text-success');
            //$('#PaperSize').val(mess.paperSize).addClass('text-success');
            //$('#KnifeMainCode').val(mess.knifeMainCode).addClass('text-success');
            //$('#WidthLenght').val(mess.widthLenght).addClass('text-success');
            //$('#Horizontal').val(mess.horizontal).addClass('text-success');
            //$('#SplitLine').val(mess.splitLine).addClass('text-success');
            //$('#KnifeStep').val(mess.knifeStep).addClass('text-success');
            //$('#StampPerStep').val(mess.stampPerStep).addClass('text-success');
            //
            //$('#Center').val(mess.center).addClass('text-success');
            //$('#KnifeCode').val(mess.knifeCode).addClass('text-success');
            //$('#Stage_1').val(mess.stage_1).addClass('text-warning');
            //$('#Stage_2').val(mess.stage_2).addClass('text-warning');
            //$('#Stage_3').val(mess.stage_3).addClass('text-warning');
            //$('#Stage_4').val(mess.stage_4).addClass('text-warning');
            //$('#Stage_5').val(mess.stage_5).addClass('text-warning');
            //$('#PrintStep').val(mess.printStep).addClass('text-warning');
            //$('#LayoutName').val(mess.layoutName).addClass('text-warning');
            //$('#LayoutPosition').val(mess.layoutPosition).addClass('text-warning');


            $.each(mess.products, function (index, mess) {
                productList.append($("<option></option>")
                    .attr("value", mess.value).text(mess.text));

            });

            $('#layoutList').amsifySelect({
                searchable: true,
                type: 'bootstrap'
            }, 'refresh');
            //$('#Width').val(mess.width).addClass('text-danger');
        },
        error: function (err) {
            alert("Error: " + err);
        }

    });

});

$('#btnChooseProduct').on('click', function () {

    var product = $("#productList :selected").val();
    //alert(product);

    if (product <= 0) {
        alert("Vui lòng chọn mã hàng");
    }
    else {
        var url = "/Manager/ProductDetail/" + product;

        $.ajax({
            type: "GET",
            url: url,
            async: true,
            //data: data,
            // async: false,
            contentType: 'application/json; charset=utf-8',
            success: function (mess) {

                console.log(mess);
                $('#Width').val(mess.widthLenght).addClass('text-success');
                $('#NumStampHorizontail').val(mess.horizontal).addClass('text-success');
                $('#Border').val(mess.border).addClass('text-success');
                $('#PaperSize').val(mess.paperSize).addClass('text-success');
                $('#PaperCode').val(mess.paperCode).addClass('text-success');
                $('#PaperSupply').val(mess.supplier).addClass('text-success');
                $('#KnifeMainCode').val(mess.knifeMainCode).addClass('text-success');
                $('#LaminatingFilm').val(mess.laminatingFilm).addClass('text-success');
                $('#LaminatingSize').val(mess.laminatingSize).addClass('text-success');
                $('#SplitLine').val(mess.splitLine).addClass('text-success');
                $('#KnifeStep').val(mess.knifeStep).addClass('text-success');
                $('#KnifeSpec').val(mess.knifeSpec).addClass('text-success');
                $('#KnifeContent').val(mess.knifeContent).addClass('text-success');
                $('#StampPerStep').val(mess.stampPerStep).addClass('text-success');

                $('#Center').val(mess.center).addClass('text-success');
                $('#KnifeCode').val(mess.knifeCode).addClass('text-success');
                $('#Stage_1').val(mess.stage1).addClass('text-warning');
                $('#Stage_2').val(mess.stage2).addClass('text-warning');
                $('#Stage_3').val(mess.stage3).addClass('text-warning');
                $('#Stage_4').val(mess.stage4).addClass('text-warning');
                $('#Stage_5').val(mess.stage5).addClass('text-warning');
                $('#PrintStep').val(mess.printStep).addClass('text-warning');
                $('#LayoutName').val(mess.layoutName).addClass('text-warning');
                $('#LayoutCode').val(mess.layoutCode).addClass('text-warning');
                $('#LayoutPosition').val(mess.layoutPosition).addClass('text-warning');
                $('#DecalMaster').val(mess.decalMaster).addClass('text-warning');
                $('#LayoutMainCode').val(mess.knifeMainCode).addClass('text-warning');
                $('#FilmCode').val(mess.filmCode).addClass('text-warning');
                $('#ColorNumber').val(mess.totalPrintColor).addClass('text-warning');
                $('#NumberTiningColor').val(mess.numberTiningColor).addClass('text-warning');
                $('#NumberStackColor').val(mess.numberStackColor).addClass('text-warning');
                $('#NumberRootColor').val(mess.numberRootColor).addClass('text-warning');
                $('#NumberOfStage').val(mess.numberOfStage).addClass('text-warning');
                //$('#PrintStep').val(mess.printStep).addClass('text-warning');
                $('#Middle').val(mess.center).addClass('text-warning');
                $('#ProductName').val(mess.productName).addClass('text-warning');
                $('#ProductCode').val(mess.productCode).addClass('text-warning');
                $('#ProductType').val(mess.productType).addClass('text-warning');
                $('#ProductContent').val(mess.productContent).addClass('text-warning');

                $('#btnChooseProduct').addClass('d-none');
                $('#btnAddProduct').addClass('d-block').removeClass('d-none');
                $('#ProductNumber').val(1);
                $('#productListSelected').append('<div class="col-xl-3 col-md-6 mb-4" id="productId"> <div class="card border-left-primary shadow h-100 py-2"> <div class="card-body"> <div class="row no-gutters align-items-center"> <div class="col mr-2"> <div class="text-md-start font-weight-bold text-primary text-uppercase mb-1"> Mã hàng  <span id="productCodeSub" class="h5 text-xl text-info">' + mess.productCode + '</span><input id="product" type="hidden" class="form-control form-inline" value="' + mess.productId + '"/> <input id="ordinal" type="hidden" class="form-control form-inline" value="' + $('#ProductNumber').val() + '"/> </div> <div class=" row h6 mb-1 font-weight-bold text-gray-800"><div class="col-md-4">Số lượng</div><div class="col-md-4"> <input id="quantity" type="number" class="form-control form-inline" value="0"></div><div class="col-md-4"> <input id="unitSub" type="text" class="form-control form-inline" value="' + $('#unit :selected').text() + '"></div></div> <div class=" row h6 mb-0 font-weight-bold text-gray-800"><div class="col-md-4">M/ Đơn</div><div class="col-md-4"> <input id="subtotal" type="number" class="form-control form-inline" value="0"></div></div></div><div class="col-auto"><i class="fas fa-product fa-2x text-gray-300"></i> </div> </div> </div> </div> </div>');
            },
            error: function (err) {
                alert("Error: " + err);
            }

        });
    }
});

$('#btnAddProduct').on('click', function () {

    var product = $("#productList :selected").val();
    //alert(product);

    if (product <= 0) {
        alert("Vui lòng chọn mã hàng");
    }
    else {
        var isExist = false;
        var url = "/Manager/ProductDetail/" + product;
        $('div#productId').each(function (index) {

            if ($(this).find('div input#product').val() == product) {
                isExist = true;

            }
            //console.log(isExist);
        });

        if (!isExist) {
            $.ajax({
                type: "GET",
                url: url,
                async: true,
                //data: data,
                // async: false,
                contentType: 'application/json; charset=utf-8',
                success: function (mess) {

                    console.log(mess);

                    //alert(productTag);

                    var totalProduct = $('#ProductNumber').val();
                    $('#ProductNumber').val(parseInt(totalProduct) + 1);
                    $('#productListSelected').append('<div class="col-xl-3 col-md-6 mb-4" id="productId"> <div class="card border-left-primary shadow h-100 py-2"> <div class="card-body"> <div class="row no-gutters align-items-center"> <div class="col mr-2"> <div class="text-md-start font-weight-bold text-primary text-uppercase mb-1"> Mã hàng  <span id="productCodeSub" class="h5 text-xl text-info">' + mess.productCode + '</span><input id="product" type="hidden" class="form-control form-inline" value="' + mess.productId + '"/> <input id="ordinal" type="hidden" class="form-control form-inline" value="' + $('#ProductNumber').val() + '"/> </div> <div class=" row h6 mb-1 font-weight-bold text-gray-800"><div class="col-md-4">Số lượng</div><div class="col-md-4"> <input id="quantity" type="number" class="form-control form-inline" value="0"></div><div class="col-md-4"> <input id="unitSub" type="text" class="form-control form-inline" value="' + $('#unit :selected').text() + '"></div></div> <div class=" row h6 mb-0 font-weight-bold text-gray-800"><div class="col-md-4">M/ Đơn</div><div class="col-md-4"> <input id="subtotal" type="number" class="form-control form-inline" value="0"></div></div></div><div class="col-auto"><i class="fas fa-product fa-2x text-gray-300"></i> </div> </div> </div> </div> </div>');

                },
                error: function (err) {
                    alert("Error: " + err);
                }

            });
        }
    }
});

$('#btnSave').on('click', function () {

    if (confirm("Bạn có chắc chắn muốn lưu?") == true) {
        var data = new FormData();
        //var fileUpload = $("#attachment").get(0);
        //var countFile = $("#attachment")[0].files.length;
        //var files = fileUpload.files;


        //$("#productId").val(0);
        var productionCode = $("#OrderTypeCode").val();
        var customerId = $("#cusList :selected").val();
        var customerCode = $("#CustomerCode").val();
        var customerName = $("#CustomerName").val();
        var pOCode = $("#POCode").val();
        var orderDate = $("#OrderDate").val();
        var deliveryDate = $("#DeliveryDate").val();
        var productType = $("#ProductType").val();
        var knifeSpec = $("#KnifeSpec").val();
        var content = $("#Content").val();
        var numberOfStage = $("#NumberOfStage").val();
        var numberOfCode = $("#ProductNumber").val();
        var laminatingFilm = $("#LaminatingFilm").val();
        var laminatingSize = $("#LaminatingSize").val();
        var paperCode = $("#PaperCode").val();
        var paperSize = $("#PaperSize").val();
        var metterPerRoll = $("#MetterPerRoll").val();
        var stampPerRoll = $("#StampPerRoll").val();
        var quantity = $("#Quantity").val();
        var unit = $("#unit").val();
        var corePerSheet = $("#CorePerSheet").val();
        var metterPerOrder = $("#MetterPerOrder").val();
        var totalMetterPerOrder = $("#TotalMetterPerOrder").val();
        var productedMetter = $("#ProductedMetter").val();
        var layoutCode = $("#LayoutCode").val();
        var note = $("#Note").val();
        var stage_1 = $("#Stage_1").val();
        var stage_2 = $("#Stage_2").val();
        var stage_3 = $("#Stage_3").val();
        var stage_4 = $("#Stage_4").val();
        var stage_5 = $("#Stage_5").val();
        var stage_1_Loss = $("#Stage_1_Loss").val();
        var stage_2_Loss = $("#Stage_2_Loss").val();
        var stage_3_Loss = $("#Stage_3_Loss").val();
        var stage_4_Loss = $("#Stage_4_Loss").val();
        var stage_5_Loss = $("#Stage_5_Loss").val();
        var printSurfaceLoss = $("#PrintSurfaceLoss").val();
        var printSoleLoss = $("#PrintSoleLoss").val();
        var changeProductLoss = $("#ChangeProductLoss").val();
        var changeLaminationLoss = $("#ChangeLaminationLoss").val();
        var lossPercent = $("#LossPercent").val();
        var lossTotal = $("#LossTotal").val();
        var splitLine = $("#SplitLine").val();
        var knifeStep = $("#KnifeStep").val();
        var stampPerStep = $("#StampPerStep").val();
        var width = $("#Width").val();
        var numStampHorizontail = $("#NumStampHorizontail").val();
        var printStep = $("#PrintStep").val();
        var core = $("#Core").val();
        var coreSpec = $("#CoreSpec").val();
        var layoutName = $("#LayoutName").val();
        var layoutPosition = $("#LayoutPosition").val();
        var time_1 = $("#Time_1").val();
        var time_2 = $("#Time_2").val();
        var time_3 = $("#Time_3").val();
        var time_4 = $("#Time_4").val();
        var time_5 = $("#Time_5").val();
        var middle = $("#Middle").val();
        var productionType = $("#orderType :selected").text();
        var orderBy = $("#OrderBy").val();
        var productCode = $("#ProductCode").val();
        var knifeCode = $("#KnifeCode").val();
        var knifeContent = $("#KnifeContent").val();
        var productContent = $("#ProductContent").val();
        var border = $("#Border").val();
        var paperSupply = $("#PaperSupply").val();
        var totalQuantity = $("#TotalQuantity").val();
        var layoutMainCode = $("#LayoutMainCode").val();
        var decalMaster = $("#DecalMaster").val();
        var filmCode = $("#FilmCode").val();
        var productNumber = $("#ProductNumber").val();
        var colorNumber = $("#ColorNumber").val();
        var numberTiningColor = $("#NumberTiningColor").val();
        var numberStackColor = $("#NumberStackColor").val();
        var numberRootColor = $("#NumberRootColor").val();
        var productName = $("#ProductName").val();
        //var ProductOrders = $("#ProductName").val();
        var subModel = [];

        var inputString = '';

        $('div#productId').each(function (index) {
            subModel.push({ 'ProductID': $(this).find('div input#product').val(), 'ProductCode': $(this).find('div span#productCodeSub').text(), 'Ordinal': $(this).find('div input#ordinal').val(), 'Quantity': $(this).find('div input#quantity').val(), 'Unit': $(this).find('div input#unitsub').val() })
            //alert(index);
        });
        //alert(subModel);
        ////console.log(subModel);
        //console.log(subModel);

        var model = { ProductionCode: productionCode, CustomerId: customerId, CustomerCode: customerCode, CustomerName: customerName, POCode: pOCode, OrderDate: orderDate, DeliveryDate: deliveryDate, ProductType: productType, KnifeSpec: knifeSpec, Content: content, NumberOfStage: numberOfStage, NumberOfCode: numberOfCode, LaminatingFilm: laminatingFilm, LaminatingSize: laminatingSize, PaperCode: paperCode, PaperSize: paperSize, MetterPerRoll: metterPerRoll, StampPerRoll: stampPerRoll, Quantity: quantity, Unit: unit, CorePerSheet: corePerSheet, MetterPerOrder: metterPerOrder, TotalMetterPerOrder: totalMetterPerOrder, ProductedMetter: productedMetter, LayoutCode: layoutCode, Note: note, Stage_1: stage_1, Stage_2: stage_2, Stage_3: stage_3, Stage_4: stage_4, Stage_5: stage_5, Stage_1_Loss: stage_1_Loss, Stage_2_Loss: stage_2_Loss, Stage_3_Loss: stage_3_Loss, Stage_4_Loss: stage_4_Loss, Stage_5_Loss: stage_5_Loss, PrintSurfaceLoss: printSurfaceLoss, PrintSoleLoss: printSoleLoss, ChangeProductLoss: changeProductLoss, ChangeLaminationLoss: changeLaminationLoss, LossPercent: lossPercent, LossTotal: lossTotal, SplitLine: splitLine, KnifeStep: knifeStep, StampPerStep: stampPerStep, Width: width, NumStampHorizontail: numStampHorizontail, PrintStep: printStep, Core: core, CoreSpec: coreSpec, LayoutName: layoutName, LayoutPosition: layoutPosition, Time_1: time_1, Time_2: time_2, Time_3: time_3, Time_4: time_4, Time_5: time_5, Middle: middle, ProductionType: productionType, OrderBy: orderBy, ProductCode: productCode, KnifeCode: knifeCode, KnifeContent: knifeContent, ProductContent: productContent, Border: border, PaperSupply: paperSupply, TotalQuantity: totalQuantity, LayoutMainCode: layoutMainCode, DecalMaster: decalMaster, FilmCode: filmCode, ProductNumber: productNumber, ColorNumber: colorNumber, NumberTiningColor: numberTiningColor, NumberStackColor: numberStackColor, NumberRootColor: numberRootColor, ProductName: productName, ProductOrders: subModel };

        console.log(model);

        var url = "/Order/CreateOrderDetailNew";
        //console.log(model);
        $.ajax({
            type: "POST",
            url: url,
            dataType: 'JSON',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(model),
            async: true,
            success: function (mess) {
                alert(url);
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
                //console.log(err);
                //setTimeout(function () {// wait for 5 secs(2)
                //    location.reload(); // then reload the page.(3)
                //}, 5000);
            }

        });
        //}
    }
});
