using Application.Catalog.STB0010_BARCODE_Printing_Logs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.STB0010_BARCODE_Printing_Logs;

namespace MaterialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly ISTB0010_BARCODE_Printing_LogService _stb0010BarcodePrintingLogService;
        //private readonly ISTA0020_Material_Supplier_LOTNOService _sta0020SupplierService;
        //private readonly IMaterialService _materialService;
        public TrackingController(ISTB0010_BARCODE_Printing_LogService stb0010BarcodePrintingLogService) //, ISTA0020_Material_Supplier_LOTNOService sta0020SupplierService)
        {
            _stb0010BarcodePrintingLogService = stb0010BarcodePrintingLogService;
            //_sta0020SupplierService = sta0020SupplierService;
        }

        [HttpGet("GetMaterialExportTracking")]
        public async Task<IActionResult> GetMaterialExportTracking()
        {
            var data = await _stb0010BarcodePrintingLogService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetMaterialExportTrackingById/{id}")]
        public async Task<IActionResult> GetMaterialExportTrackingById(int id)
        {
            var data = await _stb0010BarcodePrintingLogService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreateMaterialExportTracking")]
        public async Task<IActionResult> CreateMaterialExportTracking([FromBody] STB0010_BARCODE_Printing_LogCreateRequest request)
        {

            var data = await _stb0010BarcodePrintingLogService.Create(request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(data);
        }
    }
}
