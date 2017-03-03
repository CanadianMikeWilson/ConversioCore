using System.Collections.Generic;

namespace ConversioCore
{
    public class SendReceiptRequest
    {
        public SendReceiptRequest()
        {
            Items = new HashSet<SendReceiptPaymentItem>();
        }
        public string Reference { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string AmountNotes { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Date { get; set; }
        public SendReceiptBillingRequest Billing { get; set; }
        public SendReceiptAddress Shipping { get; set; }
        public SendReceiptPaymentRequest Payment { get; set; }
        public ICollection<SendReceiptPaymentItem> Items { get; set; }
        public SendReceiptSubtotalRequest Subtotals { get; set; }
    }

    public class SendReceiptBillingRequest
    {
        public SendReceiptAddress Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class SendReceiptAddress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
    }

    public class SendReceiptPaymentRequest
    {
        public string Type { get; set; }
        public string Last4 { get; set; }
    }
    
    public class SendReceiptPaymentItem
    {
        public SendReceiptPaymentItem()
        {
            Metas = new HashSet<IDictionary<string,string>>();
        }
        public string Reference { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Amount { get; set; }
        public string Image { get; set; }
        public ICollection<IDictionary<string, string>> Metas { get; set; }
    }

    public class SendReceiptSubtotalRequest
    {
        public string Description { get; set; }
        public string Amount { get; set; }
    }
}