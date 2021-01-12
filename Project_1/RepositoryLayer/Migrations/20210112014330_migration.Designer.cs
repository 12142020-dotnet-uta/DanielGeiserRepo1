﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(StoreAppContext))]
    [Migration("20210112014330_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ModelLayer.Cart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("InShoppingCartId")
                        .HasColumnType("int");

                    b.Property<Guid>("customer")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Owner_Id");

                    b.Property<int?>("store_idId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("InShoppingCartId");

                    b.HasIndex("store_idId");

                    b.ToTable("cart");
                });

            modelBuilder.Entity("ModelLayer.Customer", b =>
                {
                    b.Property<Guid>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Addmin")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ByteArrayImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("favstore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Customer_Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("ModelLayer.Item", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Id_TO_S")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("qty")
                        .HasColumnType("int");

                    b.Property<double>("sale")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ItemsAtStore");
                });

            modelBuilder.Entity("ModelLayer.OrderedItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("pricePaid")
                        .HasColumnType("float");

                    b.Property<int>("qtyOrdered")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("orderedItems");
                });

            modelBuilder.Entity("ModelLayer.Orders", b =>
                {
                    b.Property<int>("orderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<Guid?>("Customer_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("stroeLocationId")
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("orderID");

                    b.HasIndex("Customer_Id");

                    b.HasIndex("stroeLocationId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("ModelLayer.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("ModelLayer.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("storeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("totalSales")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("stores");
                });

            modelBuilder.Entity("ModelLayer.Cart", b =>
                {
                    b.HasOne("ModelLayer.Item", "InShoppingCart")
                        .WithMany()
                        .HasForeignKey("InShoppingCartId");

                    b.HasOne("ModelLayer.Store", "store_id")
                        .WithMany()
                        .HasForeignKey("store_idId");

                    b.Navigation("InShoppingCart");

                    b.Navigation("store_id");
                });

            modelBuilder.Entity("ModelLayer.Orders", b =>
                {
                    b.HasOne("ModelLayer.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("Customer_Id");

                    b.HasOne("ModelLayer.Store", "stroeLocation")
                        .WithMany()
                        .HasForeignKey("stroeLocationId");

                    b.Navigation("customer");

                    b.Navigation("stroeLocation");
                });
#pragma warning restore 612, 618
        }
    }
}