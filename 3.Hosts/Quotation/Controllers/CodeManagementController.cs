using ApiIntergration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels.Catalog.CodeLevel1Managements;
using ViewModels.Catalog.CodeLevel2Managements;

namespace Quotation.Controllers
{
    public class CodeManagementController : Controller
    {
        private readonly ICodeLevel1ManagementApiClient _codeLevel1ManagementApiClient;
        private readonly ICodeLevel2ManagementApiClient _codeLevel2ManagementApiClient;
        private readonly IConfiguration _configuration;
        public CodeManagementController(ICodeLevel1ManagementApiClient codeLevel1ManagementApiClient, IConfiguration configuration, ICodeLevel2ManagementApiClient codeLevel2ManagementApiClient)
        {
            _configuration = configuration;
            _codeLevel1ManagementApiClient = codeLevel1ManagementApiClient;
            _codeLevel2ManagementApiClient = codeLevel2ManagementApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region CodeLevel1
        public async Task<IActionResult> CodeLevel1List()
        {
            var result = await _codeLevel1ManagementApiClient.GetList();

            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> CreateCodeLevel1([FromBody] CodeLevel1ManagementCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }

            var resultAPI = await _codeLevel1ManagementApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateCodeLevel1(int id, [FromBody] CodeLevel1ManagementUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _codeLevel1ManagementApiClient.Update(id, model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
        }

        public async Task<JsonResult> CodeLV1ManagementDetail(int id)
        {
            var data = await _codeLevel1ManagementApiClient.GetById(id);
            return Json(data);
        }
        #endregion

        #region CodeLevel2
        public async Task<IActionResult> CodeLevel2List()
        {
            var result = await _codeLevel2ManagementApiClient.GetList();

            var codeLevel1 = await _codeLevel1ManagementApiClient.GetSelectList();
            var codeLevel1Select = new SelectList(codeLevel1.ResultObj, "Id", "Name");
            ViewData["codeLevel1"] = codeLevel1Select;

            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> CreateCodeLevel2([FromBody] CodeLevel2ManagementCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }

            var resultAPI = await _codeLevel2ManagementApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateCodeLevel2(int id, [FromBody] CodeLevel2ManagementUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _codeLevel2ManagementApiClient.Update(id, model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
        }

        public async Task<JsonResult> CodeLevel2ManagementDetail(int id)
        {
            var data = await _codeLevel2ManagementApiClient.GetById(id);
            return Json(data);
        }
        #endregion
    }
}
