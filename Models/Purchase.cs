using System;

namespace TitanApp.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int SessionsCount { get; set; }
        public bool Unlimited { get; set; }
        public int DurationMonths { get; set; }
        public decimal Cost { get; set; }
    }
}