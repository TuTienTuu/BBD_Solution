using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.MaterialTypes;
using ViewModels.Common;

namespace Application.Catalog.MaterialTypes
{
    public interface IMaterialTypeService
    {
        Task<ApiResult<int>> Create(MaterialTypeCreateRequest request);
        Task<ApiResult<int>> Update(int id, MaterialTypeUpdateRequest request);
        Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<MaterialTypeViewModel>> GetById(int id);
        Task<ApiResult<List<MaterialTypeViewModel>>> GetAll();
        Task<ApiResult<List<SelectItem>>> GetSelectList();
    }
}
