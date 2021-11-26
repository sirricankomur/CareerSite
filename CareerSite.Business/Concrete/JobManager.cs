using CareerSite.Business.Abstract;
using CareerSite.DataAccess.Abstract;
using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Concrete
{
    public class JobManager : IJobService
    {
        private IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public List<Job> GetAll()
        {
            return _jobDal.GetList();
        }

        public List<Job> GetByCategory(int categoryId)
        {
            return _jobDal.GetList(j => j.CategoryId == categoryId);
        }

        public void Add(Job job)
        {
            _jobDal.Add(job);
        }

        public void Delete(Job job)
        {
            _jobDal.Delete(job);
        }

        public void Update(Job job)
        {
            _jobDal.Update(job);
        }
    }
}
