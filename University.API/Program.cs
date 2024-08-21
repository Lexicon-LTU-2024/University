using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using University.API.Data;

namespace University.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<UniversityContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityContext") ?? throw new InvalidOperationException("Connection string 'UniversityContext' not found.")));

            builder.Services.AddControllers();

            //builder.Services.AddScoped<>
            //builder.Services.AddSingleton<>
            //builder.Services.AddTransient<>


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
}
