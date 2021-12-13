using CareerSite.Business.Abstract;
using CareerSite.Core.Abstract;
using CareerSite.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly IUnitOfWork _unitofwork;
        public CourseManager(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public bool Create(Course entity)
        {
            if (Validation(entity))
            {
                _unitofwork.Courses.Create(entity);
                _unitofwork.Save();
                return true;
            }
            return false;
        }

        public void Delete(Course entity)
        {
            _unitofwork.Courses.Delete(entity);
            _unitofwork.Save();
        }

        public List<Course> GetAll()
        {
            return _unitofwork.Courses.GetAll();
        }

        public Course GetById(int id)
        {
            return _unitofwork.Courses.GetById(id);
        }

        public Course GetByIdWithCategories(int id)
        {
            return _unitofwork.Courses.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _unitofwork.Courses.GetCountByCategory(category);
        }

        public List<Course> GetHomePageCourses()
        {
            return _unitofwork.Courses.GetHomePageCourses();
        }

        public Course GetCourseDetails(string url)
        {
            return _unitofwork.Courses.GetCourseDetails(url);
        }

        public List<Course> GetCoursesByCategory(string name, int page, int pageSize)
        {
            return _unitofwork.Courses.GetCoursesByCategory(name, page, pageSize);
        }

        //public List<Course> GetNavbarByCategory(string name)
        //{
        //    return _unitofwork.Courses.GetNavbarByCategory(name);
        //}

        public List<Course> GetSearchResult(string searchString)
        {
            return _unitofwork.Courses.GetSearchResult(searchString);
        }

        public void Update(Course entity)
        {
            _unitofwork.Courses.Update(entity);
            _unitofwork.Save();
        }

        public bool Update(Course entity, int[] categoryIds)
        {
            if (Validation(entity))
            {
                if (categoryIds.Length == 0)
                {
                    ErrorMessage += "Ürün için en az bir kategori seçmelisiniz.";
                    return false;
                }
                _unitofwork.Courses.Update(entity, categoryIds);
                _unitofwork.Save();
                return true;
            }
            return false;
        }

        public string ErrorMessage { get; set; }

        public bool Validation(Course entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "ürün ismi girmelisiniz.\n";
                isValid = false;
            }

            if (entity.Price < 0)
            {
                ErrorMessage += "ürün fiyatı negatif olamaz.\n";
                isValid = false;
            }

            return isValid;
        }

      
    }
}
