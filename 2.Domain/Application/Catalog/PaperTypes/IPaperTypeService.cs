using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.PaperType;
using ViewModels.Common;

namespace Application.Catalog.PaperTypes
{
    public interface IPaperTypeService
    {
        Task<ApiResult<int>> Create(PaperTypeCreateRequest request);
        Task<ApiResult<int>> Update(int id, PaperTypeUpdateRequest request);
        Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<PaperTypeViewModel>> GetById(int id);
        Task<ApiResult<List<PaperTypeViewModel>>> GetAll();
        Task<ApiResult<List<SelectItem>>> GetSelectList();
    }
}
