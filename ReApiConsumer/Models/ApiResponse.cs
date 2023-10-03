using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using ReApiConsumer.Models.Interfaces;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Policy;

namespace ReApiConsumer.Models
{
    public class ApiResponse<T , Dto> 
    {
        private string url = "http://localhost:5000";
        HttpClient client = new HttpClient();

        public ApiResponse()
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<T> Delete(string api)
        {
            HttpResponseMessage Del = await client.DeleteAsync(api);
            return await Del.Content.ReadAsAsync<T>();
        }

        public async Task<List<T>> Get(string Api)
        {
          
            HttpResponseMessage Res = await client.GetAsync(Api);
            List<T>? list = new List<T>();
            if (Res.IsSuccessStatusCode)
            {
                var EmpResponcse = Res.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<T>>(EmpResponcse);
            }

            return list;
        }

        public async Task<T> GetById(string Api)
        {
            List<T> response = new List<T>();
            HttpResponseMessage Res = await client.GetAsync(Api);
            if(Res.IsSuccessStatusCode)
            {
                var result = await Res.Content.ReadAsAsync<T>();
                return result;
            }

            return response[0];
        }

        //put
        public async Task<Dto> Update(string Api, Dto entity)
        {
            HttpResponseMessage Res = await client.PutAsJsonAsync(Api, entity);

            Res.EnsureSuccessStatusCode();
            entity = await Res.Content.ReadAsAsync<Dto>();
            return entity;
        }

        //post
        public async Task<Dto> Create(string Api, Dto entity)
        {
            HttpResponseMessage Res = await client.PostAsJsonAsync(Api, entity);

            Res.EnsureSuccessStatusCode();
            entity = await Res.Content.ReadAsAsync<Dto>();
            return entity;
        }
    }
}
