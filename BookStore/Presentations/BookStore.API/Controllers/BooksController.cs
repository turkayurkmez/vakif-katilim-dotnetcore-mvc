using BookStore.Services;
using BookStore.Services.DataTransferObjects.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [Authorize(Roles = "Admin,Editor")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await bookService.GetBooksForDisplayAsync();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await bookService.GetBookForAddToCardAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpGet("[action]/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(string name)
        {
            var books = await bookService.SearchBooks(name);
            return Ok(books);

        }
        [Authorize(Roles = "Admin,Editor")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateNewBookRequest newBookRequest)
        {
            if (ModelState.IsValid)
            {
                var lastBookId = await bookService.CreateNewBook(newBookRequest);
                return CreatedAtAction(nameof(GetBookById), routeValues: new { id = lastBookId }, value: null);
            }

            return BadRequest(ModelState);
        }
        [Authorize(Roles = "Admin,Editor")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, UpdateBookRequest updateBookRequest)
        {
            if (await bookService.IsBookExists(id))
            {
                if (ModelState.IsValid)
                {
                    await bookService.UpdateExistingBook(updateBookRequest);
                    return Ok(updateBookRequest);
                }

                return BadRequest(ModelState);
            }
            return NotFound(new { message = $"{id} değeri veritabanında bulunamadı." });
        }
        [Authorize(Roles = "Admin,Editor")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (await bookService.IsBookExists(id))
            {
                await bookService.DeleteAsync(id);
                return Ok();
            }
            return NotFound(new { message = $"{id} değeri veritabanında bulunamadı." });

        }

    }
}
