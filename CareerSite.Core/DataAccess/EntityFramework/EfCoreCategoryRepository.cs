using CareerSite.Core.Abstract;
using CareerSite.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.DataAccess.EntityFramework
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {

        public EfCoreCategoryRepository(CareerContext context) : base(context)
        {

        }

        private CareerContext CareerContext
        {
            get { return context as CareerContext; }
        }
        public void DeleteFromCategory(int courseId, int categoryId)
        {
            var cmd = "delete from coursecategory where CourseId=@p0 and CategoryId=@p1";
            CareerContext.Database.ExecuteSqlRaw(cmd, courseId, categoryId);
        }

        public Category GetByIdWithCourses(int categoryId)
        {
            return CareerContext.Categories
                        .Where(i => i.CategoryId == categoryId)
                        .Include(i => i.CourseCategories)
                        .ThenInclude(i => i.Course)
                        .FirstOrDefault();
        }


    }
}
