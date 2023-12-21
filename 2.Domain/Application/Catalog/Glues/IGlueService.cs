using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Glues;
using ViewModels.Common;

namespace Application.Catalog.Glues
{
    public interface IGlueService
    {
        Task<ApiResult<int>> Create(GlueCreateRequest request);
        Task<ApiResult<int>> Update(GlueUpdateRequest request);
        Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<bool>> UpdatePrice(int id, decimal newPrice);
        Task<ApiResult<GlueViewModel>> GetById(int id);
        Task<ApiResult<List<GlueViewModel>>> GetAll();
        Task<ApiResult<PagedResult<GlueViewModel>>> GetAllPaging(GetPublicProductPagingRequest request);
        Task<ApiResult<List<SelectItem>>> GetSelectList();
    }
}
