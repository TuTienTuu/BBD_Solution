using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.PaperTypeMains
{
    public class PaperTypeMainUpdateRequest
    {
        public int ID { get; set; }
        public string PaperTypeMainName { get; set; }
        public string? PaperTypeMainCode { get; set; }
       // public int PaperTypeID { get; set; }
        //public string PaperTypeCode { get; set; }
        //public string PaperTypeName { get; set; }
    }
}
