using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0010_Material_Masters;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface ISTA0010MaterialMasterApiClient
    {
        Task<ApiResult<bool>> Create(STA0010_Material_MasterCreateRequest request);
        Task<ApiResult<IEnumerable<STA0010_Material_MasterViewModel>>> GetList();
        Task<ApiResult<STA0010_Material_MasterViewModel>> GetById(int id);
        Task<ApiResult<bool>> Update(int id, STA0010_Material_MasterUpdateRequest request);
        Task<ApiResult<bool>> CheckExist(string materialCode, string groupCD);
        Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList(string? matCDSearch);
    }
}
