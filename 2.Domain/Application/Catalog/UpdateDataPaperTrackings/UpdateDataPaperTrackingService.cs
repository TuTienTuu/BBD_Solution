using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.UpdateDataPaperTrackings;
using ViewModels.Common;

namespace Application.Catalog.UpdateDataPaperTrackings
{
    public class UpdateDataPaperTrackingService : IUpdateDataPaperTrackingService
    {
        private readonly DatabaseContext _context;
        public UpdateDataPaperTrackingService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<int>> Create(CreateRequest request)
        {
            try
            {
                var model = new UpdateDataPaperTracking()
                {
                    NewValue = request.NewValue,
                    OldValue = request.OldValue,
                    TableName = request.TableName,
                    UpdateBy = request.UpdateBy,
                    Created = DateTime.Now,
                };
                _context.UpdateDataPaperTrackings.Add(model);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(model.ID);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<ViewModel>>> GetAll()
        {
            var data = await _context.UpdateDataPaperTrackings.Select(x => new ViewModel()
            {
                ID = x.ID,
                UpdateBy = x.UpdateBy,
                TableName = x.TableName,
                OldValue = x.OldValue,
                NewValue = x.NewValue,
                Created = x.Created,
                // GlueDescription = x.Description,
            }).OrderByDescending(x => x.Created).ToListAsync();
            return new ApiSuccessResult<List<ViewModel>>(data);
        }

        public async Task<ApiResult<ViewModel>> GetById(int id)
        {
            var data = await _context.UpdateDataPaperTrackings.Select(x => new ViewModel()
            {
              
                ID = x.ID,
               NewValue = x.NewValue,
               OldValue = x.OldValue,
               TableName = x.TableName, 
               UpdateBy= x.UpdateBy,
               Created = x.Created

            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<ViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<ViewModel>(data);
        }
    }
}
