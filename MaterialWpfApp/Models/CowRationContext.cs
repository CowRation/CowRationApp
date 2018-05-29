using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace MaterialWpfApp
{
    

    public partial class CowRationContext : DbContext
    {
        public CowRationContext()
            : base("name=CowRationContext")
        {
        }

        public virtual DbSet<CatalogIndexNutritional> CatalogIndexNutritionals { get; set; }
        public virtual DbSet<Faza> Fazas { get; set; }
        public virtual DbSet<FNutritionalCharacteristic> FNutritionalCharacteristics { get; set; }
        public virtual DbSet<Korm> Korms { get; set; }
        public virtual DbSet<Milk> Milk { get; set; }
        public virtual DbSet<NNutritionalCharacteristic> NNutritionalCharacteristics { get; set; }
        public virtual DbSet<NutritionalCategory> NutritionalCategories { get; set; }
        public virtual DbSet<Ration> Rations { get; set; }
        public virtual DbSet<RationCow> RationCows { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Models.Expenses> Expenses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogIndexNutritional>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CatalogIndexNutritional>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<CatalogIndexNutritional>()
                .HasMany(e => e.FNutritionalCharacteristics)
                .WithRequired(e => e.CatalogIndexNutritional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CatalogIndexNutritional>()
                .HasMany(e => e.NNutritionalCharacteristics)
                .WithRequired(e => e.CatalogIndexNutritional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faza>()
                .Property(e => e.Faza1)
                .IsFixedLength();

            modelBuilder.Entity<Faza>()
                .HasMany(e => e.NutritionalCategories)
                .WithRequired(e => e.Faza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FNutritionalCharacteristic>()
                .Property(e => e.FValue)
                ;

            modelBuilder.Entity<Korm>()
                .Property(e => e.Name_korm)
                .IsUnicode(false);

            modelBuilder.Entity<Korm>()
                .Property(e => e.Price_korm)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Korm>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<Korm>()
                .Property(e => e.Voluminousness)
                .IsUnicode(false);

            modelBuilder.Entity<Korm>()
                .HasMany(e => e.FNutritionalCharacteristics)
                .WithRequired(e => e.Korm)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korm>()
                .HasMany(e => e.Rations)
                .WithRequired(e => e.Korm)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korm>()
                .HasMany(e => e.RationCows)
                .WithRequired(e => e.Korm)
                .HasForeignKey(e => e.KormId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Korm>()
                .HasMany(e => e.Storages)
                .WithOptional(e => e.Korm)
                .HasForeignKey(e => e.KormId);

            modelBuilder.Entity<Korm>()
                .HasMany(e => e.NNutritionalCharacteristics)
                .WithRequired(e => e.Korm)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Milk>()
                .HasMany(e => e.RationCows)
                .WithRequired(e => e.Milk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NNutritionalCharacteristic>()
                .Property(e => e.NValue);

            modelBuilder.Entity<NutritionalCategory>()
                .Property(e => e.Fat_content)
                .HasPrecision(3, 2);

            modelBuilder.Entity<NutritionalCategory>()
                .Property(e => e.Protein)
                .HasPrecision(3, 2);

            modelBuilder.Entity<NutritionalCategory>()
                .HasMany(e => e.FNutritionalCharacteristics)
                .WithRequired(e => e.NutritionalCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NutritionalCategory>()
                .HasMany(e => e.NNutritionalCharacteristics)
                .WithRequired(e => e.NutritionalCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ration>()
                .Property(e => e.Heft)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Tasks>()
                .Property(e => e.Task1)
                .IsUnicode(false);

            modelBuilder.Entity<Tasks>()
                .HasMany(e => e.FNutritionalCharacteristics)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tasks>()
                .HasMany(e => e.Rations)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete(false);
        }
    }
}
