using ApiIntergration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ViewModels.Catalog.Glues;
using ViewModels.Catalog.Papers;
using ViewModels.Catalog.PaperType;
using ViewModels.Catalog.PaperTypeMains;
using ViewModels.Catalog.Soles;
using ViewModels.Catalog.UpdateDataPaperTrackings;

namespace Quotation.Controllers
{
    public class PaperController : Controller
    {
        private readonly IGlueApiClient _glueApiClient;
        private readonly ISoleApiClient _soleApiClient;
        private readonly IPaperTypeApiClient _paperTypeApiClient;
        private readonly IPaperTypeMainApiClient _paperTypeMainApiClient;
        private readonly IPaperApiClient _paperApiClient;
        private readonly IDataTrackingApiClient _datatrackingApiClient;
        private readonly IConfiguration _configuration;

        public PaperController(IGlueApiClient glueApiClient,
            IConfiguration configuration, ISoleApiClient soleApiClient, IPaperTypeApiClient paperTypeApiClient, IPaperTypeMainApiClient paperTypeMainApiClient, IPaperApiClient paperApiClient, IDataTrackingApiClient datatrackingApiClient)
        {
            _glueApiClient = glueApiClient;
            _configuration = configuration;
            _soleApiClient = soleApiClient;
            _paperTypeApiClient = paperTypeApiClient;
            _paperTypeMainApiClient = paperTypeMainApiClient;
            _paperApiClient = paperApiClient;
            _datatrackingApiClient = datatrackingApiClient;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //public async Task<IActionResult> CreateGlue()
        //{
        //    return View();
        //}
        #region Glue
        [HttpPost]
        public async Task<JsonResult> CreateGlue([FromBody] GlueCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _glueApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateGlue([FromBody] GlueUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _glueApiClient.Update(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteGlue(int id)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _glueApiClient.Delete(id);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Xóa dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Xóa dữ liệu không thành công" });
        }

        public async Task<IActionResult> GlueList()
        {
            var result = await _glueApiClient.GetList();

            return View(result);
        }

        public async Task<JsonResult> GlueDetail(int id)
        {
            var data = await _glueApiClient.GetById(id);
            return Json(data);
        }
        #endregion

        #region Sole
        [HttpPost]
        public async Task<JsonResult> CreateSole([FromBody] SoleCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _soleApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateSole(int id, [FromBody] SoleUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _soleApiClient.Update(id, model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteSole(int id)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _soleApiClient.Delete(id);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Xóa dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Xóa dữ liệu không thành công" });
        }

        public async Task<IActionResult> SoleList()
        {
            var result = await _soleApiClient.GetList();

            return View(result);
        }

        public async Task<JsonResult> SoleDetail(int id)
        {
            var data = await _soleApiClient.GetById(id);
            return Json(data);
        }

        #endregion

        #region PaperTypeMain

        [HttpPost]
        public async Task<JsonResult> CreatePaperTypeMain([FromBody] PaperTypeMainCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            //if (model.PaperTypeID <= 0 || model.PaperTypeID == null)
            //{
            //    return Json(new { isSuccessResult = false, result = "Mã hàng không hợp lệ!" });
            //}
            var resultAPI = await _paperTypeMainApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        [HttpPost]
        public async Task<JsonResult> UpdatePaperTypeMain(int id, [FromBody] PaperTypeMainUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _paperTypeMainApiClient.Update(id, model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
        }

        [HttpDelete]
        public async Task<JsonResult> DeletePaperTypeMain(int id)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _paperTypeMainApiClient.Delete(id);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Xóa dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Xóa dữ liệu không thành công" });
        }

        public async Task<IActionResult> PaperTypeMainList()
        {
            var result = await _paperTypeMainApiClient.GetList();

            return View(result);
        }

        public async Task<JsonResult> PaperTypeMainDetail(int id)
        {
            var data = await _paperTypeMainApiClient.GetById(id);
            return Json(data);
        }
        #endregion

        #region PaperType

        [HttpPost]
        public async Task<JsonResult> CreatePaperType([FromBody] PaperTypeCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _paperTypeApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        [HttpPost]
        public async Task<JsonResult> UpdatePaperType(int id, [FromBody] PaperTypeUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _paperTypeApiClient.Update(id, model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
        }

        [HttpDelete]
        public async Task<JsonResult> DeletePaperType(int id)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _paperTypeApiClient.Delete(id);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Xóa dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Xóa dữ liệu không thành công" });
        }

        public async Task<IActionResult> PaperTypeList()
        {
            var result = await _paperTypeApiClient.GetList();

            var paperTypeMainList = await _paperTypeMainApiClient.GetSelectList();
            var paperTypeMainListSelect = new SelectList(paperTypeMainList.ResultObj, "Id", "Name");
            ViewData["paperTypeMainList"] = paperTypeMainListSelect;
            return View(result);
        }

        public async Task<JsonResult> PaperTypeDetail(int id)
        {
            var data = await _paperTypeApiClient.GetById(id);
            return Json(data);
        }

        public async Task<JsonResult> PaperTypeSelectList()
        {
            var result = await _paperTypeApiClient.GetList();

            return Json(result);
        }
        #endregion

        #region Paper
        [HttpPost]
        public async Task<JsonResult> CreatePaper([FromBody] PaperCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            if (model.PaperTypeID <= 0 || model.PaperTypeID == null)
            {
                return Json(new { isSuccessResult = false, result = "Mã hàng không hợp lệ!" });
            }
            var resultAPI = await _paperApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        [HttpPost]
        public async Task<JsonResult> UpdatePaper(int id, [FromBody] PaperUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var oldData = await _paperApiClient.GetById(id);
            var resultAPI = await _paperApiClient.Update(id, model);
            var newData = JsonConvert.SerializeObject(model.ToString());

            if (resultAPI.IsSuccessed)
            {
                var request = new CreateRequest()
                {
                    TableName = "UpdatePrice",
                    OldValue = oldData.ResultObj.ToString(),
                    // NewValue = model.ID +model.BCode.ToString()+ model.Characteristic+ model.Core+ model.GlueID + model.GlueName+model.Note+ model.PaperName + model.PaperSize + model.PaperTypeCode + model.PaperTypeID + model.PaperTypeMainCode + model.PaperTypeMainID + model.PaperTypeName + model.Purpose + model.QuantitativePaper + model.SoleBaseThick + model.SoleID+ model.SoleName + model.SoleThick + model.Supplier + model.SurfaceThick + model.TotalThick + model.Unit,  
                    NewValue = newData,
                    UpdateBy = "Test"
                };
                var resultTrackingAPI = await _datatrackingApiClient.Create(request);
                if (resultTrackingAPI.IsSuccessed)
                {
                    return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
                }
                else
                    return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
            }
            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });

        }

        [HttpDelete]
        public async Task<JsonResult> DeletePaper(int id)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _paperApiClient.Delete(id);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Xóa dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Xóa dữ liệu không thành công" });
        }

        public async Task<IActionResult> PaperList(int paperTypeList, int paperTypeMainList, int soleLsist, int paperThick)
        {
            var result = await _paperApiClient.GetList(paperThick,paperTypeList, paperTypeMainList, soleLsist);

            var paperTypes = await _paperTypeApiClient.GetSelectList();
            var paperTypeListSelect = new SelectList(paperTypes.ResultObj, "Id", "Name");
            ViewData["paperTypeList"] = paperTypeListSelect;

            var paperTypeMains = await _paperTypeMainApiClient.GetSelectList();
            var paperTypeMainListSelect = new SelectList(paperTypeMains.ResultObj, "Id", "Name");
            ViewData["paperTypeMainList"] = paperTypeMainListSelect;

            var glues = await _glueApiClient.GetSelectList();
            var glueListSelect = new SelectList(glues.ResultObj, "Id", "Name");
            ViewData["glueList"] = glueListSelect;

            var soles = await _soleApiClient.GetSelectList();
            var soleListSelect = new SelectList(soles.ResultObj, "Id", "Name");
            ViewData["soleList"] = soleListSelect;


            //var paperTypeListSearch = new SelectList(paperTypeList.ResultObj, "Id", "Name", paperType > 0 ? paperType : 0);
            //ViewData["paperTypeListSearch"] = paperTypeListSearch;


            //var paperTypeMainListSearch = new SelectList(paperTypeMainList.ResultObj, "Id", "Name", paperTypeMain > 0 ? paperTypeMain : 0);
            //ViewData["paperTypeMainListSearch"] = paperTypeMainListSearch;

            //var soleListSearch = new SelectList(soleList.ResultObj, "Id", "Name", sole > 0 ? sole : 0);
            //ViewData["soleListSearch"] = soleListSearch;


            ViewData["paperThick"] = paperThick > 0? paperThick : 0;

            return View(result);
        }

        public async Task<JsonResult> PaperDetail(int id)
        {
            var data = await _paperApiClient.GetById(id);
            return Json(data);
        }

        public async Task<JsonResult> GetPaperPriceById(int id)
        {
            var data = await _paperApiClient.GetPriceById(id);
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> UpdatePaperPrice(int id, [FromBody] PaperPriceModel model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _paperApiClient.UpdatePrice(id, model);

            if (resultAPI.IsSuccessed)
            {
                var request = new CreateRequest()
                {
                    TableName = "UpdatePrice",
                    OldValue = model.OldPrice.ToString(),
                    NewValue = model.NewPrice.ToString(),
                    UpdateBy = "Test"
                };
                var resultTrackingAPI = await _datatrackingApiClient.Create(request);
                if (resultTrackingAPI.IsSuccessed)
                {
                    return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
                }
                else
                    return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
        }
        #endregion

        public async Task<IActionResult> CreatePaper()
        {
            return View();
        }
    }
}
