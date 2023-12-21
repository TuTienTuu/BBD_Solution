function myFunction(e) {
    if (confirm('Lệnh sản xuất sẽ thay đổi, bạn có chắc chắn muốn lưu?')) {
        $(e.element).closest('form').submit();
    }
}
