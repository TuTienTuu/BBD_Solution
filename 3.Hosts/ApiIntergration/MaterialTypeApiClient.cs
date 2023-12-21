using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.MaterialTypes;
using ViewModels.Common;

namespace ApiIntergration
{
    public class MaterialTypeApiClient : IMaterialTypeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public MaterialTypeApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<ApiResult<bool>> Create(MaterialTypeCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"api/material/creatematerialtype", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.DeleteAsync($"api/material/deletematerialType/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ApiResult<MaterialTypeViewModel>> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"api/material/getmaterialtypebyid/{id}");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<MaterialTypeViewModel>>(content);

            return data;
        }

        public async Task<ApiResult<IEnumerable<MaterialTypeViewModel>>> GetList()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"api/material/getmaterialtype");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<MaterialTypeViewModel>>>(content);

            return data;
        }

        public async Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"api/material/getmaterialtypeselectlist");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<SelectItem>>>(content);

            return data;
        }

        public async Task<ApiResult<bool>> Update(int id, MaterialTypeUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"api/material/updatematerialtype/{id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(await response.Content.ReadAsStringAsync());
        }
    }
}
