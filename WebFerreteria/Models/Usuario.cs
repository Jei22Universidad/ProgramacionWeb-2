using System;
using System.Collections.Generic;

namespace WebFerreteria.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }

    public string? Rol { get; set; }

    public bool? Activo { get; set; }
}
