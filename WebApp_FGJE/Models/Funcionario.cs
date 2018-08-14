namespace WebApp_FGJE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Funcionario")]
    public partial class Funcionario
    {
        public decimal claveFuncionario { get; set; }
        public string nombre { get; set; }
        public string username { get; set; }
        public decimal? estatus { get; set; }
        public DateTime? fechaIngreso { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionario()
        {
            Usuario = new HashSet<Usuario>();
            NumeroExpediente = new HashSet<NumeroExpediente>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public decimal iClaveFuncionario { get; set; }

        [StringLength(50)]
        public string cNombreFuncionario { get; set; }

        [StringLength(50)]
        public string cApellidoPaternoFuncionario { get; set; }

        [StringLength(50)]
        public string cApellidoMaternoFuncionario { get; set; }

        [StringLength(1)]
        public string cSexo { get; set; }

        [StringLength(13)]
        public string cRFC { get; set; }

        [StringLength(18)]
        public string cCURP { get; set; }

        public DateTime? dFechaNacimiento { get; set; }

        [StringLength(60)]
        public string cEmail { get; set; }

        [StringLength(50)]
        public string cCedula { get; set; }

        public decimal? iClaveFuncionarioJefe { get; set; }

        public decimal? Especialidad_val { get; set; }

        public decimal? Puesto_val { get; set; }

        public decimal? JerarquiaOrganizacional_id { get; set; }

        public decimal? dcCargaTrabajo { get; set; }

        public decimal? TipoEspecialidad_val { get; set; }

        public decimal? bEsPar { get; set; }

        [StringLength(20)]
        public string cNumeroEmpleado { get; set; }

        public decimal? catDiscriminante_id { get; set; }

        public DateTime? dFechaIngreso { get; set; }

        public decimal? ArchivoDigital_id { get; set; }

        public decimal? catUIE_id { get; set; }

        public decimal? CatAreasNegocio_id { get; set; }

        public byte EsMP { get; set; }

        [StringLength(100)]
        public string cNumeroCertificado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NumeroExpediente> NumeroExpediente { get; set; }
        
    }
}
