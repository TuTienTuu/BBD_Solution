using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Material
    {
        [Required]
        [Key]
        public int ID { get; set; }
        public int MaterialTypeID { get; set; }
        public string MaterialTypeName { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string Supplier { get; set; }
        public string Note { get; set; }
        public string Size { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Deleted { get; set; }
    }
}
