using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.CodeLevel2Managements;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface ICodeLevel2ManagementApiClient
    {
        Task<ApiResult<bool>> Create(CodeLevel2ManagementCreateRequest request);
        Task<ApiResult<IEnumerable<CodeLevel2ManagementViewModel>>> GetList();
        Task<ApiResult<CodeLevel2ManagementViewModel>> GetById(int id);
        Task<ApiResult<bool>> Update(int id, CodeLevel2ManagementUpdateRequest request);
    }
}
