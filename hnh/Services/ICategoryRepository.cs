using hnh.Models;
namespace hnh.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryVM> GetCategories();
        CategoryVM GetCategory(int id);
        CategoryVM AddCategory(CategoryVM category);
        void UpdateCategory(CategoryVM category);
        void DeleteCategory(int id);
        bool CategoryExists(int id);
        bool Save();
    }
}
