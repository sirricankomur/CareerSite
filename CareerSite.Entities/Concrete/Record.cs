using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerSite.Entities.Concrete
{
    public class Record
    {
        public int Id { get; set; }
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
        public string PaymentId { get; set; }
        public string ConversationId { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public EnumRecordState RecordState { get; set; }
        public List<RecordItem> RecordItems { get; set; }
    }

    public enum EnumPaymentType
    {
        CreditCard = 0,
        Eft = 1
    }

    public enum EnumRecordState
    {
        waiting = 0,
        unpaid = 1,
        completed = 2
    }
}
