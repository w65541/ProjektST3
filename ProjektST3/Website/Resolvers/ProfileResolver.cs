using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Website.ExternalDto;

namespace Website.Resolvers
{
    public class ProfileResolver
    {
        string apiUrl = "https://localhost:7150/profile/";
        public async Task<ProfileDto> GetByIdAsync(int id) {
            if (id == 0) id++;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("get/" + id);

                string responseData = await response.Content.ReadAsStringAsync();

                ProfileDto result = JsonConvert.DeserializeObject<ProfileDto>(responseData);

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

                HttpResponseMessage response = await client.GetAsync("delete/" + id);

            }
        }
        public async Task<List<ProfileDto>> GetAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("get");

                string responseData = await response.Content.ReadAsStringAsync();

                List<ProfileDto> result = JsonConvert.DeserializeObject<List<ProfileDto>>(responseData);

                return result;


            }
        }
        public async Task Add(ProfileDto dto)
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
            public async Task Update(int id,ProfileDto dto) {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var jsonData = JsonConvert.SerializeObject(dto);
                var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("update/"+id, contentData);


            }


        }
    }
}
