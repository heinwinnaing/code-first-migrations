using CodeFirstMigrations.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstMigrations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly BookStoreDbContext _dbContext;

        public BooksController(ILogger<BooksController> logger,
            BookStoreDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var books = await _dbContext.Books.ToListAsync();
            return Ok(books);
        }
    }
}
