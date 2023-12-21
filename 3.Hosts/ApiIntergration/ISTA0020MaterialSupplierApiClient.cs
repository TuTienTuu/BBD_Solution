using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0020_Material_Supplier_LOTNOs;
using ViewModels.Common;

namespace ApiIntergration
{
    public interface ISTA0020MaterialSupplierApiClient
    {
        Task<ApiResult<bool>> Create(STA0020_Material_Supplier_LOTNOCreateRequest request);
        Task<ApiResult<IEnumerable<STA0020_Material_Supplier_LOTNOViewModel>>> GetList(string? matCDSearch, string? typeSearch);
        Task<ApiResult<IEnumerable<STA0020_Material_InventoryViewModel>>> GetInventoryList();
        Task<ApiResult<STA0020_Material_Supplier_LOTNOViewModel>> GetById(int id);
       
    }
}
