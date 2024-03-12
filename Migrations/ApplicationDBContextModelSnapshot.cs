﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace incidentdbapi.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("incidentdbapi.IncidentModel", b =>
                {
                    b.Property<int>("Incidentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("IncidentAssignTo")
                        .HasColumnType("longtext");

                    b.Property<string>("IncidentComment")
                        .HasColumnType("longtext");

                    b.Property<string>("IncidentCreateBy")
                        .HasColumnType("longtext");

                    b.Property<string>("IncidentCreateDate")
                        .HasColumnType("longtext");

                    b.Property<string>("IncidentDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("IncidentModifyBy")
                        .HasColumnType("longtext");

                    b.Property<string>("IncidentModifyDate")
                        .HasColumnType("longtext");

                    b.Property<string>("IncidentName")
                        .HasColumnType("longtext");

                    b.Property<string>("IncidentStatus")
                        .HasColumnType("longtext");

                    b.HasKey("Incidentid");

                    b.ToTable("incident");
                });

            modelBuilder.Entity("incidentdbapi.RegistrationModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserCompany")
                        .HasColumnType("longtext");

                    b.Property<string>("UserCreateDate")
                        .HasColumnType("longtext");

                    b.Property<string>("UserEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserPassword")
                        .HasColumnType("longtext");

                    b.Property<string>("UserRole")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("login");
                });
#pragma warning restore 612, 618
        }
    }
}
