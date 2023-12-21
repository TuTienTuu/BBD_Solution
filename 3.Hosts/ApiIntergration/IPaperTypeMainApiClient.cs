using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.PaperTypeMains;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface IPaperTypeMainApiClient
    {
        Task<ApiResult<bool>> Create(PaperTypeMainCreateRequest request);
        Task<ApiResult<IEnumerable<PaperTypeMainViewModel>>> GetList();
        Task<ApiResult<PaperTypeMainViewModel>> GetById(int id);
        Task<ApiResult<bool>> Update(int id, PaperTypeMainUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList();
    }
}
