using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.Soles;
using ViewModels.Common;

namespace ApiIntergration
{
    public class SoleApiClient : ISoleApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public SoleApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<ApiResult<bool>> Create(SoleCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"api/paper/createsole", httpContent);

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

            var response = await client.DeleteAsync($"api/paper/deletesole/{id}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ApiResult<SoleViewModel>> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"api/paper/getsolebyid/{id}");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<SoleViewModel>>(content);

            return data;
        }

        public async Task<ApiResult<IEnumerable<SoleViewModel>>> GetList()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"api/paper/getsole");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<SoleViewModel>>>(content);

            return data;
        }

        public async Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var response = await client.GetAsync($"api/paper/getsoleselectlist");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<SelectItem>>>(content);

            return data;
        }

        public async Task<ApiResult<bool>> Update(int id, SoleUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"api/paper/updatesole/{id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(await response.Content.ReadAsStringAsync());
        }
    }
}
