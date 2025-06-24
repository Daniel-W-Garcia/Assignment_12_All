using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MAUI_Demo.ViewModels;

[QueryProperty("Text", "Text")]
public partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task GoToMainPage()
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}