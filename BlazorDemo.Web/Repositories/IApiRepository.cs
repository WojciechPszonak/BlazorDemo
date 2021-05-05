using BlazorDemo.Models.Weather;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.Web.Repositories
{
    public interface IApiRepository
    {
        [Get("/WeatherForecast")]
        Task<IEnumerable<WeatherForecast>> GetAsync();
    }
}
