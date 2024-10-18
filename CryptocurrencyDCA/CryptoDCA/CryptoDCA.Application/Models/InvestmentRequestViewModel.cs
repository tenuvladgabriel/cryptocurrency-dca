namespace CryptoDCA.Application.Models;

public record InvestmentRequestViewModel(
    int CryptocurrencyId,
    DateTime Date,
    decimal InvestedAmount,
    decimal CryptoAmount,
    decimal ValueToday,
    decimal ROI);