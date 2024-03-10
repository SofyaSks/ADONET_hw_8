using System;
using System.Collections.Generic;

namespace MusicDb;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte IsBanned { get; set; }

    public string Password { get; set; } = null!;
}
