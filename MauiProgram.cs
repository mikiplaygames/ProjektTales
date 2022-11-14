global using ProjektTales.Model;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ProjektTales.Services;
using ProjektTales.ViewModels;

namespace ProjektTales;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<EquationListViewModel>();

        builder.Services.AddTransient<EquationUsePage>();
        builder.Services.AddTransient<EquationUseViewModel>();

        builder.Services.AddSingleton<EquationService>();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
