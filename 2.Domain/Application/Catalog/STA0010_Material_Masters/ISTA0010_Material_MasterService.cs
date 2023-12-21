using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0010_Material_Masters;
using ViewModels.Common;

namespace Application.Catalog.STA0010_Material_Masters
{
    public interface ISTA0010_Material_MasterService
    {
        Task<ApiResult<int>> Create(STA0010_Material_MasterCreateRequest request);
        Task<ApiResult<int>> Update(int id, STA0010_Material_MasterUpdateRequest request);
        //Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<STA0010_Material_MasterViewModel>> GetById(int id);
        Task<ApiResult<List<STA0010_Material_MasterViewModel>>> GetAll();
        Task<ApiResult<List<SelectItem>>> GetSelectList(string? matCDSearch);
        Task<ApiResult<int>> CheckExistMaterial(string materialCode, string groupCD);
        string GetMATCD(string groupCode);
    }
}
