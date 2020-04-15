using System.Collections;
using Microsoft.AspNetCore.Identity;
using WADProject.Models;

namespace WADProject.Repositories.Abstractions
{
    public interface IAccountRepository : IGeneralRepository<Account>
    {
        public IEnumerable GetUserAccounts(IdentityUser user);
    }
}