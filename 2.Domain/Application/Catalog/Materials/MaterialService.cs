using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Materials;
using ViewModels.Common;

namespace Application.Catalog.Materials
{
    public class MaterialService : IMaterialService
    {
        private readonly DatabaseContext _context;
        public MaterialService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<int>> CheckExistMaterial(MaterialCreateRequest request)
        {
            var data = await _context.Materials.FirstOrDefaultAsync(x =>

                x.Supplier == request.Supplier && x.IsDeleted == false && x.Unit == request.Unit && x.Price == request.Price && x.Note == request.Note && x.MaterialCode == request.MaterialCode && x.MaterialName == request.MaterialName && x.MaterialTypeID == request.MaterialTypeID && x.MaterialTypeName == request.MaterialTypeName && x.Size == request.Size
            );

            if (data != null)
            {
                return new ApiSuccessResult<int>(data.ID);
            }
            return new ApiSuccessResult<int>(0);
        }

        public async Task<ApiResult<int>> Create(MaterialCreateRequest request)
        {
            try
            {
                var model = new Material()
                {
                    Supplier = request.Supplier,
                    MaterialCode = request.MaterialCode,
                    Price = request.Price,
                    MaterialName = request.MaterialName,
                    MaterialTypeID = request.MaterialTypeID,
                    MaterialTypeName = request.MaterialTypeName,
                    Unit = request.Unit,
                    Note = request.Note,
                    //Description = request.GlueDescription,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    IsDeleted = false,
                    Deleted = DateTime.MinValue,
                    Size = request.Size,
                };
                _context.Materials.Add(model);
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
                var data = await _context.Materials.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu: id={id}");
                }
                data.IsDeleted = true;
                data.Deleted = DateTime.Now;

                _context.Materials.Update(data);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(id);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }
        public async Task<ApiResult<List<MaterialViewModel>>> GetAll(int materialType, string materialName)
        {
            var query = _context.Materials.Where(x => x.IsDeleted != true).AsQueryable();

            if (materialType > 0)
            {
                query = query.Where(x => x.MaterialTypeID == materialType);
            }

            if (!string.IsNullOrEmpty(materialName))
            {
                query = query.Where(x => x.MaterialName.Contains(materialName));
            }

            var data = await query.Select(x => new MaterialViewModel()
            {
                MaterialTypeID = x.MaterialTypeID,
                MaterialTypeName = x.MaterialTypeName,
                ID = x.ID,
                Unit = x.Unit,
                Supplier = x.Supplier,
                MaterialName = x.MaterialName,
                Price = x.Price,
                Note = x.Note,
                MaterialCode = x.MaterialCode,
                Created = x.Created,
                Modified = x.Modified,
                Deleted = x.Deleted,
                IsDeleted = x.IsDeleted,
                // GlueDescription = x.Description,
                Size = x.Size,
            }).ToListAsync();
            return new ApiSuccessResult<List<MaterialViewModel>>(data);
        }

        public async Task<ApiResult<MaterialViewModel>> GetById(int id)
        {
            var data = await _context.Materials.Select(x => new MaterialViewModel()
            {
                MaterialTypeID = x.MaterialTypeID,
                MaterialTypeName = x.MaterialTypeName,
                ID = x.ID,
                Unit = x.Unit,
                Supplier = x.Supplier,
                MaterialName = x.MaterialName,
                Price = x.Price,
                MaterialCode = x.MaterialCode,
                Created = x.Created,
                Deleted = x.Deleted,
                Modified = x.Modified,
                IsDeleted = x.IsDeleted,
                Note = x.Note,
                //GlueDescription = x.Description,
                Size = x.Size,

            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<MaterialViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<MaterialViewModel>(data);
        }

        public async Task<ApiResult<MaterialPriceModel>> GetPriceById(int id)
        {
            var data = await _context.Materials.Select(x => new MaterialPriceModel()
            {

                ID = x.ID,
                NewPrice = 0,
                OldPrice = x.Price,

                Note = x.Note,
                //MaterialTypeMainName = x.MaterialTypeMainName,

            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<MaterialPriceModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<MaterialPriceModel>(data);
        }

        public async Task<ApiResult<List<SelectItem>>> GetSelectList(int materialTypeId)
        {
            var query = _context.Materials.Where(x => x.IsDeleted != true).AsQueryable();

            if (materialTypeId>0)
            {
                query = query.Where(x => x.MaterialTypeID == materialTypeId);
            }

            var data = await query.Select(x => new SelectItem()
            {
                Id = x.ID.ToString(),
                Name = x.MaterialCode,// x.GlueCode + "-" +
                Selected = false,
            }).ToListAsync();

            data.Insert(0, new SelectItem() { Id = "0", Name = "Chọn vật tư", Selected = true });

            return new ApiSuccessResult<List<SelectItem>>(data);
        }

        public async Task<ApiResult<int>> Update(int id, MaterialUpdateRequest request)
        {
            try
            {
                var data = await _context.Materials.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
                }

                data.Unit = request.Unit;
                data.MaterialName = request.MaterialName;
                data.MaterialTypeID = request.MaterialTypeID;
                data.MaterialTypeName = request.MaterialTypeName;
                data.Supplier = request.Supplier;
                data.Note = request.Note;
                data.Size = request.Size;
                //data.Description = request.Description;
                data.Modified = DateTime.Now;
                data.MaterialCode = request.MaterialCode;
                _context.Materials.Update(data);
                await _context.SaveChangesAsync();
                return new ApiSuccessResult<int>(id);
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<int>(ex.Message);
            }
        }

        public async Task<ApiResult<decimal>> UpdatePrice(int id, MaterialPriceModel request)
        {
            try
            {
                var data = await _context.Materials.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<decimal>($"Không tìm thấy dữ liệu. Id={id}");
                }
                decimal oldPrice = data.Price;
                data.Price = request.NewPrice;
                //data.Descript ion = request.Description;
                data.Note = request.Note;
                //data.Purpose = request.Note;
                data.Modified = DateTime.Now;

                _context.Materials.Update(data);
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
