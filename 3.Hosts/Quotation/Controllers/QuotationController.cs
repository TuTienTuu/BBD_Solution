using ApiIntergration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels.Catalog.UnitPrices;

namespace Quotation.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IMachineConfigApiClient _machineConfigApiClient;
        private readonly IPaperApiClient _paperApiClient;
        private readonly IConfigFeeApiClient _configFeeApiClient;
        private readonly IMaterialApiClient _materialApiClient;
        private readonly IUnitPriceApiClient _unitPriceApiClient;

        public QuotationController(IMachineConfigApiClient machineConfigApiClient, IPaperApiClient paperApiClient, IConfigFeeApiClient configFeeApiClient, IMaterialApiClient materialApiClient, IUnitPriceApiClient unitPriceApiClient)
        {
            _machineConfigApiClient = machineConfigApiClient;
            _paperApiClient = paperApiClient;
            _configFeeApiClient = configFeeApiClient;
            _materialApiClient = materialApiClient;
            _unitPriceApiClient = unitPriceApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult QuotationList()
        {
            return View();
        }

        public async Task<IActionResult> CreateQuotation()
        {
            var unitPriceList = await _unitPriceApiClient.GetSelectList();
            ViewBag.unitPriceList = new SelectList(unitPriceList.ResultObj, "Id", "Name");
            return View();
        }

        public IActionResult ApproveQuotation()
        {
            return View();
        }

        public async Task<IActionResult> UnitPriceList()
        {
            var data = await _unitPriceApiClient.GetList();
            return View(data);
        }

        public async Task<JsonResult> UnitPriceDetail(int id)
        {
            var data = await _unitPriceApiClient.GetById(id);
            return Json(data);
        }
        public async Task<IActionResult> CreateUnitPrice()
        {

            var printMachine = await _machineConfigApiClient.GetSelectList("A");
            var dieCuttingMachine = await _machineConfigApiClient.GetSelectList("B");
            var divideMachine = await _machineConfigApiClient.GetSelectList("C");
            //var packingMachine = await _machineConfigApiClient.GetSelectList("D");
            var compressMachine = await _machineConfigApiClient.GetSelectList("D");
            var paperList = await _paperApiClient.GetSelectList();

            //Material
            var box = await _materialApiClient.GetSelectList(1003);
            var lamination = await _materialApiClient.GetSelectList(1);
            var core = await _materialApiClient.GetSelectList(1006);
            var ink = await _materialApiClient.GetSelectList(2);
            var printType = await _materialApiClient.GetSelectList(2);

            ViewBag.printMachine = new SelectList(printMachine.ResultObj, "Id", "Name");
            ViewBag.dieCuttingMachine = new SelectList(dieCuttingMachine.ResultObj, "Id", "Name");
            ViewBag.divideMachine = new SelectList(divideMachine.ResultObj, "Id", "Name");
            //ViewBag.packingMachine = new SelectList(packingMachine.ResultObj, "Id", "Name");
            ViewBag.compressMachine = new SelectList(compressMachine.ResultObj, "Id", "Name");
            ViewBag.paperList = new SelectList(paperList.ResultObj, "Id", "Name");
            //Material
            ViewBag.box = new SelectList(box.ResultObj, "Id", "Name");
            ViewBag.lamination = new SelectList(lamination.ResultObj, "Id", "Name");
            ViewBag.core = new SelectList(core.ResultObj, "Id", "Name");
            ViewBag.ink = new SelectList(ink.ResultObj, "Id", "Name");
            ViewBag.printType = new SelectList(printType.ResultObj, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUnitPrice(UnitPriceCreateRequest model)
        {
            var quotationUnit = new UnitPriceExecutingRequest()
            {
                Width = model.Width,
                Height = model.Height,
                NumberStampHorizontal = model.NumberStampHorizontal,
                NumberRowStamp = model.NumberRowStamp,
                Border = model.Border,
                Midle = model.Midle,
                Gap = model.Gap,
                RowStampHaveGap = model.RowStampHaveGap,
                Point = model.Point,
                SplitLine = model.SplitLine,

                MetterPerRoll = model.MetterPerRoll,
                StampPerRoll = model.StampPerRoll,
                Quantity = model.Quantity,

                Unit = model.Unit,
                PaperCode = model.PaperCode,
                TypeCopy = model.TypeCopy,
                ColorType = model.ColorType,
                NumberOfColor = model.NumberOfColor,
                NumberOfCode = model.NumberOfCode,
                AreaPrint = model.AreaPrint,
                Lamination = model.Lamination,
                Core = model.Core,
                MachinePrint = model.MachinePrint,
                MachinePressedPowder = model.MachinePressedPowder,
                MachineDieCutting = model.MachineDieCutting,
                MachineDivide = model.MachineDivide,
                MachinePacking = model.MachinePacking,
                Characteristic = model.Characteristic,

                KnifeNumber = model.KnifeNumber,
                KnifeOtherFee = model.KnifeOtherFee,
            };
            //CartonNumber = 0,

            var printMachine = await _machineConfigApiClient.GetById(model.MachinePrint);
            var pressPowderMachine = await _machineConfigApiClient.GetById(model.MachinePressedPowder);
            var dieCuttingMachine = await _machineConfigApiClient.GetById(model.MachineDieCutting);
            var divideMachine = await _machineConfigApiClient.GetById(model.MachineDivide);
            var packingMachine = await _machineConfigApiClient.GetById(model.MachinePacking);
            var configFee = await _configFeeApiClient.GetById(2);

            var paperInfo = await _paperApiClient.GetById(model.PaperCode);
            var managermentFee = await _machineConfigApiClient.GetById(model.MachinePacking);


            quotationUnit.MachinePrintCode = printMachine.ResultObj.MachineName;
            quotationUnit.MachinePressedPowderCode = pressPowderMachine.ResultObj.MachineName;
            quotationUnit.MachineDieCuttingCode = dieCuttingMachine.ResultObj.MachineName;
            quotationUnit.MachineDivideCode = divideMachine.ResultObj.MachineName;

            quotationUnit.LaminationCode = model.Lamination.ToString();
            quotationUnit.TypeCopyCode = model.TypeCopy.ToString();
            quotationUnit.ColorTypeCode = model.ColorType.ToString();
            quotationUnit.MachinePackingCode = model.MachinePacking.ToString();
            quotationUnit.PaperCode_ = paperInfo.ResultObj.PaperName;

            quotationUnit.PaperSize = (model.Border * 2 + (model.Width * model.NumberStampHorizontal) + (model.NumberStampHorizontal - 1) * model.Midle) * model.SplitLine + model.Point;//(biên  * 2+ (rộng * số tem ngang) + (số tem ngang - 1)* giữa) * xẻ line + tiêu điểm

            quotationUnit.StampStep = model.Height * model.NumberRowStamp + model.Gap * model.NumberRowStamp / model.RowStampHaveGap; //Cao * Hàng tem + gap * hàng tem/hàng tem có gap
            quotationUnit.StampPerStep = model.NumberRowStamp * model.NumberStampHorizontal; //Tem ngang * Hàng tem
            quotationUnit.MetterPerOrder = (model.Quantity * model.MetterPerRoll) / model.SplitLine + (((quotationUnit.StampStep * model.StampPerRoll / 1000) / model.SplitLine / quotationUnit.StampPerStep) * model.Quantity) + (model.MetterPerRoll != 0 ? 0 : (model.Quantity * quotationUnit.StampStep / 1000) / model.SplitLine / quotationUnit.StampPerStep); // (số lượng*met\cuộn)/xẻ line+ ((bước tem*tem\cuộn/1000)/xẻ line/tem\bước) * Số lượng + (nếu m\cuộn =0 thì (số lượng * bước tem/1000)/xẻ line/ bước tem)
            quotationUnit.MetterSquarePerOrder = quotationUnit.MetterPerOrder * quotationUnit.PaperSize / 1000; //Met\đơn * size giấy /1000

            quotationUnit.PrintChangeRoll = printMachine.ResultObj.ChangeRoll;
            quotationUnit.PrintColor = printMachine.ResultObj.Color;
            quotationUnit.PrintCarryCompensation = printMachine.ResultObj.Compensation;
            quotationUnit.PrintWhiteCarry = printMachine.ResultObj.WhiteCarry;
            quotationUnit.PrintChangeCode = printMachine.ResultObj.ChangeSpec;
            quotationUnit.PrintRisk = printMachine.ResultObj.Risk;
            quotationUnit.PrintTarget = printMachine.ResultObj.Target;
            quotationUnit.PrintHourSalary = (float)printMachine.ResultObj.HourlySalary;
            quotationUnit.PrintChange = (float)printMachine.ResultObj.Change;
            quotationUnit.PrintElectric = (float)printMachine.ResultObj.ElectricPrice;

            quotationUnit.PressedPowderChangeRoll = pressPowderMachine.ResultObj.ChangeRoll;
            quotationUnit.PressedPowderColor = pressPowderMachine.ResultObj.Color;
            quotationUnit.PressedPowderCarryCompensation = pressPowderMachine.ResultObj.Compensation;
            quotationUnit.PressedPowderRisk = pressPowderMachine.ResultObj.Risk;
            quotationUnit.PressedPowderTarget = pressPowderMachine.ResultObj.Target;
            quotationUnit.PressedPowderHourSalary = (float)pressPowderMachine.ResultObj.HourlySalary;
            quotationUnit.PressedPowderChange = (float)pressPowderMachine.ResultObj.Change;
            quotationUnit.PressedPowderElectric = (float)pressPowderMachine.ResultObj.ElectricPrice;

            quotationUnit.CarryChangeRoll = dieCuttingMachine.ResultObj.ChangeRoll;
            quotationUnit.CarryColor = dieCuttingMachine.ResultObj.Color;
            quotationUnit.CarryCompensation = dieCuttingMachine.ResultObj.Compensation;
            quotationUnit.CarryWhiteCarry = dieCuttingMachine.ResultObj.WhiteCarry;
            quotationUnit.CarryRisk = dieCuttingMachine.ResultObj.Risk;
            quotationUnit.CarryTarget = dieCuttingMachine.ResultObj.Target;
            quotationUnit.CarryHourSalary = (float)dieCuttingMachine.ResultObj.HourlySalary;
            quotationUnit.CarryChange = (float)dieCuttingMachine.ResultObj.Change;
            quotationUnit.CarryElectric = (float)dieCuttingMachine.ResultObj.ElectricPrice;

            quotationUnit.DivideChangeRoll = divideMachine.ResultObj.ChangeRoll;
            quotationUnit.DivideColor = divideMachine.ResultObj.Color;
            quotationUnit.DivideCarryCompensation = divideMachine.ResultObj.Compensation;
            quotationUnit.DivideWhiteCarry = divideMachine.ResultObj.WhiteCarry;
            quotationUnit.DivideRisk = divideMachine.ResultObj.Risk;
            quotationUnit.DivideTarget = divideMachine.ResultObj.Target;
            quotationUnit.DivideHourSalary = (float)divideMachine.ResultObj.HourlySalary;
            quotationUnit.DivideChange = (float)divideMachine.ResultObj.Change;
            quotationUnit.DivideElectric = (float)divideMachine.ResultObj.ElectricPrice;


            quotationUnit.TotalMetter = quotationUnit.MetterPerOrder + quotationUnit.Loss;//Tổng m\đơn + hao hụt
            quotationUnit.TotalSquareMetter = quotationUnit.TotalMetter * quotationUnit.PaperSize / 1000;//Tổng m * khổ giấy
            quotationUnit.PrintSquareMetter = quotationUnit.TotalSquareMetter * model.AreaPrint / 100; //Tổng m2 * Diện tích in
            quotationUnit.SFilm = ((quotationUnit.StampStep + 10 * 2) / 10) * (quotationUnit.PaperSize / 10) * (model.NumberOfColor * model.NumberOfCode);//(Bước tem+10*2)/10 * (Khổ giấy/10) * (số màu * số mã)
            quotationUnit.NumberRoll = quotationUnit.MetterPerOrder / 1000 > 1 ? (quotationUnit.MetterPerOrder / 1000) : 0; //Met\ đơn /1000 và làm tròn nếu lớn hơn 1
            quotationUnit.Loss = printMachine.ResultObj.Color + printMachine.ResultObj.Compensation + printMachine.ResultObj.ChangeSpec + (printMachine.ResultObj.Risk / 100) * quotationUnit.MetterPerOrder + printMachine.ResultObj.ChangeRoll * quotationUnit.NumberRoll; //Màu + Bù bế + Thay mã + Rủi ro * M\đơn + Thay cuộn * Số cuộn 
            quotationUnit.Core_ = model.Unit == "Cuộn" ? (model.Width * model.NumberStampHorizontal + model.Border * 2) * model.Quantity / 1000 : 0;// Nếu đơn vị là cuộn thì = (KT ngang * Tem ngang + Biên * 2) * số luượng / 1000

            quotationUnit.PrintHours = printMachine.ResultObj.Target == 0 ? 0 : (quotationUnit.TotalMetter / printMachine.ResultObj.Target); //Tổng m * target in
            quotationUnit.PressedPowderHours = pressPowderMachine.ResultObj.Target == 0 ? 0 : (quotationUnit.TotalMetter / pressPowderMachine.ResultObj.Target); //Tổng m * target ép nhũ
            quotationUnit.DieCuttingHours = dieCuttingMachine.ResultObj.Target == 0 ? 0 : (quotationUnit.TotalMetter / dieCuttingMachine.ResultObj.Target); //Tổng m * target bế
            quotationUnit.DivideHours = divideMachine.ResultObj.Target == 0 ? 0 : (quotationUnit.TotalMetter / divideMachine.ResultObj.Target); //Tổng m * target chia

            quotationUnit.SLamination = model.Lamination == 0 ? 0 : quotationUnit.TotalMetter * quotationUnit.PaperSize / 1000; //Nếu có cán màng thì = tổng mét * khổ giấy
            quotationUnit.SrinkFilm = model.Unit == "Xấp" || model.Unit == "Cuộn" ? (((quotationUnit.PaperSize / model.SplitLine) + 30 * 2) / 1000) * model.Quantity : 0;//Nếu đơn vị là cuộn hoặc xấp thì = (((khổ giấy / xẻ line) + 30*2) /100) * số lượng

            quotationUnit.ManagermentFeePrint = (float)configFee.ResultObj.ManagerFee;
            quotationUnit.ManagermentFeeCarry = (float)configFee.ResultObj.ManagerFee;
            quotationUnit.ManagermentFeeDivide = (float)configFee.ResultObj.ManagerFee;
            quotationUnit.ManagermentFeeTotal = quotationUnit.ManagermentFeePrint * quotationUnit.PrintHours + quotationUnit.ManagermentFeeCarry * quotationUnit.DieCuttingHours + quotationUnit.ManagermentFeeDivide * quotationUnit.DivideHours;//(Phí quản lý công đoạn in * giờ in) + (Phí quản lý công đoạn bế * giờ bế) + (Phí quản lý công đoạn chia * giờ chia)
            quotationUnit.WorkshopRentalFee = (float)configFee.ResultObj.WorkshopRentalFeePerMachine * (quotationUnit.PrintHours + quotationUnit.DivideHours + quotationUnit.DieCuttingHours);//Phí thuê mặt bằng cố định từng máy * (giờ in + giờ bế + giờ chia)

            quotationUnit.DepriciationPrintFee = (float)configFee.ResultObj.DepreciationFee;
            quotationUnit.DepriciationCarryFee = (float)configFee.ResultObj.DepreciationFee;
            quotationUnit.DepriciationDivideFee = (float)configFee.ResultObj.DepreciationFee;
            quotationUnit.DepriciationTotalFee = quotationUnit.DepriciationPrintFee * quotationUnit.PrintHours + quotationUnit.DepriciationCarryFee * quotationUnit.DieCuttingHours + quotationUnit.DepriciationDivideFee * quotationUnit.DivideHours; //(Phí hao mòn công đoạn in * giờ in) + (Phí hao mòn công đoạn bế * giờ bế) + (Phí hao mòn công đoạn chia * giờ chia)

            quotationUnit.ElectricFee = (float)configFee.ResultObj.ElectricFee * (quotationUnit.PrintHours + quotationUnit.DieCuttingHours + quotationUnit.DivideHours); //Tiền điện chung * (giờ in + giờ bế + giờ chia)

            quotationUnit.KnifeUnitFee = model.KnifeOtherFee > 0 ? ((((((((model.Height + (model.Gap * model.RowStampHaveGap)) + model.Midle)))) + (model.Width + model.Border * 2)) * model.NumberStampHorizontal * model.NumberRowStamp) * 2 / 1000 * 380000 + (((model.Width + model.Border * 2)) * model.NumberStampHorizontal * model.NumberRowStamp) * model.NumberRowStamp / 1000 * 350000) * model.KnifeNumber : 0;
            // ((((Cao + (Gap * hàng tem có gap)) + giữa) + (Ngang + biên * 2))* Tem ngang* hàng tem)*2 /1000*380000+ (((ngang + biên*2)) * tem ngang * hàng tem ) * hàng tem/1000*350000) *  số lượng dao

            quotationUnit.Spec = model.Width + " x " + model.Height + " x " + model.NumberStampHorizontal + " x " + model.NumberRowStamp;

            quotationUnit.CD_PrintHour = quotationUnit.PrintHours == 0 ? 0 : quotationUnit.PrintHours / 8; //CĐ in (Số h/ 8)
            quotationUnit.CD_PrintSalary = quotationUnit.PrintHours == 0 ? 0 : quotationUnit.PrintHours * quotationUnit.PrintHourSalary; //CĐ in (Số h * tiền lương theo giờ)
            quotationUnit.CD_PrintElectric = 0; //75000 * số h 

            quotationUnit.CD_PressedPowderHour = quotationUnit.PressedPowderHours == 0 ? 0 : quotationUnit.PressedPowderHours / 8; //CĐ ép nhũ (Số h/ 8)
            quotationUnit.CD_PressedPowderSalary = quotationUnit.PressedPowderHours == 0 ? 0 : quotationUnit.PressedPowderHours * quotationUnit.PressedPowderHourSalary; //CĐ ép nhũ (Số h * tiền lương theo giờ)
            quotationUnit.CD_PressedPowderElectric = 0; //75000 * số h 

            quotationUnit.CD_CarryHour = quotationUnit.DieCuttingHours == 0 ? 0 : quotationUnit.DieCuttingHours / 8; //CĐ bế (Số h/ 8)
            quotationUnit.CD_CarrySalary = quotationUnit.DieCuttingHours == 0 ? 0 : quotationUnit.DieCuttingHours * quotationUnit.CarryHourSalary; //CĐ bế (Số h * tiền lương theo giờ)
            quotationUnit.CD_CarryElectric = 0; //75000 * số h 

            quotationUnit.CD_DivideHour = quotationUnit.DivideHours == 0 ? 0 : quotationUnit.DivideHours / 8; //CĐ chia (Số h/ 8)
            quotationUnit.CD_DivideSalary = quotationUnit.DivideHours == 0 ? 0 : quotationUnit.DivideHours * quotationUnit.DivideHourSalary; //CĐ chia (Số h * tiền lương theo giờ)
            quotationUnit.CD_DivideElectric = 0; //75000 * số h 

            quotationUnit.CD_TotalHour = quotationUnit.CD_PrintHour + quotationUnit.CD_PressedPowderHour + quotationUnit.CD_CarryHour + quotationUnit.CD_DivideHour;
            quotationUnit.CD_TotalSalary = quotationUnit.CD_PrintSalary + quotationUnit.CD_PressedPowderSalary + quotationUnit.CD_CarrySalary + quotationUnit.CD_DivideSalary;
            quotationUnit.CD_TotalElectric = quotationUnit.CD_PrintElectric + quotationUnit.CD_PressedPowderElectric + quotationUnit.CD_CarryElectric + quotationUnit.CD_DivideElectric;

            //Định mức NVL
            quotationUnit.DecalPrice = (float)paperInfo.ResultObj.Price;
            quotationUnit.DecalTotalPrice = quotationUnit.TotalSquareMetter * quotationUnit.DecalPrice;//Đơn giá * tổng M2

            quotationUnit.MetterSquareLamination = ((quotationUnit.PaperSize - 2) / 1000) * quotationUnit.TotalMetter;//((Size giấy -2)/1000) * Tổng m
            quotationUnit.LaminationUnitPrice = 0;//Giá giấy hoặc giá vật tư
            quotationUnit.LaminationTotalPrice = quotationUnit.MetterSquareLamination * quotationUnit.LaminationUnitPrice;//M2 * đơn giá

            quotationUnit.CoreUnitPrice = 0; //Giá lõi
            quotationUnit.CorePrice = quotationUnit.Core_ * quotationUnit.CoreUnitPrice;//Số lượng * đơn giá

            quotationUnit.ColorPrintKG = quotationUnit.PrintSquareMetter / 350; //M2 in / 350
            quotationUnit.ColorUnitPrice = 1;//Giá vật tư theo mã code
            quotationUnit.ColorPrice = quotationUnit.ColorPrintKG * quotationUnit.ColorUnitPrice;//Số kg * đơn giá

            quotationUnit.FilmUnitPrice = 30;
            quotationUnit.FilmPrice = quotationUnit.SFilm * quotationUnit.FilmUnitPrice;//Đơn giá * S fiml M2

            quotationUnit.Print_SFilm = quotationUnit.SFilm;
            quotationUnit.Print_UnitPrice = 1;//Đơn giá vật tư s film;
            quotationUnit.Print_Price = quotationUnit.Print_UnitPrice * quotationUnit.Print_SFilm;//Đơn giá vật tư * S film;

            quotationUnit.BoxUnitPrice = 1;//Đơn giá vật tư thùng


            quotationUnit.SrinkFilmUnitPrice = 470;
            quotationUnit.SrinkFilmPrice = quotationUnit.SrinkFilmUnitPrice * quotationUnit.SrinkFilm;//Đơn giá * màn co

            quotationUnit.Total = quotationUnit.CD_TotalSalary + quotationUnit.ManagermentFeeTotal + quotationUnit.ElectricFee + quotationUnit.DepriciationTotalFee + quotationUnit.WorkshopRentalFee + quotationUnit.DecalTotalPrice + quotationUnit.LaminationTotalPrice + quotationUnit.CorePrice + quotationUnit.ColorPrice + quotationUnit.FilmPrice + quotationUnit.Print_Price + quotationUnit.BoxPrice + quotationUnit.SrinkFilmPrice + quotationUnit.KnifeUnitFee;//Tổng chi phí = Công VH máy + Công QL + Điện máy + Khấu hao + Thuê xưởng + Chi phí Decal + chi phí màng/phủ UV + chi phí lõi + chi phí màu + chi phí Film + chi phí bản in + chi phí thùng + chi phí màng co + chi phí dao bé

            quotationUnit.SaleDiscount = model.SaleDiscount;
            quotationUnit.CustomerDiscount = model.CustomerDiscount;
            quotationUnit.ProfitPercent = model.ProfitPercent;
            quotationUnit.FinalyTotal = (double)(quotationUnit.Total + quotationUnit.Total * (model.SaleDiscount + model.CustomerDiscount + model.ProfitPercent) / 100);

            quotationUnit.Box_t = 0.14f;
            quotationUnit.Box_L = model.MetterPerRoll <= 0 ? (model.StampPerRoll * quotationUnit.StampStep) / quotationUnit.StampPerStep : model.MetterPerRoll * 1000; //nếu tem/ cuộn >0 thì 
            quotationUnit.Box_d = model.Core + 6;//Lõi + 6
            quotationUnit.Box_DD = (quotationUnit.Box_L * quotationUnit.Box_t) / 0.75f + (quotationUnit.Box_d * quotationUnit.Box_d);
            quotationUnit.Roll_width = quotationUnit.Box_d;
            quotationUnit.Roll_height = (model.Width * model.NumberStampHorizontal + model.Border * 2) + (model.NumberStampHorizontal - 1) * model.Midle;//(ngang * số tem ngang + biên * 2) + (số tem ngang - 1) * giữa
            quotationUnit.Box_width = model.Box_width;//Nhập liệu
            quotationUnit.Box_long = model.Box_long;//Nhập liệu
            quotationUnit.Box_height = model.Box_height;//Nhập liệu
            quotationUnit.Width_1 = quotationUnit.Box_width / quotationUnit.Roll_width;//KT cuộn tem dài/KT thùng dài
            quotationUnit.Long_1 = quotationUnit.Box_long / quotationUnit.Roll_width; //KT cuộn tem rộng/KT thùng dài
            quotationUnit.Height_1 = quotationUnit.Box_height / quotationUnit.Roll_height; //KT cuộn tem cao/KT thùng cao
            quotationUnit.RollPerBox = quotationUnit.Width_1 + quotationUnit.Long_1 + quotationUnit.Height_1;//dài 1 + rộng 1 + cao 1
            quotationUnit.CartonPerOrder = model.Quantity / quotationUnit.RollPerBox;//Số lượng / Cuộn\ Thùng

            quotationUnit.BoxPrice = quotationUnit.BoxUnitPrice * quotationUnit.CartonPerOrder; // Đơn giá * số thùng

            var request = new UnitPriceViewModel()
            {
                BoxPrice = quotationUnit.BoxPrice,
                CD_TotalSalary = quotationUnit.CD_TotalSalary,
                Characteristic = model.Characteristic,
                ColorPrice = quotationUnit.ColorPrice,
                CorePrice = quotationUnit.CorePrice,
                CustomerDiscount = quotationUnit.CustomerDiscount,
                DecalTotalPrice = quotationUnit.DecalTotalPrice,
                DepriciationTotalFee = quotationUnit.DepriciationTotalFee,
                ElectricFee = quotationUnit.ElectricFee,
                FilmPrice = quotationUnit.FilmPrice,
                FinalyTotal = quotationUnit.FinalyTotal,
                KnifeUnitFee = quotationUnit.KnifeUnitFee,
                LaminationTotalPrice = quotationUnit.LaminationTotalPrice,
                ManagermentFeeTotal = quotationUnit.ManagermentFeeTotal,
                Print_Price = quotationUnit.Print_Price,
                ProfitPercent = quotationUnit.ProfitPercent,
                Quantity = quotationUnit.Quantity,
                SaleDiscount = quotationUnit.SaleDiscount,
                Spec = quotationUnit.Spec,
                SrinkFilmPrice = quotationUnit.SrinkFilmPrice,
                Total = quotationUnit.Total,
                Unit = quotationUnit.Unit,
                WorkshopRentalFee = quotationUnit.WorkshopRentalFee,
            };

            await _unitPriceApiClient.Create(request);

            return View("ViewQuotationUnit", quotationUnit);
        }
    }
}
