using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.Papers
{
    public class PaperUpdateRequest
    {
        public int ID { get; set; }
        public string Supplier { get; set; }
        public string BCode { get; set; }
        public int PaperTypeID { get; set; }
        public string PaperTypeName { get; set; }
        public int PaperTypeMainID { get; set; }
        public string PaperTypeMainCode { get; set; }
        public string PaperTypeMainName { get; set; }

        public int SoleID { get; set; }
        public string SoleName { get; set; }
        public string PaperName { get; set; }
        //public string SoleInfomation { get; set; }
        public int GlueID { get; set; }
        public string GlueName { get; set; }
        public string Purpose { get; set; }
        public string Characteristic { get; set; }
        public string? PaperSize { get; set; }
        public string Unit { get; set; }
        public int SurfaceThick { get; set; }
        public int SoleBaseThick { get; set; }
        public int SoleThick { get; set; }
        public int TotalThick { get; set; }
        public string QuantitativePaper { get; set; }
        public string? PaperTypeCode { get; set; }
        public string Core { get; set; }
        public string Note { get; set; }
    }
}
