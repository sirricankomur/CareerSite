using CareerSite.Core.Abstract;
using CareerSite.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.Concrete.EfCore
{
    public class EfCoreCourseRepository : EfCoreGenericRepository<Course>, ICourseRepository
    {
        public EfCoreCourseRepository(CareerContext context) : base(context)
        {

        }

        private CareerContext CareerContext
        {
            get { return context as CareerContext; }
        }
        public Course GetByIdWithCategories(int id)
        {
            return CareerContext.Courses
                            .Where(i => i.CourseId == id)
                            .Include(i => i.CourseCategories)
                            .ThenInclude(i => i.Category)
                            .FirstOrDefault();
        }

        public int GetCountByCategory(string category)
        {

            var courses = CareerContext.Courses.Where(i => i.IsApproved).AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                courses = courses
                                .Include(i => i.CourseCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.CourseCategories.Any(a => a.Category.Url == category));
            }

            return courses.Count();

        }
        public List<Course> GetHomePageCourses()
        {
            return CareerContext.Courses
                .Where(i => i.IsApproved && i.IsHome).ToList();
        }
        public Course GetCourseDetails(string url)
        {
            return CareerContext.Courses
                            .Where(i => i.Url == url)
                            .Include(i => i.CourseCategories)
                            .ThenInclude(i => i.Category)
                            .FirstOrDefault();

        }
        public List<Course> GetCoursesByCategory(string name, int page, int pageSize)
        {
            var courses = CareerContext
                .Courses
                .Where(i => i.IsApproved)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                courses = courses
                                .Include(i => i.CourseCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.CourseCategories.Any(a => a.Category.Url == name));
            }

            return courses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Course> GetSearchResult(string searchString)
        {
            var courses = CareerContext
                .Courses
                .Where(i => i.IsApproved && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower())))
                .AsQueryable();

            return courses.ToList();
        }

        public void Update(Course entity, int[] categoryIds)
        {
            var course = CareerContext.Courses
                                .Include(i => i.CourseCategories)
                                .FirstOrDefault(i => i.CourseId == entity.CourseId);


            if (course != null)
            {
                course.Name = entity.Name;
                course.Price = entity.Price;
                course.Description = entity.Description;
                course.Url = entity.Url;
                course.ImageUrl = entity.ImageUrl;
                course.IsApproved = entity.IsApproved;
                course.IsHome = entity.IsHome;

                course.CourseCategories = categoryIds.Select(catid => new CourseCategory()
                {
                    CourseId = entity.CourseId,
                    CategoryId = catid
                }).ToList();

            }
        }
    }
}
