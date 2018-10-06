namespace Inventario.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo6")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<Detalle_compras> Detalle_compras { get; set; }
        public virtual DbSet<Detalle_factura> Detalle_factura { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.categoria1)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Productos)
                .WithOptional(e => e.Categoria)
                .HasForeignKey(e => e.id_categoria);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Factura)
                .WithOptional(e => e.Clientes)
                .HasForeignKey(e => e.id_Cliente);

            modelBuilder.Entity<Compras>()
                .HasMany(e => e.Detalle_compras)
                .WithOptional(e => e.Compras)
                .HasForeignKey(e => e.id_compras);

            modelBuilder.Entity<Factura>()
                .HasMany(e => e.Detalle_factura)
                .WithOptional(e => e.Factura)
                .HasForeignKey(e => e.id_factura)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Marca>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Marca>()
                .HasMany(e => e.Productos)
                .WithOptional(e => e.Marca)
                .HasForeignKey(e => e.id_marca);

            modelBuilder.Entity<Marca>()
                .HasMany(e => e.Productos1)
                .WithOptional(e => e.Marca1)
                .HasForeignKey(e => e.id_marca);

            modelBuilder.Entity<Productos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.Detalle_compras)
                .WithOptional(e => e.Productos)
                .HasForeignKey(e => e.id_productos);

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.Detalle_factura)
                .WithOptional(e => e.Productos)
                .HasForeignKey(e => e.id_productos)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .Property(e => e.empresa)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedores>()
                .HasMany(e => e.Compras)
                .WithOptional(e => e.Proveedores)
                .HasForeignKey(e => e.id_proveedores);

            modelBuilder.Entity<Proveedores>()
                .HasMany(e => e.Compras1)
                .WithOptional(e => e.Proveedores1)
                .HasForeignKey(e => e.id_proveedores);

            modelBuilder.Entity<rol>()
                .Property(e => e.rol1)
                .IsUnicode(false);

            modelBuilder.Entity<rol>()
                .HasMany(e => e.usuario)
                .WithOptional(e => e.rol)
                .HasForeignKey(e => e.id_rol);

            modelBuilder.Entity<rol>()
                .HasMany(e => e.usuario1)
                .WithOptional(e => e.rol1)
                .HasForeignKey(e => e.id_rol);

            modelBuilder.Entity<usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.Compras)
                .WithOptional(e => e.usuario)
                .HasForeignKey(e => e.id_usuario);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.Compras1)
                .WithOptional(e => e.usuario1)
                .HasForeignKey(e => e.id_usuario);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.Factura)
                .WithOptional(e => e.usuario)
                .HasForeignKey(e => e.id_usuario);
        }
    }
}
