using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using progCompany.Data;
using progCompany.dtos;
using progCompany.Models.DeveloperModel;

namespace progCompany.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Projects/GetAssignedProjects/{developerId}
        [HttpGet("GetAssignedProjects/{developerId}")]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAssignedProjects(int developerId)
        {
            var projects = await _context.Projects
                .Where(p => p.ProjectDevelopers.Any(pd => pd.DeveloperId == developerId))
                .Include(p => p.TeamLead)
                .Include(p => p.ProjectDevelopers)
                    .ThenInclude(pd => pd.Developer)
                .Select(p => new ProjectDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Status = p.Status,
                    Deadline = p.Deadline.ToString("yyyy-MM-dd"),
                    Assigned = new AssignedDto
                    {
                        TeamLead = p.TeamLead.User.FullName,
                        Developers = p.ProjectDevelopers.Select(pd => pd.Developer.User.FullName).ToList()
                    },
                    Progress = new ProgressDto
                    {
                        Percent = p.ProgressPercent
                    }
                })
                .ToListAsync();

            return Ok(projects);
        }

        // PUT: api/Projects/UpdateProgress/{projectId}
        [HttpPut("UpdateProgress/{projectId}")]
        public async Task<ActionResult> UpdateProgress(int projectId, [FromBody] UpdateProgressDto dto)
        {
            var project = await _context.Projects
                .Include(p => p.ProjectDevelopers)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
                return NotFound(new { message = "Project not found" });

            if (!project.ProjectDevelopers.Any(pd => pd.DeveloperId == dto.DeveloperId))
                return Unauthorized(new { message = "You are not assigned to this project" });

            project.ProgressPercent = dto.ProgressPercent;
            project.LastUpdated = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Progress updated successfully",
                newProgress = dto.ProgressPercent
            });
        }
    }
}
