using CareerSite.Entities.Concrete;

namespace CareerSite.MvcWebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
