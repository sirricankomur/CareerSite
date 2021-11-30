using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Abstract
{
    public interface ICourseService
    {
        List<Course> GetAll();
        List<Course> GetByCategory(int categoryId);
        Course GetById(int id);
        void Add(Course course);
        void Update(Course course);
        void Delete(Course course);
    }
}
