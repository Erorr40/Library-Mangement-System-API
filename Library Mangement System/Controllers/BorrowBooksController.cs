using Library_Mangement_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mangement_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowBooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BorrowBooksController()
        {
            _context = new AppDbContext();
        }

        //16 reacp
        [HttpPost("PostWithValitade")]
        public IActionResult PostWileValitadeEverything(BorrowRecord borrow)
        {
            if (borrow == null)
            {
                return BadRequest("Borrow Record is null");
            }
            if (borrow.Members == null || !borrow.Members.Any())
            {
                return BadRequest("one member is required");
            }
            if (borrow.Books == null || !borrow.Books.Any())
            {
                return BadRequest("one book is required");
            }
            if (borrow.Books.Where(e => e.AvailableCopies <= 0).Any())
            {
                return BadRequest("One or more books are not available");
            }
            _context.BorrowRecords.Add(borrow);
            _context.SaveChanges();
            return Ok();
        }

        //17
        [HttpPatch("returnBook/{id}")]
        public IActionResult returnBook(int Id)
        {
            var r = _context.BorrowRecords.Find(Id);
            if (r == null) return NotFound("Not Found !");
            if (r.ReturnDate != null) return NotFound("Book Already Returned !");
            r.ReturnDate = DateTime.Now;
            _context.SaveChanges();
            return Ok("Returned !");
        }

        //18
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteBorrowBook(int id)
        {
            var b = _context.BorrowRecords.Find(id);
            if (b == null) return NotFound();
            if (b.ReturnDate == null) return BadRequest("Book's Active Borrowing !");
            _context.BorrowRecords.Remove(b);
            _context.SaveChanges();
            return NoContent();
        }
    }
}