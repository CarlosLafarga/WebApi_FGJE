

namespace WebApp_FGJE.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    [Table("Rol")]
    public class Roles
    {
        [Key]
        public decimal Rol_id { get; set; }

        [StringLength(50)]
        public string cNombreRol { get; set; }
        public string cDescripcionRol { get; set; }
        public decimal bEsActivo { get; set; }
        public decimal ConfInstitucion_id { get; set; }
        public decimal JerarquiaOrganizacional_id { get; set; }

        public decimal? RolPadre_id  {get; set;}



    }
}