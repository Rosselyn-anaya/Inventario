namespace Inventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Compras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compras()
        {
            Detalle_compras = new HashSet<Detalle_compras>();
        }

        public int id { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? fecha { get; set; }

        public int? id_proveedores { get; set; }

        public int? id_usuario { get; set; }

        public virtual Proveedores Proveedores { get; set; }

        public virtual Proveedores Proveedores1 { get; set; }

        public virtual usuario usuario { get; set; }

        public virtual usuario usuario1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_compras> Detalle_compras { get; set; }
    }
}
