using System;
using System.Collections.Generic;

namespace Esemka.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<EkskulMember> EkskulMembers { get; set; } = new List<EkskulMember>();
}
