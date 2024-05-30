using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Website.ExternalDto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Website.Resolvers
{
    public class RejectionResolver
    {
        string apiUrl = "https://localhost:7200/rejection/";
        public async Task<List<RejectionDto>> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("get");

                string responseData = await response.Content.ReadAsStringAsync();

                List<RejectionDto> result = JsonConvert.DeserializeObject<List<RejectionDto>>(responseData);

                return result;


            }
        }
        public async void Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("delete/"+id);

            }
        }
        public async Task Add(RejectionDto dto) {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                

                var jsonData = JsonConvert.SerializeObject(dto);
                var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("create", contentData);


            }




        }
    }
}
