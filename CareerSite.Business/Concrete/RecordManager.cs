using CareerSite.Business.Abstract;
using CareerSite.Core.Abstract;
using CareerSite.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Concrete
{
    public class RecordManager : IRecordService
    {
        private readonly IUnitOfWork _unitofwork;
        public RecordManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public void Create(Record entity)
        {
            _unitofwork.Records.Create(entity);
            _unitofwork.Save();
        }

        public List<Record> GetRecords(string userId)
        {
            return _unitofwork.Records.GetRecords(userId);
        }
    }
}
