namespace LekTest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AccountDbContext : DbContext
    {
        public AccountDbContext()
            : base("name=AccountDbContext")
        {
        }

        public virtual DbSet<DailyPayment> DailyPayments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyPayment>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DailyPayment>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
