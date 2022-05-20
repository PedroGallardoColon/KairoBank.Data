using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KairoBank.Data.entities
{
    public partial class Solicitude
    {
        public Solicitude()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        [Key]
        public int Id { get; set; }
        public int IdUsuarioAnunciante { get; set; }
        public int IdUsuarioSolicitante { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaSolicitud { get; set; }
        public int EstadoSolicitud { get; set; }

        [ForeignKey("IdUsuarioAnunciante")]
        [InverseProperty("SolicitudeIdUsuarioAnuncianteNavigations")]
        public virtual Usuario IdUsuarioAnuncianteNavigation { get; set; }
        [ForeignKey("IdUsuarioSolicitante")]
        [InverseProperty("SolicitudeIdUsuarioSolicitanteNavigations")]
        public virtual Usuario IdUsuarioSolicitanteNavigation { get; set; }
        [InverseProperty("IdSolicitudNavigation")]
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
