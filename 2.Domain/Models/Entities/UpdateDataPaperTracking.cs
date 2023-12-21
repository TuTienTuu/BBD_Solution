using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UpdateDataPaperTracking
    {
        public int ID { get; set; }
        public string UpdateBy { get; set; }
        public string TableName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Created { get; set; }
    }
}
