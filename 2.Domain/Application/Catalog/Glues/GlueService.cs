using Data.EF;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Exceptions;
using ViewModels.Catalog.Glues;
using ViewModels.Common;

namespace Application.Catalog.Glues
{
    public class GlueService : IGlueService
    {
        private readonly DatabaseContext _context;
        public GlueService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<int>> Create(GlueCreateRequest request)
        {
            try
            {
                var model = new Glue()
                {
                    GlueCode = request.GlueCode,
                    GlueName = request.GlueName,
                    Description = request.GlueDescription,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    IsDeleted = false,
                    Deleted = DateTime.MinValue,
                };
                _context.Glues.Add(model);
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
            var data = await _context.Glues.FirstOrDefaultAsync(x => x.ID == id);

            if (data == null)
            {
                return new ApiErrorResult<int>($"Không tìm thấy dữ liệu: id={id}");
            }
            data.IsDeleted = true;
            data.Deleted = DateTime.Now;

            _context.Glues.Update(data);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<int>();

        }

        public async Task<ApiResult<List<GlueViewModel>>> GetAll()
        {
            var data = await _context.Glues.Where(x => x.IsDeleted != true).Select(x => new GlueViewModel()
            {
                GlueName = x.GlueName,
                GlueCode = x.GlueCode,
                Id = x.ID,
                GlueDescription = x.Description,
            }).ToListAsync();
            return new ApiSuccessResult<List<GlueViewModel>>(data);
        }

        public async Task<ApiResult<PagedResult<GlueViewModel>>> GetAllPaging(GetPublicProductPagingRequest request)
        {
            var data = await _context.Glues.Where(x => x.GlueName.Contains(request.keyword))
                .Select(x => new GlueViewModel()
                {
                    Id = x.ID,
                    GlueName = x.GlueName,
                    GlueCode = x.GlueCode,
                }).ToListAsync();
            var result = new PagedResult<GlueViewModel>()
            {
                Items = data,
                TotalRecord = data.Count,
            };
            return new ApiSuccessResult<PagedResult<GlueViewModel>>(result);
        }

        public async Task<ApiResult<GlueViewModel>> GetById(int id)
        {
            var data = await _context.Glues.Select(x => new GlueViewModel()
            {
                GlueCode = x.GlueCode,
                GlueName = x.GlueName,
                GlueDescription = x.Description,
                Id = x.ID,
            }).FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return new ApiErrorResult<GlueViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<GlueViewModel>(data);
        }

        public async Task<ApiResult<List<SelectItem>>> GetSelectList()
        {
            var data = await _context.Glues.Where(x => x.IsDeleted != true).Select(x => new SelectItem()
            {
                Id = x.ID.ToString(),
                Name = x.GlueName,// x.GlueCode + "-" +
                Selected = false,
            }).ToListAsync();

            data.Insert(0, new SelectItem() { Id = "0", Name = "Chọn keo", Selected = true });

            return new ApiSuccessResult<List<SelectItem>>(data);
        }

        public async Task<ApiResult<int>> Update(GlueUpdateRequest request)
        {
            var data = await _context.Glues.FirstOrDefaultAsync(x => x.ID == request.Id);

            if (data == null)
            {
                return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={request.Id}");
            }

            data.GlueName = request.GlueName;
            data.GlueCode = request.GlueCode;
            data.Description = request.GlueDescription;
            data.Modified = DateTime.Now;

            _context.Glues.Update(data);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<int>(request.Id);
        }

        public async Task<ApiResult<bool>> UpdatePrice(int id, decimal newPrice)
        {
            var data = await _context.Glues.FirstOrDefaultAsync(x => x.ID == id);

            if (data == null)
            {
                return new ApiErrorResult<bool>($"Không tìm thấy dữ liệu. Id={id}");
            }

            data.GlueName = newPrice.ToString();
            // data.GlueCode = request.GlueCode;

            _context.Glues.Update(data);
            return new ApiSuccessResult<bool>(await _context.SaveChangesAsync() > 0);
        }
    }
}
