using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Soles;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface ISoleApiClient
    {
        Task<ApiResult<bool>> Create(SoleCreateRequest request);
        Task<ApiResult<IEnumerable<SoleViewModel>>> GetList();
        Task<ApiResult<SoleViewModel>> GetById(int id);
        Task<ApiResult<bool>> Update(int id,SoleUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList();
    }
}
