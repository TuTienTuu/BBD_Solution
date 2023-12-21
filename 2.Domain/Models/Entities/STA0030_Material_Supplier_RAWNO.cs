using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class STA0030_Material_Supplier_RAWNO
    {
        [Required]
        [Key]
        public int ID { get; set; }
        //public string RAWNO { get; set; } //Rowno
        public string RawNo { get; set; } //Rowno
                                          // public string LOTNO { get; set; } //Lotno
        public string LotNo { get; set; } //Lotno
        //public string MATCD { get; set; } //Mã NVL
        public string MatCD { get; set; } //Mã NVL
        public string MaterialCode { get; set; } //Mã quản lý
        public string MaterialName { get; set; } //Tên quản lý
        public string Supplier { get; set; } //Nhà cung cấp
        public string Remark { get; set; }// Ghi chú
        public float QTY { get; set; } //Số lượng mỗi đơn vị
        //public float UNITQTY { get; set; } //Số lượng mỗi đơn vị
        public float UnitQuantity { get; set; } //Số lượng mỗi đơn vị
        public string Unit { get; set; }// Đơn vị tính
        public decimal Price { get; set; } //Giá
        //public DateTime Created { get; set; } //Ngày tạo
        //public DateTime Modified { get; set; } //Ngày chỉnh sửa
        //public bool IsDeleted { get; set; } //Xóa
        //public DateTime Deleted { get; set; } //Ngày xóa
        public string Size { get; set; } //Kích thước
        public string SupLOT { get; set; } //
        //public float InEAQuantity { get; set; } // Số lượng
        public DateTime? ProductDate { get; set; } //Ngày sản xuất
        //public string PROD_DAT { get; set; } //Ngày sản xuất
        public DateTime? ImportDate { get; set; } //Ngày nhập
        //public string IMPORT_DAT { get; set; } //Ngày nhập
        public DateTime? InStockDate { get; set; } //Ngày kiểmr tra
        public DateTime? TestDate { get; set; } //Ngày kiểmr tra
        //public string TEST_DAT { get; set; } //Ngày kiểmr tra
        //public string TEST_RESULT { get; set; } //Kết quả kiểm tra
        public string TestResult { get; set; } //Kết quả kiểm tra
        //public string EXPIRED_DAT { get; set; } //Ngày hết hạn
        public DateTime? ExpiredDate { get; set; } //Ngày hết hạn
        public DateTime? OutStockDate { get; set; }//Tên NVL
        //public string EXPORT_DAT { get; set; }//Tên NVL
        //public string USE_DAT { get; set; } //Giá
        public DateTime? UseDate { get; set; }
        public Single RemainQuantity { get; set; } //Giá

    }
}
