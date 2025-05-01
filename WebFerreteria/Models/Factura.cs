using System;
using System.Collections.Generic;

namespace WebFerreteria.Models;

public partial class Factura
{
    public int FacturaId { get; set; }

    public DateTime? FechaFactura { get; set; }

    public decimal? MontoTotal { get; set; }

    public string? MetodoPago { get; set; }

    public int? PedidoId { get; set; }

    public int? ClienteId { get; set; }

    public int? EntregaId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Entrega? Entrega { get; set; }

    public virtual Pedido? Pedido { get; set; }
}
