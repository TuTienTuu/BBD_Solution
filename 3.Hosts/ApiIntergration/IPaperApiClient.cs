using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Papers;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface IPaperApiClient
    {
        Task<ApiResult<bool>> Create(PaperCreateRequest request);
        Task<ApiResult<IEnumerable<PaperViewModel>>> GetList(int soleThick, int paperType, int paperTypeMain, int sole);
        Task<ApiResult<PaperViewModel>> GetById(int id);
       
        Task<ApiResult<bool>> Update(int id, PaperUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> UpdatePrice(int id, PaperPriceModel request);
        Task<ApiResult<PaperPriceModel>> GetPriceById(int id);
        Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList();
    }
}
