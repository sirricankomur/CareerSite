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
        Course GetCourseDetails(string url);
        Course GetByIdWithCategories(int id);
        List<Course> GetCoursesByCategory(string name, int page, int pageSize);
        //List<Course> GetNavbarByCategory(string name);

        List<Course> GetSearchResult(string searchString);
        List<Course> GetHomePageCourses();
        int GetCountByCategory(string category);
        void Update(Course entity, int[] categoryIds);
    }
}
