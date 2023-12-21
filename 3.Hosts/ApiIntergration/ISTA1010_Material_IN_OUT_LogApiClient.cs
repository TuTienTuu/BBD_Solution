using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA1010_Material_IN_OUT_Logs;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface ISTA1010_Material_IN_OUT_LogApiClient
    {
        Task<ApiResult<IEnumerable<STA1010_Material_IN_OUT_LogViewModel>>> GetList(string? searchType, DateTime? date, string? subLot);
    }
}
