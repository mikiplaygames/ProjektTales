using System.Net.Http.Json;
using System.Text.Json;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace ProjektTales.Services
{
    public class EquationService
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "equations.json");

        HttpClient httpClient;
        public EquationService()
        {
            this.httpClient = new HttpClient();
        }
        
        List<EquationStats> equations;

        public async Task<List<EquationStats>> GetEquasionsAsync()
        {
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;
            if (accessType == NetworkAccess.Internet)
            {
                var response = await httpClient.GetAsync("https://raw.githubusercontent.com/mikiplaygames/JsonData/main/equations.json");
                if (response.IsSuccessStatusCode)
                {
                    equations = await response.Content.ReadFromJsonAsync<List<EquationStats>>();
                }
                else
                {
                    using var stream = await FileSystem.OpenAppPackageFileAsync("equations.json");
                    using var reader = new StreamReader(stream);
                    var contents = await reader.ReadToEndAsync();
                    equations = JsonSerializer.Deserialize<List<EquationStats>>(contents);

                    await Toast.Make("No Internet Connection, loading defaults", ToastDuration.Long).Show();
                }
            }
            else
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("equations.json");
                using var reader = new StreamReader(stream);
                var contents = await reader.ReadToEndAsync();
                equations = JsonSerializer.Deserialize<List<EquationStats>>(contents);

                await Toast.Make("No Internet Connection, loading defaults", ToastDuration.Long).Show();
            }
            
            return equations;
        }
    }
}