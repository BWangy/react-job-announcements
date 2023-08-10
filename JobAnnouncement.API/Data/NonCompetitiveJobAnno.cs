using System;
using System.Collections.Generic;

namespace JobAnnouncement.API.Data;

public partial class NonCompetitiveJobAnno
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime OpenDate { get; set; }

    public DateTime ClosingDate { get; set; }

    public string Restriction { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<NonCompetitiveApplication> NonCompetitiveApplications { get; set; } = new List<NonCompetitiveApplication>();
}
