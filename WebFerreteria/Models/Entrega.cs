using System;
using System.Collections.Generic;

namespace WebFerreteria.Models;

public partial class Entrega
{
    public int EntregaId { get; set; }

    public DateTime? FechaEntrega { get; set; }

    public string? Estado { get; set; }

    public string? Observaciones { get; set; }

    public int? PedidoId { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Pedido? Pedido { get; set; }
}
