namespace WebApp_FGJE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("UsuarioRol")]
        public decimal Usuario_id { get; set; }

        [Required]
        [StringLength(30)]
        public string cClaveUsuario { get; set; }

        [StringLength(10)]
        public string cPalabraSecreta { get; set; }

        [ForeignKey("Funcionario")]
        public decimal iClaveFuncionario { get; set; }

        [MaxLength(255)]
        public byte[] password { get; set; }

        [MaxLength(255)]
        public byte[] cllave { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? iSesion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? iIntentos { get; set; }

        [StringLength(20)]
        public string cIP { get; set; }

        public decimal? bEsActivo { get; set; }

        [StringLength(50)]
        public string idSesionServer { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
