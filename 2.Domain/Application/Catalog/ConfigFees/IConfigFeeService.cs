using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.ConfigFees;
using ViewModels.Common;

namespace Application.Catalog.ConfigFees
{
    public interface IConfigFeeService
    {
        Task<ApiResult<int>> Create(ConfigFeeCreateRequest request);
        Task<ApiResult<int>> Update(int id, ConfigFeeUpdateRequest request);
        Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<ConfigFeeViewModel>> GetById(int id);
        Task<ApiResult<List<ConfigFeeViewModel>>> GetAll();
        //Task<ApiResult<List<SelectItem>>> GetSelectList();
    }
}
