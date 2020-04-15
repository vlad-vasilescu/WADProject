using Microsoft.AspNetCore.Identity;

namespace WADProject.Models
{
    public class Account
    {
        public int Id { get; set; }
        public Currency Currency { get; set; }
        public float Balance { get; set; }
        public IdentityUser User { get; set; }
    }
}