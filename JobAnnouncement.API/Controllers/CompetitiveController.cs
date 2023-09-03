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
    public class CompetitiveController : ControllerBase
    {
        private readonly ILogger<CompetitiveController> _logger;

        private readonly JobAnnouncementDbContext _context;


        public static List<CompetitiveAnnounce> lsAnno = new List<CompetitiveAnnounce>();


        public CompetitiveController(ILogger<CompetitiveController> logger, JobAnnouncementDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public List<AnnoForDisplay> Get()
        {
            List<AnnoForDisplay> lsAnno =  (from a in _context.CompetitiveJobAnnos
                    where a.OpenDate <= DateTime.Today && a.ClosingDate >= DateTime.Today 
                    select new AnnoForDisplay  { desc ="This is a competitive announcement!",  identifier = a.Id, title = a.Title,
                        strOpenDate = a.OpenDate.ToString("MM/dd/yyyy"), strClosingDate = a.ClosingDate.ToString("MM/dd/yyyy"), 
                        applicationFee = Convert.ToDouble(a.ApplicationFee), department = a.Department.Description }).ToList();
       
            return lsAnno;
        }

        [HttpPost]
        public IActionResult Post(AnnoForDisplay detail)
        {
            //NameValueCollection vals = Request.Form;
            CompetitiveJobAnno job = new CompetitiveJobAnno();                
            try
            {
                job.Title = detail.title;
                job.ClosingDate = detail.datClosingDate;
                job.OpenDate = detail.datOpenDate;
                job.ApplicationFee = Convert.ToDecimal(detail.applicationFee);
                job.DepartmentId = detail.departmentId;

                _context.CompetitiveJobAnnos.Add(job);
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
