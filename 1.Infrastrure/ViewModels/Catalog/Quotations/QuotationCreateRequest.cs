using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.Quotations
{
    public class QuotationCreateRequest
    {
        public int ID { get; set; }

        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; } //Tên khách hàng
        [Display(Name = "Tên công ty")]
        public string CompanyName { get; set; }//Kích thước cao x
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }//Địa chỉ x
        [Display(Name = "Số điện thoại")]
        public string TelephoneNumber { get; set; }//Số điện thoại
        [Display(Name = "Email")]
        public string? Email { get; set; }//Email x
        [Display(Name = "Website")]
        public string? Website { get; set; }//Website x 

        [Display(Name = "Nguời tạo")]
        public string CreatedBy { get; set; }//Website x 
        public int UnitPrice { get; set; }//Website x 
        public List<UnitPrice>? UnitPrices { get; set; }
    }

    public class UnitPrice
    {
        public int UnitPriceID { get; set; }
        public string Spec { get; set; }
        public int Quantity { get; set; }
        //public int SubTotal { get; set; }
        public int Ordinal { get; set; }
    }

}
