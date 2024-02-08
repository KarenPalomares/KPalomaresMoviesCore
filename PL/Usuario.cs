using System;
using System.Collections.Generic;

namespace PL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[]? Password { get; set; }

    public int? IdRol { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
