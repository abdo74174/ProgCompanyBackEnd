using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using progCompany.Data;
using progCompany.Models.UserModel;

namespace progCompany.Controllers.dashboard
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashBoardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashBoardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("developer-count")]
        public async Task<IActionResult> DeveloperCount()
        {
            int count = await _context.Users
                .Where(u => u.Role == UserRole.Developer)
                .CountAsync();

            return Ok(count);
        }
    }
}
