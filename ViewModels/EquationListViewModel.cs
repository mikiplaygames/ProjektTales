using CommunityToolkit.Mvvm.Input;
using ProjektTales.Services;
using System.Diagnostics;
using ProjektTales.Model;
using System.Collections.ObjectModel;

namespace ProjektTales.ViewModels
{
    public partial class EquationListViewModel : BaseViewModel
    {
        EquationService equationService;
        public ObservableCollection<EquationStats> Equations { get; } = new();
        
        public EquationListViewModel(EquationService equationService)
        {
            Title = "Equations";
            this.equationService = equationService;
        }
        /*
        [RelayCommand]
        async Task EnterCreateModeAsync()
        {
            
        }
        */
        [RelayCommand]
        async Task EnterEquationModeAsync(EquationStats stats)
        {
            if (stats is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(EquationUsePage)}", true, new Dictionary<string, object>
            {
                {"EquationStats", stats}
            });
        }

        [RelayCommand]
        async Task LoadEquationsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var equations = await equationService.GetEquasions();
                if (equations.Count != 0)
                    Equations.Clear();
                
                foreach (var equation in equations)
                    Equations.Add(equation);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                await Shell.Current.DisplayAlert("Error", $"Unable to load equations {e.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
