using CryptoDCA.Application.Contracts;
using CryptoDCA.Application.Models;
using CryptoDCA.Core.Entities;
using CryptoDCA.Infrastructure.Contracts;

namespace CryptoDCA.Application.Services;

public class CryptocurrencyService(IGenericRepository<CryptocurrencyEntity> cryptoRepository) : ICryptocurrencyService
{
    public async Task<List<CryptocurrencyViewModel>> GetAll()
    {
        var entities = await cryptoRepository.GetAllAsync();
        if (entities.Count is 0)
            return Enumerable.Empty<CryptocurrencyViewModel>().ToList();

        return entities
            .Select(entity => new CryptocurrencyViewModel(entity.Id, entity.Name, entity.Symbol, entity.CurrentPrice))
            .ToList();
    }

    public Task Create(CryptocurrencyCreateViewModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.Symbol))
            return Task.CompletedTask;

        return cryptoRepository.AddAsync(new CryptocurrencyEntity
            { Name = model.Name, Symbol = model.Symbol, CurrentPrice = model.CurrentPrice });
    }
}