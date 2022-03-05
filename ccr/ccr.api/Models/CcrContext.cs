using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ccr.api.Models
{
    public partial class CcrContext : DbContext
    {
        public CcrContext()
        {
        }

        public CcrContext(DbContextOptions<CcrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chef> Chefs { get; set; } = null!;
        public virtual DbSet<Crew> Crews { get; set; } = null!;
        public virtual DbSet<Ingrediant> Ingrediants { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<XRecipeCrew> XRecipeCrews { get; set; } = null!;
        public virtual DbSet<XRecipeIngrediant> XRecipeIngrediants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;initial catalog=food;Trusted_Connection=True;persist security info=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chef>(entity =>
            {
                entity.HasKey(e => e.IdChef)
                    .HasName("PK__chef__68D7E078B2FA1851");

                entity.ToTable("chef");

                entity.Property(e => e.IdChef).HasColumnName("id_chef");

                entity.Property(e => e.EmailChef)
                    .HasMaxLength(50)
                    .HasColumnName("email_chef");

                entity.Property(e => e.NameChef)
                    .HasMaxLength(50)
                    .HasColumnName("name_chef");

                entity.Property(e => e.PasswordChef)
                    .HasMaxLength(50)
                    .HasColumnName("password_chef");

                entity.HasMany(d => d.IdCrews)
                    .WithMany(p => p.IdChefs)
                    .UsingEntity<Dictionary<string, object>>(
                        "XChefCrew",
                        l => l.HasOne<Crew>().WithMany().HasForeignKey("IdCrew").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_chef_crew_crew"),
                        r => r.HasOne<Chef>().WithMany().HasForeignKey("IdChef").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_chef_crew_chef"),
                        j =>
                        {
                            j.HasKey("IdChef", "IdCrew").HasName("pk_chef_crew");

                            j.ToTable("x_chef_crew");

                            j.IndexerProperty<int>("IdChef").HasColumnName("id_chef");

                            j.IndexerProperty<int>("IdCrew").HasColumnName("id_crew");
                        });

                entity.HasMany(d => d.IdIngrediants)
                    .WithMany(p => p.IdChefs)
                    .UsingEntity<Dictionary<string, object>>(
                        "XChefIngrediant",
                        l => l.HasOne<Ingrediant>().WithMany().HasForeignKey("IdIngrediant").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_chef_ingrediant_ingrediant"),
                        r => r.HasOne<Chef>().WithMany().HasForeignKey("IdChef").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_chef_ingrediant_chef"),
                        j =>
                        {
                            j.HasKey("IdChef", "IdIngrediant").HasName("pk_chef_ingrediant");

                            j.ToTable("x_chef_ingrediant");

                            j.IndexerProperty<int>("IdChef").HasColumnName("id_chef");

                            j.IndexerProperty<int>("IdIngrediant").HasColumnName("id_ingrediant");
                        });

                entity.HasMany(d => d.IdRecipes)
                    .WithMany(p => p.IdChefs)
                    .UsingEntity<Dictionary<string, object>>(
                        "XChefRecipe",
                        l => l.HasOne<Recipe>().WithMany().HasForeignKey("IdRecipe").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_chef_recipe_recipe"),
                        r => r.HasOne<Chef>().WithMany().HasForeignKey("IdChef").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_chef_recipe_chef"),
                        j =>
                        {
                            j.HasKey("IdChef", "IdRecipe").HasName("pk_chef_recipe");

                            j.ToTable("x_chef_recipe");

                            j.IndexerProperty<int>("IdChef").HasColumnName("id_chef");

                            j.IndexerProperty<int>("IdRecipe").HasColumnName("id_recipe");
                        });
            });

            modelBuilder.Entity<Crew>(entity =>
            {
                entity.HasKey(e => e.IdCrew)
                    .HasName("PK__crew__6C2BEF97D5EAF908");

                entity.ToTable("crew");

                entity.Property(e => e.IdCrew).HasColumnName("id_crew");

                entity.Property(e => e.NameCrew)
                    .HasMaxLength(50)
                    .HasColumnName("name_crew");
            });

            modelBuilder.Entity<Ingrediant>(entity =>
            {
                entity.HasKey(e => e.IdIngrediant)
                    .HasName("PK__ingredia__9A4EA44969E54730");

                entity.ToTable("ingrediant");

                entity.Property(e => e.IdIngrediant).HasColumnName("id_ingrediant");

                entity.Property(e => e.NameIngrediant)
                    .HasMaxLength(50)
                    .HasColumnName("name_ingrediant");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.IdRecipe)
                    .HasName("PK__recipe__1F2843E653DBF01A");

                entity.ToTable("recipe");

                entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");

                entity.Property(e => e.ImageRecipe)
                    .HasMaxLength(8000)
                    .HasColumnName("image_recipe");

                entity.Property(e => e.NameRecipe)
                    .HasMaxLength(50)
                    .HasColumnName("name_recipe");
            });

            modelBuilder.Entity<XRecipeCrew>(entity =>
            {
                entity.HasKey(e => new { e.IdRecipe, e.IdCrew })
                    .HasName("pk_recipe_crew");

                entity.ToTable("x_recipe_crew");

                entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");

                entity.Property(e => e.IdCrew).HasColumnName("id_crew");

                entity.Property(e => e.StateOfRecipe)
                    .HasMaxLength(10)
                    .HasColumnName("state_of_recipe");

                entity.HasOne(d => d.IdCrewNavigation)
                    .WithMany(p => p.XRecipeCrews)
                    .HasForeignKey(d => d.IdCrew)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recipe_crew_crew");

                entity.HasOne(d => d.IdRecipeNavigation)
                    .WithMany(p => p.XRecipeCrews)
                    .HasForeignKey(d => d.IdRecipe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recipe_crew_recipe");
            });

            modelBuilder.Entity<XRecipeIngrediant>(entity =>
            {
                entity.HasKey(e => new { e.IdRecipe, e.IdIngrediant })
                    .HasName("pk_recipe_ingrediant");

                entity.ToTable("x_recipe_ingrediant");

                entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");

                entity.Property(e => e.IdIngrediant).HasColumnName("id_ingrediant");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdIngrediantNavigation)
                    .WithMany(p => p.XRecipeIngrediants)
                    .HasForeignKey(d => d.IdIngrediant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recipe_ingrediant_ingrediant");

                entity.HasOne(d => d.IdRecipeNavigation)
                    .WithMany(p => p.XRecipeIngrediants)
                    .HasForeignKey(d => d.IdRecipe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recipe_ingrediant_recipe");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
