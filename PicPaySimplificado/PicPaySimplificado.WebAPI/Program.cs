
using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Data.Context;
using PicPaySimplificado.Data.Repository;
using PicPaySimplificado.Domain;
using PicPaySimplificado.Service.Interfaces;
using PicPaySimplificado.Service.Services;

namespace PicPaySimplificado.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ICarteiraRepository, CarteiraRepository>();
            builder.Services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
            builder.Services.AddScoped<ICarteiraServices, CarteiraServices>();
            builder.Services.AddScoped<INotificacaoService, NotificacaoService>();
            builder.Services.AddScoped<ITransferenciaService, TransferenciaService>();
            builder.Services.AddHttpClient<IAutorizadorService, AutorizadorService>();
            

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
