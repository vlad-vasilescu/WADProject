using System;
using Microsoft.AspNetCore.Identity;

namespace WADProject.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CVV { get; set; }
        public IdentityUser Holder { get; set; }
        public Account Account { get; set; }
    }
}