using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.Materials
{
    public class MaterialPriceModel
    {
        public int ID { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string Note { get; set; }
    }
}
