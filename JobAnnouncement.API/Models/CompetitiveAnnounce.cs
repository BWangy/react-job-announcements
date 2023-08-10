namespace JobAnnouncement.API.Models
{
    public class CompetitiveAnnounce : JobAnnounce
    {
        public double applicationFee;

        public CompetitiveAnnounce(string title, DateOnly closingDate, double applicationFee, string department) : base(title, closingDate, department)
        {
            this.applicationFee = applicationFee;
        }
    }
}
