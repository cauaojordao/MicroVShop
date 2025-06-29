using System.Text.Json;
using MicroVShop.Web.Models;
using MicroVShop.Web.Services.Interfaces;

namespace MicroVShop.Web.Services;

public class CategoryService : ICategoryService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly JsonSerializerOptions _options;
    private const string ApiEndpoint = "api/category/";

    public CategoryService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
    public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
    {
        var client = _clientFactory.CreateClient("ProductAPI");

        var response = await client.GetAsync(ApiEndpoint);
        if (!response.IsSuccessStatusCode)
            return [];

        var apiResponse = await response.Content.ReadAsStreamAsync();
        var categories = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse, _options);
        return categories ?? [];
    }
}