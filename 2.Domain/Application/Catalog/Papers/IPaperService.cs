using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Papers;
using ViewModels.Common;

namespace Application.Catalog.Papers
{
    public interface IPaperService
    {
        Task<ApiResult<int>> Create(PaperCreateRequest request);
        Task<ApiResult<int>> Update(int id, PaperUpdateRequest request);
        Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<PaperViewModel>> GetById(int id);
        Task<ApiResult<List<PaperViewModel>>> GetAll(int paperType, int paperTypeMain, int sole, int soleThick);
        //Task<ApiResult<decimal>> UpdatePrice(int id, decimal price);
        Task<ApiResult<PaperPriceModel>> GetPriceById(int id);
        Task<ApiResult<decimal>> UpdatePrice(int id, PaperPriceModel request);
        Task<ApiResult<List<SelectItem>>> GetSelectList();
    }
}
