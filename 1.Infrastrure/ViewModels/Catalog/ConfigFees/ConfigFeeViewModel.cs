using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.ConfigFees
{
    public class ConfigFeeViewModel
    {
        public int ID { get; set; }
        public decimal ManagerFee { get; set; }//Phí quản lý, đóng gói, giao hàng 
        public decimal WorkshopRentalFee { get; set; }//Phí thuê xưởng
        public decimal ElectricFee { get; set; }//Tiền điêện chung
        public decimal DepreciationFee { get; set; }//Khấu hao tài sản
        public decimal ManagerFeePerMachine { get; set; }//Phí quản lý, đóng gói, giao hàng từng máy
        public decimal WorkshopRentalFeePerMachine { get; set; }//Phí thuê xưởng từng máy
        public decimal ElectricFeePerMachine { get; set; }//Tiền điêện chung từng máy
        public decimal DepreciationFeePerMachineHours { get; set; }//Khấu hao tài sản từng máy theo giờ
        public decimal DepreciationFeePerMachineDay { get; set; }//Khấu hao tài sản từng máy theo ngày
        public decimal MaintainFee { get; set; }//0.5 % phí bảo trì
    }
}
