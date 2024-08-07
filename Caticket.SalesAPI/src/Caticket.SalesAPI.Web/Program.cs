using Caticket.SalesAPI.Web.Middlewares;
using Caticket.SalesAPI.Identity.Services;
using Caticket.SalesAPI.Core.Services;
using Caticket.SalesAPI.Infrastructure.Services;
using Caticket.SalesAPI.Web.Endpoints.Authentication;
using FluentValidation;
using Caticket.SalesAPI.Application.Validators;
using Caticket.SalesAPI.Web.Endpoints;
using Caticket.SalesAPI.Web.Services;
using Caticket.SalesAPI.Identity.DTOs.Request;

string AllowSpecificOrigins = "AllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: AllowSpecificOrigins,
        policy  =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
            }
        );
});

builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.ConfigureIdentity(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddCoreServices(builder.Configuration);

builder.Services.AddScoped<IValidator<UserSignUpRequest>, UserSignUpValidator>();
builder.Services.AddScoped<IValidator<UserLoginRequest>, UserLoginValidator>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<UserProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIdentity();
app.UseCors(AllowSpecificOrigins);
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.MapEventsEndpoints();
app.MapUserEndpoints();

app.Run();
