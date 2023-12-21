using ApiIntergration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ViewModels.Catalog.STA0010_Material_Masters;
using ViewModels.Catalog.STA0020_Material_Supplier_LOTNOs;
using ViewModels.Catalog.STB0010_BARCODE_Printing_Logs;

namespace Quotation.Controllers
{
    public class WareHouseController : Controller
    {
        private readonly ISTA0010MaterialMasterApiClient _sta0010ApiClient;
        private readonly ISTA0020MaterialSupplierApiClient _sta0020ApiClient;
        private readonly ISTA0030_Material_Supplier_RAWNOApiClient _sta0030ApiClient;
        private readonly ISTA1010_Material_IN_OUT_LogApiClient _sta1010ApiClient;
        private readonly ISTB0010_BARCODE_Printing_LogApiClient _stb0010ApiClient;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public WareHouseController(ISTA0010MaterialMasterApiClient sta0010ApiClient, ISTA0020MaterialSupplierApiClient sta0020ApiClient, IWebHostEnvironment hostingEnvironment, ISTB0010_BARCODE_Printing_LogApiClient stb0010ApiClient, ISTA0030_Material_Supplier_RAWNOApiClient sta0030ApiClient, ISTA1010_Material_IN_OUT_LogApiClient sta1010ApiClient)
        {
            _sta0010ApiClient = sta0010ApiClient;
            _sta0020ApiClient = sta0020ApiClient;
            _hostingEnvironment = hostingEnvironment;
            _sta1010ApiClient = sta1010ApiClient;
            _stb0010ApiClient = stb0010ApiClient;
            _sta0030ApiClient = sta0030ApiClient;

        }

        public IActionResult Index()
        {
            return View();
        }

        #region STA0010MaterialMaster
        public async Task<IActionResult> STA0010MaterialMasterList(string matGroupSearch)
        {
            var data = await _sta0010ApiClient.GetList();

            var type = new List<SelectListItem> {
          new SelectListItem { Value="P", Text="Giấy" },
          new SelectListItem { Value="K", Text="Dao" },
        };

            var typeSearch = type;
            ViewData["type"] = type;

            if (!string.IsNullOrEmpty(matGroupSearch))
            {
                foreach (var item in typeSearch)
                {
                    if (matGroupSearch == item.Value)
                    {
                        item.Selected = true;
                    }
                }
            }

            ViewData["typeSearch"] = typeSearch;

            return View(data);
        }

        public async Task<JsonResult> STA0010MaterialMasterDetail(int id)
        {
            var data = await _sta0010ApiClient.GetById(id);
            return Json(data);
        }

        [HttpPost]
        public async Task<JsonResult> CreateSTA0010MaterialMaster([FromBody] STA0010_Material_MasterCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var isExist = await _sta0010ApiClient.CheckExist(model.MaterialCode, model.MATGROUPCD);
            if (!isExist.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = isExist.Message });
            }

