using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Catalog.STA0020_Material_Supplier_LOTNOs;
using ViewModels.Common;

namespace ApiIntergration
{
    public class STA0020MaterialSupplierApiClient : ISTA0020MaterialSupplierApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public STA0020MaterialSupplierApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<ApiResult<bool>> Create(STA0020_Material_Supplier_LOTNOCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");


            //return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(await checkExist.Content.ReadAsStringAsync());

            var response = await client.PostAsync($"api/Infomation/createMaterialSupplier", httpContent);

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

        public async Task<ApiResult<STA0020_Material_Supplier_LOTNOViewModel>> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var response = await client.GetAsync($"api/Infomation/GetMaterialSupplierById/{id}");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<STA0020_Material_Supplier_LOTNOViewModel>>(content);

            return data;
        }

        public async Task<ApiResult<IEnumerable<STA0020_Material_Supplier_LOTNOViewModel>>> GetList(string? matCDSearch, string? typeSearch)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var response = await client.GetAsync($"api/Infomation/GetMaterialSupplier/{typeSearch}/{matCDSearch}");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<STA0020_Material_Supplier_LOTNOViewModel>>>(content);

            return data;
        }


        public async Task<ApiResult<IEnumerable<STA0020_Material_InventoryViewModel>>> GetInventoryList()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["WareHouseAddress"]);

            var response = await client.GetAsync($"api/Infomation/GetInventory");

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiSuccessResult<IEnumerable<STA0020_Material_InventoryViewModel>>>(content);

            return data;
        }

       
    }
}
