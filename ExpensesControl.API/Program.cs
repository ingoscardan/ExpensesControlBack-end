using System.Configuration;
using System.Reflection;
using ExpensesControl.API.Services;
using ExpensesControl.Rdb;
using ExpensesControl.Services;
using ExpensesControl.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<PgSqlDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ExpensesControl")));
builder.Services.AddScoped<ICreditBucketService, CreditBucketService>();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
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