function myFunction(e) {
    if (confirm('Lệnh sản xuất sẽ thay đổi, bạn có chắc chắn muốn lưu?')) {
        $(e.element).closest('form').submit();
    }
}
           ////var stage = $("#numberOfStage").val();
           //// alert(stage);
           ////if(stage == 1)
           ////{
           ////    document.getElementById("machine_1_confirm").setAttribute('disabled', false);

           ////}else if(stage == 2)
           //{
           //    $('#machine_1_confirm').prop('disabled', false);
           //    $('#machine_2_confirm').prop('disabled', false);

           //}else if(stage == 3)
           //{
           //    $('#machine_1_confirm').prop('disabled', false);
           //    $('#machine_2_confirm').prop('disabled', false);
           //    $('#machine_3_confirm').prop('disabled', false);

           //}else if(stage == 4)
           //{
           //    $('#machine_1_confirm').prop('disabled', false);
           //    $('#machine_2_confirm').prop('disabled', false);
           //    $('#machine_3_confirm').prop('disabled', false);
           //    $('#machine_4_confirm').prop('disabled', false);

           //}else if(stage == 5)
           //{
           //    $('#machine_1_confirm').prop('disabled', false);
           //    $('#machine_2_confirm').prop('disabled', false);
           //    $('#machine_3_confirm').prop('disabled', false);
           //    $('#machine_4_confirm').prop('disabled', false);
           //    $('#machine_5_confirm').prop('disabled', false);

           //}
         //  }

