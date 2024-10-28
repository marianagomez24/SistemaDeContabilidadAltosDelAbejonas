﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaContabilidadAltosDelAbejonal.Models
{
    [Table("PedidoProducto")]
    public class PedidoProducto
    {
        [Key]
        public int IDPedido { get; set; }

        [ForeignKey("Proveedor")]
        public int? IDProveedor { get; set; }
        public Proveedor Proveedor { get; set; }

        [ForeignKey("EstadoEntrega")]
        public int? IDEstado { get; set; }
        public EstadoEntrega EstadoEntrega { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntregaEstimada { get; set; }

        [StringLength(200)]
        public string Observaciones { get; set; }
    }
}