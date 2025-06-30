using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using MAUI_Demo_Advanced.Model;
using MAUI_Demo_Advanced.Service;
using MAUI_Demo_Advanced.View;

namespace MAUI_Demo_Advanced.ViewModel;

public partial class MonkeyViewModel : BaseViewModel
{
    MonkeyService monkeyService;
    IConnectivity connectivity;
    IGeolocation geolocation;

    public ObservableCollection<Monkey> Monkeys { get; } = new();

    public MonkeyViewModel(MonkeyService monkeyService, IConnectivity connectivity, IGeolocation geolocation)
    {
        this.monkeyService = monkeyService;
        this.connectivity = connectivity;
        this.geolocation = geolocation;
        Title = "Monkey Finder App";
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy) return;
        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No Internet Connection",
                    "Please check your internet connection and try again.", "OK");
                return;
            }

            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();
            if (Monkeys.Count > 0)
            {
                Monkeys.Clear();
            }

            foreach (var monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GetClosestMonkey()
    {
        if (IsBusy || Monkeys.Count == 0) return;
        try
        {
            IsBusy = true;
            var location = await geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }
            var first = Monkeys.OrderBy(x => location.CalculateDistance(
                x.Latitude, x.Longitude, DistanceUnits.Kilometers)).FirstOrDefault();
            if (first == null)
            {
                await Shell.Current.DisplayAlert("No Monkeys", "There are no monkeys nearby.", "OK");
                return;
            }
            await Shell.Current.DisplayAlert("Closest Monkey",
                $"The closest monkey is {first.Name} at {first.Latitude}, {first.Longitude}.", "OK");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    [RelayCommand]
    async Task GoToDetails(Monkey monkey)
    {
        if(monkey == null) return;
        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true, new Dictionary<string, object>
        {
            { "Monkey", monkey }
        });
    }
}