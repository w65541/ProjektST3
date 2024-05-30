using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Website.ExternalDto;

namespace Website.Resolvers
{
    public class UserResolver
    {
        string apiUrl = "https://localhost:7014/user/";
        public async Task<List<UserDto>> Get()
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("get");

                string responseData = await response.Content.ReadAsStringAsync();

                List<UserDto> result = JsonConvert.DeserializeObject<List<UserDto>>(responseData);

                return result;


            }

        }

        public async Task<UserDto> GetById(int id)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("get/" + id);

                string responseData = await response.Content.ReadAsStringAsync();

                List<UserDto> result = JsonConvert.DeserializeObject<List<UserDto>>(responseData);

                return result.FirstOrDefault();


            }

        }

        public async void Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("delete/" + id);

            }
        }
        public async Task Add(UserDto dto)
        {
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
