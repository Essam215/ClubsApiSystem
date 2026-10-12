using ClubManagmentSystem.Data;
using ClubManagmentSystem.Repos.Implementations;
using ClubManagmentSystem.Repos.Interfaces;
using ClubManagmentSystem.UOW;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMemberRepo, MemberRepo>();
builder.Services.AddScoped<IBookingRepo, BookingRepo>();
builder.Services.AddScoped<IFacilityRepo, FacilityRepo>();
builder.Services.AddScoped<IMemberShipRepo, MemberShipRepo>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<ClubContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
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
