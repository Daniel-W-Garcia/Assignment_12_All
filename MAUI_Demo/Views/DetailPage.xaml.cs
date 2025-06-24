using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUI_Demo.ViewModels;

namespace MAUI_Demo.Views;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}