﻿using Microsoft.EntityFrameworkCore;
using ShipmentApp.Infrastructure.Entities;

namespace ShipmentApp.Infrastructure.Context
{
    public partial class ShipmentContext : DbContext
    {
        public ShipmentContext(DbContextOptions<ShipmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrier> Carriers { get; set; } = null!;
        public virtual DbSet<Shipment> Shipments { get; set; } = null!;
        public virtual DbSet<ShipmentRate> ShipmentRates { get; set; } = null!;
        public virtual DbSet<Shipper> Shippers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.ToTable("CARRIER");

                entity.Property(e => e.CarrierId)
                    .ValueGeneratedNever()
                    .HasColumnName("carrier_id");

                entity.Property(e => e.CarrierMode)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("carrier_mode");

                entity.Property(e => e.CarrierName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("carrier_name");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("SHIPMENT");

                entity.Property(e => e.ShipmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("shipment_id");

                entity.Property(e => e.CarrierId).HasColumnName("carrier_id");

                entity.Property(e => e.ShipmentDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("shipment_description");

                entity.Property(e => e.ShipmentRateId).HasColumnName("shipment_rate_id");

                entity.Property(e => e.ShipmentWeight)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("shipment_weight");

                entity.Property(e => e.ShipperId).HasColumnName("shipper_id");

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SHIPMENT_CARRIER");

                entity.HasOne(d => d.ShipmentRate)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.ShipmentRateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SHIPMENT_SHIPMENT_RATE");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.ShipperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SHIPMENT_SHIPPER");
            });

            modelBuilder.Entity<ShipmentRate>(entity =>
            {
                entity.ToTable("SHIPMENT_RATE");

                entity.Property(e => e.ShipmentRateId)
                    .ValueGeneratedNever()
                    .HasColumnName("shipment_rate_id");

                entity.Property(e => e.ShipmentRateClass)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("shipment_rate_class");

                entity.Property(e => e.ShipmentRateDescription)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("shipment_rate_description");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("SHIPPER");

                entity.Property(e => e.ShipperId)
                    .ValueGeneratedNever()
                    .HasColumnName("shipper_id");

                entity.Property(e => e.ShipperName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("shipper_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
