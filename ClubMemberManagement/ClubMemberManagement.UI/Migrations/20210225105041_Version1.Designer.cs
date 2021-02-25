﻿// <auto-generated />
using System;
using ClubMemberManagement.UI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClubMemberManagement.UI.Migrations
{
    [DbContext(typeof(ClubMemberManagementDbContext))]
    [Migration("20210225105041_Version1")]
    partial class Version1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClubMemberManagement.UI.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Geburtstag")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hausnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Land")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nachname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PLZ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Straße")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Vereinseintritt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Vorname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("ClubMemberManagement.UI.Models.MemberPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsPayed")
                        .HasColumnType("bit");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("MembershipFeeId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("MembershipFeeId");

                    b.ToTable("MembershipPayment");
                });

            modelBuilder.Entity("ClubMemberManagement.UI.Models.MembershipFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Betrag")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MembershipFee");
                });

            modelBuilder.Entity("ClubMemberManagement.UI.Models.PaymentHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MemberPaymentId")
                        .HasColumnType("int");

                    b.Property<decimal>("Payed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PayedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MemberPaymentId");

                    b.ToTable("PaymentHistory");
                });

            modelBuilder.Entity("ClubMemberManagement.UI.Models.MemberPayment", b =>
                {
                    b.HasOne("ClubMemberManagement.UI.Models.Member", "Member")
                        .WithMany("MemberPayments")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClubMemberManagement.UI.Models.MembershipFee", "MembershipFee")
                        .WithMany("MemberPayments")
                        .HasForeignKey("MembershipFeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("MembershipFee");
                });

            modelBuilder.Entity("ClubMemberManagement.UI.Models.PaymentHistory", b =>
                {
                    b.HasOne("ClubMemberManagement.UI.Models.MemberPayment", "MemberPayments")
                        .WithMany("PaymentHistory")
                        .HasForeignKey("MemberPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MemberPayments");
                });

            modelBuilder.Entity("ClubMemberManagement.UI.Models.Member", b =>
                {
                    b.Navigation("MemberPayments");
                });

            modelBuilder.Entity("ClubMemberManagement.UI.Models.MemberPayment", b =>
                {
                    b.Navigation("PaymentHistory");
                });

            modelBuilder.Entity("ClubMemberManagement.UI.Models.MembershipFee", b =>
                {
                    b.Navigation("MemberPayments");
                });
#pragma warning restore 612, 618
        }
    }
}
