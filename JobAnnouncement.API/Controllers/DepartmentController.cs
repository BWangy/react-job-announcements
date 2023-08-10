using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using JobAnnouncement.API.Models;
using Microsoft.EntityFrameworkCore;
using JobAnnouncement.API.Data;

namespace JobAnnouncement.API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<CompetitiveController> _logger;

        private readonly JobAnnouncementDbContext _context;


        public DepartmentController(ILogger<CompetitiveController> logger, JobAnnouncementDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Tuple<int, string>> Get()
        {
            return (from a in _context.Departments
                    select new Tuple<int, string> (a.Id, a.Code + " - " + a.Description)).ToArray();
        }
    }
}
