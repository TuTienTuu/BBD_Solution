using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA1010_Material_IN_OUT_Logs;
using ViewModels.Common;

namespace ApiIntergration
{
    public class STA1010_Material_IN_OUT_LogApiClient : ISTA1010_Material_IN_OUT_LogApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public STA1010_Material_IN_OUT_LogApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<ApiResult<IEnumerable<STA1010_Material_IN_OUT_LogViewModel>>> GetList(string? searchType, DateTime? date, string? subLot)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);
            var response = new HttpResponseMessage();

            if (date== null && string.IsNullOrEmpty(subLot))
            {
                response = await client.GetAsync($"api/Infomation/GetMaterialInOutLogList/{searchType}");
            }
            else if (date != null && !string.IsNullOrEmpty(subLot))
                response = await client.GetAsync($"api/Infomation/GetMaterialInOutLogList/{searchType}/{date.Value.ToString("yyyy-MM-dd")}/{subLot}");
            else if (date != null && string.IsNullOrEmpty(subLot))
                response = await client.GetAsync($"api/Infomation/GetMaterialInOutLogList_/{searchType}/{date.Value.ToString("yyyy-MM-dd")}");
            //https://localhost:7145/api/Infomation/GetMaterialInOutLogList_/A/2023-11-23
            else if (date == null && !string.IsNullOrEmpty(subLot))
                response = await client.GetAsync($"api/Infomation/GetMaterialInOutLogList/{searchType}/{subLot}");


            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<STA1010_Material_IN_OUT_LogViewModel>>>(content);

            return data;
        }
    }
}
