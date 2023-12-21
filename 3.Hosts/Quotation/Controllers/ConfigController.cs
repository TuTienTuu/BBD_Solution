using ApiIntergration;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Catalog.ConfigFees;
using ViewModels.Catalog.MachineConfigs;

namespace Quotation.Controllers
{
    public class ConfigController : Controller
    {
        private readonly IMachineConfigApiClient _machineConfigApiClient;
        private readonly IConfigFeeApiClient _configFeeApiClient;
        private readonly IConfiguration _configuration;
        public ConfigController(IMachineConfigApiClient machineConfigApiClient, IConfiguration configuration, IConfigFeeApiClient configFeeApiClient)
        {
            _configuration = configuration;
            _machineConfigApiClient = machineConfigApiClient;
            _configFeeApiClient = configFeeApiClient;
        }
        #region MachineConfig
        public async Task<IActionResult> MachineConfigList()
        {
            var result = await _machineConfigApiClient.GetList();

            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> CreateMachineConfig([FromBody] MachineConfigCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            if (model.MachineName.Contains("A06") || model.MachineName.Contains("A07") || model.MachineName.Contains("A08") || model.MachineName.Contains("A09"))
            {
                model.NumberStageMachine = 6;
            }
            else if (model.MachineName.Contains("B"))
            {
                model.NumberStageMachine = 5;
            }
            else if (model.MachineName.Contains("C"))
            {
                model.NumberStageMachine = 3;
            }
            else if (model.MachineName.Contains("D"))
            {
                model.NumberStageMachine = 2;
            }

            var resultAPI = await _machineConfigApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        public async Task<JsonResult> MachineConfigDetail(int id)
        {
            var data = await _machineConfigApiClient.GetById(id);
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateMachineConfig(int id, [FromBody] MachineConfigUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _machineConfigApiClient.Update(id, model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteMachineConfig(int id)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _machineConfigApiClient.Delete(id);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Xóa dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Xóa dữ liệu không thành công" });
        }
        #endregion

        #region ConfigFee

        public async Task<IActionResult> ConfigFeeList()
        {
            var result = await _configFeeApiClient.GetList();

            return View(result);
        }

        [HttpPost]
        public async Task<JsonResult> CreateConfigFee([FromBody] ConfigFeeCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }

            model.NumberOfMachine = 16;

            var resultAPI = await _configFeeApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        public async Task<JsonResult> ConfigFeeDetail(int id)
        {
            var data = await _configFeeApiClient.GetById(id);
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateConfigFee(int id, [FromBody] ConfigFeeUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }

            model.NumberOfMachine = 16;

            var resultAPI = await _configFeeApiClient.Update(id, model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteConfigFee(int id)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _configFeeApiClient.Delete(id);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Xóa dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Xóa dữ liệu không thành công" });
        }
        #endregion
    }
}
