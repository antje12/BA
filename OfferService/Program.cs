using ClassLibrary.Data_Brokers;
using ClassLibrary.Interfaces;
using OfferService.Data_Providers;
using OfferService.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IDataProvider, MySQLDataProvider>();
builder.Services.AddTransient<IJobService, JobBroker>();
builder.Services.AddTransient<IContractService, ContractBroker>();

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
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
