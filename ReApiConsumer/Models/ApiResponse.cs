using Newtonsoft.Json;
using ReApiConsumer.Models.Interfaces;
using System.Net.Http.Headers;

namespace ReApiConsumer.Models
{
    public class ApiResponse<T> 
    {
        private string url = "http://localhost:5000";

        public Task<T> Delete(string api, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> Get(string Api )
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage Res = await client.GetAsync(Api);
            List<T> list = new List<T>();
            if (Res.IsSuccessStatusCode)
            {
                var EmpResponcse = Res.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<T>>(EmpResponcse);
            }

            return list;
        }

        public Task<List<T>> GetById(string api, int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Post(string api, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Put(string api, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
