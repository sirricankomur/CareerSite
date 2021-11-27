using CareerSite.Core.DataAccess.EntityFramework;
using CareerSite.DataAccess.Abstract;
using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.DataAccess.Concrete.EntityFramework
{
    public class EfMemberDal : EfEntityRepositoryBase<Member, CareerContext>, IMemberDal 
    {
        
    }
}
