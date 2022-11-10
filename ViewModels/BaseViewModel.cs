using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjektTales.ViewModels
{
    [INotifyPropertyChanged]
    public partial class BaseViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;
        
        [ObservableProperty] 
        string title;

        public bool IsNotBusy => !IsBusy;
    }
}