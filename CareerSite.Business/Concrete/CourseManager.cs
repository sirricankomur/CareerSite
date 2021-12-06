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
    public class CourseManager : ICourseService
    {
        private ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public List<Course> GetAll()
        {
            return _courseDal.GetList();
        }

        public List<Course> GetByCategory(int categoryId)
        {
            return _courseDal.GetList(c => c.CategoryID == categoryId || categoryId == 0);
        }

        public Course GetById(int courseId)
        {
            return _courseDal.Get(c => c.CourseID == courseId);
        }

        public void Add(Course course)
        {
            _courseDal.Add(course);
        }

        public void Delete(Course course)
        {
            _courseDal.Delete(course);
        }

        public void Update(Course course)
        {
            _courseDal.Update(course);
        }
    }
}
