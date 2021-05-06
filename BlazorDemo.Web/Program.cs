using BlazorDemo.Web.Repositories;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Refit;
using System;
using System.Threading.Tasks;

namespace BlazorDemo.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddRefitClient<IQuestionRepository>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:8081/api/Questions"));

            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}
