using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.MaterialTypes;
using ViewModels.Common;

namespace Application.Catalog.MaterialTypes
{
    public class MaterialTypeService : IMaterialTypeService
    {
        private readonly DatabaseContext _context;
        public MaterialTypeService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> Create(MaterialTypeCreateRequest request)
        {
            try
            {
                var model = new MateriaType()
                {
                    Name = request.Name,
                    //MaterialTypeName = request.MaterialTypeName,
                    //Description = request.GlueDescription,
                    //Created = DateTime.Now,
                    //Modified = DateTime.MinValue,
                    //IsDeleted = false,
                    //Deleted = DateTime.MinValue,

                };
                _context.MaterialTypes.Add(model);
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
                var data = await _context.MaterialTypes.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu: id={id}");
                }
                data.IsDeleted = true;
                data.Deleted = DateTime.Now;

                _context.MaterialTypes.Update(data);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(id);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<MaterialTypeViewModel>>> GetAll()
        {
            var data = await _context.MaterialTypes.Where(x => x.IsDeleted != true).Select(x => new MaterialTypeViewModel()
            {
                Created = x.Created,
                Name = x.Name,
                Modified = x.Modified,
                ID = x.ID,
                // GlueDescription = x.Description,
            }).ToListAsync();
            return new ApiSuccessResult<List<MaterialTypeViewModel>>(data);
        }

        public async Task<ApiResult<MaterialTypeViewModel>> GetById(int id)
        {
            var data = await _context.MaterialTypes.Select(x => new MaterialTypeViewModel()
            {
                Created = x.Created,
                Name = x.Name,
                Modified = x.Modified,
                //GlueDescription = x.Description,
                ID = x.ID,
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<MaterialTypeViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<MaterialTypeViewModel>(data);
        }

        public async Task<ApiResult<List<SelectItem>>> GetSelectList()
        {
            var listMaterialType = await _context.MaterialTypes.Where(x => x.IsDeleted != true).Select(x => new SelectItem()
            {
                Id = x.ID.ToString(),
                Name = x.Name ,
                Selected = false,
            }).ToListAsync();

            listMaterialType.Insert(0, new SelectItem() { Id = "0", Name = "Chọn mã hàng", Selected = true });

            return new ApiSuccessResult<List<SelectItem>>(listMaterialType);
        }

        public async Task<ApiResult<int>> Update(int id, MaterialTypeUpdateRequest request)
        {
            try
            {
                var data = await _context.MaterialTypes.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
                }

                data.Name = request.Name;
                //data.MaterialTypeName = request.MaterialTypeName;
                //data.Description = request.Description;
                data.Modified = DateTime.Now;

                _context.MaterialTypes.Update(data);
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
