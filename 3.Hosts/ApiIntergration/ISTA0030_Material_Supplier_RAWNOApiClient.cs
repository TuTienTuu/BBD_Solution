using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0030_Material_Supplier_RAWNOs;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface ISTA0030_Material_Supplier_RAWNOApiClient
    {
        //Task<ApiResult<bool>> Create(STA0020_Material_Supplier_LOTNOCreateRequest request);
        Task<ApiResult<IEnumerable<STA0030_Material_Supplier_RAWNOViewModel>>> GetList(string matCD);
        Task<ApiResult<STA0030_Material_Supplier_RAWNOViewModel>> GetById(int id);
        Task<ApiResult<IEnumerable<STA0030_Material_Supplier_RAWNOViewModel>>> GetListByLotNo(string lotNo);
    }
}
