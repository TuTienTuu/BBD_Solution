using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Materials;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface IMaterialApiClient
    {
        Task<ApiResult<bool>> Create(MaterialCreateRequest request);
        Task<ApiResult<IEnumerable<MaterialViewModel>>> GetList(int materialType, string materialName);
        Task<ApiResult<MaterialViewModel>> GetById(int id);

        Task<ApiResult<bool>> Update(int id, MaterialUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> UpdatePrice(int id, MaterialPriceModel request);
        Task<ApiResult<MaterialPriceModel>> GetPriceById(int id);
        Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList(int materialTypeId);
    }
}
