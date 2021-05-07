using BlazorDemo.Configuration;
using BlazorDemo.Database;
using BlazorDemo.Mapper;
using BlazorDemo.Repositories;
using BlazorDemo.Worker.Handlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorDemo.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<RabbitMqOptions>(hostContext.Configuration.GetSection("RabbitMqOptions"));

                    services.AddHostedService<Worker>();

                    services.AddDbContext<BlazorDbContext>(options => options.UseSqlServer(hostContext.Configuration.GetConnectionString("BlazorDb")));
                    services.AddAutoMapper(typeof(SurveyProfile));
                    services.AddMediatR(
                        typeof(AddSurveyHandler),
                        typeof(EditSurveyHandler));

                    services.AddScoped<SurveyRepository>();
                });
    }
}
