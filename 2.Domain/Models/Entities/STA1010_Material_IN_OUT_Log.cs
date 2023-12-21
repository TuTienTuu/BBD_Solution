using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class STA1010_Material_IN_OUT_Log
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public string StockCD { get; set; } //Lotno
        public string Action { get; set; } //Mã NVL
        //public int STA0020_Material_Supplier_LotnoID { get; set; } //ID STA0020
        public string StatusCheck { get; set; } //Mã quản lý
        public string RawNo { get; set; } //Mã quản lý
        public float Quantity { get; set; }//STT bắt đầu
        public string FIFOYN { get; set; }// STT kết thúc
        public string EmployeeID { get; set; }// STT kết thúc
        public DateTime WorkDateTime { get; set; }// STT kết thúc
        public string Remark { get; set; }// STT kết thúc
        //public DateTime DateCreate { get; set; } //Ngày tạo 
    }
}
