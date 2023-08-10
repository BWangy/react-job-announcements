namespace JobAnnouncement.API.Models
{
    public class NonCompetitiveAnnounce : JobAnnounce
    {
        public string restriction;

        public NonCompetitiveAnnounce(String title, DateOnly closingDate, String restriction, string department) : base(title, closingDate, department)
        {
            this.restriction = restriction;
        }
    }
}
