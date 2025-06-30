using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUI_Demo_Advanced.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    public BaseViewModel() { }
    
    [ObservableProperty]
    string title = string.Empty;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;
    
    public bool IsNotBusy => !IsBusy;

}