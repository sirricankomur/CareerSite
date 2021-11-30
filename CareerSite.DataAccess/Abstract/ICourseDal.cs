using CareerSite.Core.DataAccess;
using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.DataAccess.Abstract
{
    public interface ICourseDal : IEntityRepository<Course>
    {

    }
}
