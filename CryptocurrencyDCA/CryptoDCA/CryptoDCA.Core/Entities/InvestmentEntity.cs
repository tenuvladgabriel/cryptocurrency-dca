namespace CryptoDCA.Core.Entities;

public class InvestmentEntity : IEntity
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal InvestedAmount { get; set; }
    public decimal CryptoAmount { get; set; }
    public decimal ValueToday { get; set; }
    public decimal ROI { get; set; }
    public int CryptocurrencyId { get; set; }
    public CryptocurrencyEntity Cryptocurrency { get; set; }
}