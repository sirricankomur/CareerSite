using CareerSite.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CareerSite.MvcWebUI.Models
{
    public class RecordListModel
    {
        public int RecordId { get; set; }
        public string RecordNumber { get; set; }
        public DateTime RecordDate { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public EnumRecordState RecordState { get; set; }
        public List<RecordItemModel> RecordItems { get; set; }

        public double TotalPrice()
        {
            return RecordItems.Sum(i => i.Price * i.Quantity);
        }
    }

}
