using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Soles;
using ViewModels.Common;

namespace Application.Catalog.Soles
{
    public interface ISoleService
    {
        Task<ApiResult<int>> Create(SoleCreateRequest request);
        Task<ApiResult<int>> Update(int id,SoleUpdateRequest request);
        Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<SoleViewModel>> GetById(int id);
        Task<ApiResult<List<SoleViewModel>>> GetAll();
        Task<ApiResult<List<SelectItem>>> GetSelectList();
    }
}
