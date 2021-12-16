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

        public int GetCountByCategoryTr(string category)
        {

            var courses = CareerContext.Courses.Where(i => i.IsApproved).AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                courses = courses
                                .Include(i => i.CourseCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.CourseCategories.Any(a => a.Category.UrlTr == category));
            }

            return courses.Count();
        }

        public int GetCountByCategoryEn(string category)
        {

            var courses = CareerContext.Courses.Where(i => i.IsApproved).AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                courses = courses
                                .Include(i => i.CourseCategories)
                                .ThenInclude(i => i.Category)
                                .Where(i => i.CourseCategories.Any(a => a.Category.UrlEn == category));
            }

            return courses.Count();
        }
        public List<Course> GetHomePageCourses()
        {
            return CareerContext.Courses
                .Where(i => i.IsApproved && i.IsHome).ToList();
        }



        public Course GetCourseDetailsTr(string url)
        {
            return CareerContext.Courses
                            .Where(i => i.UrlTr == url)
                            .Include(i => i.CourseCategories)
                            .ThenInclude(i => i.Category)
                            .FirstOrDefault();

        }

        public Course GetCourseDetailsEn(string url)
        {
            return CareerContext.Courses
                            .Where(i => i.UrlEn == url)
                            .Include(i => i.CourseCategories)
                            .ThenInclude(i => i.Category)
                            .FirstOrDefault();

        }
        public List<Course> GetCoursesByCategoryTr(string name, int page, int pageSize)
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
                                .Where(i => i.CourseCategories.Any(a => a.Category.UrlTr == name));
            }

            return courses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Course> GetCoursesByCategoryEn(string name, int page, int pageSize)
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
                                .Where(i => i.CourseCategories.Any(a => a.Category.UrlEn == name));
            }

            return courses.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Course> GetSearchResultTr(string searchString)
        {
            var courses = CareerContext
                .Courses
                .Where(i => i.IsApproved && (i.NameTr.ToLower().Contains(searchString.ToLower()) || i.DescriptionTr.ToLower().Contains(searchString.ToLower())))
                .AsQueryable();

            return courses.ToList();
        }
        public List<Course> GetSearchResultEn(string searchString)
        {
            var courses = CareerContext
                .Courses
                .Where(i => i.IsApproved && (i.NameEn.ToLower().Contains(searchString.ToLower()) || i.DescriptionEn.ToLower().Contains(searchString.ToLower())))
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
                course.NameTr = entity.NameTr;
                course.NameEn = entity.NameEn;
                course.Price = entity.Price;
                course.DescriptionTr = entity.DescriptionTr;
                course.DescriptionEn = entity.DescriptionEn;
                
                course.UrlTr = entity.UrlTr;
                course.UrlEn = entity.UrlEn;
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
