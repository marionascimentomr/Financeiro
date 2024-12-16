﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pay.Infra.Data.Contexts;

#nullable disable

namespace Pay.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241214021631_CreateCustomerTable")]
    partial class CreateCustomerTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Pay.Domain.Moldes.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BankCode")
                        .HasColumnType("integer");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("InterestPercentage")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("Pay.Domain.Moldes.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ValorLimite")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Pay.Domain.Moldes.PaymentSlip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BankId")
                        .HasColumnType("uuid");

                    b.Property<string>("BeneficiaryDocument")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BeneficiaryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PayerDocument")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PayerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("PaymentSlip");
                });

            modelBuilder.Entity("Pay.Domain.Moldes.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Pay.Domain.Moldes.PaymentSlip", b =>
                {
                    b.HasOne("Pay.Domain.Moldes.Bank", "Bank")
                        .WithMany("PaymentSlips")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("Pay.Domain.Moldes.Bank", b =>
                {
                    b.Navigation("PaymentSlips");
                });
#pragma warning restore 612, 618
        }
    }
}
