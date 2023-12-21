
$('#knifeList').amsifySelect({
    searchable: true,
    type: 'bootstrap'
});

$('#cusList').amsifySelect({
    searchable: true,
    type: 'bootstrap'
});

$('#paperList').amsifySelect({
    searchable: true,
    type: 'bootstrap'
});

$('#layoutList').amsifySelect({
    searchable: true,
    type: 'bootstrap'
});

$('#cusList').on('change', function () {
    //alert($(this).val());

    var url = "/Manager/CustomerDetail/" + $(this).val();

    $.ajax({
        type: "GET",
        url: url,
        async: true,
        //data: data,
        // async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (mess) {

            console.log(mess);
            $('#CustomerCode').val(mess.customerCodeForProduct).addClass('text-warning');
            $('#CustomerName').val(mess.customerName).addClass('text-warning');
            //$('#NumberTiningColor').val(mess.numberTiningColor).addClass('text-warning');
            //$('#NumberStackColor').val(mess.numberStackColor).addClass('text-warning');
            //$('#NumberRootColor').val(mess.numberRootColor).addClass('text-warning');
            //$('#NumberOfStage').val(mess.numberOfStage).addClass('text-warning');
            //$('#Stage_1').val(mess.stage_1).addClass('text-warning');
            //$('#Stage_2').val(mess.stage_2).addClass('text-warning');
            //$('#Stage_3').val(mess.stage_3).addClass('text-warning');
            //$('#Stage_4').val(mess.stage_4).addClass('text-warning');
            //$('#Stage_5').val(mess.stage_5).addClass('text-warning');
            //$('#PrintStep').val(mess.printStep).addClass('text-warning');
            //$('#LayoutName').val(mess.layoutName).addClass('text-warning');
            //$('#LayoutPosition').val(mess.layoutPosition).addClass('text-warning');


            //$('#Width').val(mess.width).addClass('text-danger');
        },
        error: function (err) {
            alert("Error: " + err);
        }

    });

});

$('#knifeList').on('change', function () {
    //alert($(this).val());
    var layoutList = $("#layoutList");
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
            $('#KnifeSpec').val(mess.knifeSpec).addClass('text-success');
            $('#KnifeContent').val(mess.knifeContent).addClass('text-success');
            $('#Border').val(mess.border).addClass('text-success');
            $('#PaperSize').val(mess.paperSize).addClass('text-success');
            $('#KnifeMainCode').val(mess.knifeMainCode).addClass('text-success');
            $('#WidthLenght').val(mess.widthLenght).addClass('text-success');
            $('#Horizontal').val(mess.horizontal).addClass('text-success');
            $('#SplitLine').val(mess.splitLine).addClass('text-success');
            $('#KnifeStep').val(mess.knifeStep).addClass('text-success');
            $('#StampPerStep').val(mess.stampPerStep).addClass('text-success');

            $('#Center').val(mess.center).addClass('text-success');
            $('#KnifeCode').val(mess.knifeCode).addClass('text-success');
            //$('#Stage_1').val(mess.stage_1).addClass('text-warning');
            //$('#Stage_2').val(mess.stage_2).addClass('text-warning');
            //$('#Stage_3').val(mess.stage_3).addClass('text-warning');
            //$('#Stage_4').val(mess.stage_4).addClass('text-warning');
            //$('#Stage_5').val(mess.stage_5).addClass('text-warning');
            //$('#PrintStep').val(mess.printStep).addClass('text-warning');
            //$('#LayoutName').val(mess.layoutName).addClass('text-warning');
            //$('#LayoutPosition').val(mess.layoutPosition).addClass('text-warning');


            $.each(mess.layouts, function (index, mess) {
                layoutList.append($("<option></option>")
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

$('#paperList').on('change', function () {
    //alert($(this).val());
    //var layoutList = $("#layoutCode");
    //layoutList.empty();
    var url = "/Manager/PaperDetail/" + $(this).val();

    $.ajax({
        type: "GET",
        url: url,
        async: true,
        //data: data,
        // async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (mess) {

            console.log(mess);
            //$('#KnifeSpec').val(mess.knifeSpec).addClass('text-info');
            //$('#LaminatingFilm').val(mess.laminatingFilm).addClass('text-info');

            $('#Supplier').val(mess.supplier).addClass('text-info');

            $('#DecalMaster').val(mess.decalType).addClass('text-info');
            $('#PaperCode').val(mess.paperCode).addClass('text-info');
            //$('#Stage_2').val(mess.stage_2).addClass('text-warning');
            //$('#Stage_3').val(mess.stage_3).addClass('text-warning');
            //$('#Stage_4').val(mess.stage_4).addClass('text-warning');
            //$('#Stage_5').val(mess.stage_5).addClass('text-warning');
            //$('#PrintStep').val(mess.printStep).addClass('text-warning');
            //$('#LayoutName').val(mess.layoutName).addClass('text-warning');
            //$('#LayoutPosition').val(mess.layoutPosition).addClass('text-warning');


            //});
            //$('#Width').val(mess.width).addClass('text-danger');
        },
        error: function (err) {
            alert("Error: " + err);
        }

    });

});

$('#layoutList').on('change', function () {
    //alert($(this).val());
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
            $('#FilmCode').val(mess.filmCode).addClass('text-danger');
            //$('#LaminatingFilm').val(mess.laminatingFilm).addClass('text-danger');
            $('#TotalPrintColor').val(mess.totalPrintColor).addClass('text-danger');
            $('#NumberTiningColor').val(mess.numberTiningColor).addClass('text-danger');
            $('#LayoutOrdinalCode').val(mess.ordinalCode).addClass('text-danger');
            $('#NumberStackColor').val(mess.numberStackColor).addClass('text-danger');
            $('#NumberRootColor').val(mess.numberRootColor).addClass('text-danger');
            $('#NumberOfStage').val(mess.numberOfStage).addClass('text-danger');
            $('#Stage1').val(mess.stage_1).addClass('text-danger');
            $('#Stage2').val(mess.stage_2).addClass('text-danger');
            $('#Stage3').val(mess.stage_3).addClass('text-danger');
            $('#Stage4').val(mess.stage_4).addClass('text-danger');
            $('#Stage5').val(mess.stage_5).addClass('text-danger');
            $('#Stage6').val(mess.stage_6).addClass('text-danger');
            $('#Stage7').val(mess.stage_7).addClass('text-danger');


            $('#PrintStep').val(mess.printStep).addClass('text-danger');


            $('#LayoutName').val(mess.layoutName).addClass('text-danger');
            $('#LayoutPosition').val(mess.layoutPosition).addClass('text-danger');
            $('#LayoutCode').val(mess.layoutCode).addClass('text-danger');


            //});
            //$('#Width').val(mess.width).addClass('text-danger');
        },
        error: function (err) {
            alert("Error: " + err);
        }

    });

});