            var resultAPI = await _sta0010ApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        [HttpPost]
        public async Task<JsonResult> UpdateSTA0010MaterialMaster(int id, [FromBody] STA0010_Material_MasterUpdateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _sta0010ApiClient.Update(id, model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Cập nhật dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Cập nhật dữ liệu không thành công" });
        }
        #endregion

        #region MyRegion
        public async Task<IActionResult> STA0020MaterialSupplierLOTNOList(string? typeSearch, string? matCDSearch)
        {
            if (string.IsNullOrEmpty(typeSearch))
                typeSearch = "A";

            var data = await _sta0020ApiClient.GetList(matCDSearch, typeSearch);

            var matCD = await _sta0010ApiClient.GetSelectList(null);
            var type = new List<SelectListItem>
            {
          new SelectListItem { Value="A", Text="Tất cả" },
          new SelectListItem { Value="P", Text="Giấy" },
          new SelectListItem { Value="K", Text="Dao" },
        };

            var matCDList = new SelectList(matCD.ResultObj, "Id", "Name");
            ViewData["matCDList"] = matCDList;

            if (!string.IsNullOrEmpty(typeSearch))
            {
                foreach (var item in type)
                {
                    if (typeSearch == item.Value)
                    {
                        item.Selected = true;
                    }
                }
            }

            ViewData["typeSearch"] = type;
            ViewData["matCDSearch"] = matCDSearch;

            return View(data);
        }

        [HttpPost]
        public async Task<JsonResult> CreateSTA0020MaterialSupplier([FromBody] STA0020_Material_Supplier_LOTNOCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            if (string.IsNullOrEmpty(model.TestResult))
                model.TestResult = "F";//Fail
            else if (model.TestResult == "on")
                model.TestResult = "A";//Pass
            else
                model.TestResult = "U";//unknow

            if (!ModelState.IsValid)
            {
                return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
            }
            var resultAPI = await _sta0020ApiClient.Create(model);

            if (resultAPI.IsSuccessed)
            {
                return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
            }

            return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        }

        public async Task<JsonResult> STA0020MaterialSupplierLOTNODetail(int id)
        {
            var data = await _sta0020ApiClient.GetById(id);

            return Json(data);
        }

        #endregion

        [HttpPost]
        public async Task<JsonResult> CreateSTB0010BarcodePrintingLog([FromBody] STB0010_BARCODE_Printing_LogCreateRequest model)
        {
            bool isSuccessResult = false;
            string result = string.Empty;
            var data = await _sta0020ApiClient.GetById(model.STA0020_Material_Supplier_LotnoID);

            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            string sFileName = @"Export.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Nhập NVL");
                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("STT");
                row.CreateCell(1).SetCellValue("RawLOT");
                row.CreateCell(2).SetCellValue("LOTNo");
                row.CreateCell(3).SetCellValue("Mã NL");
                row.CreateCell(4).SetCellValue("Tên NL");
                row.CreateCell(5).SetCellValue("EA");
                row.CreateCell(6).SetCellValue("Trọng lượng");
                row.CreateCell(7).SetCellValue("Đơn vị");
                row.CreateCell(8).SetCellValue("Ngày SX");
                row.CreateCell(9).SetCellValue("Ngày nhập kho");
                row.CreateCell(10).SetCellValue("LOT DN");
                row.CreateCell(11).SetCellValue("Nhà cung cấp");
                row.CreateCell(12).SetCellValue("Người nhập kho");
                row.CreateCell(13).SetCellValue("Ghi chú");

                for (int i = 1; i <= model.ExportQuantityEnd; i++)
                {

                    row = excelSheet.CreateRow(i);
                    row.CreateCell(0).SetCellValue(i);
                    row.CreateCell(1).SetCellValue(data.ResultObj.LotNo + (i < 10 ? "00" + i : i > 10 && i < 100 ? "0" + i : "000"));
                    row.CreateCell(2).SetCellValue(data.ResultObj.LotNo);
                    row.CreateCell(3).SetCellValue(data.ResultObj.MatCD);
                    row.CreateCell(4).SetCellValue(data.ResultObj.MaterialCode);
                    row.CreateCell(5).SetCellValue(data.ResultObj.Quantity);
                    row.CreateCell(6).SetCellValue(data.ResultObj.UnitQuantity);
                    row.CreateCell(7).SetCellValue(data.ResultObj.Unit);
                    row.CreateCell(8).SetCellValue(data.ResultObj.ProductDate);
                    row.CreateCell(9).SetCellValue(data.ResultObj.ImportDate);
                    row.CreateCell(10).SetCellValue(data.ResultObj.SupLOT);
                    row.CreateCell(11).SetCellValue(data.ResultObj.Supplier);
                    row.CreateCell(12).SetCellValue("Test");
                    row.CreateCell(13).SetCellValue("Test");
                }

                workbook.Write(fs);
            }

            var insertTracking = await _stb0010ApiClient.Create(model);

