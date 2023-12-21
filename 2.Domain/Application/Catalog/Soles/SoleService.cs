using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Soles;
using ViewModels.Common;

namespace Application.Catalog.Soles
{
    public class SoleService : ISoleService
    {
        private readonly DatabaseContext _context;
        public SoleService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<int>> Create(SoleCreateRequest request)
        {
            try
            {
                var model = new Sole()
                {
                    SoleCode = request.SoleCode,
                    SoleInfomation = request.SoleInfomation,
                    //Description = request.GlueDescription,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    IsDeleted = false,
                    Deleted = DateTime.MinValue,
                };
                _context.Soles.Add(model);
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
                var data = await _context.Soles.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu: id={id}");
                }
                data.IsDeleted = true;
                data.Deleted = DateTime.Now;

                _context.Soles.Update(data);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(id);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<SoleViewModel>>> GetAll()
        {

            var data = await _context.Soles.Where(x => x.IsDeleted != true).Select(x => new SoleViewModel()
            {
                SoleCode = x.SoleCode,
                SoleInfomation = x.SoleInfomation,
                Id = x.ID,
                // GlueDescription = x.Description,
            }).ToListAsync();
            return new ApiSuccessResult<List<SoleViewModel>>(data);

        }

        public async Task<ApiResult<SoleViewModel>> GetById(int id)
        {
            var data = await _context.Soles.Select(x => new SoleViewModel()
            {
                SoleCode = x.SoleCode,
                SoleInfomation = x.SoleInfomation,
                //GlueDescription = x.Description,
                Id = x.ID,
            }).FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new ApiErrorResult<SoleViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<SoleViewModel>(data);
        }

        public async Task<ApiResult<List<SelectItem>>> GetSelectList()
        {
            var data = await _context.Soles.Where(x => x.IsDeleted != true).Select(x => new SelectItem()
            {
                Id = x.ID.ToString(),
                Name = x.SoleInfomation,// x.SoleCode + "-" +
                Selected = false,
            }).ToListAsync();

            data.Insert(0, new SelectItem() { Id = "0", Name = "Chọn đế", Selected = true });

            return new ApiSuccessResult<List<SelectItem>>(data);
        }

        public async Task<ApiResult<int>> Update(int id,SoleUpdateRequest request)
        {
            try
            {
            var data = await _context.Soles.FirstOrDefaultAsync(x => x.ID == id);

            if (data == null)
            {
                return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
            }

            data.SoleCode = request.SoleCode;
            data.SoleInfomation = request.SoleInfomation;
            //data.Description = request.Description;
            data.Modified = DateTime.Now;

            _context.Soles.Update(data);
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
