using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.UpdateDataPaperTrackings;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface IDataTrackingApiClient
    {
        Task<ApiResult<bool>> Create(CreateRequest request);
        Task<ApiResult<IEnumerable<ViewModel>>> GetList();
        Task<ApiResult<ViewModel>> GetById(int id);
    }
}
