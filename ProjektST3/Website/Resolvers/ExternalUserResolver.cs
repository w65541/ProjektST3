using Newtonsoft.Json;
using System.Net.Http.Headers;
using Website.ExternalDto;

namespace Website.Resolvers
{
    public class ExternalUserResolver
    {
        string apiUrl = "https://localhost:7195/externalUser/";
        public async Task<List<ExternalUserDto>> Get()
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("get");

                string responseData = await response.Content.ReadAsStringAsync();

                List<ExternalUserDto> result = JsonConvert.DeserializeObject<List<ExternalUserDto>>(responseData);

                return result;


            }

        }
    }
}
