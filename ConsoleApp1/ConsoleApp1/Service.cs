using Newtonsoft.Json;


//using System.Text.Json;

namespace ConsoleApp1
{
    public class Service
    {
        public static async Task<Root> Requete(string constrequete)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(String.Format("https://api.openweathermap.org/data/2.5/weather?{0}&units=metric&appid=bbe8fe51aa7d630332569e6f1e92fb77",constrequete))
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var stringResult = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<Root>(stringResult);
                return obj ?? throw new InvalidOperationException();
            }
        }
    }
}
