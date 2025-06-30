using MAUI_Demo_Advanced.ViewModel;

namespace MAUI_Demo_Advanced.View;

public partial class MainPage : ContentPage
{
    public MainPage(MonkeyViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}