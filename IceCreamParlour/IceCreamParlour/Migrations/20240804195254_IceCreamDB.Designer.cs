﻿// <auto-generated />
using IceCreamProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IceCreamParlour.Migrations
{
    [DbContext(typeof(AddDBContext))]
    [Migration("20240804195254_IceCreamDB")]
    partial class IceCreamDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IceCreamProject.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("IceCreamProject.Models.Books", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("B_Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("IceCreamProject.Models.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("IceCreamProject.Models.Order", b =>
                {
                    b.Property<int>("Order_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Order_ID"));

                    b.Property<int>("Amount_Payable")
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Order_ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("IceCreamProject.Models.Recipe", b =>
                {
                    b.Property<int>("Recipe_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Recipe_ID"));

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Procedure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("R_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("R_Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recipe_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Recipe_ID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("IceCreamProject.Models.Users", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("active")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IceCreamParlour.Models.payments", b =>
            {
                b.Property<int>("PaymentID")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                b.Property<string>("NameOnCard")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CardNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CVV")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ExpirationDate")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("PaymentID");

                b.ToTable("payments");
            });
#pragma warning restore 612, 618
        }
    }
}
