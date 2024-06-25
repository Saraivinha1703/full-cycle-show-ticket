using Caticket.PartnerAPI.Core.Services;
using Caticket.PartnerAPI.Infrastructure.Services;
using Caticket.PartnerAPI.Web.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDatabase();
builder.Services.AddCoreServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEventEndpoints();
app.MapSpotEndpoints();

app.Run();

