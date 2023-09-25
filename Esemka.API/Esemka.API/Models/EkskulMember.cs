using System;
using System.Collections.Generic;

namespace Esemka.Models;

public partial class EkskulMember
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int EkskulId { get; set; }

    public string Position { get; set; } = null!;

    public DateTime JoinDate { get; set; }

    public virtual Ekskul Ekskul { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
