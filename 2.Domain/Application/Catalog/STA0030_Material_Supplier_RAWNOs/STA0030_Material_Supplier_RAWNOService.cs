using Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0030_Material_Supplier_RAWNOs;
using ViewModels.Common;

namespace Application.Catalog.STA0030_Material_Supplier_RAWNOs
{
    public class STA0030_Material_Supplier_RAWNOService : ISTA0030_Material_Supplier_RAWNOService
    {
        private readonly DatabaseContext _context;
        public STA0030_Material_Supplier_RAWNOService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<List<STA0030_Material_Supplier_RAWNOViewModel>>> GetListByLotNo(string lotNo)
        {
            try
            {


                var query = _context.STA0030_Material_Supplier_RAWNOs.Where(x=>x.OutStockDate==null).Select(x => new STA0030_Material_Supplier_RAWNOViewModel()
                {
                    //Created = x.Created,
                    //Deleted = x.Deleted,
                    ExpiredDate = x.ExpiredDate.ToString(),
                    ExportDate = x.OutStockDate.ToString(),
                    ImportDate = x.InStockDate.ToString(),
                    //IsDeleted = x.IsDeleted,
                    LOTNO = x.LotNo,
                    MATCD = x.MatCD,
                    MaterialName = x.MaterialName,
                    //Modified = x.Modified,
                    Remark = x.Remark,
                    MaterialCode = x.MaterialCode,
                    Price = x.Price,
                    ProductDate = x.ProductDate.ToString(),
                    ID = x.ID,
                    RAWNO = x.RawNo,
                    Size = x.Size,
                    Supplier = x.Supplier,
                    Sup_LOT = x.SupLOT,
                    TestDate = x.TestDate.ToString(),
                    TestReult = x.TestResult,
                    Unit = x.Unit,
                    UNITQTY = x.UnitQuantity,
                    UseDate = x.UseDate.ToString(),

                });
                if (!string.IsNullOrEmpty(lotNo))
                {
                    query = query.Where(x => x.LOTNO == lotNo);
                }
                var data = await query.ToListAsync();
                return new ApiSuccessResult<List<STA0030_Material_Supplier_RAWNOViewModel>>(data);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ApiResult<List<STA0030_Material_Supplier_RAWNOViewModel>>> GetAll(string matCD)
        {
            try
            {

           
            var query = _context.STA0030_Material_Supplier_RAWNOs.Select(x => new STA0030_Material_Supplier_RAWNOViewModel()
            {
                //Created = x.Created,
                //Deleted = x.Deleted,
                ExpiredDate = x.ExpiredDate.ToString(),
                ExportDate = x.OutStockDate.ToString(),
                ImportDate = x.InStockDate.ToString(),
                //IsDeleted = x.IsDeleted,
                LOTNO = x.LotNo,
                MATCD = x.MatCD,
                MaterialName = x.MaterialName,
                //Modified = x.Modified,
                Remark = x.Remark,
                MaterialCode = x.MaterialCode,
                Price = x.Price,
                ProductDate = x.ProductDate.ToString(),
                ID = x.ID,
                RAWNO = x.RawNo,
                Size = x.Size,
                Supplier = x.Supplier,
                Sup_LOT = x.SupLOT,
                TestDate = x.TestDate.ToString(),
                TestReult = x.TestResult,
                Unit = x.Unit,
                UNITQTY = x.UnitQuantity,
                UseDate = x.UseDate.ToString(),

            });
            if (!string.IsNullOrEmpty(matCD))
            {
                query = query.Where(x => x.MATCD.Contains(matCD));
            }
                var data = await query.ToListAsync();
            return new ApiSuccessResult<List<STA0030_Material_Supplier_RAWNOViewModel>>(data);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ApiResult<STA0030_Material_Supplier_RAWNOViewModel>> GetById(int id)
        {
            var data = await _context.STA0030_Material_Supplier_RAWNOs.Select(x => new STA0030_Material_Supplier_RAWNOViewModel()
            {
                //Created = x.Created,
                //Deleted = x.Deleted,
                ExpiredDate = x.ExpiredDate.ToString(),
                ExportDate = x.OutStockDate.ToString(),
                ImportDate = x.InStockDate.ToString(),
                //IsDeleted = x.IsDeleted,
                LOTNO = x.LotNo,
                MATCD = x.MatCD,
                MaterialName = x.MaterialName,
                //Modified = x.Modified,
                Remark = x.Remark,
                MaterialCode = x.MaterialCode,
                Price = x.Price,
                ProductDate = x.ProductDate.ToString(),
                ID = x.ID,
                RAWNO = x.RawNo,
                Size = x.Size,
                Supplier = x.Supplier,
                Sup_LOT = x.SupLOT,
                TestDate = x.TestDate.ToString(),
                TestReult = x.TestResult,
                Unit = x.Unit,
                UNITQTY = x.UnitQuantity,
                UseDate = x.UseDate.ToString(),
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<STA0030_Material_Supplier_RAWNOViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<STA0030_Material_Supplier_RAWNOViewModel>(data);
        }
    }
}
