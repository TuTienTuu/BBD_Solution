using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Sole
    {
        [Required]
        [Key]
        public int ID { get; set; }
        //public string GlueName { get; set; }
        public string SoleCode { get; set; }
        public string SoleInfomation { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Deleted { get; set; }
    }
}
