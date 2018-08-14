
namespace WebApp_FGJE.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    [Table("CatDiscriminante")]
    public class catDiscriminante
    {
         [Key]
         public decimal catDiscriminante_id { get; set; }
         public decimal catDistrito_id { get; set; }
          
         public string  cClaveDiscriminante { get; set; }
         
         public string cNombre { get; set; }

         public decimal iTipo { get; set; }
         public int CatDelegacion_id { get; set; }

    }
}