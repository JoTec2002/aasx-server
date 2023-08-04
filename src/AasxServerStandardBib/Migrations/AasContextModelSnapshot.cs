﻿// <auto-generated />
using AasxServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AasxServerStandardBib.Migrations
{
    [DbContext(typeof(AasContext))]
    partial class AasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AasxServer.AASXSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AASX")
                        .HasColumnType("text");

                    b.Property<long>("AASXNum")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AASXNum");

                    b.ToTable("AASXSets");
                });

            modelBuilder.Entity("AasxServer.AasSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("AASXNum")
                        .HasColumnType("bigint");

                    b.Property<string>("AasId")
                        .HasColumnType("text");

                    b.Property<long>("AasNum")
                        .HasColumnType("bigint");

                    b.Property<string>("AssetId")
                        .HasColumnType("text");

                    b.Property<string>("AssetKind")
                        .HasColumnType("text");

                    b.Property<string>("Idshort")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AasNum");

                    b.ToTable("AasSets");
                });

            modelBuilder.Entity("AasxServer.DbConfigSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("AASXCount")
                        .HasColumnType("bigint");

                    b.Property<long>("AasCount")
                        .HasColumnType("bigint");

                    b.Property<long>("SMECount")
                        .HasColumnType("bigint");

                    b.Property<long>("SubmodelCount")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("DbConfigSets");
                });

            modelBuilder.Entity("AasxServer.SMESet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("FValue")
                        .HasColumnType("double precision");

                    b.Property<long>("IValue")
                        .HasColumnType("bigint");

                    b.Property<string>("Idshort")
                        .HasColumnType("text");

                    b.Property<long>("ParentSMENum")
                        .HasColumnType("bigint");

                    b.Property<long>("SMENum")
                        .HasColumnType("bigint");

                    b.Property<string>("SMEType")
                        .HasColumnType("text");

                    b.Property<string>("SValue")
                        .HasColumnType("text");

                    b.Property<string>("SemanticId")
                        .HasColumnType("text");

                    b.Property<long>("SubmodelNum")
                        .HasColumnType("bigint");

                    b.Property<string>("ValueType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SMENum");

                    b.HasIndex("SubmodelNum");

                    b.ToTable("SMESets");
                });

            modelBuilder.Entity("AasxServer.SubmodelSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long>("AASXNum")
                        .HasColumnType("bigint");

                    b.Property<long>("AasNum")
                        .HasColumnType("bigint");

                    b.Property<string>("Idshort")
                        .HasColumnType("text");

                    b.Property<string>("SemanticId")
                        .HasColumnType("text");

                    b.Property<string>("SubmodelId")
                        .HasColumnType("text");

                    b.Property<long>("SubmodelNum")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SubmodelNum");

                    b.ToTable("SubmodelSets");
                });
#pragma warning restore 612, 618
        }
    }
}
