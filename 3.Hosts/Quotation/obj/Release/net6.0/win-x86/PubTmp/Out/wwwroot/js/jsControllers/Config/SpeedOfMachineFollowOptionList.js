function show(id) {

    //confirm("Bạn có chắc chắn muốn xóa?");

    var url = "/Config/SpeedOfMachineFollowOptionDetail/" + id;

    $.ajax({
        type: "DELETE",
        url: url,
        async: true,
        success: function (mess) {

            $('#id').val(mess.id);
            $('#stageName').val(mess.stageName);
            $('#machineName').val(mess.machineName);
            $('#value').val(mess.value);

        }

    });

}


function save() {
    if ($('#value').val() <= 0) {
        alert("Tốc độ không hợp lý");
        return;
    }


    if (confirm("Bạn có chắc chắn muốn lưu?") == true) {
        var data = new FormData();
        //var fileUpload = $("#attachment").get(0);
        //var countFile = $("#attachment")[0].files.length;
        //var files = fileUpload.files;

        var url = "/Config/SpeedOfMachineFollowOptionUpdate";
        //$("#productId").val(0);
        var id = $("#id").val();
        var value = $("#value").val();

        var model = { ID: id, Value: value };
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
