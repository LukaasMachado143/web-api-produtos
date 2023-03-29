using Produtos.Data.Context;
using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Interfaces.Repositories;
using Produtos.Data.Repositories;
using Produtos.Domain.Interfaces.Services;
using Produtos.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("Default"))  
);
builder.Services.AddScoped<IProdutoRepo, ProdutoRepo>();
builder.Services.AddScoped<IGeneralRepo, GeneralRepo>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
