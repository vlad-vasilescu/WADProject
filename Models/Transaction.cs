using System;
using Microsoft.AspNetCore.Identity;

namespace WADProject.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public IdentityUser Sender { get; set; }
        public IdentityUser Receiver { get; set; }
        public float Balance { get; set; }
        public Currency Currency { get; set; }
        public DateTime Date { get; set; }
    }
}