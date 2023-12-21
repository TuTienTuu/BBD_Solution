using Application.Catalog.CodeLevel1Managements;
using Application.Catalog.CodeLevel2Managements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.CodeLevel1Managements;
using ViewModels.Catalog.CodeLevel2Managements;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeLevelManagementController : ControllerBase
    {
        private readonly ICodeLevel1ManagementService _codeLevel1ManagementService;
        private readonly ICodeLevel2ManagementService _codeLevel2ManagementService;
        public CodeLevelManagementController(ICodeLevel1ManagementService codeLevel1ManagementService, ICodeLevel2ManagementService codeLevel2ManagementService)
        {
            _codeLevel1ManagementService = codeLevel1ManagementService;
            _codeLevel2ManagementService = codeLevel2ManagementService;
        }
        #region CodeLevel1Management
        [HttpGet("GetCodeLevel1")]
        public async Task<IActionResult> GetCodeLevel1()
        {
            var data = await _codeLevel1ManagementService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetCodeLevel1ById/{id}")]
        public async Task<IActionResult> GetCodeLevel1ById(int id)
        {
            var data = await _codeLevel1ManagementService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreateCodeLevel1")]
        public async Task<IActionResult> CreateCodeLevel1([FromBody] CodeLevel1ManagementCreateRequest request)
        {

            var data = await _codeLevel1ManagementService.Create(request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(data);
        }

        [HttpPost("UpdateCodeLevel1/{id}")]
        public async Task<IActionResult> UpdateCodeLevel1(int Id, [FromBody] CodeLevel1ManagementUpdateRequest request)
        {
            var productId = await _codeLevel1ManagementService.Update(Id, request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }



        [HttpGet("GetCodeLevel1SelectList")]
        public async Task<IActionResult> GetCodeLevel1SelectList()
        {
            var data = await _codeLevel1ManagementService.GetSelectList();
            return Ok(data);
        }

        #endregion

        #region CodeLevel2Management
        [HttpGet("GetCodeLevel2")]
        public async Task<IActionResult> GetCodeLevel2()
        {
            var data = await _codeLevel2ManagementService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetCodeLevel2ById/{id}")]
        public async Task<IActionResult> GetCodeLevel2ById(int id)
        {
            var data = await _codeLevel2ManagementService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreateCodeLevel2")]
        public async Task<IActionResult> CreateCodeLevel2([FromBody] CodeLevel2ManagementCreateRequest request)
        {

            var data = await _codeLevel2ManagementService.Create(request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(data);
        }

        [HttpPost("UpdateCodeLevel2/{id}")]
        public async Task<IActionResult> UpdateCodeLevel2(int Id, [FromBody] CodeLevel2ManagementUpdateRequest request)
        {
            var productId = await _codeLevel2ManagementService.Update(Id, request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }



        //[HttpGet("GetCodeLevel2SelectList")]
        //public async Task<IActionResult> GetSelectList()
        //{
        //    var data = await _CodeLevel2Service.GetSelectList();
        //    return Ok(data);
        //}

        #endregion
    }
}
