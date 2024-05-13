using hnh.Models;
using hnh.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace hnh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: api/Category
        [HttpGet]
        public IActionResult GetCategories(int id)
        {
            try
            {
                return Ok(_categoryRepository.GetCategories());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi lấy dữ liệu từ cơ sở dữ liệu");
            }
        }

        // GET: api/Category/id
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var data = _categoryRepository.GetCategory(id);
                if ( data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi lấy dữ liệu từ cơ sở dữ liệu");
            }
        }
        // PUT: api/Category/id
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, CategoryVM category)
        {
            try
            {
                if (id != category.categoryid)
                {
                    return BadRequest("Id không khớp với danh mục");
                }
                _categoryRepository.UpdateCategory(category);
                return Ok("Cập nhật danh mục thành công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi cập nhật dữ liệu");
            }
        }
        // POST: api/Category
        [HttpPost]
        public IActionResult PostCategory(CategoryVM category)
        {
            try
            {
                var data = _categoryRepository.AddCategory(category);
                return CreatedAtAction("GetCategory", new { id = data.categoryid }, data);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi thêm dữ liệu");
            }
        }

        // DELETE: api/Category/id
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                if (!_categoryRepository.CategoryExists(id))
                {
                    return NotFound();
                }
                _categoryRepository.DeleteCategory(id);
                return Ok("Xóa danh mục thành công");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi xóa dữ liệu");
            }
        }

      

    }
}
