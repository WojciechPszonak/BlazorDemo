﻿using BlazorDemo.Models.Weather;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorDemo.Web.Pages
{
    public partial class FetchData
    {
        private List<WeatherForecast> forecasts;

        [Inject]
        private HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetFromJsonAsync<List<WeatherForecast>>("WeatherForecast");
        }
    }
}
