using Application.Catalog.UnitPrices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.UnitPrices;

namespace QuotationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        private readonly IUnitPriceService _unitPriceService;
        //private readonly IMachineConfigService _machineConfigService;
        public QuotationController(IUnitPriceService unitPriceService) //, IMachineConfigService machineConfigService)
        {
            _unitPriceService = unitPriceService;
            //_machineConfigService = machineConfigService;
        }
        [HttpPost("CreateUnitPrice")]
        public async Task<IActionResult> CreateUnitPrice([FromBody] UnitPriceViewModel request)
        {

            var data = await _unitPriceService.Create(request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(data);
        }

        [HttpGet("GetUnitPrice")]
        public async Task<IActionResult> GetUnitPrice()
        {
            var data = await _unitPriceService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetUnitPriceSelectList")]
        public async Task<IActionResult> GetSelectList()
        {
            var data = await _unitPriceService.GetSelectList();
            return Ok(data);
        }

        [HttpGet("GetUnitPriceById/{id}")]
        public async Task<IActionResult> GetUnitPriceById(int id)
        {
            var data = await _unitPriceService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("UpdateUnitPrice/{id}")]
        public async Task<IActionResult> UpdateUnitPrice(int Id, [FromBody] UnitPriceViewModel request)
        {
            var productId = await _unitPriceService.Update(Id, request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }
    }
}
