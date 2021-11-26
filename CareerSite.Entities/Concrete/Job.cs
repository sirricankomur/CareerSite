using CareerSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Entities.Concrete
{
    public class Job : IEntity
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public int CategoryId { get; set; }
    }
}
