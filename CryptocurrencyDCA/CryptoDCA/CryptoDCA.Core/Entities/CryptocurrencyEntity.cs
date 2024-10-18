namespace CryptoDCA.Core.Entities;

public class CryptocurrencyEntity : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
}