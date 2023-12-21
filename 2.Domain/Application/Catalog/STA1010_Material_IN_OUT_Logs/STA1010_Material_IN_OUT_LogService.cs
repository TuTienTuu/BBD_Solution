using Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA1010_Material_IN_OUT_Logs;
using ViewModels.Common;

namespace Application.Catalog.STA1010_Material_IN_OUT_Logs
{
    public class STA1010_Material_IN_OUT_LogService : ISTA1010_Material_IN_OUT_LogService
    {
        private readonly DatabaseContext _context;
        public STA1010_Material_IN_OUT_LogService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<List<STA1010_Material_IN_OUT_LogViewModel>>> GetAll(string? searchType,  DateTime? date, string? subLot)
        {
            var query = _context.STA1010_Material_IN_OUT_Logs
                .GroupJoin(_context.STA0020_Material_Supplier_LOTNOs, x => x.RawNo.Substring(0,11), y => y.LotNo, (x, y) => new { Sta1010 = x, Sta0020 = y })
                .SelectMany(xy => xy.Sta0020.DefaultIfEmpty(), (x, y) => new { Sta1010 = x.Sta1010, Sta0020 = y }).Select(x => new STA1010_Material_IN_OUT_LogViewModel()
            {
                Action = x.Sta1010.Action,
                ImportDate = x.Sta0020.ImportDate,
                FifoYN = x.Sta1010.FIFOYN,
                ID = x.Sta1010.ID,
                IDEmployee = x.Sta1010.EmployeeID,
                LotNo = x.Sta0020.LotNo,
                MatCD = x.Sta0020.MatCD,
                MaterialName = x.Sta0020.MaterialName,
                Quantity = x.Sta1010.Quantity,
                RawLot = x.Sta1010.RawNo,
                RawNo = x.Sta1010.RawNo,
                Remark = x.Sta1010.Remark,
                StatusCheck = x.Sta1010.StatusCheck,
                StockCode = x.Sta1010.StockCD,
                Supplier = x.Sta0020.Supplier,
                SupplierLot = x.Sta0020.SupLOT,
                Unit = x.Sta0020.Unit,
                WorkDateTime = x.Sta1010.WorkDateTime,

                });

            if (!string.IsNullOrEmpty(searchType) && searchType != "A" &&  !string.IsNullOrEmpty(subLot) && date!= null)
                query = query.Where(x => x.Action.Contains(searchType) &&( x.ImportDate.Date == date.Value.Date|| x.WorkDateTime.Date == date.Value.Date) && x.RawNo.Contains(subLot));

            else if (!string.IsNullOrEmpty(searchType) && searchType != "A" && !string.IsNullOrEmpty(subLot) && date == null)
                query = query.Where(x => x.Action.Contains(searchType) && x.RawLot.Contains(subLot) );

            else if (!string.IsNullOrEmpty(searchType) && searchType != "A" && string.IsNullOrEmpty(subLot) && date != null)
                query = query.Where(x => x.Action.Contains(searchType) && (x.ImportDate.Date == date.Value.Date || x.WorkDateTime.Date == date.Value.Date));

            else if (string.IsNullOrEmpty(searchType) && searchType != "A" && !string.IsNullOrEmpty(subLot) && date != null)
                query = query.Where(x => (x.ImportDate.Date == date.Value.Date || x.WorkDateTime.Date == date.Value.Date) && x.RawNo.Contains(subLot));

           else if (!string.IsNullOrEmpty(searchType) && searchType != "A"  && string.IsNullOrEmpty(subLot) && date == null)
                query = query.Where(x => x.Action.Contains(searchType));


            //if (!string.IsNullOrEmpty(lotNo))
            //{
            //    query = query.Where(x => x.LOTNO == lotNo);
            //}
            var data = await query.ToListAsync();
            return new ApiSuccessResult<List<STA1010_Material_IN_OUT_LogViewModel>>(data);
        }

        public async Task<ApiResult<List<STA1010_Material_IN_OUT_LogViewModel>>> GetAll(string? searchType, string? subLot)
        {
            var query = _context.STA1010_Material_IN_OUT_Logs
                .GroupJoin(_context.STA0020_Material_Supplier_LOTNOs, x => x.RawNo.Substring(0, 11), y => y.LotNo, (x, y) => new { Sta1010 = x, Sta0020 = y })
                .SelectMany(xy => xy.Sta0020.DefaultIfEmpty(), (x, y) => new { Sta1010 = x.Sta1010, Sta0020 = y }).Select(x => new STA1010_Material_IN_OUT_LogViewModel()
                {
                    Action = x.Sta1010.Action,
                    ImportDate = x.Sta0020.ImportDate,
                    FifoYN = x.Sta1010.FIFOYN,
                    ID = x.Sta1010.ID,
                    IDEmployee = x.Sta1010.EmployeeID,
                    LotNo = x.Sta0020.LotNo,
                    MatCD = x.Sta0020.MatCD,
                    MaterialName = x.Sta0020.MaterialName,
                    Quantity = x.Sta1010.Quantity,
                    RawLot = x.Sta1010.RawNo,
                    RawNo = x.Sta1010.RawNo,
                    Remark = x.Sta1010.Remark,
                    StatusCheck = x.Sta1010.StatusCheck,
                    StockCode = x.Sta1010.StockCD,
                    Supplier = x.Sta0020.Supplier,
                    SupplierLot = x.Sta0020.SupLOT,
                    Unit = x.Sta0020.Unit,
                    WorkDateTime = x.Sta1010.WorkDateTime,

                });

             if (!string.IsNullOrEmpty(searchType) && searchType != "A" && !string.IsNullOrEmpty(subLot) )
                query = query.Where(x => x.Action.Contains(searchType) && x.RawNo.Contains(subLot));

            //if (!string.IsNullOrEmpty(lotNo))
            //{
            //    query = query.Where(x => x.LOTNO == lotNo);
            //}
            var data = await query.ToListAsync();
            return new ApiSuccessResult<List<STA1010_Material_IN_OUT_LogViewModel>>(data);
        }

