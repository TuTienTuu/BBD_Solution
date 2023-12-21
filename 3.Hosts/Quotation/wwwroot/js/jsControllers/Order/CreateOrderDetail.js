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

$('#knifeList').on('change', function () {
    //alert($(this).val());
    var layoutList = $("#layoutCode");
    layoutList.empty();
    var url = "/Manager/KnifeDetail/" + $(this).val();

    $.ajax({
        type: "GET",
        url: url,
        async: true,
        //data: data,
        // async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (mess) {

            console.log(mess);
            $('#KnifeSpec').val(mess.knifeSpec).addClass('text-danger');
            $('#KnifeContent').val(mess.knifeContent).addClass('text-danger');
            $('#Border').val(mess.border).addClass('text-danger');
            $('#PaperSize').val(mess.paperSize).addClass('text-danger');
            $('#SplitLine').val(mess.splitLine).addClass('text-danger');
            $('#Gap').val(mess.gap).addClass('text-danger');
            $('#StampPerStep').val(mess.stampPerStep).addClass('text-danger');
            $('#KnifeStep').val(mess.knifeStep).addClass('text-danger');
            $('#Width').val(mess.width).addClass('text-danger');
            $('#NumStampHorizontail').val(mess.numStampHorizontail).addClass('text-danger');
            var coreSpec = ((mess.width * mess.numStampHorizontail) + (mess.center * (mess.numStampHorizontail - 1))) + mess.border * 2; //KT ngang * Số tem ngang + Giữa* (Số tem ngang-1) + Biên * 2.

            $('#CoreSpec').val(coreSpec).addClass('text-info');


            $.each(mess.layouts, function (index, mess) {
                layoutList.append($("<option></option>")
                    .attr("value", mess.value).text(mess.text));


            });
            //$('#Width').val(mess.width).addClass('text-danger');
        },
        error: function (err) {
            alert("Error: " + err);
        }

    });

});

$('#layoutCode').on('change', function () {
    //alert($(this).val());
    //var layoutList = $("#layoutCode");
    //layoutList.empty();
    var url = "/Manager/LayoutDetail/" + $(this).val();

    $.ajax({
        type: "GET",
        url: url,
        async: true,
        //data: data,
        // async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (mess) {

            console.log(mess);
            $('#FilmCode').val(mess.filmCode).addClass('text-warning');
            $('#ColorNumber').val(mess.colorNumber).addClass('text-warning');
            $('#NumberTiningColor').val(mess.numberTiningColor).addClass('text-warning');
            $('#NumberStackColor').val(mess.numberStackColor).addClass('text-warning');
            $('#NumberRootColor').val(mess.numberRootColor).addClass('text-warning');
            $('#NumberOfStage').val(mess.numberOfStage).addClass('text-warning');
            $('#Stage_1').val(mess.stage_1).addClass('text-warning');
            $('#Stage_2').val(mess.stage_2).addClass('text-warning');
            $('#Stage_3').val(mess.stage_3).addClass('text-warning');
            $('#Stage_4').val(mess.stage_4).addClass('text-warning');
            $('#Stage_5').val(mess.stage_5).addClass('text-warning');
            $('#PrintStep').val(mess.printStep).addClass('text-warning');
            $('#LayoutName').val(mess.layoutName).addClass('text-warning');
            $('#LayoutPosition').val(mess.layoutPosition).addClass('text-warning');
            if (mess.stage_1 = "In mặt") {
                //(Tổng m/đơn /1000 )*20 + hao hụt in mặt
                alert("Ok");
            }
            if ($('#ProductType').val() = "In màu") {
                if ($('#ProductNumber').val() = 1) {
                    $('#LossPercent').val($('#TotalQuantity').val());
                }
                else {
                    $('#LossPercent').val(0);

                }
            } else {
                $('#LossPercent').val(0);
            }
            //  $.each(mess.layouts, function (index, mess) {
            //layoutList.append($("<option></option>")
            //    .attr("value", mess.value).text(mess.text));


            //});
            //$('#Width').val(mess.width).addClass('text-danger');
        },
        error: function (err) {
            alert("Error: " + err);
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

