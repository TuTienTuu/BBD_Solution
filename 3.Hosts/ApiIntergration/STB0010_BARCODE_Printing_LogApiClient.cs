using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STB0010_BARCODE_Printing_Logs;
using ViewModels.Common;

namespace ApiIntergration
{
    public class STB0010_BARCODE_Printing_LogApiClient : ISTB0010_BARCODE_Printing_LogApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public STB0010_BARCODE_Printing_LogApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<ApiResult<bool>> Create(STB0010_BARCODE_Printing_LogCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");


            //return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await checkExist.Content.ReadAsStringAsync());

            var response = await client.PostAsync($"api/Tracking/CreateMaterialExportTracking", httpContent);

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

        public async Task<ApiResult<STB0010_BARCODE_Printing_LogViewModel>> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var response = await client.GetAsync($"api/Tracking/GetMaterialExportTrackingById/{id}");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<STB0010_BARCODE_Printing_LogViewModel>>(content);

            return data;
        }

        public async Task<ApiResult<IEnumerable<STB0010_BARCODE_Printing_LogViewModel>>> GetList()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var response = await client.GetAsync($"api/Tracking/GetMaterialExportTracking");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<STB0010_BARCODE_Printing_LogViewModel>>>(content);

            return data;
        }
    }
}
