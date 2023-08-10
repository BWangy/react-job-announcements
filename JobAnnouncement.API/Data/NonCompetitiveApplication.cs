using System;
using System.Collections.Generic;

namespace JobAnnouncement.API.Data;

public partial class NonCompetitiveApplication
{
    public int Id { get; set; }

    public int JobId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string LetterToHr { get; set; } = null!;

    public virtual NonCompetitiveJobAnno Job { get; set; } = null!;
}
