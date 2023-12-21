using Application.Catalog.UpdateDataPaperTrackings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.UpdateDataPaperTrackings;

namespace PaperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly IUpdateDataPaperTrackingService _dataPaperTrackingService;
        public TrackingController(IUpdateDataPaperTrackingService dataPaperTrackingService)
        {
           _dataPaperTrackingService = dataPaperTrackingService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetPaperType()
        {
            var data = await _dataPaperTrackingService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _dataPaperTrackingService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreateTrackingData")]
        public async Task<IActionResult> CreateTrackingData([FromBody] CreateRequest request)
        {
            var productId = await _dataPaperTrackingService.Create(request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(productId);
        }
    }
}
