using CryptoDCA.Application.Models;

namespace CryptoDCA.Application.Contracts;

public interface IInvestmentService
{
    Task<List<InvestmentRequestViewModel>> GetInvestmentsByMonthAsync();
    Task SaveInvestmentAsync(InvestmentRequestViewModel model);
}