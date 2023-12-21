using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.CodeLevel2Managements;
using ViewModels.Common;

namespace Application.Catalog.CodeLevel2Managements
{
    public interface ICodeLevel2ManagementService
    {
        Task<ApiResult<int>> Create(CodeLevel2ManagementCreateRequest request);
        Task<ApiResult<int>> Update(int id, CodeLevel2ManagementUpdateRequest request);
        Task<ApiResult<CodeLevel2ManagementViewModel>> GetById(int id);
        Task<ApiResult<List<CodeLevel2ManagementViewModel>>> GetAll();
    }
}
