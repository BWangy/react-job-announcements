using System;
using System.Collections.Generic;

namespace JobAnnouncement.API.Data;

public partial class CompetitiveJobAnno
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime OpenDate { get; set; }

    public DateTime ClosingDate { get; set; }

    public decimal ApplicationFee { get; set; }

    public int DepartmentId { get; set; }

    public virtual ICollection<CompetitiveApplication> CompetitiveApplications { get; set; } = new List<CompetitiveApplication>();

    public virtual Department Department { get; set; } = null!;
}
