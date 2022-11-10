using System.Text.Json;

namespace ProjektTales.Services
{
    public class EquationService
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "equations.json");
        
        List<EquationStats> equations;

        public async Task<List<EquationStats>> GetEquasions()
        {
            
            using var stream = await FileSystem.OpenAppPackageFileAsync("equations.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            equations = JsonSerializer.Deserialize<List<EquationStats>>(contents);

            return equations;
        }
    }
}