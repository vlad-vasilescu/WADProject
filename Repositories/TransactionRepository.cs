using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using WADProject.Data;
using WADProject.Models;

namespace WADProject.Repositories
{
    public class TransactionRepository : GeneralRepository<Transaction>
    {
        public TransactionRepository(ApplicationDbContext dbContext) : base(dbContext) {}

        public IEnumerable GetUserTransactions(IdentityUser user)
        {
            return dbContext.Transactions.Where(t => t.Sender == user);
        }
    }
}