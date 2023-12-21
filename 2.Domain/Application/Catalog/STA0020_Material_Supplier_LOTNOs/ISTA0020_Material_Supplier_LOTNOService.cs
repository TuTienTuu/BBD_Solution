using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0020_Material_Supplier_LOTNOs;
using ViewModels.Common;

namespace Application.Catalog.STA0020_Material_Supplier_LOTNOs
{
    public interface ISTA0020_Material_Supplier_LOTNOService
    {
        Task<ApiResult<int>> Create(STA0020_Material_Supplier_LOTNOCreateRequest request);
        //Task<ApiResult<int>> Update(int id, STA0010_Material_MasterUpdateRequest request);
        //Task<ApiResult<int>> Delete(int id);
        Task<ApiResult<STA0020_Material_Supplier_LOTNOViewModel>> GetById(int id);
        Task<ApiResult<List<STA0020_Material_Supplier_LOTNOViewModel>>> GetAll(string? matCDSearch, string? typeSearch);
        Task<ApiResult<List<STA0020_Material_InventoryViewModel>>> GetInventory();
        string GetLOTNO(string matCD);
    }
}
