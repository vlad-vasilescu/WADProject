using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using WADProject.Data;
using WADProject.Models;

namespace WADProject.Repositories
{
    public class CardRepository : GeneralRepository<Card>
    {
        public CardRepository(ApplicationDbContext dbContext) : base(dbContext) {}

        public IEnumerable GetUserCards(IdentityUser user)
        {
            return dbContext.Cards.Where(c => c.Holder == user);
        }
    }
}