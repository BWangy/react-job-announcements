using System;
using System.Collections.Generic;

namespace JobAnnouncement.API.Data;

public partial class CompetitiveApplication
{
    public int Id { get; set; }

    public int JobId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual CompetitiveJobAnno Job { get; set; } = null!;
}
