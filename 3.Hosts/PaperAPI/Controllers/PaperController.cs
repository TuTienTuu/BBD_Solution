using Application.Catalog.Glues;
using Application.Catalog.Papers;
using Application.Catalog.PaperTypeMains;
using Application.Catalog.PaperTypes;
using Application.Catalog.Soles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.Glues;
using ViewModels.Catalog.Papers;
using ViewModels.Catalog.PaperType;
using ViewModels.Catalog.PaperTypeMains;
using ViewModels.Catalog.Soles;

namespace PaperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaperController : ControllerBase
    {
        private readonly IGlueService _glueService;
        private readonly ISoleService _soleService;
        private readonly IPaperTypeService _paperTypeService;
        private readonly IPaperTypeMainService _paperTypeMainService;
        private readonly IPaperService _paperService;
        public PaperController(IGlueService glueService, ISoleService soleService, IPaperTypeService paperTypeService, IPaperTypeMainService paperTypeMainService, IPaperService paperService)
        {
            _glueService = glueService;
            _soleService = soleService;
            _paperTypeService = paperTypeService;
            _paperTypeMainService = paperTypeMainService;
            _paperService = paperService;
        }

        #region Glue
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _glueService.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _glueService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GlueCreateRequest request)
        {
            var productId = await _glueService.Create(request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(productId);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] GlueUpdateRequest request)
        {
            var productId = await _glueService.Update(request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productId = await _glueService.Delete(id);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpPost("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice)
        {
            var result = await _glueService.UpdatePrice(id, newPrice);

            if (!result.IsSuccessed)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetGlueSelectList")]
        public async Task<IActionResult> GetGlueSelectList()
        {
            var data = await _glueService.GetSelectList();
            return Ok(data);
        }

        #endregion

        #region Sole
        [HttpGet("GetSole")]
        public async Task<IActionResult> GetSole()
        {
            var data = await _soleService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetSoleById/{id}")]
        public async Task<IActionResult> GetSoleById(int id)
        {
            var data = await _soleService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreateSole")]
        public async Task<IActionResult> CreateSole([FromBody] SoleCreateRequest request)
        {
            var productId = await _soleService.Create(request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(productId);
        }

        [HttpPost("UpdateSole/{id}")]
        public async Task<IActionResult> UpdateSole(int Id,[FromBody] SoleUpdateRequest request)
        {
            var productId = await _soleService.Update(Id,request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpDelete("DeleteSole/{id}")]
        public async Task<IActionResult> DeleteSole(int id)
        {
            var productId = await _soleService.Delete(id);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpGet("GetSoleSelectList")]
        public async Task<IActionResult> GetSoleSelectList()
        {
            var data = await _soleService.GetSelectList();
            return Ok(data);
        }

        #endregion

        #region PaperType
        [HttpGet("GetPaperType")]
        public async Task<IActionResult> GetPaperType()
        {
            var data = await _paperTypeService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetPaperTypeById/{id}")]
        public async Task<IActionResult> GetPaperTypeById(int id)
        {
            var data = await _paperTypeService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreatePaperType")]
        public async Task<IActionResult> CreatePaperType([FromBody] PaperTypeCreateRequest request)
        {
            var productId = await _paperTypeService.Create(request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(productId);
        }

        [HttpPost("UpdatePaperType/{id}")]
        public async Task<IActionResult> UpdatePaperType(int Id, [FromBody] PaperTypeUpdateRequest request)
        {
            var productId = await _paperTypeService.Update(Id, request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpDelete("DeletePaperType/{id}")]
        public async Task<IActionResult> DeletePaperType(int id)
        {
            var productId = await _paperTypeService.Delete(id);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpGet("GetPaperTypeSelectList")]
        public async Task<IActionResult> GetSelectList()
        {
            var data = await _paperTypeService.GetSelectList();
            return Ok(data);
        }

        #endregion

        #region PaperTypeMain
        [HttpGet("GetPaperTypeMain")]
        public async Task<IActionResult> GetPaperTypeMain()
        {
            var data = await _paperTypeMainService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetPaperTypeMainById/{id}")]
        public async Task<IActionResult> GetPaperTypeMainById(int id)
        {
            var data = await _paperTypeMainService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreatePaperTypeMain")]
        public async Task<IActionResult> CreatePaperTypeMain([FromBody] PaperTypeMainCreateRequest request)
        {
            var productId = await _paperTypeMainService.Create(request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(productId);
        }

        [HttpPost("UpdatePaperTypeMain/{id}")]
        public async Task<IActionResult> UpdatePaperTypeMain(int Id, [FromBody] PaperTypeMainUpdateRequest request)
        {
            var productId = await _paperTypeMainService.Update(Id, request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpDelete("DeletePaperTypeMain/{id}")]
        public async Task<IActionResult> DeletePaperTypeMain(int id)
        {
            var productId = await _paperTypeMainService.Delete(id);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpGet("GetPaperTypeMainSelectList")]
        public async Task<IActionResult> GetPaperTypeMainSelectList()
        {
            var data = await _paperTypeMainService.GetSelectList();
            return Ok(data);
        }

        #endregion

        #region Paper
        [HttpGet("GetPaper/{paperThick}/{paperType}/{paperTypeMain}/{sole}")]
        public async Task<IActionResult> GetPaper( int paperThick,int paperType, int paperTypeMain, int sole)
        {
            var data = await _paperService.GetAll(paperThick, paperType, paperTypeMain, sole);
            return Ok(data);
        }

        [HttpGet("GetPaperById/{id}")]
        public async Task<IActionResult> GetPaperById(int id)
        {
            var data = await _paperService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreatePaper")]
        public async Task<IActionResult> CreatePaper([FromBody] PaperCreateRequest request)
        {
            var productId = await _paperService.Create(request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(productId);
        }

        [HttpPost("UpdatePaper/{id}")]
        public async Task<IActionResult> UpdatePaper(int Id, [FromBody] PaperUpdateRequest request)
        {
            var productId = await _paperService.Update(Id, request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpDelete("DeletePaper/{id}")]
        public async Task<IActionResult> DeletePaper(int id)
        {
            var productId = await _paperService.Delete(id);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpPost("UpdatePaperPrice/{id}")]
        public async Task<IActionResult> UpdatePaperPrice(int Id, PaperPriceModel request)
        {
            var productId = await _paperService.UpdatePrice(Id, request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpGet("GetPaperPriceById/{id}")]
        public async Task<IActionResult> GetPaperPriceById(int id)
        {
            var data = await _paperService.GetPriceById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpGet("GetPaperSelectList")]
        public async Task<IActionResult> GetPaperSelectList()
        {
            var data = await _paperService.GetSelectList();
            return Ok(data);
        }

        #endregion
    }
}
