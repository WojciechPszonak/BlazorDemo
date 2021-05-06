using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Web.Shared
{
    public partial class NavMenu
    {

        [Parameter]
        public bool IsOpen { get; set; }
    }
}
