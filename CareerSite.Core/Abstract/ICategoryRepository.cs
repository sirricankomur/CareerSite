using CareerSite.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByIdWithCourses(int categoryId);
        void DeleteFromCategory(int courseId, int categoryId);
    }
}
