using ProjektTales.ViewModels;

namespace ProjektTales;

public partial class MainPage : ContentPage
{
	public MainPage(EquationListViewModel equationListView)
	{
		InitializeComponent();
		BindingContext = equationListView;
	}
}