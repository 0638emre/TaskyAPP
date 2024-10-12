﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tasky.DAL.Context;

#nullable disable

namespace Tasky.DAL.Migrations
{
    [DbContext(typeof(TaskDBContext))]
    partial class TaskDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tasky.Entities.Models.Iletisim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AracPlaka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EvAdres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Il")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ilce")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsAdres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KanGrubu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<string>("Memleket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostaKodu")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId")
                        .IsUnique();

                    b.ToTable("Iletisimler");
                });

            modelBuilder.Entity("Tasky.Entities.Models.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Kategori");
                });

            modelBuilder.Entity("Tasky.Entities.Models.Konu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KonuAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Konular");
                });

            modelBuilder.Entity("Tasky.Entities.Models.KonuKategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<int>("KonuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KategoriId");

                    b.HasIndex("KonuId");

                    b.ToTable("KonuKategori");
                });

            modelBuilder.Entity("Tasky.Entities.Models.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GSM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("Tasky.Entities.Models.KullaniciKonu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("KonuId")
                        .HasColumnType("int");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KonuId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("KullaniciKonulari");
                });

            modelBuilder.Entity("Tasky.Entities.Models.KullaniciYetki", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<int>("YetkiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId")
                        .IsUnique();

                    b.HasIndex("YetkiId");

                    b.ToTable("KullaniciYetkiler");
                });

            modelBuilder.Entity("Tasky.Entities.Models.Lugat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<string>("OzluSoz")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Lugatlar");
                });

            modelBuilder.Entity("Tasky.Entities.Models.Yetki", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("YetkiAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Yetkiler");
                });

            modelBuilder.Entity("Tasky.Entities.Models.Iletisim", b =>
                {
                    b.HasOne("Tasky.Entities.Models.Kullanici", "Kullanici")
                        .WithOne("KullaniciIletisim")
                        .HasForeignKey("Tasky.Entities.Models.Iletisim", "KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("Tasky.Entities.Models.KonuKategori", b =>
                {
                    b.HasOne("Tasky.Entities.Models.Kategori", "Kategori")
                        .WithMany("KonuKategoriler")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasky.Entities.Models.Konu", "Konu")
                        .WithMany("KonuKategoriler")
                        .HasForeignKey("KonuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");

                    b.Navigation("Konu");
                });

            modelBuilder.Entity("Tasky.Entities.Models.KullaniciKonu", b =>
                {
                    b.HasOne("Tasky.Entities.Models.Konu", "Konu")
                        .WithMany("KullaniciKonular")
                        .HasForeignKey("KonuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasky.Entities.Models.Kullanici", "Kullanici")
                        .WithMany("KullaniciKonular")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Konu");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("Tasky.Entities.Models.KullaniciYetki", b =>
                {
                    b.HasOne("Tasky.Entities.Models.Kullanici", "Kullanici")
                        .WithOne("KullaniciYetki")
                        .HasForeignKey("Tasky.Entities.Models.KullaniciYetki", "KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasky.Entities.Models.Yetki", "Yetki")
                        .WithMany("KullaniciYetkileri")
                        .HasForeignKey("YetkiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");

                    b.Navigation("Yetki");
                });

            modelBuilder.Entity("Tasky.Entities.Models.Lugat", b =>
                {
                    b.HasOne("Tasky.Entities.Models.Kullanici", "Kullanici")
                        .WithMany()
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("Tasky.Entities.Models.Kategori", b =>
                {
                    b.Navigation("KonuKategoriler");
                });

            modelBuilder.Entity("Tasky.Entities.Models.Konu", b =>
                {
                    b.Navigation("KonuKategoriler");

                    b.Navigation("KullaniciKonular");
                });

            modelBuilder.Entity("Tasky.Entities.Models.Kullanici", b =>
                {
                    b.Navigation("KullaniciIletisim")
                        .IsRequired();

                    b.Navigation("KullaniciKonular");

                    b.Navigation("KullaniciYetki")
                        .IsRequired();
                });

            modelBuilder.Entity("Tasky.Entities.Models.Yetki", b =>
                {
                    b.Navigation("KullaniciYetkileri");
                });
#pragma warning restore 612, 618
        }
    }
}
