using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UnitPrice
    {
        [Required]
        [Key]
        //public int ID { get; set; }

        //public float Width { get; set; } //Kích thước ngang x
        //public float Height { get; set; }//Kích thước cao x
        //public float NumberStampHorizontal { get; set; }//Tem ngang x
        //public float NumberRowStamp { get; set; }//Hàng tem x
        //public float Border { get; set; }//Biên x
        //public float Giữa { get; set; }//Giữa x
        //public float Gap { get; set; }//Gap x
        //public float RowStampHaveGap { get; set; }//Hàng tem có gap x
        //public string Characteristic { get; set; }//Đặc tính sản phẩm x

        //public float Point { get; set; }//Point x
        //public float SplitLine { get; set; }//Xẻ line x
        //public float PaperSize { get; set; }//Khổ giấy x
        //public float MetterPerRoll { get; set; }//M/cuộn x
        //public float StampPerRoll { get; set; }//Tem/cuộn x
        //public float Quantity { get; set; }//Số luượng x
        //public string Unit { get; set; }//Đơn vị tính x
        //public string PaperCode { get; set; }//Mã giấy x chọn
        //public string TypeCopy { get; set; }//Mã giấy x
        //public string ColorType { get; set; }//Loại màu x
        //public string NumberOfColor { get; set; }//Số màu x
        //public string NumberOfCode { get; set; }//Số mã x
        //public int AreaPrint { get; set; }//Diện tích in x
        //public string Lamination { get; set; }//Cán màng x
        //public float Core { get; set; }//Lõi x
        //public string MachinePrint { get; set; }//Máy theo công đoạn in x chọn
        //public string MachineDieCutting { get; set; }//Máy theo công đoạn in-bế x chọn
        //public string MachineDivide { get; set; }//Máy theo công đoạn chia x chọn
        //public string MachinePacking { get; set; }//Máy theo công đoạn đóng thùng x chọn
        //public float CartonNumber { get; set; } //Số thùng x

        //#region Tổng quan năng lực và vật tư
        //public float TotalMetter { get; set; } //Tổng m xx
        //public float TotalSquareMetter { get; set; } //Tổng m2 xx
        //public float StampStep { get; set; } //Bước tem xx
        //public float MetterPerOrder { get; set; } //mét/đơn xx
        //public float MetterSquarePerOrder { get; set; } //mét vuông/ đơn xx
        //public float Core_ { get; set; }//Cây lõi xx
        //public float Loss { get; set; }//Hao hụt x
        //public float PrintSquareMetter { get; set; }//m2 in xx
        //public float SFilm { get; set; }//S film (cm2) xx
        //public float PrintHours { get; set; }//Giờ in x
        //public float PressedPowderHours { get; set; }//Giờ ép nhũ x
        //public float DieCuttingHours { get; set; }//Giờ bế x
        //public float DivideHours { get; set; }//Giờ chia x
        //public float NumberRoll { get; set; }//Số cuộn xx

        //#endregion

        //#region In
        //public float Print_ChangeRoll { get; set; }//Thay cuộn 
        //public float Print_Color { get; set; }//Màu
        //public float Print_Compensation { get; set; }//Bù bế
        //public float Print_ChangeCode { get; set; }//Thay mã
        //public float Print_Risk { get; set; }//Rủi ro
        //public float Print_WhiteCarry { get; set; }//Bế trắng
        //public float Print_Targer { get; set; }//Target
        //public float Print_SalaryPerHour { get; set; }//Tiền công/h
        //public float Print_Change { get; set; }//Lên bài
        //public float Print_ElectricFee { get; set; }//Tiền điện
        //public float PrintWorkHours { get; set; }//Số công
        //#endregion
        //#region Ép nhũ
        //public float PressedPowder_ChangeRoll { get; set; }//Thay cuộn 
        //public float PressedPowder_Color { get; set; }//Màu
        //public float PressedPowder_Compensation { get; set; }//Bù bế
        ////public int PressedPowder_ChangeCode { get; set; }//Thay mã
        //public float PressedPowder_Risk { get; set; }//Rủi ro
        ////public int PressedPowder_WhiteCarry { get; set; }//Bế trắng
        //public float PressedPowder_Targer { get; set; }//Target
        //public float PressedPowder_SalaryPerHour { get; set; }//Tiền công/h
        //public float PressedPowder_Change { get; set; }//Lên bài
        //public float PressedPowder_ElectricFee { get; set; }//Tiền điện
        //public float PressedPowderWorkHours { get; set; }//Số công
        //#endregion

        //#region In-Bế
        //public float DieCutting_ChangeRoll { get; set; }//Thay cuộn 
        //public float DieCutting_Color { get; set; }//Màu
        //public float DieCutting_Compensation { get; set; }//Bù bế
        ////public int DieCutting_ChangeCode { get; set; }//Thay mã
        //public float DieCutting_Risk { get; set; }//Rủi ro
        //public float DieCutting_WhiteCarry { get; set; }//Bế trắng
        //public float DieCutting_Targer { get; set; }//Target x
        //public float DieCutting_SalaryPerHour { get; set; }//Tiền công/h
        //public float DieCutting_Change { get; set; }//Lên bài
        //public float DieCutting_ElectricFee { get; set; }//Tiền điện
        //public float DieCuttingWorkHours { get; set; }//Số công
        //#endregion

        //#region Chia
        //public float Divide_ChangeRoll { get; set; }//Thay cuộn 
        //public float Divide_Color { get; set; }//Màu
        //public float Divide_Compensation { get; set; }//Bù bế
        ////public int Divide_ChangeCode { get; set; }//Thay mã
        //public float Divide_Risk { get; set; }//Rủi ro
        //public float Divide_WhiteCarry { get; set; }//Bế trắng
        //public float Divide_Targer { get; set; }//Target
        //public float Divide_SalaryPerHour { get; set; }//Tiền công/h
        //public float Divide_Change { get; set; }//Lên bài
        //public float Divide_ElectricFee { get; set; }//Tiền điện
        //public float DivideWorkHours { get; set; }//Số công
        //#endregion

        //#region Màng
        //public float LaminationFilm { get; set; } //S cán màng
        //public float ShrinkFilm { get; set; } //Màn co
        //#endregion

        //#region Quản lý đơn hàng
        //public float ManagerFeeStage1 { get; set; }//QLĐH 1
        //public float ManagerFeeStage2 { get; set; }//QLĐH 2
        //public float ManagerFeeStage3 { get; set; }//QLĐH 3
        //public float ManagerFeeTotal { get; set; }//Tiền
        //#endregion
        //public float RentalWorkshopFee { get; set; }//Chi phí mặt bằng

        //#region Khấu hao+ phí hao mòn
        //public float DepreciationStage1 { get; set; }//Khấu hao + phí hao mòn cđ 1
        //public float DepreciationStage2 { get; set; }//Khấu hao + phí hao mòn cđ 2
        //public float DepreciationStage3 { get; set; }//Khấu hao + phí hao mòn cđ 3
        //public float DepreciationFeeTotal { get; set; }//Tiền
        //#endregion

        //#region Dao bế
        //public float KnifeFee { get; set; }//Đơn giá  
        //public float KnifeNumber { get; set; }//Số lượng dao
        //public float KnifeCarryFee { get; set; }//Bế từ
        //#endregion

        //public float TotalWorkHours { get; set; }//Tổng số công
        //public float OperatorSalary { get; set; }//Tiền công vận hành máy
        //public float MachineElectric { get; set; }//Tiền công vận hành máy

        //#region Định mức NVL
        //public float DecalFee { get; set; }//Tiền Decal
        //public float LaminationFee { get; set; }//Tiền cán màng/Phủ UV
        //public float CoreFee { get; set; }//Tiền lõi
        //public float ColorKg { get; set; }//Số kí
        //public float ColorFee { get; set; }//Tiền màu in
        //public float UnitFilmFee { get; set; }//Đơn giá Film
        //public float FilmFee { get; set; }//Tiền Film
        //public float PrintTemplateFee { get; set; }//Tiền bản in
        //#endregion

        //public float TotalCost { get; set; }//Tổng chi phí
        //public int DiscountSale { get; set; }//Chiết khấu sale x
        //public int DiscountCustomer { get; set; }//Chiết khấu khách hàng x
        //public int ProfitPercent { get; set; }//Chiết khấu khách hàng x
        //public float GrandTotal { get; set; }//Grand total
        //public float UnitPriceOfProduct { get; set; }//Đơn giá
        //public float UnitPriceOneOfProduct { get; set; }//Đơn giá 1 đv

        public int ID { get; set; }
        [Display(Name = "Phí quản lý tổng cộng **")]
        public float ManagermentFeeTotal { get; set; }//Phí quản lý tổng cộng x
        [Display(Name = "Số lượng")]
        public float Quantity { get; set; }//Số luượng x
        [Display(Name = "Đơn vị tính")]
        public string Unit { get; set; }//Đơn vị tính x
        [Display(Name = "Đặc tính sản phẩm")]
        public string Characteristic { get; set; }//Đặc tính sản phẩm x

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
        public float TotalSalary { get; set; }//Tiền công chia x
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

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Deleted { get; set; }
        public string Note { get; set; }

    }
}
