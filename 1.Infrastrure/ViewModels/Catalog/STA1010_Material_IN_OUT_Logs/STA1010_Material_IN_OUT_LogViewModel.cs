using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.STA1010_Material_IN_OUT_Logs
{
    public class STA1010_Material_IN_OUT_LogViewModel
    {
        public int ID { get; set; }
        public string StockCode { get; set; } //Lotno
        public string Action { get; set; } //Mã NVL
        public string StatusCheck { get; set; } //Mã quản lý
        public string RawNo { get; set; } //Mã quản lý
        public float Quantity { get; set; }//STT bắt đầu
        public string FifoYN { get; set; }// STT kết thúc
        public string IDEmployee { get; set; }// STT kết thúc
        public DateTime WorkDateTime { get; set; }// STT kết thúc
        public string Remark { get; set; }// STT kết thúc
        public string RawLot { get; set; }// STT kết thúc
        public string LotNo { get; set; }// STT kết thúc
        public string MatCD { get; set; }// STT kết thúc
        public string MaterialName { get; set; }// STT kết thúc
        public string Unit { get; set; }// STT kết thúc
        public DateTime ImportDate { get; set; }// STT kết thúc
        public string SupplierLot { get; set; }// STT kết thúc
        public string Supplier { get; set; }// STT kết thúc

    }
}
