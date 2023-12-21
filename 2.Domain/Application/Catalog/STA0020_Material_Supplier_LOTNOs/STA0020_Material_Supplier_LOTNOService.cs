using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0020_Material_Supplier_LOTNOs;
using ViewModels.Common;

namespace Application.Catalog.STA0020_Material_Supplier_LOTNOs
{
    public class STA0020_Material_Supplier_LOTNOService : ISTA0020_Material_Supplier_LOTNOService
    {
        private readonly DatabaseContext _context;
        public STA0020_Material_Supplier_LOTNOService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<int>> Create(STA0020_Material_Supplier_LOTNOCreateRequest request)
        {
            try
            {
                string lotNO = GetLOTNO(request.MatCD);
                var model = new STA0020_Material_Supplier_LOTNO()
                {
                    UnitQuantity = request.UnitQuantity,
                    Unit = request.Unit,
                    Price = request.Price,
                    Note = request.Note,
                    ExpiredDate = request.ExpiredDate,
                    ImportDate = request.ImportDate,
                    //MaterialName = request.MaterialName,
                    Quantity = request.Quantity,
                    StandardUnit = request.StandardUnit,
                    MaterialCode = request.MaterialCode,
                    MatCD = request.MatCD,
                    ProductDate = request.ProductDate,
                    Size = request.Size,
                    Supplier = request.Supplier,
                    TestDate = request.TestDate,
                    TestResult = request.TestResult.Substring(0, 1),
                    SupLOT = request.SupLOT,
                    LotNo = lotNO,
                    MaterialName = string.Empty,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    IsDeleted = false,
                    Deleted = DateTime.MinValue,
                };
                _context.STA0020_Material_Supplier_LOTNOs.Add(model);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(model.ID);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<STA0020_Material_Supplier_LOTNOViewModel>>> GetAll(string? matCDSearch, string? typeSearch)
        {
            var query = _context.STA0020_Material_Supplier_LOTNOs.Where(x => x.IsDeleted != true).AsQueryable();

            if (!string.IsNullOrEmpty(matCDSearch) && !string.IsNullOrEmpty(typeSearch))
            {
                query = query.Where((x => x.MatCD.Contains(typeSearch) && x.MatCD.Contains(matCDSearch)));
            }

            else if (!string.IsNullOrEmpty(matCDSearch))
            {
                query = query.Where(x => x.MatCD.Contains(matCDSearch));
            }

            else if (!string.IsNullOrEmpty(typeSearch) && typeSearch != "A")
            {
                query = query.Where(x => x.MatCD.Contains(typeSearch));
            }

            var data = await query.Select(x => new STA0020_Material_Supplier_LOTNOViewModel()
            {
                ImportDate = x.ImportDate,
                LotNo = x.LotNo,
                ExpiredDate = x.ExpiredDate,
                MatCD = x.MatCD,
                MaterialCode = x.MaterialCode,
                MaterialName = x.MaterialName,
                ProductDate = x.ProductDate,
                Note = x.Note,
                Price = x.Price,
                Unit = x.Unit,
                UnitQuantity = x.UnitQuantity,
                StandardUnit = x.StandardUnit,
                Quantity = x.Quantity,
                Size = x.Size,
                SupLOT = x.SupLOT,
                Supplier = x.Supplier,
                TestDate = x.TestDate,
                TestResult = x.TestResult,
                ID = x.ID,
            }).ToListAsync();
            return new ApiSuccessResult<List<STA0020_Material_Supplier_LOTNOViewModel>>(data);
        }

        public async Task<ApiResult<STA0020_Material_Supplier_LOTNOViewModel>> GetById(int id)
        {
            var data = await _context.STA0020_Material_Supplier_LOTNOs.Select(x => new STA0020_Material_Supplier_LOTNOViewModel()
            {
                ImportDate = x.ImportDate,
                LotNo = x.LotNo,
                ExpiredDate = x.ExpiredDate,
                MatCD = x.MatCD,
                MaterialCode = x.MaterialCode,
                MaterialName = x.MaterialName,
                ProductDate = x.ProductDate,
                Note = x.Note,
                Price = x.Price,
                Unit = x.Unit,
                UnitQuantity = x.UnitQuantity,
                StandardUnit = x.StandardUnit,
                Quantity = x.Quantity,
                Size = x.Size,
                SupLOT = x.SupLOT,
                Supplier = x.Supplier,
                TestDate = x.TestDate,
                TestResult = x.TestResult,
                ID = x.ID,
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<STA0020_Material_Supplier_LOTNOViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<STA0020_Material_Supplier_LOTNOViewModel>(data);
        }

        public async Task<ApiResult<List<STA0020_Material_InventoryViewModel>>> GetInventory()
        {
            var data = await _context.STA0020_Material_Supplier_LOTNOs
                     //.GroupJoin(_context.STA0030_Material_Supplier_RAWNOs, x => x.LotNo, y => y.LOTNO, (x, y) => new { sta0020 = x, sta0030 = y })
                     //     .SelectMany(
                     //xy => xy.sta0030.DefaultIfEmpty(),
                     //(x, y) => new { sta0020 = x.sta0020, sta0030 = y })
                     .Where(x => x.IsDeleted != true).Select(x => new STA0020_Material_InventoryViewModel()
                     {
                         ImportDate = x.ImportDate,
                         Quantity = x.Quantity,
                         LotNo = x.LotNo,
                         ExpiredDate = x.ExpiredDate,
                         MatCD = x.MatCD,
                         MaterialCode = x.MaterialCode,
                         MaterialName = x.MaterialName,
                         ProductDate = x.ProductDate,
                         Note = x.Note,
                         Price = x.Price,
                         Unit = x.Unit,
                         RemainStandardQuantity = (_context.STA0030_Material_Supplier_RAWNOs.Where(y => y.LotNo == x.LotNo).Sum(x => x.UnitQuantity)),
                         UnitQuantity = x.Quantity,
                         Size = x.Size,
                         SupLOT = x.SupLOT,
                         Supplier = x.Supplier,
                         TestDate = x.TestDate,
                         TestResult = x.TestResult,
                         ID = x.ID,
                         OutStockDate = (_context.STA0030_Material_Supplier_RAWNOs.Where(y => y.LotNo == x.LotNo).Max(x => x.OutStockDate).ToString()),
                         RemainQuantity = (_context.STA0030_Material_Supplier_RAWNOs.Where(y => y.LotNo == x.LotNo).Sum(x => x.RemainQuantity)),
                         InventoryQuantity = (_context.STA0030_Material_Supplier_RAWNOs.Where(y => y.LotNo == x.LotNo && y.OutStockDate == null).Count()),
                     }).ToListAsync();

            //var query = from sta0020 in _context.STA0020_Material_Supplier_LOTNOs
            //            join sta0030 in _context.STA0030_Material_Supplier_RAWNOs on sta0020.LotNo equals sta0030.LOTNO into sta0020M
            //            from sta0020m in sta0020M.DefaultIfEmpty()
            //            group sta0020m by new
            //            {
            //                ID= sta0020m.ID,
            //                MaterialName= sta0020m.MaterialName,
            //                MATCD= sta0020m.MATCD,
            //                MaterialCode=  sta0020m.MaterialCode,
            //                UNITQTY=  sta0020m.UNITQTY,
            //                Unit=  sta0020m.Unit,
            //                PROD_DAT= sta0020m.PROD_DAT,
            //                TEST_RESULT= sta0020m.TEST_RESULT,
            //                TEST_DAT=  sta0020m.TEST_DAT,
            //                IMPORT_DAT=  sta0020m.IMPORT_DAT,
            //                EXPIRED_DAT=   sta0020m.EXPIRED_DAT,
            //                EXPORT_DAT=   sta0020m.EXPORT_DAT,
            //                Supplier=  sta0020m.Supplier,
            //                Price=  sta0020m.Price,
            //                Sup_LOT= sta0020m.Sup_LOT,

            //            } into groupby
            //            select x=> new
            //            {
            //                ID = x.ID,
            //                MaterialName = x.MaterialName,
            //                MATCD = x.MATCD,
            //                MaterialCode = x.MaterialCode,
            //                UNITQTY = x.UNITQTY,
            //                Unit = x.Unit,
            //                PROD_DAT = x.PROD_DAT,
            //                TEST_RESULT = x.TEST_RESULT,
            //                TEST_DAT = x.TEST_DAT,
            //                IMPORT_DAT = x.IMPORT_DAT,
            //                EXPIRED_DAT = x.EXPIRED_DAT,
            //                EXPORT_DAT = x.EXPORT_DAT,
            //                Supplier = x.Supplier,
            //                Price = x.Price,
            //                Sup_LOT = x.Sup_LOT,
            //                Total = x.Sum(y=>y.)
            //            }

            return new ApiSuccessResult<List<STA0020_Material_InventoryViewModel>>(data);
        }

        public string GetLOTNO(string matCD)
        {
            return _context.FunctionResults.FromSqlInterpolated($"select dbo.FN_GET_MAT_LOTNO({matCD}) as ResultString, cast(0 as bit) as ResultBool, 0 as ResultNumber").FirstOrDefault().ResultString;
        }
    }
}
