using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Abstract
{
    public interface IMemberService
    {
        List<Member> GetAll();
        
        void Add(Member person);
        void Update(Member person);
        void Delete(Member person);
    }
}
