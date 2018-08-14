namespace WebApp_FGJE.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AccessModel : DbContext
    {
        

        public AccessModel()
            : base("name=AccessModel")
        {
        }

        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<NumeroExpediente> NumeroExpediente { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }
        public virtual DbSet<catDiscriminante> CatDiscriminantes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Funcionario>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Funcionario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Funcionario>()
                .HasMany(e => e.NumeroExpediente)
                .WithRequired(e => e.Funcionario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NumeroExpediente>()
                .HasMany(e => e.NumeroExpediente1)
                .WithOptional(e => e.NumeroExpediente2)
                .HasForeignKey(e => e.NumExpedientePadre_id);

           
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.UsuarioRol)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsuarioRol>()
                .Property(e => e.Usuario_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UsuarioRol>()
                .Property(e => e.Rol_id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UsuarioRol>()
                .Property(e => e.esPrincipal)
                .HasPrecision(1, 0);
        }

        
    }
}
