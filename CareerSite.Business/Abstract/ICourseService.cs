﻿using CareerSite.Entity.Concrete;
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
        Course GetCourseDetails(string url);
        List<Course> GetCoursesByCategory(string name, int page, int pageSize);
        int GetCountByCategory(string category);
        List<Course> GetHomePageCourses();
        List<Course> GetSearchResult(string searchString);
        List<Course> GetAll();

        bool Create(Course entity);
        void Update(Course entity);
        void Delete(Course entity);
        bool Update(Course entity, int[] categoryIds);
    }
}
