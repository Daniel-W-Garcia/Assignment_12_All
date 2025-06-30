using System.Net.Http.Json;
using MAUI_Demo_Advanced.Model;

namespace MAUI_Demo_Advanced.Service;

public class MonkeyService
{
    HttpClient _httpClient;
    List<Monkey>? _monkeys = new();
    
    public MonkeyService()
    {
        _httpClient = new HttpClient();
    }
    
    public async Task<List<Monkey>?> GetMonkeys()
    {
        if (_monkeys?.Count > 0)
        {
            return _monkeys;
        }

        var url = "https://montemagno.com/monkeys.json";
        var response = await _httpClient.GetAsync(url);
        
        if(response.IsSuccessStatusCode)
        {
            _monkeys = await response.Content.ReadFromJsonAsync<List<Monkey>>();
        }
        return _monkeys;
    }
}