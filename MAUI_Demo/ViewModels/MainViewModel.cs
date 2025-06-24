using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Demo.Views;

namespace MAUI_Demo.ViewModels;

public partial class MainViewModel : ObservableObject
{
    
    private readonly IConnectivity connectivity;

    // this attribute generates a property called Text with a backing field in a separate file
    [ObservableProperty]
    string text;

    [ObservableProperty]
    ObservableCollection<string> items;
    
    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        Text = string.Empty;
        this.connectivity = connectivity;
    }


    [RelayCommand]
    async void Add()
    {
        if (string.IsNullOrWhiteSpace(Text)) return;
        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No Internet Connection",
                "Please check your internet connection and try again.", "OK");
                return;
        }
        Items.Add(Text); // add a new task to the list
        Text = string.Empty; // clear the text box
    }

    [RelayCommand]
    void Delete(string item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item); // remove the task from the list
        }
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }
}