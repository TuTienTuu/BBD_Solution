using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.UnitPrices;
using ViewModels.Common;

namespace Application.Catalog.UnitPrices
{
    public interface IUnitPriceService
    {
        Task<ApiResult<int>> Create(UnitPriceViewModel request);
        Task<ApiResult<int>> Update(int id, UnitPriceViewModel request);
        Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<UnitPriceViewModel>> GetById(int id);
        Task<ApiResult<List<UnitPriceViewModel>>> GetAll();
        //Task<ApiResult<decimal>> UpdatePrice(int id, decimal price);
        //Task<ApiResult<UnitPriceViewModel>> GetPriceById(int id);
        //Task<ApiResult<decimal>> UpdatePrice(int id, MaterialPriceModel request);
        //Task<ApiResult<int>> CheckExistMaterial(MaterialCreateRequest request);
        Task<ApiResult<List<SelectItem>>> GetSelectList();
    }
}
