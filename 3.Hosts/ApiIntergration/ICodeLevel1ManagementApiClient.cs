using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.CodeLevel1Managements;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface ICodeLevel1ManagementApiClient
    {
        Task<ApiResult<bool>> Create(CodeLevel1ManagementCreateRequest request);
        Task<ApiResult<IEnumerable<CodeLevel1ManagementViewModel>>> GetList();
        Task<ApiResult<CodeLevel1ManagementViewModel>> GetById(int id);
        Task<ApiResult<bool>> Update(int id, CodeLevel1ManagementUpdateRequest request);
        Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList();
    }
}
