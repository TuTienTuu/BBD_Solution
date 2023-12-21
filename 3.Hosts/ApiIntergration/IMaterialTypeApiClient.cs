using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.MaterialTypes;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface IMaterialTypeApiClient
    {
        Task<ApiResult<bool>> Create(MaterialTypeCreateRequest request);
        Task<ApiResult<IEnumerable<MaterialTypeViewModel>>> GetList();
        Task<ApiResult<MaterialTypeViewModel>> GetById(int id);
        Task<ApiResult<bool>> Update(int id, MaterialTypeUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList();
    }
}
