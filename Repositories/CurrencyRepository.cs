using WADProject.Data;
using WADProject.Models;

namespace WADProject.Repositories
{
    public class CurrencyRepository : GeneralRepository<Currency>
    {
        public CurrencyRepository(ApplicationDbContext dbContext) : base(dbContext) {}
    }
}