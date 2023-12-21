using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.UpdateDataPaperTrackings;
using ViewModels.Common;

namespace Application.Catalog.UpdateDataPaperTrackings
{
    public interface IUpdateDataPaperTrackingService
    {
        Task<ApiResult<int>> Create(CreateRequest request);
        Task<ApiResult<List<ViewModel>>> GetAll();
        Task<ApiResult<ViewModel>> GetById(int id);
    }
}
