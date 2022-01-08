using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GymModel
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelGym")
        {
        }

        public virtual DbSet<Antrenori> Antrenori { get; set; }
        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<Suplimente> Suplimente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Antrenori>()
                .Property(e => e.Prenume)
                .IsFixedLength();

            modelBuilder.Entity<Antrenori>()
                .Property(e => e.Varsta)
                .IsFixedLength();

            modelBuilder.Entity<Clienti>()
                .Property(e => e.Nume)
                .IsFixedLength();

            modelBuilder.Entity<Clienti>()
                .Property(e => e.TipAbonament)
                .IsFixedLength();

            modelBuilder.Entity<Suplimente>()
                .Property(e => e.ClientID)
                .IsFixedLength();
        }
    }
}
