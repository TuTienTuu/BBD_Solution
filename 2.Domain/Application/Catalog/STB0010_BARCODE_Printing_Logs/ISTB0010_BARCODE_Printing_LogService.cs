using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STB0010_BARCODE_Printing_Logs;
using ViewModels.Common;

namespace Application.Catalog.STB0010_BARCODE_Printing_Logs
{
    public interface ISTB0010_BARCODE_Printing_LogService
    {
        Task<ApiResult<int>> Create(STB0010_BARCODE_Printing_LogCreateRequest request);
        //Task<ApiResult<int>> Update(int id, STA0010_Material_MasterUpdateRequest request);
        //Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<STB0010_BARCODE_Printing_LogViewModel>> GetById(int id);
        Task<ApiResult<List<STB0010_BARCODE_Printing_LogViewModel>>> GetAll();
    }
}
