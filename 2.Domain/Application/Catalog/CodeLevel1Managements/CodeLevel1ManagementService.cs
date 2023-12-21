using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.CodeLevel1Managements;
using ViewModels.Common;

namespace Application.Catalog.CodeLevel1Managements
{
    public class CodeLevel1ManagementService : ICodeLevel1ManagementService
    {
         private readonly DatabaseContext _context;
        public CodeLevel1ManagementService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<int>> Create(CodeLevel1ManagementCreateRequest request)
        {
            try
            {
                var model = new CodeLevel1Management()
                {
                   CodeLevel1 = request.CodeLevel1,
                   CodeLevel1Description = request.CodeLevel1Description,
                   CodeLevel1Lenght = request.CodeLevel1Lenght,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    //IsDeleted = false,
                    //Deleted = DateTime.MinValue,
                };
             
                _context.CodeLevel1Managements.Add(model);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(model.ID);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<CodeLevel1ManagementViewModel>>> GetAll()
        {
            var data = await _context.CodeLevel1Managements.Select(x => new CodeLevel1ManagementViewModel()
            {
               
                ID = x.ID,
               CodeLevel1 = x.CodeLevel1,
               CodeLevel1Description  =x.CodeLevel1Description,
               CodeLevel1Lenght = x.CodeLevel1Lenght,
                // GlueDescription = x.Description,
            }).ToListAsync();
            return new ApiSuccessResult<List<CodeLevel1ManagementViewModel>>(data);
        }

        public async Task<ApiResult<CodeLevel1ManagementViewModel>> GetById(int id)
        {
            var data = await _context.CodeLevel1Managements.Select(x => new CodeLevel1ManagementViewModel()
            {
               
                ID = x.ID,
                CodeLevel1 = x.CodeLevel1,
                CodeLevel1Description = x.CodeLevel1Description,
                CodeLevel1Lenght = x.CodeLevel1Lenght,
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<CodeLevel1ManagementViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<CodeLevel1ManagementViewModel>(data);
        }

        public async Task<ApiResult<List<SelectItem>>> GetSelectList()
        {
            var data = await _context.CodeLevel1Managements.Select(x => new SelectItem()
            {
                Id = x.ID.ToString(),
                Name = x.CodeLevel1,// x.GlueCode + "-" +
                Selected = false,
            }).ToListAsync();

            data.Insert(0, new SelectItem() { Id = "0", Name = "Chọn code LV 1", Selected = true });

            return new ApiSuccessResult<List<SelectItem>>(data);
        }

        public async Task<ApiResult<int>> Update(int id, CodeLevel1ManagementUpdateRequest request)
        {
            try
            {
                var data = await _context.CodeLevel1Managements.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
                }

                data.CodeLevel1Lenght = request.CodeLevel1Lenght;
                data.CodeLevel1 = request.CodeLevel1;
                data.CodeLevel1Description = request.CodeLevel1Description;
                data.Modified = DateTime.Now;
               

                _context.CodeLevel1Managements.Update(data);
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
