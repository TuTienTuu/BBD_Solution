using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.PaperTypeMains;
using ViewModels.Common;

namespace Application.Catalog.PaperTypeMains
{
    public interface IPaperTypeMainService
    {
        Task<ApiResult<int>> Create(PaperTypeMainCreateRequest request);
        Task<ApiResult<int>> Update(int id, PaperTypeMainUpdateRequest request);
        Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<PaperTypeMainViewModel>> GetById(int id);
        Task<ApiResult<List<PaperTypeMainViewModel>>> GetAll();
        Task<ApiResult<List<SelectItem>>> GetSelectList();
    }
}
