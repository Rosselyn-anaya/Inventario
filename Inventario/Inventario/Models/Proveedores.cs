namespace Inventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedores()
        {
            Compras = new HashSet<Compras>();
            Compras1 = new HashSet<Compras>();
        }

        public int id { get; set; }

        [StringLength(100)]
        [Required]
        public string nombre { get; set; }

        [StringLength(100)]
        [Required]
        public string direccion { get; set; }

        [StringLength(100)]
        [Required]
        public string telefono { get; set; }

        [StringLength(100)]
        [Required]
        public string empresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compras> Compras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compras> Compras1 { get; set; }
    }
}
