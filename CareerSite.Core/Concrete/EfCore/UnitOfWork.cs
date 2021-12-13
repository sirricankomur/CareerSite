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
    public class UnitOfWork: IUnitOfWork
    {
        private readonly CareerContext _context;
        public UnitOfWork(CareerContext context)
        {
            _context = context;
        }

        private EfCoreCartRepository _cartRepository;
        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreRecordRepository _recordRepository;
        private EfCoreCourseRepository _courseRepository;

        public ICartRepository Carts =>
            _cartRepository = _cartRepository ?? new EfCoreCartRepository(_context);

        public ICategoryRepository Categories =>
            _categoryRepository = _categoryRepository ?? new EfCoreCategoryRepository(_context);

        public IRecordRepository Records =>
            _recordRepository = _recordRepository ?? new EfCoreRecordRepository(_context);

        public ICourseRepository Courses =>
            _courseRepository = _courseRepository ?? new EfCoreCourseRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
