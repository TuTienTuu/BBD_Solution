using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0010_Material_Masters;
using ViewModels.Common;

namespace ApiIntergration
{
    public class STA0010MaterialMasterApiClient : ISTA0010MaterialMasterApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public STA0010MaterialMasterApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<ApiResult<bool>> CheckExist(string materialCode, string groupCD)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var response = await client.GetAsync($"api/Infomation/CheckExist?materialCode={materialCode}&groupCD={groupCD}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(content);
            }
            else
            {
               return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(content);
            }
           // return data;
        }

        public async Task<ApiResult<bool>> Create(STA0010_Material_MasterCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");


            //return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await checkExist.Content.ReadAsStringAsync());

            var response = await client.PostAsync($"api/Infomation/createMaterialMaster", httpContent);

            if (response.IsSuccessStatusCode && response.Content.ReadAsStringAsync() != null)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
            }

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(await response.Content.ReadAsStringAsync());


        }

        public async Task<ApiResult<STA0010_Material_MasterViewModel>> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var response = await client.GetAsync($"api/Infomation/GetMaterialMasterById/{id}");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<STA0010_Material_MasterViewModel>>(content);

            return data;
        }

        public async Task<ApiResult<IEnumerable<STA0010_Material_MasterViewModel>>> GetList()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var response = await client.GetAsync($"api/Infomation/GetMaterialMaster");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<STA0010_Material_MasterViewModel>>>(content);

            return data;
        }

        public async Task<ApiResult<IEnumerable<SelectItem>>> GetSelectList(string? matCDSearch)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var response = await client.GetAsync($"api/Infomation/GetMaterialMasterselectlist/{matCDSearch}");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<SelectItem>>>(content);

            return data;
        }

        public async Task<ApiResult<bool>> Update(int id, STA0010_Material_MasterUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"api/Infomation/updateMaterialMaster/{id}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(await response.Content.ReadAsStringAsync());
        }
    }
}
