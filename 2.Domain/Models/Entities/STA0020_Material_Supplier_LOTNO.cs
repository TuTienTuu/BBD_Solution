using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class STA0020_Material_Supplier_LOTNO
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public string LotNo { get; set; } //Lotno
        public string MatCD { get; set; } //Mã NVL
        public string Supplier { get; set; } //Nhà cung cấp
        public string SupLOT { get; set; } //
        public float Quantity { get; set; } // Số lượng
        public float UnitQuantity { get; set; } //Số lượng mỗi đơn vị
        public string StandardUnit { get; set; } //Đơn vị chuẩn x
        public DateTime ProductDate { get; set; } //Ngày sản xuất
        public DateTime ImportDate { get; set; } //Ngày nhập
        public DateTime TestDate { get; set; } //Ngày kiểmr tra
        public string TestResult { get; set; } //Kết quả kiểm tra
        public DateTime ExpiredDate { get; set; } //Ngày hết hạn
        public string MaterialCode { get; set; } //Mã quản lý
        public string MaterialName { get; set; }//Tên NVL
        public string Note { get; set; }// Ghi chú
        public string Unit { get; set; }// Đơn vị tính
        public decimal Price { get; set; } //Giá
        public DateTime Created { get; set; } //Ngày tạo
        public DateTime Modified { get; set; } //Ngày chỉnh sửa
        public bool IsDeleted { get; set; } //Xóa
        public DateTime Deleted { get; set; } //Ngày xóa
        public string Size { get; set; } //Kích thước
    }
}
