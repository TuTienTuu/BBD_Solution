using Application.Catalog.Materials;
using Application.Catalog.MaterialTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.Materials;
using ViewModels.Catalog.MaterialTypes;

namespace MaterialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialTypeService _materialTypeService;
        private readonly IMaterialService _materialService;
        public MaterialController(IMaterialTypeService materialTypeService, IMaterialService materialService)
        {
            _materialTypeService = materialTypeService;
            _materialService = materialService;
        }
        #region MaterailType
        [HttpGet("GetMaterialType")]
        public async Task<IActionResult> GetMaterialType()
        {
            var data = await _materialTypeService.GetAll();
            return Ok(data);
        }

        [HttpGet("GetMaterialTypeById/{id}")]
        public async Task<IActionResult> GetMaterialTypeById(int id)
        {
            var data = await _materialTypeService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreateMaterialType")]
        public async Task<IActionResult> CreateMaterialType([FromBody] MaterialTypeCreateRequest request)
        {

            var data = await _materialTypeService.Create(request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(data);
        }

        [HttpPost("UpdateMaterialType/{id}")]
        public async Task<IActionResult> UpdateMaterialType(int Id, [FromBody] MaterialTypeUpdateRequest request)
        {
            var productId = await _materialTypeService.Update(Id, request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpDelete("DeleteMaterialType/{id}")]
        public async Task<IActionResult> DeleteMaterialType(int id)
        {
            var productId = await _materialTypeService.Delete(id);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpGet("GetMaterialTypeSelectList")]
        public async Task<IActionResult> GetSelectList()
        {
            var data = await _materialTypeService.GetSelectList();
            return Ok(data);
        }

        #endregion

        #region Material
        [HttpGet("GetMaterial/{materialType}/{materialName?}")]
        public async Task<IActionResult> GetMaterial(int materialType, string? materialName = null)
        {
            try
            {
                var data = await _materialService.GetAll(materialType, materialName);
                return Ok(data);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }

        }

        [HttpGet("GetMaterialById/{id}")]
        public async Task<IActionResult> GetMaterialById(int id)
        {
            var data = await _materialService.GetById(id);
            if (data == null)
                return BadRequest(data.Message);

            return Ok(data);
        }

        [HttpPost("CreateMaterial")]
        public async Task<IActionResult> CreateMaterial([FromBody] MaterialCreateRequest request)
        {
            var productId = await _materialService.Create(request);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);//Thêm dữ liệu lỗi

            //var product = await _glueService.GetById(productId.ResultObj);

            return Ok(productId);//Thành công
        }

        [HttpPost("CheckExist")]
        public async Task<IActionResult> CheckExist([FromBody] MaterialCreateRequest request)
        {
            var productId = await _materialService.CheckExistMaterial(request);
            if (productId != null && productId.ResultObj > 0)
                return Ok(productId);//Tồn tại dữ liệu

            //var product = await _glueService.GetById(productId.ResultObj);

            return NotFound(productId);//Chưa tồn tại dữ liệu
        }

        [HttpPost("UpdateMaterial/{id}")]
        public async Task<IActionResult> UpdateMaterial(int Id, [FromBody] MaterialUpdateRequest request)
        {
            var data = await _materialService.Update(Id, request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            return Ok(data);
        }

        [HttpDelete("DeleteMaterial/{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var productId = await _materialService.Delete(id);
            if (productId == null || productId.ResultObj <= 0)
                return BadRequest(productId);

            return Ok(productId);
        }

        [HttpPost("UpdateMaterialPrice/{id}")]
        public async Task<IActionResult> UpdateMaterialPrice(int Id, MaterialPriceModel request)
        {
            var data = await _materialService.UpdatePrice(Id, request);
            if (data == null || data.ResultObj <= 0)
                return BadRequest(data);

            return Ok(data);
        }

        [HttpGet("GetMaterialPriceById/{id}")]
        public async Task<IActionResult> GetMaterialPriceById(int id)
        {
            try
            {
                var data = await _materialService.GetPriceById(id);
                if (data == null)
                    return BadRequest(data.Message);

                return Ok(data);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        
        }

        [HttpGet("GetMaterialSelectList/{materialTypeId}")]
        public async Task<IActionResult> GetSelectList(int materialTypeId)
        {
            var data = await _materialService.GetSelectList(materialTypeId);
            return Ok(data);
        }

        #endregion
    }
}
