using hnh.Data;
using hnh.Models;

namespace hnh.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbcontext _context;
        public CategoryRepository(MyDbcontext context) 
        {
            _context = context;     
        }
        public CategoryVM AddCategory(CategoryVM category)
        {
            if (category == null)
        {
            throw new ArgumentNullException(nameof(category));
        }
            // them danh muc
            var ca = new Category
            {
                name = category.name,
                slug = category.slug
            };
            _context.categories.Add(ca);
            Save();
            return new CategoryVM
            {
                categoryid = ca.categoryid,
                name = ca.name,
                slug = ca.slug
            };

        }

        public bool CategoryExists(int id)
        {
            // kiem tra xem danh muc co ton tai hay khong
            return _context.categories.Any(c => c.categoryid == id);

        }

        public void DeleteCategory(int id)
        {
            // xoa danh muc
            var categoryFromDb = _context.categories.FirstOrDefault(c => c.categoryid == id);
            if (categoryFromDb == null)
            {
                throw new Exception("Không tìm thấy danh mục với id đã cung cấp");
            }
            _context.categories.Remove(categoryFromDb);
            Save();
        }

        public IEnumerable<CategoryVM> GetCategories()
        {
            // Truy vấn tất cả các danh mục từ cơ sở dữ liệu
            var categoriesFromDb = _context.categories.ToList();

            // Chuyển đổi danh sách các đối tượng Category thành danh sách CategoryVM
            var categoriesVM = categoriesFromDb.Select(c => new CategoryVM
            {
                categoryid = c.categoryid,
                name = c.name,
                slug = c.slug
            });

            return categoriesVM.ToList();
        }

        public CategoryVM GetCategory(int id)
        {
            // Truy vấn một danh mục từ cơ sở dữ liệu
            var categoryFromDb = _context.categories.SingleOrDefault(c => c.categoryid == id);
            if (categoryFromDb == null)
            {
                throw new Exception("Không tìm thấy danh mục với id đã cung cấp");
            }
            else {
                var caVM = new CategoryVM
                {
                    categoryid = categoryFromDb.categoryid,
                    name = categoryFromDb.name,
                    slug = categoryFromDb.slug
                };
                return caVM;
            }
        }

        public bool Save()
        {
            // Lưu thay đổi vào cơ sở dữ liệu
            try 
            { 
                _context.SaveChanges();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }

        public void UpdateCategory(CategoryVM category)
        {
            // Truy vấn một danh mục từ cơ sở dữ liệu
            var categoryFromDb = _context.categories.FirstOrDefault(c => c.categoryid == category.categoryid);
            if (categoryFromDb == null)
            {
                throw new Exception("Không tìm thấy danh mục với id đã cung cấp");
            }
            categoryFromDb.name = category.name;
            categoryFromDb.slug = category.slug;
            Save();

        }
    }
}
