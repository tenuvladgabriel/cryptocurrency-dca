using CryptoDCA.API.Endpoints;
using CryptoDCA.Application.Contracts;
using CryptoDCA.Application.Services;
using CryptoDCA.Infrastructure;
using CryptoDCA.Infrastructure.Context;
using CryptoDCA.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
builder.Services.AddDbContext<CryptoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IInvestmentService, InvestmentService>();
builder.Services.AddScoped<ICryptocurrencyService, CryptocurrencyService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.RegisterCryptocurrenciesEndpoints();
app.RegisterInvestmentEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.Run();