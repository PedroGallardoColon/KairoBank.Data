using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KairoBank.Data.entities
{
    public partial class Anuncio
    {
        [Key]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Categoria { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Titulo { get; set; }
        [Required]
        [Unicode(false)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PrecioHoras { get; set; }
        [Required]
        [StringLength(255)]
        [Unicode(false)]
        public string Ubicacion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaInicio { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaBaja { get; set; }

        [ForeignKey("IdUsuario")]
        [InverseProperty("Anuncios")]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
