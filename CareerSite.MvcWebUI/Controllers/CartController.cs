using CareerSite.Business.Abstract;
using CareerSite.Entity.Concrete;
using CareerSite.MvcWebUI.Identity;
using CareerSite.MvcWebUI.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CareerSite.MvcWebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ICartService _cartService;
        private IRecordService _recordService;
        private UserManager<User> _userManager;
        public CartController(IRecordService recordService, ICartService cartService, UserManager<User> userManager)
        {
            _cartService = cartService;
            _recordService = recordService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    CourseId = i.CourseId,
                    Name = i.Course.Name,
                    Price = (double)i.Course.Price,
                    ImageUrl = i.Course.ImageUrl,
                    Quantity = i.Quantity

                }).ToList()
            });
        }

        [HttpPost]
        public IActionResult AddToCart(int courseId, int quantity)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.AddToCart(userId, courseId, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int courseId)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.DeleteFromCart(userId, courseId);
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));

            var recordModel = new RecordModel();

            recordModel.CartModel = new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    CourseId = i.CourseId,
                    Name = i.Course.Name,
                    Price = (double)i.Course.Price,
                    ImageUrl = i.Course.ImageUrl,
                    Quantity = i.Quantity

                }).ToList()
            };

            return View(recordModel);
        }

        [HttpPost]
        public IActionResult Checkout(RecordModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var cart = _cartService.GetCartByUserId(userId);

                model.CartModel = new CartModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(i => new CartItemModel()
                    {
                        CartItemId = i.Id,
                        CourseId = i.CourseId,
                        Name = i.Course.Name,
                        Price = (double)i.Course.Price,
                        ImageUrl = i.Course.ImageUrl,
                        Quantity = i.Quantity
                    }).ToList()
                };

                var payment = PaymentProcess(model);

                if (payment.Status == "success")
                {
                    SaveRecord(model, payment, userId);
                    ClearCart(model.CartModel.CartId);
                    return View("Success");
                }
                else
                {
                    var msg = new AlertMessage()
                    {
                        Message = $"{payment.ErrorMessage}",
                        AlertType = "danger"
                    };

                    TempData["message"] = JsonConvert.SerializeObject(msg);
                }
            }
            return View(model);
        }
        
        public IActionResult GetRecords()
        {
            var userId = _userManager.GetUserId(User);
            var records = _recordService.GetRecords(userId);

            var recordListModel = new List<RecordListModel>();
            RecordListModel recordModel;
            foreach (var record in records)
            {
                recordModel = new RecordListModel();

                recordModel.RecordId = record.Id;
                recordModel.RecordNumber = record.RecordNumber;
                recordModel.RecordDate = record.RecordDate;
                recordModel.Phone = record.Phone;
                recordModel.FirstName = record.FirstName;
                recordModel.LastName = record.LastName;
                recordModel.Email = record.Email;
                recordModel.Address = record.Address;
                recordModel.City = record.City;
                recordModel.RecordState = record.RecordState;
                recordModel.PaymentType = record.PaymentType;

                recordModel.RecordItems = record.RecordItems.Select(i => new RecordItemModel()
                {
                    RecordItemId = i.Id,
                    Name = i.Course.Name,
                    Price = (double)i.Price,
                    Quantity = i.Quantity,
                    ImageUrl = i.Course.ImageUrl
                }).ToList();

                recordListModel.Add(recordModel);
            }


            return View("Records", recordListModel);
        }

        private void ClearCart(int cartId)
        {
            _cartService.ClearCart(cartId);
        }


        private void SaveRecord(RecordModel model, Payment payment, string userId)
        {
            var record = new Record();

            record.RecordNumber = new Random().Next(111111, 999999).ToString();
            record.RecordState = EnumRecordState.completed;
            record.PaymentType = EnumPaymentType.CreditCard;
            //record.PaymentId = payment.PaymentId;
            //record.ConversationId = payment.ConversationId;
            record.RecordDate = new DateTime();
            record.FirstName = model.FirstName;
            record.LastName = model.LastName;
            record.UserId = userId;
            record.Address = model.Address;
            record.Phone = model.Phone;
            record.Email = model.Email;
            record.City = model.City;
            record.Note = model.Note;

            record.RecordItems = new List<Entity.Concrete.RecordItem>();

            foreach (var item in model.CartModel.CartItems)
            {
                var recordItem = new CareerSite.Entity.Concrete.RecordItem()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    CourseId = item.CourseId
                };
                record.RecordItems.Add(recordItem);
            }
            _recordService.Create(record);
        }

        
        private Payment PaymentProcess(RecordModel model)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-OqrwiIrlhVmMGGqoi27fmxzPq7qA34S4";
            options.SecretKey = "sandbox-2bjKKuGoIoOpF6B0QLED1nWlA1QZj9YH";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111, 999999999).ToString();
            request.Price = model.CartModel.TotalPrice().ToString();
            request.PaidPrice = model.CartModel.TotalPrice().ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CardName;
            paymentCard.CardNumber = model.CardNumber;
            paymentCard.ExpireMonth = model.ExpirationMonth;
            paymentCard.ExpireYear = model.ExpirationYear;
            paymentCard.Cvc = model.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            //  paymentCard.CardNumber = "5528790000000008";
            // paymentCard.ExpireMonth = "12";
            // paymentCard.ExpireYear = "2030";
            // paymentCard.Cvc = "123";

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = model.FirstName;
            buyer.Surname = model.LastName;
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;

            foreach (var item in model.CartModel.CartItems)
            {
                basketItem = new BasketItem();
                basketItem.Id = item.CourseId.ToString();
                basketItem.Name = item.Name;
                basketItem.Category1 = "Telefon";
                basketItem.Price = item.Price.ToString();
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItems.Add(basketItem);
            }
            request.BasketItems = basketItems;
            return Payment.Create(request, options);
        }
       

    }
}
