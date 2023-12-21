using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.UnitPrices;
using ViewModels.Common;

namespace Application.Catalog.UnitPrices
{
    public class UnitPriceService : IUnitPriceService
    {
        private readonly DatabaseContext _context;
        public UnitPriceService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<int>> Create(UnitPriceViewModel request)
        {
            try
            {
                var model = new UnitPrice()
                {
                    Spec = request.Spec,
                    BoxPrice = request.BoxPrice,
                    Characteristic = request.Characteristic,
                    ColorPrice = request.ColorPrice,
                    CorePrice = request.CorePrice,
                    CustomerDiscount = request.CustomerDiscount,
                    DecalTotalPrice = request.DecalTotalPrice,
                    DepriciationTotalFee = request.DepriciationTotalFee,
                    ElectricFee = request.ElectricFee,
                    FilmPrice = request.FilmPrice,
                    KnifeUnitFee = request.KnifeUnitFee,
                    LaminationTotalPrice = request.LaminationTotalPrice,
                    ManagermentFeeTotal = request.ManagermentFeeTotal,
                    Print_Price = request.Print_Price,
                    ProfitPercent = request.ProfitPercent,
                    Quantity = request.Quantity,
                    SaleDiscount = request.SaleDiscount,
                    SrinkFilmPrice = request.SrinkFilmPrice,
                    Total = request.Total,
                    FinalyTotal = request.FinalyTotal,
                    TotalSalary = request.CD_TotalSalary,
                    WorkshopRentalFee = request.WorkshopRentalFee,
                    Unit = request.Unit,
                    Note = "",
                    //Description = request.GlueDescription,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    IsDeleted = false,
                    Deleted = DateTime.MinValue,
                    //Size = request.Size,
                };
                _context.UnitPrices.Add(model);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(model.ID);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public Task<ApiResult<int>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<List<UnitPriceViewModel>>> GetAll()
        {
            var query = _context.UnitPrices.Where(x => x.IsDeleted != true).AsQueryable();

            //if (materialType > 0)
            //{
            //    query = query.Where(x => x.MaterialTypeID == materialType);
            //}

            //if (!string.IsNullOrEmpty(materialName))
            //{
            //    query = query.Where(x => x.MaterialName.Contains(materialName));
            //}

            var data = await query.Select(x => new UnitPriceViewModel()
            {

                ID = x.ID,
                Unit = x.Unit,
                BoxPrice = x.BoxPrice,
                WorkshopRentalFee = x.WorkshopRentalFee,
                CD_TotalSalary = x.TotalSalary,
                Characteristic = x.Characteristic,
                ColorPrice = x.ColorPrice,
                CorePrice = x.CorePrice,
                CustomerDiscount = x.CustomerDiscount,
                DecalTotalPrice = x.DecalTotalPrice,
                DepriciationTotalFee = x.DepriciationTotalFee,
                ElectricFee = x.ElectricFee,
                FilmPrice = x.FilmPrice,
                KnifeUnitFee = x.KnifeUnitFee,
                LaminationTotalPrice = x.LaminationTotalPrice,
                ManagermentFeeTotal = x.ManagermentFeeTotal,
                FinalyTotal = x.FinalyTotal,
                Print_Price = x.Print_Price,
                ProfitPercent = x.ProfitPercent,
                Quantity = x.Quantity,
                SaleDiscount = x.SaleDiscount,
                Spec = x.Spec,
                SrinkFilmPrice = x.SrinkFilmPrice,
                Total = x.Total,

                //Created = x.Created,
                //Modified = x.Modified,
                //Deleted = x.Deleted,
                //IsDeleted = x.IsDeleted,

            }).ToListAsync();
            return new ApiSuccessResult<List<UnitPriceViewModel>>(data);
        }

        public async Task<ApiResult<UnitPriceViewModel>> GetById(int id)
        {
            var data = await _context.UnitPrices.Select(x => new UnitPriceViewModel()
            {
                ID = x.ID,
                Unit = x.Unit,
                BoxPrice = x.BoxPrice,
                WorkshopRentalFee = x.WorkshopRentalFee,
                CD_TotalSalary = x.TotalSalary,
                Characteristic = x.Characteristic,
                ColorPrice = x.ColorPrice,
                CorePrice = x.CorePrice,
                CustomerDiscount = x.CustomerDiscount,
                DecalTotalPrice = x.DecalTotalPrice,
                DepriciationTotalFee = x.DepriciationTotalFee,
                ElectricFee = x.ElectricFee,
                FilmPrice = x.FilmPrice,
                KnifeUnitFee = x.KnifeUnitFee,
                LaminationTotalPrice = x.LaminationTotalPrice,
                ManagermentFeeTotal = x.ManagermentFeeTotal,
                FinalyTotal = x.FinalyTotal,
                Print_Price = x.Print_Price,
                ProfitPercent = x.ProfitPercent,
                Quantity = x.Quantity,
                SaleDiscount = x.SaleDiscount,
                Spec = x.Spec,
                SrinkFilmPrice = x.SrinkFilmPrice,
                Total = x.Total,

            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<UnitPriceViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<UnitPriceViewModel>(data);
        }

        public async Task<ApiResult<List<SelectItem>>> GetSelectList()
        {
            var query = _context.UnitPrices.Where(x => x.IsDeleted != true).AsQueryable();

            //if (materialTypeId > 0)
            //{
            //    query = query.Where(x => x.MaterialTypeID == materialTypeId);
            //}

            var data = await query.Select(x => new SelectItem()
            {
                Id = x.ID.ToString(),
                Name = x.Spec,// x.GlueCode + "-" +
                Selected = false,
            }).ToListAsync();

            data.Insert(0, new SelectItem() { Id = "0", Name = "Chọn đơn giá", Selected = true });

            return new ApiSuccessResult<List<SelectItem>>(data);
        }

        public async Task<ApiResult<int>> Update(int id, UnitPriceViewModel request)
        {
            try
            {
                var data = await _context.UnitPrices.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
                }

                data.Unit = request.Unit;
                data.Unit = request.Unit;
                data.BoxPrice = request.BoxPrice;
                data.WorkshopRentalFee = request.WorkshopRentalFee;
                data.TotalSalary = request.CD_TotalSalary;
                data.Characteristic = request.Characteristic;
                data.ColorPrice = request.ColorPrice;
                data.CorePrice = request.CorePrice;
                data.CustomerDiscount = request.CustomerDiscount;
                data.DecalTotalPrice = request.DecalTotalPrice;
                data.DepriciationTotalFee = request.DepriciationTotalFee;
                data.ElectricFee = request.ElectricFee;
                data.FilmPrice = request.FilmPrice;
                data.KnifeUnitFee = request.KnifeUnitFee;
                data.LaminationTotalPrice = request.LaminationTotalPrice;
                data.ManagermentFeeTotal = request.ManagermentFeeTotal;
                data.FinalyTotal = request.FinalyTotal;
                data.Print_Price = request.Print_Price;
                data.ProfitPercent = request.ProfitPercent;
                data.Quantity = request.Quantity;
                data.SaleDiscount = request.SaleDiscount;
                data.Spec = request.Spec;
                data.SrinkFilmPrice = request.SrinkFilmPrice;
                data.Total = request.Total;
                //data.Description = request.Description;
                data.Modified = DateTime.Now;
                _context.UnitPrices.Update(data);
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
