﻿using System.Data.Entity;

namespace SistemaContabilidadAltosDelAbejonal.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<TipoGrano> TipoGranos { get; set; }
        public DbSet<TipoPresentacion> TipoPresentaciones { get; set; }
        public DbSet<CategoriaProducto> CategoriaProductos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<PedidoProducto> PedidoProductos { get; set; }
        public DbSet<EstadoEntrega> EstadoEntregas { get; set; }
        public DbSet<PedidoProductoDetalle> PedidoProductoDetalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}