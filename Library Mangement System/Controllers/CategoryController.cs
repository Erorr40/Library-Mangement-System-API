using Library_Mangement_System.DTOs.CategorysDTOs;
using Library_Mangement_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mangement_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoryController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        //14 ( Need TO Recap it )
        [HttpGet("BooksNumberinEachCategory")]
        public IActionResult GetBooksNumberinEachCategory()
        {

            var result = _context.Books.GroupBy(b => b.CategoryId)
                .Select(g => new
                {
                    catid = g.Key,
                    count = g.Count()
                });


            return Ok(result);
        }


        //15
        [HttpPost]
        public IActionResult PostCategory(Category category)
        {
            if (category != null)
            {
                var cat = _context.Categories.ToList();
                foreach (var item in cat)
                {
                    if (item.Name == category.Name)
                    {
                        return BadRequest("Name Must be Unique");
                    }
                }
                _context.Categories.Add(category);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
            }
            return BadRequest(ModelState);
        }




        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
