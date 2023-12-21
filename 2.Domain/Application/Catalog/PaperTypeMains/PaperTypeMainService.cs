using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.PaperTypeMains;
using ViewModels.Common;

namespace Application.Catalog.PaperTypeMains
{
    public class PaperTypeMainService : IPaperTypeMainService
    {
        private readonly DatabaseContext _context;
        public PaperTypeMainService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> Create(PaperTypeMainCreateRequest request)
        {
            try
            {
                //var paperType = request.PaperTypeName.Split('-'); 
                var model = new PaperTypeMain()
                {
                    
                    PaperTypeMainCode = request.PaperTypeMainCode,
                    PaperTypeMainName = request.PaperTypeMainName,
                    //Description = request.GlueDescription,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    IsDeleted = false,
                    Deleted = DateTime.MinValue,

                };
                _context.PaperTypeMains.Add(model);
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
                var data = await _context.PaperTypeMains.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu: id={id}");
                }
                data.IsDeleted = true;
                data.Deleted = DateTime.Now;

                _context.PaperTypeMains.Update(data);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(id);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<PaperTypeMainViewModel>>> GetAll()
        {
            var data = await _context.PaperTypeMains.Where(x => x.IsDeleted != true).OrderByDescending(x => x.Modified).ThenByDescending(x=>x.Created).Select(x => new PaperTypeMainViewModel()
            {
              
                ID = x.ID,
                PaperTypeMainCode = x.PaperTypeMainCode,
                PaperTypeMainName = x.PaperTypeMainName,
                // GlueDescription = x.Description,
            }).ToListAsync();
            return new ApiSuccessResult<List<PaperTypeMainViewModel>>(data);
        }

        public async Task<ApiResult<PaperTypeMainViewModel>> GetById(int id)
        {
            var data = await _context.PaperTypeMains.Select(x => new PaperTypeMainViewModel()
            {
               
                PaperTypeMainCode = x.PaperTypeMainCode,
                PaperTypeMainName = x.PaperTypeMainName,
                //GlueDescription = x.Description,
                ID = x.ID,
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<PaperTypeMainViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<PaperTypeMainViewModel>(data);
        }

        public async Task<ApiResult<List<SelectItem>>> GetSelectList()
        {
            var data = await _context.PaperTypeMains.Where(x => x.IsDeleted != true).Select(x => new SelectItem()
            {
                Id = x.ID.ToString(),
                Name =x.PaperTypeMainName,// x.PaperTypeMainCode + "-" + 
                Selected = false,
            }).ToListAsync();

            data.Insert(0, new SelectItem() { Id = "0", Name = "Chọn mã loại", Selected = true });

            return new ApiSuccessResult<List<SelectItem>>(data);
        }

        public async Task<ApiResult<int>> Update(int id, PaperTypeMainUpdateRequest request)
        {
            try
            {
                var data = await _context.PaperTypeMains.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
                }
                data.PaperTypeMainName = request.PaperTypeMainName;
                data.PaperTypeMainCode = request.PaperTypeMainCode;
               // data.PaperTypeCode = request.PaperTypeName.Substring(0, request.PaperTypeName.IndexOf('-'));
               // data.PaperTypeName = request.PaperTypeName.Substring(request.PaperTypeName.IndexOf('-'), request.PaperTypeName.Length);
                //data.Description = request.Description;
                data.Modified = DateTime.Now;

                _context.PaperTypeMains.Update(data);
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
