using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.MachineConfigs;
using ViewModels.Common;

namespace Application.Catalog.MachineConfigs
{
    public class MachineConfigService : IMachineConfigService
    {
        private readonly DatabaseContext _context;
        public MachineConfigService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<decimal>> AvgSalary(string machineName, decimal salary, int position)
        {
           var query =  _context.MachineConfigs.Where(c => c.MachineName.Substring(0,1) == machineName.Substring(0, 1)).AsQueryable();

            var totalSalary = position== 1? await query.SumAsync(x=>x.OperatorSalary_1) + salary : await query.SumAsync(x => x.OperatorSalary_2) + salary;
            var totalMachine = await query.CountAsync() +  1;

            return new ApiErrorResult<decimal>((totalSalary / totalMachine).ToString());
        }

        public async Task<ApiResult<int>> Create(MachineConfigCreateRequest request)
        {
            try
            {
                var model = new MachineConfig()
                {
                    Change = request.Change,
                   ChangeRoll = request.ChangeRoll,
                   ChangeRoll_H = request.ChangeRoll_H,
                   ChangeSpec = request.ChangeSpec,
                   ChangeSpec_H = request.ChangeSpec_H,
                   Color = request.Color,
                   Compensation = request.Compensation,
                   CostAllocationPercent = request.CostAllocationPercent,
                   
                   KWPerHour = request.Power/1000,
                   MachineName = request.MachineName,
                   Note = "",
                   OperatorNumber = request.OperatorNumber,
                   OperatorSalary_1 = request.OperatorSalary_1,
                   OperatorSalary_2 = request.OperatorSalary_2,
                   Power = request.Power,
                   Risk = request.Risk,
                   Target = request.Target,
                   WhiteCarry = request.WhiteCarry, 
                   Created = DateTime.Now,
                   HourlySalary = request.HourlySalary,
                   ElectricPrice = (request.Power / 1000)* 2500,
                   Deleted= DateTime.MinValue,
                   IsDeleted = false,
                   Modified = DateTime.MinValue
                };

              //  model.ElectricPrice = model.KWPerHour*2500;//+
              //  model.Note ="Test";//+
               // var a = ((float)model.OperatorSalary_1 * (1.225) + (float)model.OperatorSalary_2 - (1.225)) / ((float)(request.NumberStageMachine / 26) / 8 * (1.225));
               // model.HourlySalary =164.413m;

                _context.MachineConfigs.Add(model);
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
                var data = await _context.MachineConfigs.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu: id={id}");
                }
                data.IsDeleted = true;
                data.Deleted = DateTime.Now;

                _context.MachineConfigs.Update(data);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(id);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<MachineConfigViewModel>>> GetAll()
        {
            var data = await _context.MachineConfigs.Where(x => x.IsDeleted != true).Select(x => new MachineConfigViewModel()
            {
                Change = x.Change,
                ChangeRoll = x.ChangeRoll,
                ChangeRoll_H = x.ChangeRoll_H,
                ChangeSpec = x.ChangeSpec,
                ChangeSpec_H = x.ChangeSpec_H,
                Color = x.Color,
                Compensation = x.Compensation,
                CostAllocationPercent = x.CostAllocationPercent,
                ID = x.ID,
                KWPerHour = x.KWPerHour,
                MachineName = x.MachineName,
                Note = x.Note,
                OperatorNumber = x.OperatorNumber,
                OperatorSalary_1 = x.OperatorSalary_1,
                OperatorSalary_2 = x.OperatorSalary_2,
                Power = x.Power,
                Risk = x.Risk,
                Target = x.Target,
                WhiteCarry = x.WhiteCarry,
                ElectricPrice = x.ElectricPrice,
                HourlySalary = x.HourlySalary,
            }).ToListAsync();
            return new ApiSuccessResult<List<MachineConfigViewModel>>(data);
        }

        public async Task<ApiResult<MachineConfigViewModel>> GetById(int id)
        {
            var data = await _context.MachineConfigs.Select(x => new MachineConfigViewModel()
            {
                Change = x.Change,
                ChangeRoll = x.ChangeRoll,
                ChangeRoll_H = x.ChangeRoll_H,
                ChangeSpec = x.ChangeSpec,
                ChangeSpec_H = x.ChangeSpec_H,
                Color = x.Color,
                Compensation = x.Compensation,
                CostAllocationPercent = x.CostAllocationPercent,
                ID = x.ID,
                KWPerHour = x.KWPerHour,
                MachineName = x.MachineName,
                Note = x.Note,
                OperatorNumber = x.OperatorNumber,
                OperatorSalary_1 = x.OperatorSalary_1,
                OperatorSalary_2 = x.OperatorSalary_2,
                Power = x.Power,
                Risk = x.Risk,
                Target = x.Target,
                WhiteCarry = x.WhiteCarry,
                ElectricPrice = x.ElectricPrice,
                HourlySalary = x.HourlySalary,
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
            {
                var nullData = new MachineConfigViewModel() {
                    Change = 0,
                    ChangeRoll = 0,
                    ChangeRoll_H = 0,
                    ChangeSpec = 0,
                    ChangeSpec_H = 0,
                    Color = 0,
                    Compensation = 0,
                    CostAllocationPercent = 0,
                    ID = 0,
                    KWPerHour = 0,
                    MachineName = "Không có máy",
                    Note = "",
                    OperatorNumber = 0,
                    OperatorSalary_1 = 0,
                    OperatorSalary_2 = 0,
                    Power = 0,
                    Risk = 0,
                    Target = 0,
                    WhiteCarry = 0,
                    ElectricPrice = 0,
                    HourlySalary = 0,
                    
                };
                return new ApiSuccessResult<MachineConfigViewModel>(nullData);
            }
            return new ApiSuccessResult<MachineConfigViewModel>(data);
        }

        public async Task<ApiResult<List<SelectItem>>> GetSelectList(string? group)
        {
            var query = _context.MachineConfigs.Where(x => x.IsDeleted != true).AsQueryable();

            if (!string.IsNullOrEmpty(group))
            {
                query = query.Where(x => x.MachineName.Contains(group));
            }

            var data = await query.Select(x => new SelectItem()
            {
                Id = x.ID.ToString(),
                Name = x.MachineName,// x.GlueCode + "-" +
                Selected = false,
            }).ToListAsync();

            data.Insert(0, new SelectItem() { Id = "0", Name = "Chọn máy", Selected = true });

            return new ApiSuccessResult<List<SelectItem>>(data);
        }

        public async Task<ApiResult<int>> Update(int id, MachineConfigUpdateRequest request)
        {
            try
            {
                var data = await _context.MachineConfigs.FirstOrDefaultAsync(x => x.ID == id);

                if (data == null)
                {
                    return new ApiErrorResult<int>($"Không tìm thấy dữ liệu. Id={id}");
                }

                data.Change = request.Change;
                data.ChangeRoll = request.ChangeRoll;
                data.ChangeRoll_H = request.ChangeRoll_H;
                data.ChangeSpec = request.ChangeSpec;
                data.ChangeSpec_H = request.ChangeSpec_H;
                data.Color = request.Color;
                data.Compensation = request.Compensation;
                data.CostAllocationPercent = request.CostAllocationPercent;
                data.KWPerHour = request.Power / 1000;
                data.MachineName = request.MachineName;
                data.Note = string.Empty;
                data.OperatorNumber = request.OperatorNumber;
                data.OperatorSalary_1 = request.OperatorSalary_1;
                data.OperatorSalary_2 = request.OperatorSalary_2;
                data.Power = request.Power;
                data.Risk = request.Risk;
                data.Target = request.Target;
                data.WhiteCarry = request.WhiteCarry; //xưwởng / tổrng số máy/ (26 * 10)
                data.Modified = DateTime.Now;
                data.ElectricPrice = data.KWPerHour * 2500;//+
                data.HourlySalary = data.HourlySalary;
                //data.HourlySalary = ((data.OperatorSalary_1 * (49 / 40) + data.OperatorSalary_2 - (49 / 40)) / ((request.NumberStageMachine / 26)) / 8 * (49 / 40));
                _context.MachineConfigs.Update(data);
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
