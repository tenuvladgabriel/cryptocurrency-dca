using CryptoDCA.Application.Contracts;
using CryptoDCA.Application.Models;
using CryptoDCA.Core.Entities;
using CryptoDCA.Infrastructure.Contracts;

namespace CryptoDCA.Application.Services;

public class InvestmentService(IGenericRepository<InvestmentEntity> investmentRepository) : IInvestmentService
{
    public async Task<List<InvestmentRequestViewModel>> GetInvestmentsByMonthAsync()
    {
        var entities = await investmentRepository.GetAllAsync();
        if (entities.Count is 0)
            return Enumerable.Empty<InvestmentRequestViewModel>().ToList();

        return entities
            .Select(entity => new InvestmentRequestViewModel(
                entity.CryptocurrencyId,
                entity.Date,
                entity.InvestedAmount,
                entity.CryptoAmount,
                entity.ValueToday,
                entity.ROI))
            .ToList();
    }


    public Task SaveInvestmentAsync(InvestmentRequestViewModel model)
    {
        if (model.CryptocurrencyId == default || model.CryptoAmount == default || model.ValueToday == default ||
            model.ROI <= 0)
            return Task.CompletedTask;

        return investmentRepository.AddAsync(new InvestmentEntity
        {
            Date = model.Date,
            CryptoAmount = model.CryptoAmount,
            CryptocurrencyId = model.CryptocurrencyId,
            InvestedAmount = model.InvestedAmount,
            ValueToday = model.ValueToday,
            ROI = model.ROI
        });
    }
}