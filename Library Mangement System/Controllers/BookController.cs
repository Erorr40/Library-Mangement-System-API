using AutoMapper;
using Library_Mangement_System.DTOs.BooksDTOs;
using Library_Mangement_System.Mapping;
using Library_Mangement_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// With AutoMapper
namespace Library_Mangement_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BookController()
        {
            _context = new AppDbContext();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<BooksProfile>()).CreateMapper();
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _context.Books.ToList();
            var booksDTO = _mapper.Map< List<BooksDTO>>(books);
            return Ok(booksDTO);
        }

        //1
        [HttpGet("price-greater-than")]
        public IActionResult GetBooks(int price)
        {
            var books = _context.Books.Where(e => e.Price >= price).ToList();
            if (books == null) return NotFound($"No book found with greater than {price}");
            var booksDTO = _mapper.Map<List<BooksDTO>>(books);
            return Ok(booksDTO);
        }

        //2
        [HttpGet("PriceBetween")]
        public IActionResult GetAllBooksWithMinAndMax(int min = 0, int max = int.MaxValue)
        {
            var books = _context.Books.Where(e => e.Price > min && e.Price < max).ToList();
            if (books == null) return NotFound($"No Book Found with min: {min}, max: {max}");
            var bookDTO = _mapper.Map<List<BooksDTO>>(books);
            return Ok(bookDTO);
        }

        //3
        [HttpGet("search")]
        public IActionResult SearchBooks(string search)
        {
            var books = _context.Books.Where(e => e.Title.Contains(search));
            if (books == null) return NotFound($"No Books foud with this search");
            var bookDTO = _mapper.Map<List<BooksDTO>>(books);
            return Ok(bookDTO);
        }

        //4
        [HttpGet("getFrist")]
        public IActionResult FristBook()
        {
            var books = _context.Books.First();
            var bookDTO = _mapper.Map<BooksDTO>(books);
            return Ok(bookDTO);
        }

        //5
        [HttpGet("GetFirstAvalable")]
        public IActionResult FristAndAvaBook()
        {
            var books = _context.Books.Where(e => e.AvailableCopies > 0).First();
            if (books == null) return NotFound("No books found with avilable");
            var booksDTO = _mapper.Map<Book>(books);
            return Ok(booksDTO);
        }

        //6 

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var b= _context.Books.Find(id);
            if (b == null) return NotFound($"There's No Books With This id: {id}");
            var booksDTO = _mapper.Map<BooksDTO>(b);
            return Ok(booksDTO);
        }


        // 7
        [HttpGet("LastBookinCollection")]
        public IActionResult LastBookInCollection()
        {
            var book = _context.Books.Last();
            if (book == null) return NotFound();
            var booksDTO = _mapper.Map<BooksDTO>(book);
            return Ok(booksDTO);
        }

        //8
        [HttpGet("CheckID{id}")]
        public IActionResult IdChecker(int id)
        {
            return _context.Books.Find(id) != null ? Ok("Found!") : NotFound("Not Found");
        }

        //9
        [HttpGet("VerifyAllBooksAvilable")]
        public IActionResult VerifyAllBooksAvilable()
        {
            var books = _context.Books.Where(e => e.AvailableCopies == 0).ToList();
            if (books == null) return Ok("All Books are avilable !");
            return Ok($"There's {books.Count} not Avilable!");
        }

        //10
        [HttpGet("RetriveTitleOnly")]
        public IActionResult RetriveTitlesOnly()
        {
            var books = _context.Books.Select(e => e.Title).ToList();
            if (books == null) return NotFound("No Books Found in DB !");
            return Ok(books);
        }

        //11
        [HttpGet("AllBooksSortedbyTitleASCE")]
        public IActionResult AllBooksSortedByTitleASEC()
        {
            var books = _context.Books.OrderBy(e => e.Title).ToList();
            var booksDTO = _mapper.Map<BooksDTO>(books);
            return Ok(booksDTO);
        }

        //12
        [HttpGet("Lowest-Price")]
        public IActionResult Lowest_Price()
        {
            var books = _context.Books.OrderBy(e => e.Price).ToList();
            var BooksDTO = _mapper.Map<BooksDTO>(books);
            return Ok(BooksDTO);
        }

        //13
        [HttpGet("RetriveBooksUsingPentagon")]
        public IActionResult PentagonMethod(int Page, int Size)
        {
            int count = (Page - 1) * Size;
            var books = _context.Books.Skip(count).Take(Size).ToList();
            var booksDTO = _mapper.Map<BooksDTO>(books);
            return Ok(booksDTO);
        }

        //Category!
        [HttpPost]
        public IActionResult PostBook(BooksDTO bookDTO)
        {
            if (bookDTO == null) return BadRequest("Please Type The data you want to Post !");
            var book = _mapper.Map<Book>(bookDTO);
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok(bookDTO);
        }

        [HttpPut("{id}")]
        public IActionResult PutResult(BooksDTO bookDTO, int Id)
        {
            if (Id == null) return BadRequest("Where's the ID ?");
            var book = _context.Books.Find(Id);
            if (book == null) return NotFound("Book Not Found !");
            if (bookDTO == null) return BadRequest("Please Type Data u wanna to Put");
            book = _mapper.Map<Book>(bookDTO);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var book = _context.Books.Find(Id);
            if (book == null) return NotFound("Book Not Found !");
            _context.Books.Remove(book);
            return Ok();
        }


    }
}
