namespace Inventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Detalle_factura
    {
        public int id { get; set; }

        public int? cantidad { get; set; }

        public int? id_productos { get; set; }

        public int? id_factura { get; set; }

        public virtual Factura Factura { get; set; }

        public virtual Productos Productos { get; set; }
    }
}
