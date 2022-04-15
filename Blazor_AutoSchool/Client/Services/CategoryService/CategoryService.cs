namespace Blazor_AutoSchool.Client.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _http;

    public CategoryService(HttpClient http)
    {
        _http = http;
    }
    
    public List<Category> Categories { get; set; }
    
    public string Message { get; set; } = "Loading categories...";
    
    public async Task GetCategories()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
        Categories = result.Data;

        if (result == null || result.Data.Count == 0)
        {
            Message = "Categories not found.";
        }
    }
}