using System;

namespace TitanApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string LastName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string MiddleName { get; set; } = "";
        public string Phone { get; set; } = "";
        public int PurchasedSessions { get; set; }
        public DateTime SubscriptionEnd { get; set; }
        public string Telegram { get; set; } = "";
        public string Comment { get; set; } = "";
        public bool Unlimited { get; set; }
    }
}
