using BlazorDemo.Models.Weather;
using BlazorDemo.Web.Repositories;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.Web.Pages
{
    public partial class FetchData
    {
        private IEnumerable<WeatherForecast> forecasts;

        [Inject]
        private IApiRepository ApiRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            forecasts = await ApiRepository.GetAsync();
        }
    }
}
