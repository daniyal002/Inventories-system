using AutoMapper;
using Inventories.Services.StockAPI.DbContexts;
using Inventories.Services.StockAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Services.StockAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

            // Add services to the container.

            builder.Services.AddSingleton(mapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();

            builder.Services.AddScoped<IStockRepository, StockRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });


            var app = builder.Build();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


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