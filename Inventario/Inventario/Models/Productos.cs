namespace Inventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            Detalle_compras = new HashSet<Detalle_compras>();
            Detalle_factura = new HashSet<Detalle_factura>();
        }

        public int id { get; set; }

        [StringLength(100)]
        [Required]
        public string nombre { get; set; }

        [StringLength(100)]
        [Required]
        public string descripcion { get; set; }
        [Required]
        public double? precio { get; set; }

        public int? id_marca { get; set; }

        public int? id_categoria { get; set; }

        public int? existencias { get; set; }
      
        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_compras> Detalle_compras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_factura> Detalle_factura { get; set; }
      
        public virtual Marca Marca { get; set; }

        public virtual Marca Marca1 { get; set; }
    }
}
