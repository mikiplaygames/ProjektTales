using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjektTales.ViewModels;

[QueryProperty("EquationStats", "EquationStats")]
public partial class EquationUseViewModel : BaseViewModel
{
    public EquationUseViewModel()
    {
        
    }

    [ObservableProperty]
    EquationStats equationStats;
}