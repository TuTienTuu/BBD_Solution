
function deleteColorLoss(id) {

    //confirm("Bạn có chắc chắn muốn xóa?");
    if (confirm("Bạn có chắc chắn muốn xóa?") == true) {
        var url = "/Manager/DeleteColorLoss/" + id;

        $.ajax({
            type: "DELETE",
            url: url,
            async: true,
            success: function (mess) {

                if (mess.isSuccessResult == false) {
                    $("#alertMesss").removeClass("text-success");
                    $("#alertMesss").addClass("text-danger");
                    $("#alertMesss").html(mess.result);
                    alert(mess.result);
                }
                else {
                    $("#alertMesss").removeClass("text-danger");
                    $("#alertMesss").addClass("text-success");
                    $("#alertMesss").html(mess.result);
                    alert(mess.result);
                }
                location.reload();

            },
            error: function (err) {
                $("#alertMesss").removeClass("text-success");
                $("#alertMesss").addClass("text-danger");
                $("#alertMesss").html("Error: " + err);
                alert(err.responseText);
            }

        });
        setTimeout(function () {// wait for 5 secs(2)
            $("#alertMesss").fadeTo(7000, 500).slideUp(500, function () {
                $("#alertMesss").slideUp(500);
            });
        }, 3000);
    }

}

function show(id) {

    var url = "/Manager/ColorLossDetail/" + id;

    $.ajax({
        type: "GET",
        url: url,
        async: true,
        //data: data,
        // async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (mess) {
            console.log(mess);
            $('#editColorLossID').val(mess.id);
            $('#editNumberOfColor').val(mess.numberOfColor);
            $('#editLossRate').val(mess.lossRate).change();
            $('#editColorLossType').val(mess.type).change();

        },
        error: function (err) {
            alert("Error: " + err);
        }

    });
}

function save() {
    if (confirm("Bạn có chắc chắn tạo lưu?") == true) {
        var data = new FormData();
        //var fileUpload = $("#attachment").get(0);
        //var countFile = $("#attachment")[0].files.length;
        //var files = fileUpload.files;

        var url = "/Manager/ColorLossUpdate";
        //$("#productId").val(0);
        var colorLossID = $("#editColorLossID").val();
        var numberOfColor = $("#editNumberOfColor  option:selected").val();
        var lossRate = $("#editLossRate").val();
        var typeID = $("#editColorLossType option:selected").val();

        var model = { ID: colorLossID, NumberOfColor: numberOfColor, LossRate: lossRate, TypeID: typeID };
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
}

