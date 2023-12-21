using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.STB0010_BARCODE_Printing_Logs
{
    public class STB0010_BARCODE_Printing_LogCreateRequest
    {
        public string LotNo { get; set; } //Lotno
        public string MatCD { get; set; } //Mã NVL
        public int STA0020_Material_Supplier_LotnoID { get; set; } //ID STA0020
        public string MaterialCode { get; set; } //Mã quản lý
        public int ExportQuantityStart { get; set; }//STT bắt đầu
        public int ExportQuantityEnd { get; set; }// STT kết thúc
        public string EmployeeID { get; set; } //MSNV
    }
}
