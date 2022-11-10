using ProjektTales.ViewModels;

namespace ProjektTales;

public partial class MainPage : ContentPage
{
	public MainPage(EquationListViewModel equationListView)
	{
		InitializeComponent();
		BindingContext = equationListView;
	}

    async void Create_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(EquationUsePage));
    }
}