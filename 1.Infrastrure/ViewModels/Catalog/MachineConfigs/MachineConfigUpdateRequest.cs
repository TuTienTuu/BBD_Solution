using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.MachineConfigs
{
    public class MachineConfigUpdateRequest
    {
        public int ID { get; set; }
        public string MachineName { get; set; }

        #region M hao hụt
        public int ChangeRoll { get; set; }//Thay mã ----M hao hụt
        public int Color { get; set; } //Màu
        public int Compensation { get; set; }//Bù bế
        public int Risk { get; set; } //Rủi ro
        public int ChangeSpec { get; set; } //Thay mã
        public int WhiteCarry { get; set; } //Bế trắng 
        #endregion

        public int Target { get; set; } //Target ----Capa
        public int NumberStageMachine { get; set; } //Số lượng máy cùng loại

        #region Giá điện
        public decimal Power { get; set; } //Công suất
        //public decimal KWPerHour { get; set; } //KW/H
        //public decimal ElectricPrice { get; set; } //Gía điện 
        #endregion

        #region Lost time
        public decimal Change { get; set; } //Lên bài
        public decimal ChangeSpec_H { get; set; } //Thay mã
        public decimal ChangeRoll_H { get; set; } //Thay roll
        #endregion

        #region Tiền lương
        public int OperatorNumber { get; set; }//Số vận hành
        public decimal OperatorSalary_1 { get; set; }//Lương vận hành
        public decimal OperatorSalary_2 { get; set; }//Lương vận hành
        public decimal HourlySalary { get; set; }//Lương theo giờ
        #endregion

        public int CostAllocationPercent { get; set; }//% phân bổ chỉ phí
    }
}
