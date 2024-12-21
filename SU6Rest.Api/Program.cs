
using SU6Rest.Api.Date;
using Microsoft.EntityFrameworkCore;
using SU6Rest.Api.Services;

namespace SU6Rest.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var conString = @"Server=localhost;Database=SU6Rest;User Id=postgres;Password=123;Port=5432;";
        builder.Services.AddDbContext<AppDbContext>(
            option => option.UseNpgsql(conString)
            );
        //DI
        builder.Services.AddTransient<ICustomerService, CustomerService>();

        // Add services to the container.

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
    }
}