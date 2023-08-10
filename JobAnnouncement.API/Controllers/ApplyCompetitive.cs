using JobAnnouncement.API.Data;
using JobAnnouncement.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace JobAnnouncement.API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyCompetitiveController : ControllerBase
    {
        private readonly ILogger<ApplyCompetitiveController> _logger;

        private readonly JobAnnouncementDbContext _context;

        public static CompetitiveAnnounce Anno = null;


        public ApplyCompetitiveController(ILogger<ApplyCompetitiveController> logger, JobAnnouncementDbContext context)
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
                comp = (from a in _context.CompetitiveJobAnnos
                        where a.Id == id
                        select new AnnoForDisplay
                        {
                            desc = "This is a competitive announcement!",
                            identifier = a.Id,
                            title = a.Title,
                            strClosingDate = a.ClosingDate.ToString("MM/dd/yyyy"),
                            applicationFee = Convert.ToDouble(a.ApplicationFee),
                            department = a.Department.Description
                        }).First();
            }
            catch (Exception ex) { }

            return comp;
        }

        [HttpPost]
        public IActionResult Post(CandidateInfo detail)
        {
            CompetitiveApplication app = new CompetitiveApplication();
            try
            {
                app.JobId = detail.jobId;
                app.FirstName = detail.firstName;
                app.LastName = detail.lastName;
                app.Email = detail.email;
                app.PhoneNumber = detail.phoneNumber;

                _context.CompetitiveApplications.Add(app);
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
