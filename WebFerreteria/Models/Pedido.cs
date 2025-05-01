using System;
using System.Collections.Generic;

namespace WebFerreteria.Models;

public partial class Pedido
{
    public int PedidoId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public string? Estado { get; set; }

    public string? Observaciones { get; set; }

    public int? ClienteId { get; set; }

    public int? ProductoId { get; set; }

    public int? CantidadProducto { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Inventario? Producto { get; set; }
}
