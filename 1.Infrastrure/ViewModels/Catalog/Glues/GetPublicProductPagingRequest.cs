  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Common;

namespace ViewModels.Catalog.Glues
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
