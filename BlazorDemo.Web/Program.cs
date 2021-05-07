using BlazorDemo.Web.Repositories;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Refit;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorDemo.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var refitSettings = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new ObjectToInferredTypesConverter() }
                })
            };
            builder.Services
                .AddRefitClient<IQuestionRepository>(refitSettings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:8081/api/Questions"));
            builder.Services
                .AddRefitClient<ISurveyRepository>(refitSettings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:8081/api/Surveys"));

            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}
