﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(StoreAppContext))]
    partial class StoreAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("InShoppingCart")
                        .HasColumnType("int")
                        .HasColumnName("Cart");

                    b.Property<int>("amountPicked")
                        .HasColumnType("int");

                    b.Property<string>("customerGuild")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Owner_Id");

                    b.Property<int>("the_store_id")
                        .HasColumnType("int")
                        .HasColumnName("Location");

                    b.HasKey("id");

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

                    b.Property<string>("customerGuid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("storeLocationID")
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("orderID");

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
#pragma warning restore 612, 618
        }
    }
}
