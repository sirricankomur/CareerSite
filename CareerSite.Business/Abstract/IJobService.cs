using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Abstract
{
    public interface IJobService
    {
        List<Job> GetAll();
        List<Job> GetByCategory(int categoryId);  
        void Add(Job job);
        void Update(Job job);
        void Delete(Job job);
    }
}
