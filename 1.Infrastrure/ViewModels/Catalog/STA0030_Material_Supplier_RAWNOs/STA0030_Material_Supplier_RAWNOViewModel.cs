using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.STA0030_Material_Supplier_RAWNOs
{
    public class STA0030_Material_Supplier_RAWNOViewModel
    {
        public int ID { get; set; }
        public string RAWNO { get; set; } //Rowno
        public string LOTNO { get; set; } //Lotno
        public string MATCD { get; set; } //Mã NVL
        public string MaterialCode { get; set; } //Mã quản lý
        public string MaterialName { get; set; } //Tên quản lý
        public string Supplier { get; set; } //Nhà cung cấp
        public string Remark { get; set; }// Ghi chú
        public float UNITQTY { get; set; } //Số lượng mỗi đơn vị
        public string Unit { get; set; }// Đơn vị tính
        public string StandardUnit { get; set; }// Đơn vị tính
        public decimal Price { get; set; } //Giá
        public DateTime Created { get; set; } //Ngày tạo
        public DateTime Modified { get; set; } //Ngày chỉnh sửa
        public bool IsDeleted { get; set; } //Xóa
        public DateTime Deleted { get; set; } //Ngày xóa
        public string Size { get; set; } //Kích thước
        public string Sup_LOT { get; set; } //
        //public float InEAQuantity { get; set; } // Số lượng
        public string ProductDate { get; set; } //Ngày sản xuất
        public string ImportDate { get; set; } //Ngày nhập
        public string TestDate { get; set; } //Ngày kiểmr tra
        public string TestReult { get; set; } //Kết quả kiểm tra
        public string ExpiredDate { get; set; } //Ngày hết hạn
        public string ExportDate { get; set; }//Tên NVL
        public string UseDate { get; set; } //Ngày sử dụng
    }
}
