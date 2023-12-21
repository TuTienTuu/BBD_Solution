function deleteOperation(id) {

    //confirm("Bạn có chắc chắn muốn xóa?");
    if (confirm("Bạn có chắc chắn muốn xóa?") == true) {
        var url = "/Manager/DeleteOperation/" + id;

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

