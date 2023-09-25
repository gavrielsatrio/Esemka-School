using System;
using System.Collections.Generic;

namespace Esemka.Models;

public partial class Ekskul
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Day { get; set; } = null!;

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public string IconName { get; set; } = null!;

    public virtual ICollection<EkskulMember> EkskulMembers { get; set; } = new List<EkskulMember>();
}
