using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GrafanaSensorServer.Infra.Database
{
    public partial class GrafanaSensorsContext : DbContext
    {
        public GrafanaSensorsContext()
        {
        }

        public GrafanaSensorsContext(DbContextOptions<GrafanaSensorsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sensor> Sensors { get; set; }
        public virtual DbSet<Value> Values { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Sensors__737584F7F5205C92");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.State).HasMaxLength(255);
            });

            modelBuilder.Entity<Value>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ReadingTime).HasColumnType("datetime");

                entity.Property(e => e.Sensor).HasMaxLength(255);

                entity.Property(e => e.Value1).HasColumnName("Value");

                entity.HasOne(d => d.SensorNavigation)
                    .WithMany(p => p.Values)
                    .HasForeignKey(d => d.Sensor)
                    .HasConstraintName("FK__Values__Sensor__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
