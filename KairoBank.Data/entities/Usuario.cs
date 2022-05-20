using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KairoBank.Data.entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Anuncios = new HashSet<Anuncio>();
            SolicitudeIdUsuarioAnuncianteNavigations = new HashSet<Solicitude>();
            SolicitudeIdUsuarioSolicitanteNavigations = new HashSet<Solicitude>();
            Transacciones = new HashSet<Transaccione>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Nombre { get; set; }
        [Required]
        [Column("EMail")]
        [StringLength(255)]
        [Unicode(false)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Password { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Direccion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaNacimiento { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Anuncio> Anuncios { get; set; }
        [InverseProperty("IdUsuarioAnuncianteNavigation")]
        public virtual ICollection<Solicitude> SolicitudeIdUsuarioAnuncianteNavigations { get; set; }
        [InverseProperty("IdUsuarioSolicitanteNavigation")]
        public virtual ICollection<Solicitude> SolicitudeIdUsuarioSolicitanteNavigations { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
