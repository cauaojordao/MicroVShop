using System.Text;
using System.Text.Json;
using MicroVShop.Web.Models;
using MicroVShop.Web.Services.Interfaces;

namespace MicroVShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string ApiEndpoint = "api/product/";
        private readonly JsonSerializerOptions _options;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            var client = _clientFactory.CreateClient("ProductAPI");

            var response = await client.GetAsync(ApiEndpoint);
            if (!response.IsSuccessStatusCode)
                return [];

            var apiResponse = await response.Content.ReadAsStreamAsync();
            var products = await JsonSerializer.DeserializeAsync<IEnumerable<ProductViewModel>>(apiResponse, _options);
            return products ?? [];
        }

        public async Task<ProductViewModel?> GetByIdAsync(int id)
        {
            var client = _clientFactory.CreateClient("ProductAPI");

            var response = await client.GetAsync(ApiEndpoint + id);
            if (!response.IsSuccessStatusCode)
                return null;

            var apiResponse = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
        }

        public async Task<ProductViewModel?> CreateAsync(ProductViewModel productVM)
        {
            var client = _clientFactory.CreateClient("ProductAPI");

            var content = new StringContent(
                JsonSerializer.Serialize(productVM),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync(ApiEndpoint, content);
            if (!response.IsSuccessStatusCode)
                return null;

            var apiResponse = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ProductViewModel>(apiResponse, _options);
        }

        public async Task<bool> UpdateAsync(ProductViewModel product)
        {
            var client = _clientFactory.CreateClient("ProductAPI");

            var content = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PutAsync(ApiEndpoint + product.Id, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = _clientFactory.CreateClient("ProductAPI");

            var response = await client.DeleteAsync(ApiEndpoint + id);
            return response.IsSuccessStatusCode;
        }
    }
}
