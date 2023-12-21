using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.Soles
{
    public class SoleUpdateRequest
    {
        public int ID { get; set; }
        //public string GlueName { get; set; }
        public string SoleCode { get; set; }
        public string SoleInfomation { get; set; }
    }
}
