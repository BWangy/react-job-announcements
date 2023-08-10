using JobAnnouncement.API.Data;
using JobAnnouncement.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JobAnnouncement.API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class NonCompetitiveController : ControllerBase
    {
        private readonly ILogger<NonCompetitiveController> _logger;
        private readonly JobAnnouncementDbContext _context;

        public static List<NonCompetitiveAnnounce> lsAnno = new List<NonCompetitiveAnnounce>();

        public NonCompetitiveController(ILogger<NonCompetitiveController> logger, JobAnnouncementDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<AnnoForDisplay> Get()
        {
            return (from a in _context.NonCompetitiveJobAnnos
                    select new AnnoForDisplay { desc = "This is a non-competitive announcement!", identifier = a.Id, title = a.Title, strClosingDate = a.ClosingDate.ToString("MM/dd/yyyy"), restriction = a.Restriction, department = a.Department.Description }).ToArray();
        }


        [HttpPost]
        public IActionResult Post(AnnoForDisplay detail)
        {
            NonCompetitiveJobAnno job = new NonCompetitiveJobAnno();
            try
            {
                job.Title = detail.title;
                job.OpenDate = detail.datOpenDate;
                job.ClosingDate = detail.datClosingDate;
                job.Restriction = detail.restriction;
                job.DepartmentId = detail.departmentId;

                _context.NonCompetitiveJobAnnos.Add(job);
                _context.SaveChanges();

            }
            catch
            {
                return BadRequest();
            }

            return Ok(job.Id);
        }

    }
}
