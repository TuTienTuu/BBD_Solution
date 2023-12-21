using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.STA0020_Material_Supplier_LOTNOs
{
    public class STA0020_Material_Supplier_LOTNOCreateRequest
    {
        //public string LotNo { get; set; } //Lotno x
        public string MatCD { get; set; } //Mã NVL x chọn
        public string Supplier { get; set; } //Nhà cung cấp x
        public string SupLOT { get; set; } // Lot NCC x
        public float Quantity { get; set; } // Số lượng nhập
        public float UnitQuantity { get; set; } //Số lượng mỗi đơn vị x
        public string StandardUnit { get; set; } //Đơn vị chuẩnx
        public DateTime ProductDate { get; set; } //Ngày sản xuất x chọn
        public DateTime ImportDate { get; set; } //Ngày nhập x chọn
        public DateTime TestDate { get; set; } //Ngày kiểm tra x
        public string TestResult { get; set; } //Kết quả kiểm tra x chọn
        public DateTime ExpiredDate { get; set; } //Ngày hết hạn x
        public string MaterialCode { get; set; } //Mã quản lý x chọn
        //public string MaterialName { get; set; }//Tên NVL x chọn
        public string Note { get; set; }// Ghi chú
        public string Unit { get; set; }// Đơn vị tính x
        public decimal Price { get; set; } //Giá x
        public string Size { get; set; } //Kích thước
    }
}
