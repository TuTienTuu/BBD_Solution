using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.ConfigFees;
using ViewModels.Common;

namespace Application.Catalog.ConfigFees
{
    public class ConfigFeeService : IConfigFeeService
    {
        private readonly DatabaseContext _context;
        public ConfigFeeService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<int>> Create(ConfigFeeCreateRequest request)
        {
            try
            {
                var model = new ConfigFee()
                {
                    DepreciationFee = request.DepreciationFee,
                    //DepreciationFeePerMachineDay = ((request.DepreciationFee / request.NumberOfMachine) / 26) / 10, //Khấu hao máy/h = Khấsu hao tài sản / tổng số máy / 26 / 10

                    ElectricFee = request.ElectricFee,
                    ElectricFeePerMachine = request.ElectricFee /request.NumberOfMachine,

                    ManagerFee = request.ManagerFee,
                    //ManagerFeePerMachine = ((request.ManagerFee / request.NumberOfMachine) / 26) / 10, //Tổng phí /tổng số máy/ 26 / 10
                    Note = string.Empty,
                    WorkshopRentalFee = request.WorkshopRentalFee,
                    //WorkshopRentalFeePerMachine = (request.WorkshopRentalFee / request.NumberOfMachine) / (26 * 10), //Chi phí thuê xưwởng / tổrng số máy/ (26 * 10)
                    //Description = request.GlueDescription,
                    Created = DateTime.Now,
                    Modified = DateTime.MinValue,
                    IsDeleted = false,
                    Deleted = DateTime.MinValue,
                };
                model.DepreciationFeePerMachineDay = ((request.DepreciationFee / request.NumberOfMachine) / 26) / 10;
                model.ManagerFeePerMachine = ((request.ManagerFee / request.NumberOfMachine) / 26) / 10;
                model.WorkshopRentalFeePerMachine = (request.WorkshopRentalFee / request.NumberOfMachine) / (26 * 10);
                model.DepreciationFeePerMachineHours = (model.DepreciationFeePerMachineDay / 26) + ((model.DepreciationFeePerMachineDay * (5 / 1000)) / 26);//+0.5% Khấu hao máy/h
                model.MaintainFee = model.DepreciationFeePerMachineHours;
                

                _context.ConfigFees.Add(model);
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
                var data = await _context.ConfigFees.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu: id={id}");
                }
                data.IsDeleted = true;
                data.Deleted = DateTime.Now;

                _context.ConfigFees.Update(data);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(id);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<ConfigFeeViewModel>>> GetAll()
        {
            var data = await _context.ConfigFees.Where(x => x.IsDeleted != true).Select(x => new ConfigFeeViewModel()
            {
                DepreciationFee = x.DepreciationFee,
                DepreciationFeePerMachineDay = x.DepreciationFeePerMachineDay,
                ID = x.ID,
                DepreciationFeePerMachineHours = x.DepreciationFeePerMachineHours,
                ElectricFee = x.ElectricFee,
                ElectricFeePerMachine = x.ElectricFeePerMachine,
                MaintainFee = x.MaintainFee,
                ManagerFee = x.ManagerFee,
                ManagerFeePerMachine = x.ManagerFeePerMachine,
                WorkshopRentalFee = x.WorkshopRentalFee,
                WorkshopRentalFeePerMachine = x.WorkshopRentalFeePerMachine,
                // GlueDescription = x.Description,
            }).ToListAsync();
            return new ApiSuccessResult<List<ConfigFeeViewModel>>(data);
        }

        public async Task<ApiResult<ConfigFeeViewModel>> GetById(int id)
        {
            var data = await _context.ConfigFees.Select(x => new ConfigFeeViewModel()
            {
                DepreciationFee = x.DepreciationFee,
                DepreciationFeePerMachineDay = x.DepreciationFeePerMachineDay,
                ID = x.ID,
                DepreciationFeePerMachineHours = x.DepreciationFeePerMachineHours,
                ElectricFee = x.ElectricFee,
                ElectricFeePerMachine = x.ElectricFeePerMachine,
                MaintainFee = x.MaintainFee,
                ManagerFee = x.ManagerFee,
                ManagerFeePerMachine = x.ManagerFeePerMachine,
                WorkshopRentalFee = x.WorkshopRentalFee,
                WorkshopRentalFeePerMachine = x.WorkshopRentalFeePerMachine,
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<ConfigFeeViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<ConfigFeeViewModel>(data);
        }



        public async Task<ApiResult<int>> Update(int id, ConfigFeeUpdateRequest request)
        {
            try
            {
                var data = await _context.ConfigFees.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
                }

                data.DepreciationFee = request.DepreciationFee;
                data.DepreciationFeePerMachineDay = ((request.DepreciationFee / request.NumberOfMachine) / 26) / 10; //Khấu hao máy/h = Khấsu hao tài sản / tổng số máy / 26 / 10

                data.ElectricFee = request.ElectricFee;
                data.ElectricFeePerMachine = request.ElectricFee / request.NumberOfMachine;

                data.ManagerFee = request.ManagerFee;
                data.ManagerFeePerMachine = ((request.ManagerFee / request.NumberOfMachine) / 26) / 10; //Tổng phí /tổng số máy/ 26 / 10
                data.Note = string.Empty;
                data.WorkshopRentalFee = request.WorkshopRentalFee;
                data.WorkshopRentalFeePerMachine = (request.WorkshopRentalFee / request.NumberOfMachine) / (26 * 10); //Chi phí thuê xưwởng / tổrng số máy/ (26 * 10)
                data.Modified = DateTime.Now;

                data.DepreciationFeePerMachineHours = (data.DepreciationFeePerMachineDay / 26) + ((data.DepreciationFeePerMachineDay * (5 / 1000)) / 26);

                _context.ConfigFees.Update(data);
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