            return Json(new { isSuccessResult = true, result = "Xuất dữ liệu thành công" });
        }

        public FileResult Download()
        {
            string fileName = "Export.xlsx";
            string Files = "wwwroot/" + fileName;
            byte[] fileBytes = System.IO.File.ReadAllBytes(Files);
            System.IO.File.WriteAllBytes(Files, fileBytes);
            MemoryStream ms = new MemoryStream(fileBytes);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public async Task<IActionResult> STB0010BarcodePrintingLogList()
        {
            var data = await _stb0010ApiClient.GetList();

            return View(data);
        }

        public async Task<IActionResult> STA0020MaterialInventoryList(string matGroupSearch)
        {
            var data = await _sta0020ApiClient.GetInventoryList();

            foreach (var item in data.ResultObj)
            {
                if (item.OutStockDate != null)
                {
                    item.OutStockDate = item.OutStockDate.Substring(8, 2) + "-" + item.OutStockDate.Substring(5, 2) + "-" + item.OutStockDate.Substring(0, 4);
                }
            }
            return View(data);
        }

        #region STA0030MaterialSupplierROWNO
        public async Task<IActionResult> STA0030MaterialSupplierROWNOList(string matCD)
        {
            var data = await _sta0030ApiClient.GetList(matCD);

            foreach (var item in data.ResultObj)
            {
                if (item.ProductDate != null)
                {
                    item.ProductDate = item.ProductDate.Substring(8, 2) + "-" + item.ProductDate.Substring(5, 2) + "-" + item.ProductDate.Substring(0, 4);
                }
                if (item.TestDate != null)
                {
                    item.TestDate = item.TestDate.Substring(8, 2) + "-" + item.TestDate.Substring(5, 2) + "-" + item.TestDate.Substring(0, 4);
                }
                if (item.ImportDate != null)
                {
                    item.ImportDate = item.ImportDate.Substring(8, 2) + "-" + item.ImportDate.Substring(5, 2) + "-" + item.ImportDate.Substring(0, 4);
                }
                if (item.ExpiredDate != null)
                {
                    item.ExpiredDate = item.ExpiredDate.Substring(8, 2) + "-" + item.ExpiredDate.Substring(5, 2) + "-" + item.ExpiredDate.Substring(0, 4);
                }
                if (item.UseDate != null)
                {
                    item.UseDate = item.UseDate.Substring(8, 2) + "-" + item.UseDate.Substring(5, 2) + "-" + item.UseDate.Substring(0, 4);
                }

            }

            if (!string.IsNullOrEmpty(matCD))
            {
                @ViewData["matCD"] = matCD;
            }

            return View(data);
        }

        public async Task<JsonResult> STA0030MaterialSupplierROWNOFollowLOTNOList(string lotNo)
        {
            var data = await _sta0030ApiClient.GetListByLotNo(lotNo);

            foreach (var item in data.ResultObj)
            {
                if (item.ProductDate != null)
                {
                    item.ProductDate = item.ProductDate.Substring(8, 2) + "-" + item.ProductDate.Substring(5, 2) + "-" + item.ProductDate.Substring(0, 4);
                }
                if (item.TestDate != null)
                {
                    item.TestDate = item.TestDate.Substring(8, 2) + "-" + item.TestDate.Substring(5, 2) + "-" + item.TestDate.Substring(0, 4);
                }
                if (item.ImportDate != null)
                {
                    item.ImportDate = item.ImportDate.Substring(8, 2) + "-" + item.ImportDate.Substring(5, 2) + "-" + item.ImportDate.Substring(0, 4);
                }
                if (item.ExpiredDate != null)
                {
                    item.ExpiredDate = item.ExpiredDate.Substring(8, 2) + "-" + item.ExpiredDate.Substring(5, 2) + "-" + item.ExpiredDate.Substring(0, 4);
                }
                if (item.UseDate != null)
                {
                    item.UseDate = item.UseDate.Substring(8, 2) + "-" + item.UseDate.Substring(5, 2) + "-" + item.UseDate.Substring(0, 4);
                }
            }

            return Json(data.ResultObj);
        }

        ////[HttpPost]
        ////public async Task<JsonResult> CreateSTA0020MaterialSupplier([FromBody] STA0020_Material_Supplier_LOTNOCreateRequest model)
        ////{
        ////    bool isSuccessResult = false;
        ////    string result = string.Empty;
        ////    if (!ModelState.IsValid)
        ////    {
        ////        return Json(new { isSuccessResult = false, result = "Dữ liệu không hợp lệ" });
        ////    }
        ////    var resultAPI = await _sta0020ApiClient.Create(model);

        ////    if (resultAPI.IsSuccessed)
        ////    {
        ////        return Json(new { isSuccessResult = true, result = "Thêm mới dữ liệu thành công" });
        ////    }

        ////    return Json(new { isSuccessResult = false, result = "Thêm mới dữ liệu không thành công" });
        ////}

        public async Task<JsonResult> STA0030MaterialSupplierROWNODetail(int id)
        {
            var data = await _sta0020ApiClient.GetById(id);

            return Json(data);
        }


        public async Task<IActionResult> STA1010MaterialInOutLogList(string searchType, string subLot, DateTime? date)
        {
            if (string.IsNullOrEmpty(searchType))
                searchType = "A";
            //if (string.IsNullOrEmpty(lotno))
            //lotno = "";

            var data = await _sta1010ApiClient.GetList(searchType, date, subLot);
            //typeSearch
            var type = new List<SelectListItem> {
          new SelectListItem { Value="N", Text="Nhập" },
          new SelectListItem { Value="X", Text="Xuất" },
          new SelectListItem { Value="A", Text="Tất cả" },
        };

            if (!string.IsNullOrEmpty(searchType))
            {
                foreach (var item in type)
                {
                    if (searchType == item.Value)
                    {
                        item.Selected = true;
                    }
                }
            }
            var typeSearch = type;

            ViewData["searchType"] = type;
            ViewData["subLot"] = subLot;
            ViewData["date"] = date;

            return View(data);
        }
        #endregion
    }
}
