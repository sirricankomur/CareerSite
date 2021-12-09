using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICartRepository Carts { get; }
        ICategoryRepository Categories { get; }
        IRecordRepository Records { get; }
        ICourseRepository Courses { get; }
        void Save();
    }
}
