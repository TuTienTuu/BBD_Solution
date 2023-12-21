using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class STB0010_BARCODE_Printing_Log
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public string LOTNO { get; set; } //Lotno
        public string MATCD { get; set; } //Mã NVL
        public int STA0020_Material_Supplier_LotnoID { get; set; } //ID STA0020
        public string MaterialCode { get; set; } //Mã quản lý
        public string IDEmp { get; set; } //Mã quản lý
        public int STRNO { get; set; }//STT bắt đầu
        public int ENDNO { get; set; }// STT kết thúc
        public DateTime DateCreate { get; set; } //Ngày tạo 
        //public DateTime Modified { get; set; } //Ngày chỉnh sửa
        //public bool IsDeleted { get; set; } //Xóa
        //public DateTime Deleted { get; set; } //Ngày xóa
        //public string Size { get; set; } //Kích thước
    }
}
