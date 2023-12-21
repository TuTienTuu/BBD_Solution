using Application.Catalog.ConfigFees;
using Application.Catalog.MachineConfigs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.ConfigFees;
using ViewModels.Catalog.MachineConfigs;

namespace QuotationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigFeeService _configFeeService;
        private readonly IMachineConfigService _machineConfigService;
        public ConfigController(IConfigFeeService configFeeService, IMachineConfigService machineConfigService)
        {
            _configFeeService = configFeeService;
            _machineConfigService = machineConfigService;
        }
        #region MachineConfig
        [HttpGet("GetMachineConfig")]
        public async Task<IActionResult> GetMachineConfig()
        {
            var data = await _machineConfigService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetMachineConfigById/{id}")]
        public async Task<IActionResult> GetMachineConfigById(int id)
        {
            var data = await _machineConfigService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreateMachineConfig")]
        public async Task<IActionResult> CreateMachineConfig([FromBody] MachineConfigCreateRequest request)
        {

            var data = await _machineConfigService.Create(request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(data);
        }

        [HttpPost("UpdateMachineConfig/{id}")]
        public async Task<IActionResult> UpdateMachineConfig(int Id, [FromBody] MachineConfigUpdateRequest request)
        {
            var productId = await _machineConfigService.Update(Id, request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpDelete("DeleteMachineConfig/{id}")]
        public async Task<IActionResult> DeleteMachineConfig(int id)
        {
            var productId = await _machineConfigService.Delete(id);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpGet("GetMachineConfigSelectList/{group?}")]
        public async Task<IActionResult> GetSelectList(string? group)
        {
            var data = await _machineConfigService.GetSelectList(group);
            return Ok(data);
        }

        #endregion

        #region ConfigFee
        [HttpGet("GetConfigFee")]
        public async Task<IActionResult> GetConfigFee()
        {
            var data = await _configFeeService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetConfigFeeById/{id}")]
        public async Task<IActionResult> GetConfigFeeById(int id)
        {
            var data = await _configFeeService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreateConfigFee")]
        public async Task<IActionResult> CreateConfigFee([FromBody] ConfigFeeCreateRequest request)
        {

            var data = await _configFeeService.Create(request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(data);
        }

        [HttpPost("UpdateConfigFee/{id}")]
        public async Task<IActionResult> UpdateConfigFee(int Id, [FromBody] ConfigFeeUpdateRequest request)
        {
            var productId = await _configFeeService.Update(Id, request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpDelete("DeleteConfigFee/{id}")]
        public async Task<IActionResult> DeleteConfigFee(int id)
        {
            var productId = await _configFeeService.Delete(id);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        //[HttpGet("GetMachineConfigSelectList")]
        //public async Task<IActionResult> GetSelectList()
        //{
        //    var data = await _machineConfigService.GetSelectList();
        //    return Ok(data);
        //}

        #endregion
    }
}
