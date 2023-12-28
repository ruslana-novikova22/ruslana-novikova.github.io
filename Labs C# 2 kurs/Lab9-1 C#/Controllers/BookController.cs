using Lab5.Models;
using Lab9.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookRepository _repo = new BookRepository(new AppDbContext());
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<Book>> Get()
        {
            return await _repo.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _repo.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<Book> Post([FromBody] Book value)
        {
            return await _repo.Create(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> Put(int id, [FromBody] Book value)
        {
            var book = await _repo.Update(id, value);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            var book = await _repo.Delete(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
