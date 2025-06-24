using MAUI_Demo.ViewModels;

namespace MAUI_Demo;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}