using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STB0010_BARCODE_Printing_Logs;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface ISTB0010_BARCODE_Printing_LogApiClient
    {
        Task<ApiResult<bool>> Create(STB0010_BARCODE_Printing_LogCreateRequest request);
        Task<ApiResult<IEnumerable<STB0010_BARCODE_Printing_LogViewModel>>> GetList();
        Task<ApiResult<STB0010_BARCODE_Printing_LogViewModel>> GetById(int id);
    }
}
