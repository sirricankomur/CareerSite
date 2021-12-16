using CareerSite.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        Course GetCourseDetailsTr(string url);
        Course GetCourseDetailsEn(string url);
        Course GetByIdWithCategories(int id);
        List<Course> GetCoursesByCategoryTr(string name, int page, int pageSize);
        List<Course> GetCoursesByCategoryEn(string name, int page, int pageSize);

        //List<Course> GetNavbarByCategory(string name);

        List<Course> GetSearchResultTr(string searchString);
        List<Course> GetSearchResultEn(string searchString);
        List<Course> GetHomePageCourses();
        int GetCountByCategoryTr(string category);
        int GetCountByCategoryEn(string category);

        void Update(Course entity, int[] categoryIds);
    }
}
