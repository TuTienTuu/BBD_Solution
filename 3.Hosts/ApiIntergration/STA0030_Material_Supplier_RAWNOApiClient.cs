using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0030_Material_Supplier_RAWNOs;
using ViewModels.Common;

namespace ApiIntergration
{
    public class STA0030_Material_Supplier_RAWNOApiClient : ISTA0030_Material_Supplier_RAWNOApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public STA0030_Material_Supplier_RAWNOApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<ApiResult<STA0030_Material_Supplier_RAWNOViewModel>> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var response = await client.GetAsync($"api/Infomation/GetMaterialMasterSupplierRawNoById/{id}");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<STA0030_Material_Supplier_RAWNOViewModel>>(content);

            return data;
        }

        public async Task<ApiResult<IEnumerable<STA0030_Material_Supplier_RAWNOViewModel>>> GetList(string matCD)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);
            var response = new HttpResponseMessage();
            if (!string.IsNullOrEmpty(matCD))
                response = await client.GetAsync($"api/Infomation/GetMaterialMasterSupplierRawNo/{matCD}");
            else
                response = await client.GetAsync($"api/Infomation/GetMaterialMasterSupplierRawNo");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<STA0030_Material_Supplier_RAWNOViewModel>>>(content);

            return data;
        }

        public async Task<ApiResult<IEnumerable<STA0030_Material_Supplier_RAWNOViewModel>>> GetListByLotNo(string lotNo)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);
            var response = new HttpResponseMessage();
           // if (!string.IsNullOrEmpty(lotNo))
                response = await client.GetAsync($"api/Infomation/GetMaterialMasterSupplierRawNoFollowLotNo/{lotNo}");
          

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<STA0030_Material_Supplier_RAWNOViewModel>>>(content);

            return data;
        }
    }
}
