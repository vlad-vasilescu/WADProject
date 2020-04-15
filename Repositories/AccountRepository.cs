using System.Collections;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using WADProject.Data;
using WADProject.Models;
using WADProject.Repositories.Abstractions;

namespace WADProject.Repositories
{
    public class AccountRepository : GeneralRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext) {}

        public IEnumerable GetUserAccounts(IdentityUser user)
        {
            return dbContext.Accounts.Where(a => a.User == user);
        }
    }
}