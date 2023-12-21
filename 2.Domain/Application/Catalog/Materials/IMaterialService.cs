using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Materials;
using ViewModels.Common;

namespace Application.Catalog.Materials
{
    public interface IMaterialService
    {

        Task<ApiResult<int>> Create(MaterialCreateRequest request);
        Task<ApiResult<int>> Update(int id, MaterialUpdateRequest request);
        Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<MaterialViewModel>> GetById(int id);
        Task<ApiResult<List<MaterialViewModel>>> GetAll(int materialType, string materialName);
        //Task<ApiResult<decimal>> UpdatePrice(int id, decimal price);
        Task<ApiResult<MaterialPriceModel>> GetPriceById(int id);
        Task<ApiResult<decimal>> UpdatePrice(int id, MaterialPriceModel request);
        Task<ApiResult<int>> CheckExistMaterial(MaterialCreateRequest request);
        Task<ApiResult<List<SelectItem>>> GetSelectList(int materialTypeId);
    }
}
