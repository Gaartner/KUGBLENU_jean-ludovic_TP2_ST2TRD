using Newtonsoft.Json;


//using System.Text.Json;

namespace ConsoleApp1
{
    public class Service
    {
        // fetch the api at each request
        public static async Task<Root> Requete(string constrequete)
        {
            // api in clear text ready to change 
            var api = "bbe8fe51aa7d630332569e6f1e92fb77";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                // format for 
                Method = HttpMethod.Get,
                RequestUri =
                    new Uri(String.Format("https://api.openweathermap.org/data/2.5/weather?{0}&units=metric&appid={1}",constrequete,api))
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var e = await response.Content.ReadAsStringAsync();
                var objDeserial = JsonConvert.DeserializeObject<Root>(e);
                // if objDeserial is void throw exception
                return objDeserial ?? throw new InvalidOperationException();
            }
        }
    }
}