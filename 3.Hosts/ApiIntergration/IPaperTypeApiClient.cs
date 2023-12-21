using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.PaperType;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface IPaperTypeApiClient
    {
        Task<ApiResult<bool>> Create(PaperTypeCreateRequest request);
        Task<ApiResult<IEnumerable<PaperTypeViewModel>>> GetList();
        Task<ApiResult<PaperTypeViewModel>> GetById(int id);
        Task<ApiResult<bool>> Update(int id, PaperTypeUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList();
    }
}
