using CareerSite.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Abstract
{
    public interface ICourseService : IValidator<Course>
    {
        Course GetById(int id);
        Course GetByIdWithCategories(int id);
        Course GetCourseDetailsTr(string url);
        Course GetCourseDetailsEn(string url);
        List<Course> GetCoursesByCategoryTr(string name, int page, int pageSize);
        List<Course> GetCoursesByCategoryEn(string name, int page, int pageSize);
        //List<Course> GetNavbarByCategory(string name);
        int GetCountByCategoryTr(string category);
        int GetCountByCategoryEn(string category);

        List<Course> GetHomePageCourses();
        List<Course> GetSearchResultTr(string searchString);
        List<Course> GetSearchResultEn(string searchString);
        List<Course> GetAll();
        bool Create(Course entity);
        void Update(Course entity);
        void Delete(Course entity);
        bool Update(Course entity, int[] categoryIds);
    }
}
