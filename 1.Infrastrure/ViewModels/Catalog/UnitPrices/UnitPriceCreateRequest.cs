using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.UnitPrices
{
    public class UnitPriceCreateRequest
    {
        public int ID { get; set; }

        [Display(Name = "Kích thước ngang")]
        public float Width { get; set; } //Kích thước ngang x
        [Display(Name ="Kích thước cao")]
        public float Height { get; set; }//Kích thước cao x
        [Display(Name ="Số tem ngang")]
        public float NumberStampHorizontal { get; set; }//Tem ngang x
        [Display(Name ="Hàng tem")]

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
        [Display(Name = "Loại bản")]
        public int TypeCopy { get; set; }//Loại bản x
        [Display(Name = "Loại màu")]
        public int ColorType { get; set; }//Loại màu x
        [Display(Name = "Số màu")]
        public int NumberOfColor { get; set; }//Số màu x
        [Display(Name = "Số mã")]
        public int NumberOfCode { get; set; }//Số mã x
        [Display(Name = "Diện tích in")]
        public int AreaPrint { get; set; }//Diện tích in x
        [Display(Name = "Cán màng")]
        public int Lamination { get; set; }//Cán màng x
        [Display(Name = "Lõi")]
        public float Core { get; set; }//Lõi x
        [Display(Name = "Máy theo công đoạn in")]
        public int MachinePrint { get; set; }//Máy theo công đoạn in x chọn
        [Display(Name = "Máy theo công đoạn in-bế")]
        public int MachineDieCutting { get; set; }//Máy theo công đoạn in-bế x chọn
        [Display(Name = "Máy theo công đoạn ép nhũ")]
        public int MachinePressedPowder { get; set; }//Máy theo công đ
        [Display(Name = "Máy theo công đoạn chia")]
        public int MachineDivide { get; set; }//Máy theo công đoạn chia x chọn
        [Display(Name = "Máy theo công đoạn đóng thùng")]
        public int MachinePacking { get; set; }//Máy theo công đoạn đóng thùng x chọn

        [Display(Name = "Bế từ")]
        public float KnifeOtherFee { get; set; }//Bế từ x 
        [Display(Name = "Số lượng dao")]
        public int KnifeNumber { get; set; }//Số lượng dao x 

        [Display(Name = "Chiết khấu sale")]
        public int SaleDiscount { get; set; }//Chiết khấu sale x 

        [Display(Name = "Chiết khấu KH")]
        public float CustomerDiscount { get; set; }//Chiết khấu KH x 

        [Display(Name = "Phần trăm lợi nhuận")]
        public int ProfitPercent { get; set; }//Phần trăm lợi nhuận x 
        [Display(Name = "Dài ")]
        public float Box_width { get; set; }//Dài x 
        [Display(Name = "rộng ")]
        public float Box_long { get; set; }//Rộng x 
        [Display(Name = "Cao")]
        public float Box_height { get; set; }//Cao x 

    }
}
