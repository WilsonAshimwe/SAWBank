using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using SAWBank.BLL.Infrastructures;
using SAWBank.BLL.Interfaces;
using SAWBank.DAL;
using System.Net.Mail;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//EnumConverter
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});



builder.Services.AddDbContext<SAWBankContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


//mail
builder.Services.AddScoped<SmtpClient>();
builder.Services.AddScoped<IMailer, Mailer>();
builder.Services.AddSingleton(builder.Configuration.GetSection("Mailer").Get<Mailer.MailerConfig>());
builder.Services.AddScoped<HtmlRenderer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
