using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.UnitPrices;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface IUnitPriceApiClient
    {
        Task<ApiResult<bool>> Create(UnitPriceViewModel request);
        Task<ApiResult<IEnumerable<UnitPriceViewModel>>> GetList();
        Task<ApiResult<UnitPriceViewModel>> GetById(int id);
        Task<ApiResult<bool>> Update(int id, UnitPriceViewModel request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList();
    }
}
