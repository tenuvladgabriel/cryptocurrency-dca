using CryptoDCA.Application.Models;

namespace CryptoDCA.Application.Contracts;

public interface ICryptocurrencyService
{
    Task<List<CryptocurrencyViewModel>> GetAll();
    Task Create(CryptocurrencyCreateViewModel model);
}