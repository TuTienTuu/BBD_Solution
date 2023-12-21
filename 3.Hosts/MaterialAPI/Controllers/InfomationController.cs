using Application.Catalog.STA0010_Material_Masters;
using Application.Catalog.STA0020_Material_Supplier_LOTNOs;
using Application.Catalog.STA0030_Material_Supplier_RAWNOs;
using Application.Catalog.STA1010_Material_IN_OUT_Logs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.STA0010_Material_Masters;
using ViewModels.Catalog.STA0020_Material_Supplier_LOTNOs;

namespace MaterialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfomationController : ControllerBase
    {

        private readonly ISTA0010_Material_MasterService _sta0010MasterService;
        private readonly ISTA0020_Material_Supplier_LOTNOService _sta0020SupplierService;
        private readonly ISTA0030_Material_Supplier_RAWNOService _sta0030SupplierRawNoService;
        private readonly ISTA1010_Material_IN_OUT_LogService _sta1010InOutService;
        //private readonly IMaterialService _materialService;
        public InfomationController(ISTA0010_Material_MasterService sta0010MasterService, ISTA0020_Material_Supplier_LOTNOService sta0020SupplierService, ISTA0030_Material_Supplier_RAWNOService sta0030SupplierRawNoService, ISTA1010_Material_IN_OUT_LogService sta1010InOutService)
        {
            _sta0010MasterService = sta0010MasterService;
            _sta0020SupplierService = sta0020SupplierService;
            _sta0030SupplierRawNoService = sta0030SupplierRawNoService;
            _sta1010InOutService = sta1010InOutService;
        }

        #region STA0010_Material_Master
        [HttpGet("GetMaterialMaster")]
        public async Task<IActionResult> GetMaterialMaster()
        {
            var data = await _sta0010MasterService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetMaterialMasterById/{id}")]
        public async Task<IActionResult> GetMaterialMasterById(int id)
        {
            var data = await _sta0010MasterService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreateMaterialMaster")]
        public async Task<IActionResult> CreateMaterialMaster([FromBody] STA0010_Material_MasterCreateRequest request)
        {

            var data = await _sta0010MasterService.Create(request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(data);
        }

        [HttpPost("UpdateMaterialMaster/{id}")]
        public async Task<IActionResult> UpdateMaterial(int Id, [FromBody] STA0010_Material_MasterUpdateRequest request)
        {
            var data = await _sta0010MasterService.Update(Id, request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            return Ok(data);
        }

        [HttpGet("CheckExist")]
        public async Task<IActionResult> CheckExist([FromQuery] string materialCode, [FromQuery] string groupCD)
        {
            var Id = await _sta0010MasterService.CheckExistMaterial(materialCode, groupCD);
            if (Id != null && Id.ResultObj > 0)
            {
                Id.IsSuccessed = false;
                Id.Message = "Vật tư đã tồn tại, vui lòng kiểm tra lại!";
                return NotFound(Id);//Tồn tại dữ liệu
            }
            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(Id);//Chưa tồn tại dữ liệu
        }

        [HttpGet("GetMaterialMasterSelectList/{matCDSearch?}")]
        public async Task<IActionResult> GetMaterialMasterSelectList(string? matCDSearch)
        {
            var data = await _sta0010MasterService.GetSelectList(matCDSearch);
            return Ok(data);
        }
        #endregion

        #region STA0020_Material_Supplier_LOTNO
        [HttpGet("GetMaterialSupplier/{typeSearch?}/{matCDSearch?}")]
        public async Task<IActionResult> GetMaterialSupplier(string? typeSearch, string? matCDSearch)
        {
            var data = await _sta0020SupplierService.GetAll(matCDSearch, typeSearch);
            return Ok(data);
        }

        [HttpGet("GetMaterialSupplierById/{id}")]
        public async Task<IActionResult> GetMaterialSupplierById(int id)
        {
            var data = await _sta0020SupplierService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreateMaterialSupplier")]
        public async Task<IActionResult> CreateMaterialSupplier([FromBody] STA0020_Material_Supplier_LOTNOCreateRequest request)
        {

            var data = await _sta0020SupplierService.Create(request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(data);
        }
        [HttpGet("GetInventory")]
        public async Task<IActionResult> GetInventory()
        {
            var data = await _sta0020SupplierService.GetInventory();
            return Ok(data);
        }

        #endregion 

        #region STA0030_Material_Supplier_RAWNO
        [HttpGet("GetMaterialMasterSupplierRawNo/{matCD}")]
        public async Task<IActionResult> GetMaterialMasterSupplierRawNo(string? matCD)
        {
            var data = await _sta0030SupplierRawNoService.GetAll(matCD);
            return Ok(data);
        }

        [HttpGet("GetMaterialMasterSupplierRawNo")]
        public async Task<IActionResult> GetMaterialMasterSupplierRawNo()
        {
            var data = await _sta0030SupplierRawNoService.GetAll(null);
            return Ok(data);
        }

        [HttpGet("GetMaterialMasterSupplierRawNoFollowLotNo/{lotNo?}")]
        public async Task<IActionResult> GetMaterialMasterSupplierRawNoFollowLotNo(string? lotNo)
        {
            var data = await _sta0030SupplierRawNoService.GetListByLotNo(lotNo);
            return Ok(data);
        }

        [HttpGet("GetMaterialMasterSupplierRawNoById/{id}")]
        public async Task<IActionResult> GetMaterialMasterSupplierRawNoById(int id)
        {
            var data = await _sta0030SupplierRawNoService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        //[HttpPost("CreateMaterialMaster")]
        //public async Task<IActionResult> CreateMaterialMaster([FromBody] STA0010_Material_MasterCreateRequest request)
        //{

        //    var data = await _sta0010MasterService.Create(request);
        //    if (data == null || data.ResultObj <= 0)
        //        return BadRequest(data);

        //    //var product = await _glueService.GetById(productId.ResultObj);

        //    return Ok(data);
        //}

        //[HttpPost("UpdateMaterialMaster/{id}")]
        //public async Task<IActionResult> UpdateMaterial(int Id, [FromBody] STA0010_Material_MasterUpdateRequest request)
        //{
        //    var data = await _sta0010MasterService.Update(Id, request);
        //    if (data == null || data.ResultObj <= 0)
        //        return BadRequest(data);

        //    return Ok(data);
        //}

        
        
        
        
        
        
        [HttpGet("GetMaterialInOutLogList/{searchType?}/{date?}/{subLot?}")]
        public async Task<IActionResult> GetMaterialInOutLogList(string? searchType, string? subLot, DateTime? date)
        {
            var data = await _sta1010InOutService.GetAll(searchType,  date, subLot);
            return Ok(data);
        }
        [HttpGet("GetMaterialInOutLogList/{searchType?}/{subLot?}")]
        public async Task<IActionResult> GetMaterialInOutLogList(string? searchType, string? subLot)
        {
            var data = await _sta1010InOutService.GetAll(searchType, subLot);
            return Ok(data);
        }

        [HttpGet("GetMaterialInOutLogList_/{searchType?}/{date?}")]
        public async Task<IActionResult> GetMaterialInOutLogList_(string? searchType, DateTime? date)
        {
            var data = await _sta1010InOutService.GetAll_(searchType, date);
            return Ok(data);
        }

        [HttpGet("GetMaterialInOutLogList/{searchType?}")]
        public async Task<IActionResult> GetMaterialInOutLogList(string? searchType)
        {
            var data = await _sta1010InOutService.GetAll(searchType);
            return Ok(data);
        }

        #endregion
    }
}
