﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPPro.Data;

#nullable disable

namespace TPPro.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("TPPro.Model.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategorieNom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategorieId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TPPro.Model.Produit", b =>
                {
                    b.Property<int>("ProduitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategorieID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Prix")
                        .HasColumnType("REAL");

                    b.Property<string>("ProduitName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantite")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProduitID");

                    b.HasIndex("CategorieID");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("TPPro.Model.Produit", b =>
                {
                    b.HasOne("TPPro.Model.Categorie", "Categorie")
                        .WithMany("Produits")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("TPPro.Model.Categorie", b =>
                {
                    b.Navigation("Produits");
                });
#pragma warning restore 612, 618
        }
    }
}
