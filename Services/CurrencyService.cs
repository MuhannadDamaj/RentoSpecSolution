using RentospectWebAPI.Data.Rentospect;
using RentospectShared.DTOs;
using RentospectWebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace RentospectWebAPI.Services
{
    public class CurrencyService
    {
        private readonly RentospectContext _context;
        public CurrencyService(RentospectContext rentospectContext)
        {
            _context = rentospectContext;
        }
        public async Task<CustomApiResponce> SaveCurrencyAsync(CurrencyDto currencyDto)
        {
            bool currecyexist = await _context.Currencies.AsNoTracking().AnyAsync(c => c.Name == currencyDto.Name
                                                                                      &&
                                                                                      c.ID != currencyDto.ID);
            if (currecyexist)
                return CustomApiResponce.Error("Currency with same is exist already");
            if (currencyDto.ID == 0)
            {
                var currency = new Currency()
                {
                    Name = currencyDto.Name,
                    Symbol = currencyDto.Symbol,
                    IsActive = currencyDto.IsActive,
                };
                _context.Currencies.Add(currency);
            }
            else
            {
                var dbCurrency = await _context.Currencies
                                  .FirstOrDefaultAsync(curr => curr.ID == currencyDto.ID);
                if (dbCurrency == null)
                    return CustomApiResponce.Error("Currency does not exist");
                dbCurrency.Name = currencyDto.Name;
                dbCurrency.Symbol = currencyDto.Symbol;
                dbCurrency.IsActive = currencyDto.IsActive;
                _context.Currencies.Update(dbCurrency);
            }
            await _context.SaveChangesAsync();
            return CustomApiResponce.Success();
        }
        public async Task<CurrencyDto[]> GetCurrenciesAsync() => await _context.Currencies
                                                                           .AsNoTracking()
                                                                           .Select(c => new CurrencyDto
                                                                           {
                                                                               ID = c.ID,
                                                                               Name = c.Name,
                                                                               Symbol = c.Symbol,
                                                                               IsActive = c.IsActive,
                                                                           }).ToArrayAsync();
    }
}
