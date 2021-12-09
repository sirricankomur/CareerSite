using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.Abstract
{
    public interface IRecordRepository : IRepository<Record>
    {
        List<Record> GetRecords(string userId);
    }
}
