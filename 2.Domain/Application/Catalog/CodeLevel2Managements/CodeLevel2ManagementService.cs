using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.CodeLevel2Managements;
using ViewModels.Common;

namespace Application.Catalog.CodeLevel2Managements
{
    public class CodeLevel2ManagementService : ICodeLevel2ManagementService
    {
        private readonly DatabaseContext _context;
        public CodeLevel2ManagementService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<int>> Create(CodeLevel2ManagementCreateRequest request)
        {
            try
            {
                var model = new CodeLevel2Management()
                {
                    IDLevel1 = request.IDLevel1,
                    CodeLevel1 = request.CodeLevel1,
                    CodeLevel2 = request.CodeLevel2,
                    CodeLevel2Description = request.CodeLevel2Description,
                    CodeLevel2Lenght = request.CodeLevel2Lenght,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    //IsDeleted = false,
                    //Deleted = DateTime.MinValue,
                };

                _context.CodeLevel2Managements.Add(model);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(model.ID);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<CodeLevel2ManagementViewModel>>> GetAll()
        {
            var data = await _context.CodeLevel2Managements.Select(x => new CodeLevel2ManagementViewModel()
            {

                ID = x.ID,
                IDLevel1 = x.IDLevel1,
                CodeLevel1 = x.CodeLevel1,
                CodeLevel2 = x.CodeLevel2,
                CodeLevel2Description = x.CodeLevel2Description,
                CodeLevel2Lenght = x.CodeLevel2Lenght,
                // GlueDescription = x.Description,
            }).ToListAsync();
            return new ApiSuccessResult<List<CodeLevel2ManagementViewModel>>(data);
        }

        public async Task<ApiResult<CodeLevel2ManagementViewModel>> GetById(int id)
        {
            var data = await _context.CodeLevel2Managements.Select(x => new CodeLevel2ManagementViewModel()
            {

                ID = x.ID,
                IDLevel1 = x.IDLevel1,
                CodeLevel1 = x.CodeLevel1,
                CodeLevel2 = x.CodeLevel2,
                CodeLevel2Description = x.CodeLevel2Description,
                CodeLevel2Lenght = x.CodeLevel2Lenght,
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<CodeLevel2ManagementViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<CodeLevel2ManagementViewModel>(data);
        }

        public async Task<ApiResult<int>> Update(int id, CodeLevel2ManagementUpdateRequest request)
        {
            try
            {
                var data = await _context.CodeLevel2Managements.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
                }

                data.IDLevel1 = request.IDLevel1;
                data.CodeLevel1 = request.CodeLevel1;
                data.CodeLevel2Lenght = request.CodeLevel2Lenght;
                data.CodeLevel2 = request.CodeLevel2;
                data.CodeLevel2Description = request.CodeLevel2Description;
                data.Modified = DateTime.Now;


                _context.CodeLevel2Managements.Update(data);
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
