using JobAnnouncement.API.Data;
using JobAnnouncement.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace JobAnnouncement.API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyNonCompetitiveController : ControllerBase
    {
        private readonly ILogger<ApplyNonCompetitiveController> _logger;

        private readonly JobAnnouncementDbContext _context;

        public ApplyNonCompetitiveController(ILogger<ApplyNonCompetitiveController> logger, JobAnnouncementDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public AnnoForDisplay Get(int id)
        {
            // get detail for this announcement with the id
            var comp = new AnnoForDisplay();
            try
            {
                comp = (from a in _context.NonCompetitiveJobAnnos
                        where a.Id == id
                        select new AnnoForDisplay
                        {
                            desc = "This is a competitive announcement!",
                            identifier = a.Id,
                            title = a.Title,
                            strClosingDate = a.ClosingDate.ToString("MM/dd/yyyy"),
                            restriction = a.Restriction,
                            department = a.Department.Description
                        }).First();
            }
            catch (Exception ex) { }

            return comp;
        }

        [HttpPost]
        public IActionResult Post(CandidateInfo detail)
        {
            NonCompetitiveApplication app = new NonCompetitiveApplication();
            try
            {
                app.JobId = detail.jobId;
                app.FirstName = detail.firstName;
                app.LastName = detail.lastName;
                app.Email = detail.email;
                app.LetterToHr = detail.letterToHR;

                _context.NonCompetitiveApplications.Add(app);
                _context.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
