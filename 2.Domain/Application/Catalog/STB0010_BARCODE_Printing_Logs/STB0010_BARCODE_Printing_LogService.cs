using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STB0010_BARCODE_Printing_Logs;
using ViewModels.Common;

namespace Application.Catalog.STB0010_BARCODE_Printing_Logs
{
    public class STB0010_BARCODE_Printing_LogService : ISTB0010_BARCODE_Printing_LogService
    {
        private readonly DatabaseContext _context;
        public STB0010_BARCODE_Printing_LogService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<int>> Create(STB0010_BARCODE_Printing_LogCreateRequest request)
        {
            try
            {
              
                var model = new STB0010_BARCODE_Printing_Log()
                {
                 
                    STRNO = request.ExportQuantityStart,
                    //MaterialName = request.MaterialName,
                    MaterialCode = request.MaterialCode,
                    ENDNO = request.ExportQuantityEnd,
                    MATCD = request.MatCD,
                    IDEmp = request.EmployeeID,
                    LOTNO = request.LotNo,
                    STA0020_Material_Supplier_LotnoID = request.STA0020_Material_Supplier_LotnoID,
                    DateCreate = DateTime.Now,
                    //Modified = DateTime.MinValue,
                    //IsDeleted = false,
                    //Deleted = DateTime.MinValue,
                };
                _context.STB0010_Material_Export_Trackings.Add(model);
                await _context.SaveChangesAsync();

                return new ApiSuccessResult<int>(model.ID);
            }
            catch (Exception ex)
            {

                return new ApiErrorResult<int>("Lỗi" + ex.Message);
            }
        }

        public async Task<ApiResult<List<STB0010_BARCODE_Printing_LogViewModel>>> GetAll()
        {
            var data = await _context.STB0010_Material_Export_Trackings.Select(x => new STB0010_BARCODE_Printing_LogViewModel()
            {
                ExportQuantityStart = x.STRNO,
                ExportQuantityEnd = x.ENDNO,
                LotNo = x.LOTNO,
                MatCD = x.MATCD,
                EmployeeID = x.IDEmp,
                MaterialCode = x.MaterialCode,
                STA0020_Material_Supplier_LotnoID = x.STA0020_Material_Supplier_LotnoID,
                CreatedDate = x.DateCreate,
                ID = x.ID,

            }).ToListAsync();
            return new ApiSuccessResult<List<STB0010_BARCODE_Printing_LogViewModel>>(data);
        }

        public async Task<ApiResult<STB0010_BARCODE_Printing_LogViewModel>> GetById(int id)
        {
            var data = await _context.STB0010_Material_Export_Trackings.Select(x => new STB0010_BARCODE_Printing_LogViewModel()
            {
                ExportQuantityStart = x.STRNO,
                ExportQuantityEnd = x.ENDNO,
                LotNo = x.LOTNO,
                MatCD = x.MATCD,
                MaterialCode = x.MaterialCode,
                STA0020_Material_Supplier_LotnoID = x.STA0020_Material_Supplier_LotnoID,
                EmployeeID = x.IDEmp,
                CreatedDate = x.DateCreate,
                ID = x.ID,
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (data == null)
                return new ApiErrorResult<STB0010_BARCODE_Printing_LogViewModel>($"Không tìm thấy dữ liệu. Id={id}");

            return new ApiSuccessResult<STB0010_BARCODE_Printing_LogViewModel>(data);
        }
    }
}
