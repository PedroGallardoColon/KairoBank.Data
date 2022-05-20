using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KairoBank.Data.entities
{
    public partial class Transaccione
    {
        [Key]
        public int Id { get; set; }
        public int IdSolicitud { get; set; }
        public int IdUsuario { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Horas { get; set; }

        [ForeignKey("IdSolicitud")]
        [InverseProperty("Transacciones")]
        public virtual Solicitude IdSolicitudNavigation { get; set; }
        [ForeignKey("IdUsuario")]
        [InverseProperty("Transacciones")]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
