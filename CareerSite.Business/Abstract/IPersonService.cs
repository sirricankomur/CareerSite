using CareerSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Business.Abstract
{
    public interface IPersonService
    {
        List<Person> GetAll();
        
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
    }
}
