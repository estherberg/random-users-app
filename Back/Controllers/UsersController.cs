using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomUserAPI.Data;
using RandomUserAPI.Models;

namespace RandomUserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public UsersController(AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(int page = 1, int pageSize = 10)
        {
            var users = await _context.Users
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            if (!users.Any())
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetFromJsonAsync<RandomUserResponse>("https://randomuser.me/api/?results=20");

                if (response?.Results != null)
                {
                    var newUsers = response.Results.Select(u => new User
                    {
                        Id = Guid.NewGuid(),
                        FirstName = u.Name!.First ?? "N/A",
                        LastName = u.Name!.Last ?? "N/A",
                        Email = u.Email ?? "N/A",
                        DateOfBirth = DateTime.TryParse(u.Dob!.Date, out var dob) ? dob : DateTime.Now,
                        Phone = u.Phone ?? "N/A",
                        Address = $"{u.Location!.Street!.Number} {u.Location.Street.Name}, {u.Location.City}",
                        ProfilePicture = u.Picture!.Large ?? ""
                    }).ToList();

                    _context.Users.AddRange(newUsers);
                    await _context.SaveChangesAsync();

                    return newUsers
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                }
            }

            return users;
        }
        [HttpGet("{id}")]
public async Task<ActionResult<User>> GetUserById(Guid id)
{
    var user = await _context.Users.FindAsync(id);

    if (user == null)
        return NotFound();

    return user;
}
[HttpGet("search")]
public async Task<IActionResult> SearchUsers([FromQuery] string query)
{
    if (string.IsNullOrWhiteSpace(query))
        return BadRequest("Query string is required.");

    var results = await _context.Users
      .Where(u =>
    (u.FirstName != null && u.FirstName.Contains(query)) ||
    (u.LastName != null && u.LastName.Contains(query)) ||
    (u.Email != null && u.Email.Contains(query)))

        .ToListAsync();

    return Ok(results);
}
    }
}
