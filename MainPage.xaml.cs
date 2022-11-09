using System.Diagnostics;

namespace ProjektTales;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	async void Option1Bt_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(ObliczeniaMatematyczne));
	}
}