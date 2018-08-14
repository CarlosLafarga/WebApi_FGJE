namespace WebApp_FGJE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NumeroExpediente")]
    public partial class NumeroExpediente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NumeroExpediente()
        {
            NumeroExpediente1 = new HashSet<NumeroExpediente>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal NumeroExpediente_id { get; set; }

        [Required]
        [StringLength(34)]
        public string cNumeroExpediente { get; set; }

        public DateTime dFechaApertura { get; set; }

        public decimal Expediente_id { get; set; }

        public decimal JerarquiaOrganizacional_id { get; set; }

        [ForeignKey("Funcionario")]
        public decimal iClaveFuncionario { get; set; }


        public decimal? NumExpedientePadre_id { get; set; }

        public decimal? bEsPar { get; set; }

        public decimal? Etapa_val { get; set; }

        public decimal? Estatus_val { get; set; }

        public decimal? TipoExpediente_val { get; set; }

        public decimal? iIdentificadorAlmacen { get; set; }

        [StringLength(34)]
        public string cNumExpAlterno { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NumeroExpediente> NumeroExpediente1 { get; set; }

        public virtual NumeroExpediente NumeroExpediente2 { get; set; }
    }
}
