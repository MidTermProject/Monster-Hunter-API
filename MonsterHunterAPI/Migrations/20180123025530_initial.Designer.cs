﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MonsterHunterAPI.Data;
using System;

namespace MonsterHunterAPI.Migrations
{
    [DbContext(typeof(HunterDbContext))]
    [Migration("20180123025530_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MonsterHunterAPI.Models.Blade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Affinity");

                    b.Property<int>("Defense");

                    b.Property<string>("Description");

                    b.Property<int>("ElementDamage");

                    b.Property<string>("ElementType");

                    b.Property<bool>("HasChild");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ParentID");

                    b.Property<int>("Rarity");

                    b.Property<int>("RawDamage");

                    b.Property<int>("Sharpness");

                    b.Property<int>("Slots");

                    b.Property<string>("WeaponClass")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.ToTable("Blades");
                });

            modelBuilder.Entity("MonsterHunterAPI.Models.BladeMaterial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BladeID");

                    b.Property<int?>("MaterialID");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.HasIndex("BladeID");

                    b.HasIndex("MaterialID");

                    b.ToTable("BladesMaterials");
                });

            modelBuilder.Entity("MonsterHunterAPI.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Area");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("MonsterHunterAPI.Models.Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Rarity");

                    b.HasKey("ID");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("MonsterHunterAPI.Models.MaterialLocation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action")
                        .IsRequired();

                    b.Property<int>("DropRate");

                    b.Property<int?>("LocationID");

                    b.Property<int?>("MaterialID");

                    b.HasKey("ID");

                    b.HasIndex("LocationID");

                    b.HasIndex("MaterialID");

                    b.ToTable("MaterialsLocations");
                });

            modelBuilder.Entity("MonsterHunterAPI.Models.Blade", b =>
                {
                    b.HasOne("MonsterHunterAPI.Models.Blade", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("MonsterHunterAPI.Models.BladeMaterial", b =>
                {
                    b.HasOne("MonsterHunterAPI.Models.Blade", "Blade")
                        .WithMany()
                        .HasForeignKey("BladeID");

                    b.HasOne("MonsterHunterAPI.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialID");
                });

            modelBuilder.Entity("MonsterHunterAPI.Models.MaterialLocation", b =>
                {
                    b.HasOne("MonsterHunterAPI.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID");

                    b.HasOne("MonsterHunterAPI.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialID");
                });
#pragma warning restore 612, 618
        }
    }
}
