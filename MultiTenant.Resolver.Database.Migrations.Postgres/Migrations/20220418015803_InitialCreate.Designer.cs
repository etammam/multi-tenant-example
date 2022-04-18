﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiTenant.Resolver.Database.Migrations.Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MultiTenant.Resolver.Database.Migrations.Npgsql.Migrations
{
    [DbContext(typeof(NpgsqlCatalogContext))]
    [Migration("20220418015803_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MultiTenant.Core.Database.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConnectionString")
                        .HasColumnType("text");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Provider")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Identifier")
                        .IsUnique();

                    b.ToTable("Tenants");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2f50c97-8df2-4343-8e13-ce3c3c8550cb"),
                            ConnectionString = "data source=192.168.1.60;user id=sa; password=Code@1903;initial catalog=tenant-default",
                            Identifier = "default",
                            Name = "Default",
                            Provider = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
