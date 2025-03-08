using CodeFirstMigrations.Domain.Authors;
using CodeFirstMigrations.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstMigrations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly BookStoreDbContext _dbContext;

        public AuthorsController(ILogger<AuthorsController> logger,
            BookStoreDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var authors = await _dbContext.Authors.ToListAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(
            [FromRoute]Guid id)
        {
            var author = await _dbContext.Authors
                //.Include(i => i.Books.Where(r => r.AuthorId == id))
                .FirstOrDefaultAsync(r => r.Id == id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult> Create(
            [Required][FromQuery]string name,
            [Required][FromQuery] string email,
            [Required][FromQuery] string phone)
        {
            var author = new Author { Name= name, Email = email, Phone = phone, Status = AuthorStatus.Active };
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
            return Ok(author.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(
            [FromRoute]Guid id,
            [Required][FromQuery] string name,
            [Required][FromQuery] string phone)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(r => r.Id == id);
            if (author is null)
                return BadRequest($"Author with Id:{id} dose not exist.");
            
            author.Name = name;
            author.Phone = phone;
            author.UpdatedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(
            [FromRoute] Guid id)
        {
            await _dbContext.Authors
                .Where(r => r.Id == id)
                .ExecuteDeleteAsync();
            return Ok();
        }
    }
}
