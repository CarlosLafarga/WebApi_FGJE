namespace WebApp_FGJE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsuarioRol")]
    public partial class UsuarioRol
    {
        [Key]
        [Column(Order = 0)]
        public decimal Usuario_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal Rol_id { get; set; }

        public DateTime? dFechaInicio { get; set; }

        public DateTime? dFechaFin { get; set; }

        public decimal? esPrincipal { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
