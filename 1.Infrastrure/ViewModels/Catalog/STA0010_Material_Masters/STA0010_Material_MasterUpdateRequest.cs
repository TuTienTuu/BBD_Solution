using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.STA0010_Material_Masters
{
    public class STA0010_Material_MasterUpdateRequest
    {
        //public string MATCD { get; set; }
        //public string MATGROUPCD { get; set; }
        //public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string Note { get; set; }
        public string Unit { get; set; }
        public int UnitQty { get; set; }
        public decimal Price { get; set; }
    }
}
