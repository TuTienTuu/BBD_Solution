using ApiIntergration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ViewModels.Catalog.Materials;
using ViewModels.Catalog.MaterialTypes;
using ViewModels.Catalog.UpdateDataPaperTrackings;

namespace Quotation.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialTypeApiClient _materialTypeApiClient;
        private readonly IMaterialApiClient _materialApiClient;
        private readonly IConfiguration _configuration;
        private readonly IDataTrackingApiClient _datatrackingApiClient;

        public MaterialController(IMaterialTypeApiClient materialTypeApiClient, IMaterialApiClient materialApiClient, IDataTrackingApiClient datatrackingApiClient)
        {
            _materialTypeApiClient = materialTypeApiClient;
            _materialApiClient = materialApiClient;
            _datatrackingApiClient = datatrackingApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region MaterialType

        [HttpPost]
        public async Task<JsonResult> CreateMaterialType([FromBody] MaterialTypeCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _materialTypeApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateMaterialType(int id, [FromBody] MaterialTypeUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _materialTypeApiClient.Update(id, model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteMaterialType(int id)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _materialTypeApiClient.Delete(id);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Xóa dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Xóa dữ liệu không thành công" });
        }

        public async Task<JsonResult> MaterialTypeDetail(int id)
        {
            var data = await _materialTypeApiClient.GetById(id);
            return Json(data);
        }

        public async Task<JsonResult> MaterialTypeSelectList()
        {
            var result = await _materialTypeApiClient.GetList();

            return Json(result);
        }

        public async Task<IActionResult> ManagerGroupMaterial()
        {
            var result = await _materialTypeApiClient.GetList();

            return View(result);
        }

        #endregion

        #region Material
        [HttpPost]
        public async Task<JsonResult> CreateMaterial([FromBody] MaterialCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            if (model.MaterialTypeID <= 0 || model.MaterialTypeID == null)
            {
                return Json(new { isSuccessResult = false, result = "Mã hàng không hợp lệ!" });
            }
            var resultAPI = await _materialApiClient.Create(model);

            if (resultAPI.IsSuccessed && !resultAPI.ResultObj)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu đã tồn tại" });
            }

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateMaterial(int id, [FromBody] MaterialUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var oldData = await _materialApiClient.GetById(id);
            var resultAPI = await _materialApiClient.Update(id, model);
            var newData = JsonConvert.SerializeObject(model.ToString());

            if (resultAPI.IsSuccessed)
            {
                var request = new CreateRequest()
                {
                    TableName = "UpdatePrice",
                    OldValue = oldData.ResultObj.ToString(),
                    // NewValue = model.ID +model.BCode.ToString()+ model.Characteristic+ model.Core+ model.GlueID + model.GlueName+model.Note+ model.MaterialName + model.MaterialSize + model.MaterialTypeCode + model.MaterialTypeID + model.MaterialTypeMainCode + model.MaterialTypeMainID + model.MaterialTypeName + model.Purpose + model.QuantitativeMaterial + model.SoleBaseThick + model.SoleID+ model.SoleName + model.SoleThick + model.Supplier + model.SurfaceThick + model.TotalThick + model.Unit,  
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
        public async Task<JsonResult> DeleteMaterial(int id)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _materialApiClient.Delete(id);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Xóa dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Xóa dữ liệu không thành công" });
        }

        public async Task<IActionResult> ManagerMaterial(string material, int materialTypeList)
        {
            //if (string.IsNullOrEmpty(materialName))
            //{
            //    materialName = string.Empty;
            //}
            var result = await _materialApiClient.GetList(materialTypeList, material);

            var materialTypes = await _materialTypeApiClient.GetSelectList();
            var materialTypeListSelect = new SelectList(materialTypes.ResultObj, "Id", "Name");
            ViewData["materialTypeList"] = materialTypeListSelect;

            var unit = new List<SelectListItem> {
          new SelectListItem { Value="Chọn đơn vị", Text="Chọn đơn vị" },
          new SelectListItem { Value="Cái", Text="Cái" },
          new SelectListItem { Value="Cuộn", Text="Cuộn" },
          new SelectListItem { Value="Hộp", Text="Hộp" },
          new SelectListItem { Value="Kg", Text="Kg" },
          new SelectListItem { Value="Tấm", Text="Tấm" },
        };
            ViewData["unit"] = unit;

            //var materialTypeListSearch = new SelectList(materialTypeList.ResultObj, "Id", "Name", materialType > 0 ? materialType : 0);
            //ViewData["materialTypeListSearch"] = materialTypeListSearch;


            //var materialTypeMainListSearch = new SelectList(materialTypeMainList.ResultObj, "Id", "Name", materialTypeMain > 0 ? materialTypeMain : 0);
            //ViewData["materialTypeMainListSearch"] = materialTypeMainListSearch;

            //var soleListSearch = new SelectList(soleList.ResultObj, "Id", "Name", sole > 0 ? sole : 0);
            //ViewData["soleListSearch"] = soleListSearch;

            ViewData["material"] = !string.IsNullOrEmpty(material) ? material : string.Empty;

            return View(result);
        }

        public async Task<JsonResult> MaterialDetail(int id)
        {
            var data = await _materialApiClient.GetById(id);
            return Json(data);
        }

        public async Task<JsonResult> GetMaterialPriceById(int id)
        {
            var data = await _materialApiClient.GetPriceById(id);
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateMaterialPrice(int id, [FromBody] MaterialPriceModel model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _materialApiClient.UpdatePrice(id, model);

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

        //public IActionResult ManagerMaterial()
        //{
        //    return View();
        //}

        public IActionResult ManagerGroupMaterialPrice()
        {
            return View();
        }

        public IActionResult ManagerMaterialPrice()
        {
            return View();
        }
    }
}
