using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorDemo.Web.Shared
{
    public partial class AppBar
    {

        [Parameter]
        public EventCallback OnDrawerToggle { get; set; }

        private Task ToggleDrawer()
        {
            return OnDrawerToggle.InvokeAsync();
        }
    }
}
