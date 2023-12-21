using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.Glues
{
    public class GlueCreateRequest
    {
        public int ID { get; set; }
        public string GlueName { get; set; }
        public string GlueCode { get; set; }
        public string GlueDescription { get; set; }
    }
}
