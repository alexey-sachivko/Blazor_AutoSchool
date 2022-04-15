namespace Blazor_AutoSchool.Client.Services.CategoryService;

public interface ICategoryService
{
    List<Category> Categories { get; set; }
    string Message { get; set; }
    Task GetCategories();
}