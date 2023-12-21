using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0010_Material_Masters;
using ViewModels.Common;

namespace Application.Catalog.STA0010_Material_Masters
{
    public class STA0010_Material_MasterService : ISTA0010_Material_MasterService
    {
        private readonly DatabaseContext _context;
        public STA0010_Material_MasterService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> CheckExistMaterial(string materialCode, string groupCD)
        {
            var data = await _context.STA0010_Material_Masters.FirstOrDefaultAsync(x =>

             x.MaterialCode == materialCode && x.MATGROUPCD == groupCD
         );

            if (data != null)
            {
                return new ApiSuccessResult<int>(data.ID);
            }
            return new ApiSuccessResult<int>(0);
        }

        public async Task<ApiResult<int>> Create(STA0010_Material_MasterCreateRequest request)
        {
            try
            {
                string matcd = GetMATCD(request.MATGROUPCD);
                var model = new STA0010_Material_Master()
                {
                    UnitQty = request.UnitQty,
                    Unit = request.Unit,
                    Price = request.Price,
                    Note = request.Note,
                    MATGROUPCD = request.MATGROUPCD,
                    MaterialName = request.MaterialName,
                    MaterialCode = request.MaterialCode,
                    MATCD = matcd,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    IsDeleted = false,
                    Deleted = DateTime.MinValue,
                };
                _context.STA0010_Material_Masters.Add(model);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(model.ID);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<STA0010_Material_MasterViewModel>>> GetAll()
        {
            var data = await _context.STA0010_Material_Masters.Where(x => x.IsDeleted != true).Select(x => new STA0010_Material_MasterViewModel()
            {
                MATCD = x.MATCD,
                MaterialCode = x.MaterialCode,
                MaterialName = x.MaterialName,
                MATGROUPCD = x.MATGROUPCD,
                Note = x.Note,
                Price = x.Price,
                Unit = x.Unit,
                UnitQty = x.UnitQty,
                Id = x.ID,

            }).ToListAsync();
            return new ApiSuccessResult<List<STA0010_Material_MasterViewModel>>(data);
        }

        public async Task<ApiResult<STA0010_Material_MasterViewModel>> GetById(int id)
        {
            var data = await _context.STA0010_Material_Masters.Select(x => new STA0010_Material_MasterViewModel()
            {
                MATCD = x.MATCD,
                MaterialCode = x.MaterialCode,
                MaterialName = x.MaterialName,
                MATGROUPCD = x.MATGROUPCD,
                Note = x.Note,
                Price = x.Price,
                Unit = x.Unit,
                UnitQty = x.UnitQty,
                Id = x.ID,
            }).FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new ApiErrorResult<STA0010_Material_MasterViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<STA0010_Material_MasterViewModel>(data);
        }

        public string GetMATCD(string groupCode)
        {
            return _context.FunctionResults.FromSqlInterpolated($"select dbo.FN_GET_MATCD({groupCode}) as ResultString, cast(0 as bit) as ResultBool, 0 as ResultNumber").FirstOrDefault().ResultString;

        }

        public async Task<ApiResult<List<SelectItem>>> GetSelectList(string? matCDSearch)
        {
            var query =  _context.STA0010_Material_Masters.Where(x => x.IsDeleted != true).AsQueryable();

            if (!string.IsNullOrEmpty(matCDSearch))
            {
                query = query.Where(x => x.MATCD.Contains(matCDSearch));
            }

             var data = await query.Select(x => new SelectItem()
            {
                Id = x.ID.ToString(),
                Name = x.MATCD,// x.GlueCode + "-" +
                Selected = false,
            }).ToListAsync();

            data.Insert(0, new SelectItem() { Id = "0", Name = "Chọn vật tư", Selected = true });

            return new ApiSuccessResult<List<SelectItem>>(data);
        }

        public async Task<ApiResult<int>> Update(int id, STA0010_Material_MasterUpdateRequest request)
        {
            var data = await _context.STA0010_Material_Masters.FirstOrDefaultAsync(x => x.ID == id);

            if (data == null)
            {
                return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
            }

            data.MaterialName = request.MaterialName;
            data.Note = request.Note;
            data.Unit = request.Unit;
            data.UnitQty = request.UnitQty;
            data.Price = request.Price;
            data.Modified = DateTime.Now;

            _context.STA0010_Material_Masters.Update(data);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>(id);
        }
    }
}
