using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0030_Material_Supplier_RAWNOs;
using ViewModels.Common;

namespace Application.Catalog.STA0030_Material_Supplier_RAWNOs
{
    public interface ISTA0030_Material_Supplier_RAWNOService
    {
        //Task<ApiResult<int>> Create(STB0010_BARCODE_Printing_LogCreateRequest request);
        //Task<ApiResult<int>> Update(int id, STA0010_Material_MasterUpdateRequest request);
        //Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<STA0030_Material_Supplier_RAWNOViewModel>> GetById(int id);
        Task<ApiResult<List<STA0030_Material_Supplier_RAWNOViewModel>>> GetAll(string matCD);
        Task<ApiResult<List<STA0030_Material_Supplier_RAWNOViewModel>>> GetListByLotNo(string lotNo);
    }
}
