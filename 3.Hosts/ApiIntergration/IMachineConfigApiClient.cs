using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.MachineConfigs;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface IMachineConfigApiClient
    {
        Task<ApiResult<bool>> Create(MachineConfigCreateRequest request);
        Task<ApiResult<IEnumerable<MachineConfigViewModel>>> GetList();
        Task<ApiResult<MachineConfigViewModel>> GetById(int id);
        Task<ApiResult<bool>> Update(int id, MachineConfigUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList(string? group);
    }
}
