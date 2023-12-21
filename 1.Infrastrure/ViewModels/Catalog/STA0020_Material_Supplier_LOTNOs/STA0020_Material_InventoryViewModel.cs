using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.STA0020_Material_Supplier_LOTNOs
{
    public class STA0020_Material_InventoryViewModel
    {
        public int ID { get; set; }
        public string LotNo { get; set; } //Lotno x
        public string MatCD { get; set; } //Mã NVL x chọn
        public string Supplier { get; set; } //Nhà cung cấp x
        public string SupLOT { get; set; } // Lot NCC x
        public float Quantity { get; set; } // Số lượng x
        public float UnitQuantity { get; set; } //Số lượng mỗi đơn vị x
        public DateTime ProductDate { get; set; } //Ngày sản xuất x chọn
        public DateTime ImportDate { get; set; } //Ngày nhập x chọn
        public DateTime TestDate { get; set; } //Ngày kiểm tra x
        //public DateTime? OutStockDate { get; set; } //Ngày kiểm tra x
        public string OutStockDate { get; set; } //Ngày kiểm tra x
        public float RemainQuantity { get; set; } //Ngày kiểm tra x
        public float RemainStandardQuantity { get; set; } //Ngày kiểm tra x
        public string TestResult { get; set; } //Kết quả kiểm tra x chọn
        public DateTime ExpiredDate { get; set; } //Ngày hết hạn x
        public string MaterialCode { get; set; } //Mã quản lý x chọn
        public string MaterialName { get; set; }//Tên NVL x chọn
        public string Note { get; set; }// Ghi chú
        public string Unit { get; set; }// Đơn vị tính x
        public decimal Price { get; set; } //Giá x
        public int InventoryQuantity { get; set; } //Giá x
        //public DateTime Created { get; set; } //Ngày tạo
        //public DateTime Modified { get; set; } //Ngày chỉnh sửa
        //public bool IsDeleted { get; set; } //Xóa
        //public DateTime Deleted { get; set; } //Ngày xóa
        public string Size { get; set; } //Kích thước
    }
}
