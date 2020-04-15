using WADProject.Models;

namespace WADProject.Services
{
    public class CurrencyService
    {
        public float ConvertAmmount(Currency convertFrom, Currency convertTo, float ammount)
        {
            return (ammount / convertFrom.Weight) * convertTo.Weight;
        }
    }
}