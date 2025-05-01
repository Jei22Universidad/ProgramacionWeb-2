using System;
using System.Collections.Generic;

namespace WebFerreteria.Models;

public partial class Inventario
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
