using CareerSite.Core.Abstract;
using CareerSite.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.Concrete.EfCore
{
    public class EfCoreRecordRepository : EfCoreGenericRepository<Record>, IRecordRepository
    {

        public EfCoreRecordRepository(CareerContext context) : base(context)
        {

        }

        private CareerContext CareerContext
        {
            get { return context as CareerContext; }
        }
        public List<Record> GetRecords(string userId)
        {

            var records = CareerContext.Records
                                .Include(i => i.RecordItems)
                                .ThenInclude(i => i.Course)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(userId))
            {
                records = records.Where(i => i.UserId == userId);
            }

            return records.ToList();
        }
    }
}
