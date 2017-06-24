namespace WhatzQ
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WhatzQContext : DbContext
    {
        public WhatzQContext()
            : base("name=WhatzQContext")
        {
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Criterion> Criteria { get; set; }
        public virtual DbSet<Factor> Factors { get; set; }
        public virtual DbSet<QualityMetric> QualityMetrics { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Criterion>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.Criterion)
                .HasForeignKey(e => e.CNum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Criterion>()
                .HasMany(e => e.QualityMetrics)
                .WithOptional(e => e.Criterion)
                .HasForeignKey(e => e.Criteria_Id);

            modelBuilder.Entity<Factor>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.Factor)
                .HasForeignKey(e => e.FNum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Factor>()
                .HasMany(e => e.Criteria)
                .WithRequired(e => e.Factor)
                .HasForeignKey(e => e.Factor_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Factor>()
                .HasMany(e => e.QualityMetrics)
                .WithOptional(e => e.Factor)
                .HasForeignKey(e => e.Factor_Id);

            modelBuilder.Entity<QualityMetric>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.QualityMetric)
                .HasForeignKey(e => e.MNum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Applications)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Criteria)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.Subject_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Factors)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.Subject_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.QualityMetrics)
                .WithOptional(e => e.Subject)
                .HasForeignKey(e => e.Subject_Id);
        }
    }
}
