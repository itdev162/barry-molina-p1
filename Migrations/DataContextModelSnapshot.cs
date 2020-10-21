﻿// <auto-generated />
using System;
using InventoryManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventoryManager.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("InventoryManager.InventoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastOrderDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NextOrderDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderAtQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantityOnHand")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Vendor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("InventoryItems");
                });
#pragma warning restore 612, 618
        }
    }
}
