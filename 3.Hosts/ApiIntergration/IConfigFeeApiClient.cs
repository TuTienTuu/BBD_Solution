using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.ConfigFees;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface IConfigFeeApiClient
    {
        Task<ApiResult<bool>> Create(ConfigFeeCreateRequest request);
        Task<ApiResult<IEnumerable<ConfigFeeViewModel>>> GetList();
        Task<ApiResult<ConfigFeeViewModel>> GetById(int id);
        Task<ApiResult<bool>> Update(int id, ConfigFeeUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);
    }
}
