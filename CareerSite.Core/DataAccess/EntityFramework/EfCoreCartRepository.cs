using CareerSite.Core.Abstract;
using CareerSite.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Core.DataAccess.EntityFramework
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(CareerContext context) : base(context)
        {

        }

        private CareerContext CareerContext
        {
            get { return context as CareerContext; }
        }
        public void ClearCart(int cartId)
        {
            var cmd = @"delete from CartItems where CartId=@p0";
            CareerContext.Database.ExecuteSqlRaw(cmd, cartId);
        }

        public void DeleteFromCart(int cartId, int courseId)
        {
            var cmd = @"delete from CartItems where CartId=@p0 and CourseId=@p1";
            CareerContext.Database.ExecuteSqlRaw(cmd, cartId, courseId);
        }

        public Cart GetByUserId(string userId)
        {
            return CareerContext.Carts
                        .Include(i => i.CartItems)
                        .ThenInclude(i => i.Course)
                        .FirstOrDefault(i => i.UserId == userId);
        }

        public override void Update(Cart entity)
        {
            CareerContext.Carts.Update(entity);
        }
    }
}
