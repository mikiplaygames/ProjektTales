namespace ProjektTales;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ObliczeniaMatematyczne), typeof(ObliczeniaMatematyczne));
	}
}