using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.UnitPrices
{
    public class UnitPriceViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Phí quản lý tổng cộng **")]
        public float ManagermentFeeTotal { get; set; }//Phí quản lý tổng cộng x
        [Display(Name = "Số lượng")]
        public float Quantity { get; set; }//Số luượng x
        [Display(Name = "Đơn vị tính")]
        public string Unit { get; set; }//Đơn vị tính x
        [Display(Name = "Quy cách")]
        public string Spec { get; set; }//Quy cách x 

        [Display(Name = "Phí mặt bằng **")]
        public float WorkshopRentalFee { get; set; }//Phí mặt bằng x
        [Display(Name = "Phí hao mòn tổng cộng **")]
        public float DepriciationTotalFee { get; set; }//Phí hao mòn tổng cộng x

        [Display(Name = "Tiền điện **")]
        public float ElectricFee { get; set; }//Tiền điện x

        [Display(Name = "Đơn giá dao **")]
        public float KnifeUnitFee { get; set; }//Đơn giá dao x

        [Display(Name = "Tiền công **")]
        public float CD_TotalSalary { get; set; }//Tiền công chia x
        [Display(Name = "Tiền giấy **")]
        public float DecalTotalPrice { get; set; }//Tiền decal x
        [Display(Name = "Thành tiền cán màng **")]
        public float LaminationTotalPrice { get; set; }//Thành tiền cán màng x
        [Display(Name = "Thành tiền lõi **")]
        public float CorePrice { get; set; }//Thành tiền lõi x
        [Display(Name = "Thành tiền màu in **")]
        public float ColorPrice { get; set; }//Thành tiền màu in x
        [Display(Name = "Thành tiền film **")]
        public float FilmPrice { get; set; }//Thành tiền film x
        [Display(Name = "Thành tiền bản in **")]
        public float Print_Price { get; set; }//Thành tiền bản in x
        [Display(Name = "Thành tiền thùng **")]
        public float BoxPrice { get; set; }//Thành tiền thùng x
        [Display(Name = "Thành tiền màng co **")]
        public float SrinkFilmPrice { get; set; }//Thành tiền màng co x
        [Display(Name = "Tổng chi phí ")]
        public double Total { get; set; }//Tổng chi phí  x

        [Display(Name = "Tổng chi phí cuối cùng")]
        public double FinalyTotal { get; set; }//Tổng chi phí cuối cùng x

        [Display(Name = "Chiết khấu sale")]
        public int SaleDiscount { get; set; }//Chiết khấu sale x 

        [Display(Name = "Chiết khấu KH")]
        public float CustomerDiscount { get; set; }//Chiết khấu KH x 

        [Display(Name = "Phần trăm lợi nhuận")]
        public int ProfitPercent { get; set; }//Phần trăm lợi nhuận x
        [Display(Name = "Đặc tính")]
        public string Characteristic { get; set; }
    }
}
