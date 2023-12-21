using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.UnitPrices
{
    public class UnitPriceExecutingRequest
    {

        public int ID { get; set; }

        [Display(Name = "Kích thước ngang")]
        public float Width { get; set; } //Kích thước ngang x
        [Display(Name = "Kích thước cao")]
        public float Height { get; set; }//Kích thước cao x
        [Display(Name = "Số tem ngang")]
        public float NumberStampHorizontal { get; set; }//Tem ngang x
        [Display(Name = "Hàng tem")]

        public float NumberRowStamp { get; set; }//Hàng tem x
        [Display(Name = "Biên")]

        public float Border { get; set; }//Biên x
        [Display(Name = "Giữa")]

        public float Midle { get; set; }//Giữa x
        [Display(Name = "Gap")]

        public float Gap { get; set; }//Gap x
        [Display(Name = "Hàng tem có gap")]
        public float RowStampHaveGap { get; set; }//Hàng tem có gap x
        [Display(Name = "Đặc tính sản phẩm")]
        public string Characteristic { get; set; }//Đặc tính sản phẩm x

        [Display(Name = "Tiêu điểm")]
        public float Point { get; set; }//Point x
        [Display(Name = "Xẻ line")]
        public float SplitLine { get; set; }//Xẻ line x
        [Display(Name = "Khổ giấy *")]
        public float PaperSize { get; set; }//Khổ giấy x
        [Display(Name = "M/Cuộn")]
        public float MetterPerRoll { get; set; }//M/cuộn x
        [Display(Name = "Tem/cuộn")]
        public float StampPerRoll { get; set; }//Tem/cuộn x
        [Display(Name = "Số lượng")]
        public float Quantity { get; set; }//Số luượng x
        [Display(Name = "Đơn vị tính")]

        public string Unit { get; set; }//Đơn vị tính x
        [Display(Name = "Mã giấy")]
        public int PaperCode { get; set; }//Mã giấy x chọn
        [Display(Name = "Mã giấy *")]
        public string PaperCode_ { get; set; }//Mã giấy x chọn
        [Display(Name = "Bản")]
        public int TypeCopy { get; set; }//Bản x
        [Display(Name = "Bản *")]
        public string TypeCopyCode { get; set; }//Bản x
        [Display(Name = "Loại màu")]
        public int ColorType { get; set; }//Loại màu x
        [Display(Name = "Loại màu")]
        public string ColorTypeCode { get; set; }//Loại màu x
        [Display(Name = "Số màu")]
        public int NumberOfColor { get; set; }//Số màu x
        [Display(Name = "Số mã")]
        public int NumberOfCode { get; set; }//Số mã x
        [Display(Name = "Diện tích in")]
        public int AreaPrint { get; set; }//Diện tích in x
        [Display(Name = "Cán màng")]
        public int Lamination { get; set; }//Cán màng x
                                              [Display(Name = "Cán màng *")]
        public string LaminationCode { get; set; }//Cán màng x
        [Display(Name = "Lõi")]
        public float Core { get; set; }//Lõi x
        [Display(Name = "Máy theo công đoạn in")]
        public int MachinePrint { get; set; }//Máy theo công đoạn in x chọn
        [Display(Name = "Máy theo công đoạn in-bế")]
        public int MachineDieCutting { get; set; }//Máy theo công đoạn in-bế x chọn
        [Display(Name = "Máy theo công đoạn ép nhũ")]
        public int MachinePressedPowder { get; set; }//Máy theo công đoạn ép nhũ x chọn
        [Display(Name = "Máy theo công đoạn chia")]
        public int MachineDivide { get; set; }//Máy theo công đoạn chia x chọn
        [Display(Name = "Máy theo công đoạn đóng thùng")]
        public int MachinePacking { get; set; }//Máy theo công đoạn đóng thùng x chọn
        [Display(Name = "Máy theo công đoạn in *")]
        public string MachinePrintCode { get; set; }//Máy theo công đoạn in x chọn
        [Display(Name = "Máy theo công đoạn in-bế *")]
        public string MachineDieCuttingCode { get; set; }//Máy theo công đoạn in-bế x chọn
        [Display(Name = "Máy theo công đoạn ép nhũ *")]
        public string MachinePressedPowderCode { get; set; }//Máy theo công đoạn ép nhũ x chọn
        [Display(Name = "Máy theo công đoạn chia *")]
        public string MachineDivideCode { get; set; }//Máy theo công đoạn chia x chọn
        [Display(Name = "Máy theo công đoạn đóng thùng *")]
        public string MachinePackingCode { get; set; }//Máy theo công đoạn đóng thùng x chọn
        [Display(Name = "Số thùng")]
        public float CartonPerOrder { get; set; } //Số thùng x

        #region Tổng quan năng lực và vật tư
        [Display(Name = "Tổng m *")]
        public float TotalMetter { get; set; } //Tổng m x
        [Display(Name = "Tổng m2 *")]
        public float TotalSquareMetter { get; set; } //Tổng m2 x
        [Display(Name = "Tem/bước")]
        public float StampPerStep { get; set; }//Tem/cuộn x
        [Display(Name = "Bước tem *")]
        public float StampStep { get; set; } //Bước tem x
        [Display(Name = "Mét/đơn *")]
        public float MetterPerOrder { get; set; } //mét/đơn x
        [Display(Name = "Mét vuông/đơn *")]
        public float MetterSquarePerOrder { get; set; } //mét vuông/ đơn x
        [Display(Name = "Cây lõi *")]
        public float Core_ { get; set; }//Cây lõi x
        [Display(Name = "Hao hụt *")]
        public float Loss { get; set; }//Hao hụt x
        [Display(Name = "M2 in *")]
        public float PrintSquareMetter { get; set; }//m2 in x
        [Display(Name = "S film *")]
        public float SFilm { get; set; }//S film (cm2) x
        [Display(Name = "Giờ in *")]
        public float PrintHours { get; set; }//Giờ in x
        [Display(Name = "Giờ ép nhũ *")]
        public float PressedPowderHours { get; set; }//Giờ ép nhũ x
        [Display(Name = "Giờ bế *")]
        public float DieCuttingHours { get; set; }//Giờ bế x
        [Display(Name = "Giờ chia *")]
        public float DivideHours { get; set; }//Giờ chia x
        [Display(Name = "Số cuộn *")]
        public float NumberRoll { get; set; }//Số cuộn x

        #endregion
        #region Màng
        [Display(Name = "S màng cán *")]
        public float SLamination { get; set; }//S màng cán x

        [Display(Name = "Màng co *")]
        public float SrinkFilm { get; set; }//Màng co x
        #endregion

        #region Phí quản lý theo công đoạn
        [Display(Name = "Phí quản lý CĐ in *")]
        public float ManagermentFeePrint { get; set; }//Phí quản lý CĐ in x
        [Display(Name = "Phí quản lý CĐ bế *")]
        public float ManagermentFeeCarry { get; set; }//Phí quản lý CĐ bế x
        [Display(Name = "Phí quản lý CĐ chia *")]
        public float ManagermentFeeDivide { get; set; }//Phí quản lý CĐ chia x
        [Display(Name = "Phí quản lý tổng cộng **")]
        public float ManagermentFeeTotal { get; set; }//Phí quản lý tổng cộng x
        #endregion

        [Display(Name = "Phí mặt bằng **")]
        public float WorkshopRentalFee { get; set; }//Phí mặt bằng x

        #region Khấu hao + phí hao mòn
        [Display(Name = "Phí hao mòn in *")]
        public float DepriciationPrintFee { get; set; }//Phí hao mòn in x
        [Display(Name = "Phí hao mòn bế *")]
        public float DepriciationCarryFee { get; set; }//Phí hao mòn bế x
        [Display(Name = "Phí hao mòn chia *")]
        public float DepriciationDivideFee { get; set; }//Phí hao mòn chia x

        [Display(Name = "Phí hao mòn tổng cộng **")]
        public float DepriciationTotalFee { get; set; }//Phí hao mòn tổng cộng x
        #endregion

        [Display(Name = "Tiền điện **")]
        public float ElectricFee { get; set; }//Tiền điện x

        #region Dao bế
        [Display(Name = "Đơn giá dao **")]
        public float KnifeUnitFee { get; set; }//Đơn giá dao x

        [Display(Name = "Bế từ")]
        public float KnifeOtherFee { get; set; }//Bế từ x 

        [Display(Name = "Số lượng dao")]
        public int KnifeNumber { get; set; }//Số lượng dao x 
        #endregion

        #region In
        [Display(Name = "Thay cuộn")]
        public float PrintChangeRoll { get; set; }//Thay cuộn x 

        [Display(Name = "Màu")]
        public int PrintColor { get; set; }// Màux 

        [Display(Name = "Bù bế")]
        public float PrintCarryCompensation { get; set; }//Bù bế x 

        [Display(Name = "Thay mã")]
        public float PrintChangeCode { get; set; }//Thay mã x 
        [Display(Name = "Rủi ro")]
        public float PrintRisk { get; set; }//Rủi ro x 
        [Display(Name = "Bế trắng")]
        public float PrintWhiteCarry { get; set; }// x bế trắng
        [Display(Name = "Target")]
        public float PrintTarget { get; set; }//Taget x 
        [Display(Name = "Tiền công/h")]
        public float PrintHourSalary { get; set; }//Tiền công/h x 
        [Display(Name = "Lên bài")]
        public float PrintChange { get; set; }//Lên bài x 
        [Display(Name = "Điện")]
        public float PrintElectric { get; set; }//Điện x 
        #endregion

        #region Ép nhũ
        [Display(Name = "Thay cuộn")]
        public float PressedPowderChangeRoll { get; set; }//Thay cuộn x 

        [Display(Name = "Màu")]
        public int PressedPowderColor { get; set; }// Màux 

        [Display(Name = "Bù bế")]
        public float PressedPowderCarryCompensation { get; set; }//Bù bế x 

        [Display(Name = "Rủi ro")]
        public float PressedPowderRisk { get; set; }//Rủi ro x 

        [Display(Name = "Target")]
        public float PressedPowderTarget { get; set; }//Taget x 
        [Display(Name = "Tiền công/h")]
        public float PressedPowderHourSalary { get; set; }//Tiền công/h x 
        [Display(Name = "Lên bài")]
        public float PressedPowderChange { get; set; }//Lên bài x 
        [Display(Name = "Điện")]
        public float PressedPowderElectric { get; set; }//Điện x 
        #endregion

        #region Bế
        [Display(Name = "Thay cuộn")]
        public float CarryChangeRoll { get; set; }//Thay cuộn x 

        [Display(Name = "Màu")]
        public int CarryColor { get; set; }// Màux 

        [Display(Name = "Bù bế")]
        public float CarryCompensation { get; set; }//Bù bế x 
        [Display(Name = "Rủi ro")]
        public float CarryRisk { get; set; }//Rủi ro x 
        [Display(Name = "Bế trắng")]
        public float CarryWhiteCarry { get; set; }// x bế trắng
        [Display(Name = "Target")]
        public float CarryTarget { get; set; }//Taget x 
        [Display(Name = "Tiền công/h")]
        public float CarryHourSalary { get; set; }//Tiền công/h x 
        [Display(Name = "Lên bài")]
        public float CarryChange { get; set; }//Lên bài x 
        [Display(Name = "Điện")]
        public float CarryElectric { get; set; }//Điện x 
        #endregion

        #region Chia
        [Display(Name = "Thay cuộn")]
        public float DivideChangeRoll { get; set; }//Thay cuộn x 

        [Display(Name = "Màu")]
        public int DivideColor { get; set; }// Màux 

        [Display(Name = "Bù bế")]
        public float DivideCarryCompensation { get; set; }//Bù bế x 
        [Display(Name = "Rủi ro")]
        public float DivideRisk { get; set; }//Rủi ro x 
        [Display(Name = "Bế trắng")]
        public float DivideWhiteCarry { get; set; }// x bế trắng
        [Display(Name = "Target")]
        public float DivideTarget { get; set; }//Taget x 
        [Display(Name = "Tiền công/h")]
        public float DivideHourSalary { get; set; }//Tiền công/h x 
        [Display(Name = "Lên bài")]
        public float DivideChange { get; set; }//Lên bài x 
        [Display(Name = "Điện")]
        public float DivideElectric { get; set; }//Điện x 
        #endregion

        #region Công + điện
        [Display(Name = "Quy cách")]
        public string Spec { get; set; }//Quy cách x 
        [Display(Name = "Công in")]
        public float CD_PrintHour { get; set; }//Công in x
        [Display(Name = "Tiền công in")]
        public float CD_PrintSalary { get; set; }//Tiền công in x
        [Display(Name = "Tiền điện in")]
        public float CD_PrintElectric { get; set; }//Tiền điện in x
        

        [Display(Name = "Công ép nhũ")]
        public float CD_PressedPowderHour { get; set; }//Công ép nhũ x
        [Display(Name = "Tiền công ép nhũ")]
        public float CD_PressedPowderSalary { get; set; }//Tiền công ép nhũ x
        [Display(Name = "Tiền điện ép nhũ")]
        public float CD_PressedPowderElectric { get; set; }//Tiền điện ép nhũ x

        [Display(Name = "Công bế")]
        public float CD_CarryHour { get; set; }//Công bế x
        [Display(Name = "Tiền công bế")]
        public float CD_CarrySalary { get; set; }//Tiền công bế x
        [Display(Name = "Tiền điện bế")]
        public float CD_CarryElectric { get; set; }//Tiền điện bế x

        [Display(Name = "Công chia")]
        public float CD_DivideHour { get; set; }//Công chia x
        [Display(Name = "Tiền công chia")]
        public float CD_DivideSalary { get; set; }//Tiền công chia x
        [Display(Name = "Tiền điện chia")]
        public float CD_DivideElectric { get; set; }//Tiền điện chia x

        [Display(Name = "Tổng công")]
        public float CD_TotalHour { get; set; }//Tổng công x
        [Display(Name = "Tiền công **")]
        public float CD_TotalSalary { get; set; }//Tiền công chia x
        [Display(Name = "Tổng tiền điện")]
        public float CD_TotalElectric { get; set; }//Tổng tiền điện x

        #endregion

        [Display(Name = "Giá giấy")]
        public float DecalPrice { get; set; }//Giá decal x

        [Display(Name = "Tiền giấy **")]
        public float DecalTotalPrice { get; set; }//Tiền decal x

        [Display(Name = "M2 cán màng")]
        public float MetterSquareLamination { get; set; }//M2 cán màng x
        [Display(Name = "Đơn giá cán màng")]
        public float LaminationUnitPrice { get; set; }//đơn giá cán màng x
        [Display(Name = "Thành tiền cán màng **")]
        public float LaminationTotalPrice { get; set; }//Thành tiền cán màng x

        [Display(Name = "Đơn giá lõi")]
        public float CoreUnitPrice { get; set; }//Đơn giá lõi x
        [Display(Name = "Thành tiền lõi **")]
        public float CorePrice { get; set; }//Thành tiền lõi x

        [Display(Name = "Số ký màu in")]
        public float ColorPrintKG { get; set; }//Số ký màu in x
        [Display(Name = "Đơn giá màu in")]
        public float ColorUnitPrice { get; set; }//Đơn giá màu in x
        [Display(Name = "Thành tiền màu in **")]
        public float ColorPrice { get; set; }//Thành tiền màu in x

        [Display(Name = "Đơn giá Film")]
        public float FilmUnitPrice { get; set; }//Đơn giá film x
        [Display(Name = "Thành tiền film **")]
        public float FilmPrice { get; set; }//Thành tiền film x

        [Display(Name = "Đơn giá bản in")]
        public float Print_UnitPrice { get; set; }//Đơn giá bản in x
        [Display(Name = "Thành tiền bản in **")]
        public float Print_Price { get; set; }//Thành tiền bản in x
        [Display(Name = "S bản in")]
        public float Print_SFilm { get; set; }//S bản in x

        [Display(Name = "Đơn giá thùng")]
        public float BoxUnitPrice { get; set; }//Đơn giá thùng x
        [Display(Name = "Thành tiền thùng **")]
        public float BoxPrice { get; set; }//Thành tiền thùng x

        [Display(Name = "Đơn giá màng co")]
        public float SrinkFilmUnitPrice { get; set; }//Đơn giá màng co x
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
        #region Tính m >> D

        [Display(Name = "D")]
        public float Box_D { get; set; }//D x  

        [Display(Name = "D2")]
        public float Box_DD { get; set; }//D2 x  
        [Display(Name = "d")]
        public float Box_d { get; set; }//d x  
        [Display(Name = "t")]
        public float Box_t { get; set; }//t x 
        [Display(Name = "L")]
        public float Box_L { get; set; }//L x 
        [Display(Name = "Dài = rộng")]
        public float Roll_width { get; set; }//Dài = rộng x 
        [Display(Name = "Cao")]
        public float Roll_height { get; set; }//Cao x 
        [Display(Name = "Dài ")]
        public float Box_width { get; set; }//Dài x 
        [Display(Name = "rộng ")]
        public float Box_long { get; set; }//Rộng x 
        [Display(Name = "Cao")]
        public float Box_height { get; set; }//Cao x 
        [Display(Name = "Dài 1")]
        public float Long_1 { get; set; }//Dài 1 x 
        [Display(Name = "Rộng 1")]
        public float Width_1 { get; set; }//Rộng 1 x 
        [Display(Name = "Cao 1")]
        public float Height_1 { get; set; }//Cao 1 x 
        [Display(Name = "Cuộn/thùng")]
        public float RollPerBox { get; set; }//Cuộn/thùng x 
        #endregion
    }

}
