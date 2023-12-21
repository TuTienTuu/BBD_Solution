using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.ConfigFees
{
    public class ConfigFeeUpdateRequest
    {
        public decimal ManagerFee { get; set; }//Phí quản lý, đóng gói, giao hàng 
        public decimal WorkshopRentalFee { get; set; }//Phí thuê xưởng
        public decimal ElectricFee { get; set; }//Tiền điêện chung
        public decimal DepreciationFee { get; set; }//Khấu hao tài sản
        public int NumberOfMachine { get; set; }//Số lượng máy
    }
}
