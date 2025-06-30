using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUI_Demo_Advanced.ViewModel;

namespace MAUI_Demo_Advanced.View;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(MonkeyDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}