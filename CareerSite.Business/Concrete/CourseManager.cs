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

        public int GetCountByCategoryTr(string category)
        {
            return _unitofwork.Courses.GetCountByCategoryTr(category);
        }
        public int GetCountByCategoryEn(string category)
        {
            return _unitofwork.Courses.GetCountByCategoryEn(category);
        }

        public List<Course> GetHomePageCourses()
        {
            return _unitofwork.Courses.GetHomePageCourses();
        }


        public Course GetCourseDetailsTr(string url)
        {
            return _unitofwork.Courses.GetCourseDetailsTr(url);
        }
        public Course GetCourseDetailsEn(string url)
        {
            return _unitofwork.Courses.GetCourseDetailsEn(url);
        }

        public List<Course> GetCoursesByCategoryTr(string name, int page, int pageSize)
        {
            return _unitofwork.Courses.GetCoursesByCategoryTr(name, page, pageSize);
        }
        public List<Course> GetCoursesByCategoryEn(string name, int page, int pageSize)
        {
            return _unitofwork.Courses.GetCoursesByCategoryEn(name, page, pageSize);
        }

        //public List<Course> GetNavbarByCategory(string name)
        //{
        //    return _unitofwork.Courses.GetNavbarByCategory(name);
        //}

        public List<Course> GetSearchResultTr(string searchString)
        {
            return _unitofwork.Courses.GetSearchResultTr(searchString);
        }
        public List<Course> GetSearchResultEn(string searchString)
        {
            return _unitofwork.Courses.GetSearchResultEn(searchString);
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

            if (string.IsNullOrEmpty(entity.NameTr) || string.IsNullOrEmpty(entity.NameEn))
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
