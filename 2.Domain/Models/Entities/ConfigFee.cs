using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ConfigFee
    {
        [Required]
        [Key]
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

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Deleted { get; set; }
        public string Note { get; set; }
    }
}
