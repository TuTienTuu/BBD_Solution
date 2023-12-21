using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.PaperType;
using ViewModels.Common;

namespace Application.Catalog.PaperTypes
{
    public class PaperTypeService : IPaperTypeService
    {
        private readonly DatabaseContext _context;
        public PaperTypeService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<int>> Create(PaperTypeCreateRequest request)
        {
            try
            {
                var model = new PaperType()
                {
                    PaperTypeCode = request.PaperTypeCode,
                    PaperTypeName = request.PaperTypeName,
                    //Description = request.GlueDescription,
                    PaperTypeMainID = request.PaperTypeMainID,
                    PaperTypeMainName = request.PaperTypeMainName,
                    PaperTypeMainCode = request.PaperTypeMainCode,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    IsDeleted = false,
                    Deleted = DateTime.MinValue,

                };
                _context.PaperTypes.Add(model);
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
                var data = await _context.PaperTypes.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu: id={id}");
                }
                data.IsDeleted = true;
                data.Deleted = DateTime.Now;

                _context.PaperTypes.Update(data);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(id);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<PaperTypeViewModel>>> GetAll()
        {
            var data = await _context.PaperTypes.Where(x => x.IsDeleted != true).OrderByDescending(x => x.Modified).ThenByDescending(x => x.Created).Select(x => new PaperTypeViewModel()
            {
                PaperTypeCode = x.PaperTypeCode,
                PaperTypeName = x.PaperTypeName,
                PaperTypeMainCode = x.PaperTypeMainCode,
                PaperTypeMainName = x.PaperTypeMainName,
                PaperTypeMainID = x.PaperTypeMainID,
                ID = x.ID,
                // GlueDescription = x.Description,
            }).ToListAsync();
            return new ApiSuccessResult<List<PaperTypeViewModel>>(data);
        }

        public async Task<ApiResult<PaperTypeViewModel>> GetById(int id)
        {
            var data = await _context.PaperTypes.Select(x => new PaperTypeViewModel()
            {
                PaperTypeCode = x.PaperTypeCode,
                PaperTypeName = x.PaperTypeName,
                PaperTypeMainID = x.PaperTypeMainID,
                PaperTypeMainCode = x.PaperTypeMainCode,
                PaperTypeMainName = x.PaperTypeMainName,
                //GlueDescription = x.Description,
                ID = x.ID,
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<PaperTypeViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<PaperTypeViewModel>(data);
        }

        public async Task<ApiResult<List<SelectItem>>> GetSelectList()
        {
            var listPaperType = await _context.PaperTypes.Where(x => x.IsDeleted != true).Select(x => new SelectItem()
            {
                Id = x.ID.ToString(),
                Name = x.PaperTypeName,//x.PaperTypeCode + "-" +
                Selected = false,
            }).ToListAsync();

            listPaperType.Insert(0, new SelectItem() { Id = "0", Name = "Chọn mã hàng", Selected = true });

            return new ApiSuccessResult<List<SelectItem>>(listPaperType);
        }

        public async Task<ApiResult<int>> Update(int id, PaperTypeUpdateRequest request)
        {
            try
            {
                var data = await _context.PaperTypes.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
                }

                data.PaperTypeCode = request.PaperTypeCode;
                data.PaperTypeName = request.PaperTypeName;
                data.PaperTypeMainID = request.PaperTypeMainID;
                data.PaperTypeMainCode = request.PaperTypeMainCode;
                data.PaperTypeMainName = request.PaperTypeMainName;
                data.PaperTypeName = request.PaperTypeName;
                //data.Description = request.Description;
                data.Modified = DateTime.Now;

                _context.PaperTypes.Update(data);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>(id);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

    }
}
