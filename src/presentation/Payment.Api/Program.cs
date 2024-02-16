
using Microsoft.EntityFrameworkCore;
using Payment.Application.Features.Merchants.Commands;
using Payment.Domain.Entities;

namespace Payment.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add services to the container.
            builder.Services.AddDbContext<PaymentContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("Server=.\\SQLEXPRESS;Database=PaymentDB;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False;")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddMediatR(opt => {
                opt.RegisterServicesFromAssembly(typeof(CreateMerchant).Assembly);
            });

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
}
