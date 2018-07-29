﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using TransactionLedger.Models;

namespace TransactionLedger.Models.Migrations
{
    [DbContext(typeof(WoollyBusinessLedgerContext))]
    [Migration("20180729083448_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-preview1-28290")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TransactionLedger.Models.Item", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description")
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("TransactionLedger.Models.Transaction", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DateOfTransaction")
                        .HasColumnType("datetime");

                    b.Property<int>("SupplierId");

                    b.Property<int>("TypeId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("TransactionLedger.Models.TransactionDetail", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("ItemId");

                    b.Property<int>("TransactionId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionDetail");
                });

            modelBuilder.Entity("TransactionLedger.Models.TransactionType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description")
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("TransactionType");
                });

            modelBuilder.Entity("TransactionLedger.Models.Transaction", b =>
                {
                    b.HasOne("TransactionLedger.Models.TransactionType", "Type")
                        .WithMany("Transaction")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Transaction_TransactionType");
                });

            modelBuilder.Entity("TransactionLedger.Models.TransactionDetail", b =>
                {
                    b.HasOne("TransactionLedger.Models.Item", "Item")
                        .WithMany("TransactionDetail")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_TransactionDetail_Item");

                    b.HasOne("TransactionLedger.Models.Transaction", "Transaction")
                        .WithMany("TransactionDetail")
                        .HasForeignKey("TransactionId")
                        .HasConstraintName("FK_TransactionDetail_Transaction");
                });
#pragma warning restore 612, 618
        }
    }
}
