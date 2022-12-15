﻿// <auto-generated />
using System;
using ImitModelBl.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImitModelBl.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221208232532_migr")]
    partial class migr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("ImitModelBl.Model.Check", b =>
                {
                    b.Property<int>("CheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("CheckId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Checks");
                });

            modelBuilder.Entity("ImitModelBl.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeWait")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ImitModelBl.Model.Master", b =>
                {
                    b.Property<int>("MasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CheckId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Qualification")
                        .HasColumnType("TEXT");

                    b.Property<string>("Speciality")
                        .HasColumnType("TEXT");

                    b.HasKey("MasterId");

                    b.HasIndex("CheckId");

                    b.ToTable("Masters");
                });

            modelBuilder.Entity("ImitModelBl.Model.Sell", b =>
                {
                    b.Property<int>("SellId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CheckId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MasterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ServiceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SellId");

                    b.HasIndex("CheckId");

                    b.HasIndex("MasterId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Sell");
                });

            modelBuilder.Entity("ImitModelBl.Model.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeRunning")
                        .HasColumnType("INTEGER");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ImitModelBl.Model.Check", b =>
                {
                    b.HasOne("ImitModelBl.Model.Customer", "Customer")
                        .WithMany("Checks")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ImitModelBl.Model.Master", b =>
                {
                    b.HasOne("ImitModelBl.Model.Check", null)
                        .WithMany("Masters")
                        .HasForeignKey("CheckId");
                });

            modelBuilder.Entity("ImitModelBl.Model.Sell", b =>
                {
                    b.HasOne("ImitModelBl.Model.Check", "Check")
                        .WithMany("SellId")
                        .HasForeignKey("CheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImitModelBl.Model.Master", "Master")
                        .WithMany("Sells")
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImitModelBl.Model.Service", "Service")
                        .WithMany("Sells")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Check");

                    b.Navigation("Master");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ImitModelBl.Model.Check", b =>
                {
                    b.Navigation("Masters");

                    b.Navigation("SellId");
                });

            modelBuilder.Entity("ImitModelBl.Model.Customer", b =>
                {
                    b.Navigation("Checks");
                });

            modelBuilder.Entity("ImitModelBl.Model.Master", b =>
                {
                    b.Navigation("Sells");
                });

            modelBuilder.Entity("ImitModelBl.Model.Service", b =>
                {
                    b.Navigation("Sells");
                });
#pragma warning restore 612, 618
        }
    }
}
