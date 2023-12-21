using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA1010_Material_IN_OUT_Logs;
using ViewModels.Common;

namespace Application.Catalog.STA1010_Material_IN_OUT_Logs
{
    public interface ISTA1010_Material_IN_OUT_LogService
    {
        Task<ApiResult<List<STA1010_Material_IN_OUT_LogViewModel>>> GetAll(string? searchType, DateTime? date, string? subLot);
        Task<ApiResult<List<STA1010_Material_IN_OUT_LogViewModel>>> GetAll(string? searchType, string? subLot);
        Task<ApiResult<List<STA1010_Material_IN_OUT_LogViewModel>>> GetAll_(string? searchType, DateTime? date);
        Task<ApiResult<List<STA1010_Material_IN_OUT_LogViewModel>>> GetAll(string? searchType);
    }
}
