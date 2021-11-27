using CareerSite.Business.Abstract;
using CareerSite.DataAccess.Abstract;
using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _personDal;

        public MemberManager(IMemberDal personDal)
        {
            _personDal = personDal;
        }

        public List<Member> GetAll()
        {
            return _personDal.GetList();
        }

        public void Add(Member person)
        {
            _personDal.Add(person);
        }

        public void Delete(Member person)
        {
            _personDal.Delete(person);
        }

        public void Update(Member person)
        {
            _personDal.Update(person);
        }
    }
}
