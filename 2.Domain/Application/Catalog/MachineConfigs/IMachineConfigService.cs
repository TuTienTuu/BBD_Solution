using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.MachineConfigs;
using ViewModels.Common;

namespace Application.Catalog.MachineConfigs
{
    public interface IMachineConfigService
    {
        Task<ApiResult<int>> Create(MachineConfigCreateRequest request);
        Task<ApiResult<int>> Update(int id, MachineConfigUpdateRequest request);
        Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<MachineConfigViewModel>> GetById(int id);
        Task<ApiResult<List<MachineConfigViewModel>>> GetAll();
        Task<ApiResult<List<SelectItem>>> GetSelectList(string? group);
        Task<ApiResult<decimal>> AvgSalary(string machineName, decimal salary, int position);
    }
}
