using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class STA0010_Material_Master
    {
        [Required]
        [Key]
        public int ID { get; set; }
        //public string GlueName { get; set; }
        public string MATCD { get; set; }
        public string MATGROUPCD { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        //public int MaterialID { get; set; }
        public string Note { get; set; }
        public string Unit { get; set; }
        public int UnitQty { get; set; }
        public decimal Price { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Deleted { get; set; }
    }
}
