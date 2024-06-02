﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication6.Context;

#nullable disable

namespace WebApplication6.Migrations
{
    [DbContext(typeof(MasterContext))]
    partial class MasterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication6.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor")
                        .HasName("Doctor_pk");

                    b.ToTable("Doctor", (string)null);
                });

            modelBuilder.Entity("WebApplication6.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicament"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament")
                        .HasName("Medicament_pk");

                    b.ToTable("Medicament", (string)null);
                });

            modelBuilder.Entity("WebApplication6.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatient"));

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient")
                        .HasName("Patient_pk");

                    b.ToTable("Patient", (string)null);
                });

            modelBuilder.Entity("WebApplication6.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescription"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription")
                        .HasName("Prescription_pk");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescription", (string)null);
                });

            modelBuilder.Entity("WebApplication6.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament", "IdPrescription")
                        .HasName("Prescription_Medicament_pk");

                    b.HasIndex("IdPrescription");

                    b.ToTable("Prescription_Medicament", (string)null);
                });

            modelBuilder.Entity("WebApplication6.Models.Prescription", b =>
                {
                    b.HasOne("WebApplication6.Models.Doctor", "IdDoctorNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .IsRequired()
                        .HasConstraintName("Prescription_Doctor");

                    b.HasOne("WebApplication6.Models.Patient", "IdPatientNavigation")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .IsRequired()
                        .HasConstraintName("Prescription_Patient");

                    b.Navigation("IdDoctorNavigation");

                    b.Navigation("IdPatientNavigation");
                });

            modelBuilder.Entity("WebApplication6.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("WebApplication6.Models.Medicament", "IdMedicamentNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdMedicament")
                        .IsRequired()
                        .HasConstraintName("Prescription_Medicament_Medicament");

                    b.HasOne("WebApplication6.Models.Prescription", "IdPrescriptionNavigation")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("IdPrescription")
                        .IsRequired()
                        .HasConstraintName("Prescription_Medicament_Prescription");

                    b.Navigation("IdMedicamentNavigation");

                    b.Navigation("IdPrescriptionNavigation");
                });

            modelBuilder.Entity("WebApplication6.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("WebApplication6.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("WebApplication6.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("WebApplication6.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}