using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Abstract
{
    public interface IRecordService
    {
        void Create(Record entity);
        List<Record> GetRecords(string userId);
    }
}
