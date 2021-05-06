using MudBlazor;

namespace BlazorDemo.Web.Shared
{
    public partial class MainLayout
    {
        private bool isDrawerOpen = true;

        private void ToggleDrawer()
        {
            isDrawerOpen = !isDrawerOpen;
        }

        private readonly MudTheme blazorDemoTheme = new()
        {
            Palette = new Palette
            {
                Primary = Colors.Teal.Darken1,
                Secondary = Colors.Yellow.Darken3,
                Tertiary = Colors.LightBlue.Default
            },
            LayoutProperties = new LayoutProperties
            {
                DrawerWidthLeft = "300px"
            }
        };
    }
}
