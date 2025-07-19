using System;

namespace TitanApp.Models
{
    public class SubscriptionLogs
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; } = "";
        public string PurchaseName { get; set; } = "";
        public decimal Cost { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime AppliedAt { get; set; }
        public DateTime NewSubscriptionEnd { get; set; }
        public int? SessionsAdded { get; set; }
        public bool Unlimited { get; set; }
    }
}
