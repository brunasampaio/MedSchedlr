using System.Data.Entity;
using MedSchedlr.Data.Entities;

namespace MedSchedlr.Data.Context
{
    public class MedSchedlrContext : DbContext
    {
        public MedSchedlrContext() : base("MedSchedlrDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account", "application");
            modelBuilder.Entity<Plano>().ToTable("Plano", "application");
            modelBuilder.Entity<Paciente>().ToTable("Paciente", "application");
            modelBuilder.Entity<Consultorio>().ToTable("Consultorio", "application");
            modelBuilder.Entity<Medico>().ToTable("Medico", "application");
            modelBuilder.Entity<ConsultaMedica>().ToTable("ConsultaMedica", "application");
        }
    }
}
