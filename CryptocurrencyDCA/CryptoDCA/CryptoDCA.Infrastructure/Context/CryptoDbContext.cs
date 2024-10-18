using CryptoDCA.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoDCA.Infrastructure.Context;

public class CryptoDbContext(DbContextOptions<CryptoDbContext> options) : DbContext(options)
{
    public DbSet<CryptocurrencyEntity> Cryptocurrencies { get; set; }
    public DbSet<InvestmentEntity> Investments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CryptocurrencyEntity>(cryptoEntity =>
        {
            cryptoEntity.ToTable("Cryptocurrencies");
            cryptoEntity.Property(e => e.Name).HasMaxLength(255);
            cryptoEntity.Property(e => e.Symbol).HasMaxLength(255);
            cryptoEntity.Property(t => t.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<InvestmentEntity>(investmentEntity =>
        {
            investmentEntity.ToTable("Investments");
            investmentEntity.Property(i => i.Id).ValueGeneratedOnAdd();
        });
    }
}