        public async Task<ApiResult<List<STA1010_Material_IN_OUT_LogViewModel>>> GetAll(string? searchType)
        {
            var query = _context.STA1010_Material_IN_OUT_Logs
                .GroupJoin(_context.STA0020_Material_Supplier_LOTNOs, x => x.RawNo.Substring(0, 11), y => y.LotNo, (x, y) => new { Sta1010 = x, Sta0020 = y })
                .SelectMany(xy => xy.Sta0020.DefaultIfEmpty(), (x, y) => new { Sta1010 = x.Sta1010, Sta0020 = y }).Select(x => new STA1010_Material_IN_OUT_LogViewModel()
                {
                    Action = x.Sta1010.Action,
                    ImportDate = x.Sta0020.ImportDate,
                    FifoYN = x.Sta1010.FIFOYN,
                    ID = x.Sta1010.ID,
                    IDEmployee = x.Sta1010.EmployeeID,
                    LotNo = x.Sta0020.LotNo,
                    MatCD = x.Sta0020.MatCD,
                    MaterialName = x.Sta0020.MaterialName,
                    Quantity = x.Sta1010.Quantity,
                    RawLot = x.Sta1010.RawNo,
                    RawNo = x.Sta1010.RawNo,
                    Remark = x.Sta1010.Remark,
                    StatusCheck = x.Sta1010.StatusCheck,
                    StockCode = x.Sta1010.StockCD,
                    Supplier = x.Sta0020.Supplier,
                    SupplierLot = x.Sta0020.SupLOT,
                    Unit = x.Sta0020.Unit,
                    WorkDateTime = x.Sta1010.WorkDateTime,

                });

            if (!string.IsNullOrEmpty(searchType) && searchType != "A" )
                query = query.Where(x => x.Action.Contains(searchType) );

            //if (!string.IsNullOrEmpty(lotNo))
            //{
            //    query = query.Where(x => x.LOTNO == lotNo);
            //}
            var data = await query.ToListAsync();
            return new ApiSuccessResult<List<STA1010_Material_IN_OUT_LogViewModel>>(data);
        }

        public async Task<ApiResult<List<STA1010_Material_IN_OUT_LogViewModel>>> GetAll_(string? searchType, DateTime? date)
        {
            var query = _context.STA1010_Material_IN_OUT_Logs
                .GroupJoin(_context.STA0020_Material_Supplier_LOTNOs, x => x.RawNo.Substring(0, 11), y => y.LotNo, (x, y) => new { Sta1010 = x, Sta0020 = y })
                .SelectMany(xy => xy.Sta0020.DefaultIfEmpty(), (x, y) => new { Sta1010 = x.Sta1010, Sta0020 = y }).Select(x => new STA1010_Material_IN_OUT_LogViewModel()
                {
                    Action = x.Sta1010.Action,
                    ImportDate = x.Sta0020.ImportDate,
                    FifoYN = x.Sta1010.FIFOYN,
                    ID = x.Sta1010.ID,
                    IDEmployee = x.Sta1010.EmployeeID,
                    LotNo = x.Sta0020.LotNo,
                    MatCD = x.Sta0020.MatCD,
                    MaterialName = x.Sta0020.MaterialName,
                    Quantity = x.Sta1010.Quantity,
                    RawLot = x.Sta1010.RawNo,
                    RawNo = x.Sta1010.RawNo,
                    Remark = x.Sta1010.Remark,
                    StatusCheck = x.Sta1010.StatusCheck,
                    StockCode = x.Sta1010.StockCD,
                    Supplier = x.Sta0020.Supplier,
                    SupplierLot = x.Sta0020.SupLOT,
                    Unit = x.Sta0020.Unit,
                    WorkDateTime = x.Sta1010.WorkDateTime,

                });

            if (!string.IsNullOrEmpty(searchType) && searchType != "A" && date != null)
                query = query.Where(x => x.Action.Contains(searchType) && (x.ImportDate.Date == date.Value.Date || x.WorkDateTime.Date == date.Value.Date));

            //if (!string.IsNullOrEmpty(lotNo))
            //{
            //    query = query.Where(x => x.LOTNO == lotNo);
            //}
            var data = await query.ToListAsync();
            return new ApiSuccessResult<List<STA1010_Material_IN_OUT_LogViewModel>>(data);
        }
    }
}
