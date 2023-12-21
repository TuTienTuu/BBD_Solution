using ViewModels.Catalog.Glues;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface IGlueApiClient
    {
        Task<ApiResult<bool>> Create(GlueCreateRequest request);
        Task<ApiResult<IEnumerable<GlueViewModel>>> GetList();
        Task<ApiResult<GlueViewModel>> GetById(int id);
        Task<ApiResult<bool>> Update(GlueUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList();
    }
}
