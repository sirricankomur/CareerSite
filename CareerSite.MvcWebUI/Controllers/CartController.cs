using CareerSite.Business.Abstract;
using CareerSite.MvcWebUI.Models;
using CareerSite.MvcWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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

        /*[HttpPost]
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
        */
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


        private void SaveRecord(RecordModel model, string userId)
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
    }
}
