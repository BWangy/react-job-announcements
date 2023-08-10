using System;
using System.Collections.Generic;

namespace JobAnnouncement.API.Data;

public partial class Department
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public short Status { get; set; }

    public virtual ICollection<CompetitiveJobAnno> CompetitiveJobAnnos { get; set; } = new List<CompetitiveJobAnno>();

    public virtual ICollection<NonCompetitiveJobAnno> NonCompetitiveJobAnnos { get; set; } = new List<NonCompetitiveJobAnno>();
}
