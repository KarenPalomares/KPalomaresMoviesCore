﻿using System;
using System.Collections.Generic;

namespace PL;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
