using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.CodeLevel1Managements;
using ViewModels.Common;

namespace Application.Catalog.CodeLevel1Managements
{
    public interface ICodeLevel1ManagementService
    {
        Task<ApiResult<int>> Create(CodeLevel1ManagementCreateRequest request);
        Task<ApiResult<int>> Update(int id, CodeLevel1ManagementUpdateRequest request);
        Task<ApiResult<CodeLevel1ManagementViewModel>> GetById(int id);
        Task<ApiResult<List<CodeLevel1ManagementViewModel>>> GetAll();
        Task<ApiResult<List<SelectItem>>> GetSelectList();
    }
}
