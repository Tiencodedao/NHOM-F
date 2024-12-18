﻿using System;
using System.Collections.Generic;

namespace KoiPond.Repositories.Models;

public partial class UserToken
{
    public string? UserId { get; set; }

    public string LoginProvider { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Value { get; set; }
}
