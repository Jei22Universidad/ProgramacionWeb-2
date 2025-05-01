using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebFerreteria.Models;

public partial class FerreteriaDbContext : DbContext
{
    public FerreteriaDbContext()
    {
    }

    public FerreteriaDbContext(DbContextOptions<FerreteriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Entrega> Entregas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=JEI-LC\\SQLEXPRESS;Database=WebAlmacen;Integrated Security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD0A7DCACEC26");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Entrega>(entity =>
        {
            entity.HasKey(e => e.EntregaId).HasName("PK__Entregas__D9AD232310DF4D07");

            entity.Property(e => e.EntregaId).HasColumnName("EntregaID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaEntrega)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(255);
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Entregas)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__Entregas__Pedido__5AEE82B9");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK__Facturas__5C024805DC2FBDD2");

            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.EntregaId).HasColumnName("EntregaID");
            entity.Property(e => e.FechaFactura)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MetodoPago).HasMaxLength(50);
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Facturas__Client__5FB337D6");

            entity.HasOne(d => d.Entrega).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.EntregaId)
                .HasConstraintName("FK__Facturas__Entreg__60A75C0F");

            entity.HasOne(d => d.Pedido).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__Facturas__Pedido__5EBF139D");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Inventar__A430AE834C2144C7");

            entity.ToTable("Inventario");

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaIngreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("PK__Pedidos__09BA14101C147A1F");

            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.CantidadProducto).HasColumnName("cantidad_producto");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaPedido)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(255);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__Pedidos__Cliente__5535A963");

            entity.HasOne(d => d.Producto).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Pedidos__Product__5629CD9C");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7988285E347");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A1956260722").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
