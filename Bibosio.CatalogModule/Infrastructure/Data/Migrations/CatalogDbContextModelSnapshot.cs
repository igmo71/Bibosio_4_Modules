﻿// <auto-generated />
using System;
using Bibosio.CatalogModule.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bibosio.CatalogModule.Infrastructure.Data.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    partial class CatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("catalog")
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bibosio.CatalogModule.Domain.CatalogItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCategory")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsUseInProductName")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("CatalogItems", "catalog");
                });

            modelBuilder.Entity("Bibosio.CatalogModule.Domain.CatalogItemOption", b =>
                {
                    b.Property<Guid>("CatalogItemId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OptionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OptionValueId")
                        .HasColumnType("uuid");

                    b.Property<string>("Template")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CatalogItemId", "OptionId", "OptionValueId");

                    b.HasIndex("OptionId");

                    b.HasIndex("OptionValueId");

                    b.ToTable("CatalogItemOptions", "catalog");
                });

            modelBuilder.Entity("Bibosio.CatalogModule.Domain.Option", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("PriorityInProductName")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Options", "catalog");
                });

            modelBuilder.Entity("Bibosio.CatalogModule.Domain.OptionValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OptionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.ToTable("OptionValues", "catalog");
                });

            modelBuilder.Entity("Bibosio.CatalogModule.Domain.CatalogItem", b =>
                {
                    b.HasOne("Bibosio.CatalogModule.Domain.CatalogItem", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.OwnsOne("Bibosio.CatalogModule.Domain.ValueObjects.Sku", "Sku", b1 =>
                        {
                            b1.Property<Guid>("CatalogItemId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("CatalogItemId");

                            b1.ToTable("CatalogItems", "catalog");

                            b1.WithOwner()
                                .HasForeignKey("CatalogItemId");
                        });

                    b.Navigation("Parent");

                    b.Navigation("Sku");
                });

            modelBuilder.Entity("Bibosio.CatalogModule.Domain.CatalogItemOption", b =>
                {
                    b.HasOne("Bibosio.CatalogModule.Domain.CatalogItem", "CatalogItem")
                        .WithMany("CatalogItemOptions")
                        .HasForeignKey("CatalogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibosio.CatalogModule.Domain.Option", "Option")
                        .WithMany()
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bibosio.CatalogModule.Domain.OptionValue", "OptionValue")
                        .WithMany()
                        .HasForeignKey("OptionValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogItem");

                    b.Navigation("Option");

                    b.Navigation("OptionValue");
                });

            modelBuilder.Entity("Bibosio.CatalogModule.Domain.OptionValue", b =>
                {
                    b.HasOne("Bibosio.CatalogModule.Domain.Option", "Option")
                        .WithMany("OptionValues")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");
                });

            modelBuilder.Entity("Bibosio.CatalogModule.Domain.CatalogItem", b =>
                {
                    b.Navigation("CatalogItemOptions");

                    b.Navigation("Children");
                });

            modelBuilder.Entity("Bibosio.CatalogModule.Domain.Option", b =>
                {
                    b.Navigation("OptionValues");
                });
#pragma warning restore 612, 618
        }
    }
}
