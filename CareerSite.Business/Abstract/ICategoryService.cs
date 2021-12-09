using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);

        Category GetByIdWithCourses(int categoryId);

        List<Category> GetAll();

        void Create(Category entity);

        void Update(Category entity);
        void Delete(Category entity);
        void DeleteFromCategory(int courseId, int categoryId);
    }
}
