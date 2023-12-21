using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Papers;
using ViewModels.Common;

namespace Application.Catalog.Papers
{
    public class PaperService : IPaperService
    {
        private readonly DatabaseContext _context;
        public PaperService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<int>> Create(PaperCreateRequest request)
        {
            try
            {
                var model = new Paper()
                {
                    Supplier = request.Supplier,
                    Characteristic = request.Characteristic,
                    Core = request.Core,
                    GlueID = request.GlueID,
                    GlueName = request.GlueName,
                    PaperName = request.PaperName,
                    PaperSize = request.PaperSize,
                    PaperTypeMainID = request.PaperTypeMainID,
                    PaperTypeMainName = request.PaperTypeMainName,
                    Price = request.Price,
                    Purpose = request.Purpose,
                    QuantitativePaper = request.QuantitativePaper,
                    SoleBaseThick = request.SoleBaseThick,
                    SoleID = request.SoleID,
                    SoleName = request.SoleName,
                    SoleThick = request.SoleThick,
                    SurfaceThick = request.SurfaceThick,
                    TotalThick = request.SoleThick + request.SurfaceThick + request.SoleBaseThick,
                    Unit = request.Unit,
                    PaperTypeCode = request.PaperTypeCode,
                    PaperTypeName = request.PaperTypeName,
                    PaperTypeID = request.PaperTypeID,
                    PaperTypeMainCode = request.PaperTypeMainCode,
                    Note = request.Note,
                    //Description = request.GlueDescription,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    IsDeleted = false,
                    Deleted = DateTime.MinValue,
                    BCode = request.BCode,
                };
                _context.Papers.Add(model);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(model.ID);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<int>> Delete(int id)
        {
            try
            {
                var data = await _context.Papers.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu: id={id}");
                }
                data.IsDeleted = true;
                data.Deleted = DateTime.Now;

                _context.Papers.Update(data);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(id);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<PaperViewModel>>> GetAll( int paperThick,int paperType, int paperTypeMain, int sole)
        {
            var query =  _context.Papers.Where(x => x.IsDeleted != true).AsQueryable();

            if (paperThick > 0)
            {
                query = query.Where(x => x.SurfaceThick == paperThick);
            }

            if (paperType > 0)
            {
                query = query.Where(x => x.PaperTypeID == paperType);
            }

            if (paperTypeMain > 0)
            {
                query = query.Where(x => x.PaperTypeMainID == paperTypeMain);
            }

            if (sole > 0)
            {
                query = query.Where(x => x.SoleID == sole);
            }
                
           var data = await    query.OrderByDescending(x=>x.Modified).ThenByDescending(x=>x.Created).Select(x => new PaperViewModel()
            {
                PaperTypeID = x.PaperTypeID,
                PaperTypeCode = x.PaperTypeCode,
                PaperTypeName = x.PaperTypeName,
                ID = x.ID,
                PaperTypeMainCode = x.PaperTypeMainCode,
                 PaperTypeMainName = x.PaperTypeMainName,
                QuantitativePaper = x.QuantitativePaper,
                Characteristic = x.Characteristic,
                Unit = x.Unit,
                TotalThick = x.TotalThick,
                SurfaceThick = x.SurfaceThick,
                SoleThick = x.SoleThick,
                SoleName = x.SoleName,
                Supplier = x.Supplier,
                Core = x.Core,
                GlueName = x.GlueName,
                GlueID = x.GlueID,
                PaperName = x.PaperName,
                PaperSize = x.PaperSize,
                PaperTypeMainID = x.PaperTypeMainID,
                Price = x.Price,
                Purpose = x.Purpose,
                SoleBaseThick = x.SoleBaseThick,
                Note = x.Note,  
                SoleID = x.SoleID,
                BCode = x.BCode,
                // GlueDescription = x.Description,
            }).ToListAsync();
            return new ApiSuccessResult<List<PaperViewModel>>(data);
        }

        public async Task<ApiResult<PaperViewModel>> GetById(int id)
        {
            var data = await _context.Papers.Select(x => new PaperViewModel()
            {
                PaperTypeID = x.PaperTypeID,
                PaperTypeCode = x.PaperTypeCode,
                PaperTypeName = x.PaperTypeName,
                ID = x.ID,
                PaperTypeMainCode = x.PaperTypeMainCode,
                PaperTypeMainName = x.PaperTypeMainName,
                QuantitativePaper = x.QuantitativePaper,
                Characteristic = x.Characteristic,
                Unit = x.Unit,
                TotalThick = x.TotalThick,
                SurfaceThick = x.SurfaceThick,
                SoleThick = x.SoleThick,
                SoleName = x.SoleName,
                Supplier = x.Supplier,
                Core = x.Core,
                GlueName = x.GlueName,
                GlueID = x.GlueID,
                PaperName = x.PaperName,
                PaperSize = x.PaperSize,
                PaperTypeMainID = x.PaperTypeMainID,
                Price = x.Price,
                Purpose = x.Purpose,
                SoleBaseThick = x.SoleBaseThick,
               
                Note = x.Note,
                SoleID = x.SoleID,
                //PaperTypeMainName = x.PaperTypeMainName,
                BCode = x.BCode,
                //GlueDescription = x.Description,
              
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<PaperViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<PaperViewModel>(data);
        }

        public async Task<ApiResult<PaperPriceModel>> GetPriceById(int id)
        {
            var data = await _context.Papers.Select(x => new PaperPriceModel()
            {
              
                ID = x.ID,
               NewPrice = 0,
               OldPrice = x.Price,

                Note = x.Note,
                //PaperTypeMainName = x.PaperTypeMainName,

            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<PaperPriceModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<PaperPriceModel>(data);
        }

        public async Task<ApiResult<List<SelectItem>>> GetSelectList()
        {
            var query = _context.Papers.Where(x => x.IsDeleted != true).AsQueryable();

          

            var data = await query.Select(x => new SelectItem()
            {
                Id = x.ID.ToString(),
                Name = x.PaperName,// x.GlueCode + "-" +
                Selected = false,
            }).ToListAsync();

            data.Insert(0, new SelectItem() { Id = "0", Name = "Chọn giấy", Selected = true });

            return new ApiSuccessResult<List<SelectItem>>(data);
        }

        public async Task<ApiResult<int>> Update(int id, PaperUpdateRequest request)
        {
            try
            {
                var data = await _context.Papers.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
                }

                data.Unit = request.Unit;
                data.Core = request.Core;
                data.Characteristic = request.Characteristic;
                data.GlueID = request.GlueID;
                data.GlueName = request.GlueName;
                data.PaperName = request.PaperName;
                data.PaperSize = request.PaperSize;
                data.PaperTypeCode = request.PaperTypeCode;
                data.PaperTypeID = request.PaperTypeID;
                data.PaperTypeMainCode = request.PaperTypeMainCode;
                data.PaperTypeMainName = request.PaperTypeMainName;
                data.PaperTypeMainID = request.PaperTypeMainID;
                data.PaperTypeName = request.PaperTypeName;
                data.Purpose = request.Purpose;
                data.QuantitativePaper = request.QuantitativePaper;
                data.SoleBaseThick = request.SoleBaseThick;
                data.SoleName = request.SoleName;
                data.SurfaceThick = request.SurfaceThick;
                data.SoleThick = request.SoleThick;
                data.SoleID = request.SoleID;
                data.Supplier = request.Supplier;
                data.TotalThick = request.TotalThick;
                data.Note = request.Note;
                //data.Description = request.Description;
                data.Modified = DateTime.Now;
                data.BCode = data.BCode;

                _context.Papers.Update(data);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>(id);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<decimal>> UpdatePrice(int id, PaperPriceModel request)
        {
            try
            {
                var data = await _context.Papers.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<decimal>($"Không tìm thấy dữ liệu. Id={id}");
                }
                decimal oldPrice = data.Price;
                data.Price = request.NewPrice;
                //data.Descript ion = request.Description;
                data.Note = request.Note;
                data.Purpose = request.Note;
                data.Modified = DateTime.Now;

                _context.Papers.Update(data);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<decimal>(oldPrice);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<decimal>(ex.Message);
            }
        }
    }
}
