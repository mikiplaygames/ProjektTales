namespace ProjektTales;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(EquationUsePage), typeof(EquationUsePage));
        Routing.RegisterRoute(nameof(EquationCreatePage), typeof(EquationCreatePage));
    }
}