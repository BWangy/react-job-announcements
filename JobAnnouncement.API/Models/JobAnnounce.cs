namespace JobAnnouncement.API.Models
{
    public abstract class JobAnnounce
    {
        public string title;
        public DateOnly closingDate;
        public string department;
        public int identifier;
        private static int uniqueIdentifier = 1;

        public JobAnnounce(String title, DateOnly closingDate, string department)
        {
            this.title = title;
            this.closingDate = closingDate;
            this.department = department;
            this.identifier = uniqueIdentifier;
            uniqueIdentifier++;
        }

    }

    public class AnnoForDisplay
    {
        public string desc { get; set; }
        public string title { get; set; }
        public string strClosingDate { get; set; }
        public DateTime datClosingDate { get; set; }
        public string strOpenDate { get; set; }
        public DateTime datOpenDate { get; set; }
        public string? department { get; set; }
        public int departmentId { get; set; }
        public int identifier { get; set; }
        public double? applicationFee { get; set; }
        public string? restriction { get; set; }
    }

    public class CandidateInfo
    {
        public int jobId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string? phoneNumber { get; set; }

        public string? letterToHR { get; set; }
    }
}
