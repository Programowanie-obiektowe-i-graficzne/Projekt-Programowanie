﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_Programowanie.Data;

#nullable disable

namespace Projekt_Programowanie.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230804150756_Initial_Create1")]
    partial class Initial_Create1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.Krzyzowka", b =>
                {
                    b.Property<int>("ID_Krzyzowki")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pyt1ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pyt2ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pyt3ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pyt4ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pyt5ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pyt6ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Trudnosc")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WzorID_Wzoru")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID_Krzyzowki");

                    b.HasIndex("Pyt1ID");

                    b.HasIndex("Pyt2ID");

                    b.HasIndex("Pyt3ID");

                    b.HasIndex("Pyt4ID");

                    b.HasIndex("Pyt5ID");

                    b.HasIndex("Pyt6ID");

                    b.HasIndex("WzorID_Wzoru");

                    b.ToTable("Krzyzowki");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.Pytanie", b =>
                {
                    b.Property<int>("ID_Pytania")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OdpowiedzID_Slowa")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Trudnosc")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID_Pytania");

                    b.HasIndex("OdpowiedzID_Slowa");

                    b.ToTable("Pytania");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.Slowo", b =>
                {
                    b.Property<int>("ID_Slowa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Dl_Slowa")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Kategoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NazwaSlowa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID_Slowa");

                    b.ToTable("Slowa");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.TabelaWynikow", b =>
                {
                    b.Property<int>("ID_Wynikow")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Czas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KrzyzowkaID_Krzyzowki")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Trudnosc")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID_Wynikow");

                    b.HasIndex("KrzyzowkaID_Krzyzowki");

                    b.ToTable("TabeleWynikow");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.Uzytkownik", b =>
                {
                    b.Property<int>("ID_Uzytkownik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ilosc_Rozwiazanych")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Najlepszy_Czas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TabelaWynikowID_Wynikow")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID_Uzytkownik");

                    b.HasIndex("TabelaWynikowID_Wynikow");

                    b.ToTable("Uzytkownicy");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.Wzor", b =>
                {
                    b.Property<int>("ID_Wzoru")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rozmiar")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Slowo1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Slowo2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Slowo3")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Slowo4")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Slowo5")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Slowo6")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID_Wzoru");

                    b.ToTable("Wzory");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.Krzyzowka", b =>
                {
                    b.HasOne("Projekt_Programowanie.Models.MODELS.Pytanie", "Pytanie_1")
                        .WithMany()
                        .HasForeignKey("Pyt1ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Programowanie.Models.MODELS.Pytanie", "Pytanie_2")
                        .WithMany()
                        .HasForeignKey("Pyt2ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Programowanie.Models.MODELS.Pytanie", "Pytanie_3")
                        .WithMany()
                        .HasForeignKey("Pyt3ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Programowanie.Models.MODELS.Pytanie", "Pytanie_4")
                        .WithMany()
                        .HasForeignKey("Pyt4ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Programowanie.Models.MODELS.Pytanie", "Pytanie_5")
                        .WithMany()
                        .HasForeignKey("Pyt5ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Programowanie.Models.MODELS.Pytanie", "Pytanie_6")
                        .WithMany()
                        .HasForeignKey("Pyt6ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Programowanie.Models.MODELS.Wzor", "Wzor")
                        .WithMany("Krzyzowki")
                        .HasForeignKey("WzorID_Wzoru")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pytanie_1");

                    b.Navigation("Pytanie_2");

                    b.Navigation("Pytanie_3");

                    b.Navigation("Pytanie_4");

                    b.Navigation("Pytanie_5");

                    b.Navigation("Pytanie_6");

                    b.Navigation("Wzor");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.Pytanie", b =>
                {
                    b.HasOne("Projekt_Programowanie.Models.MODELS.Slowo", "Odpowiedz")
                        .WithMany("Pytania")
                        .HasForeignKey("OdpowiedzID_Slowa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Odpowiedz");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.TabelaWynikow", b =>
                {
                    b.HasOne("Projekt_Programowanie.Models.MODELS.Krzyzowka", "Krzyzowka")
                        .WithMany("Wyniki")
                        .HasForeignKey("KrzyzowkaID_Krzyzowki")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Krzyzowka");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.Uzytkownik", b =>
                {
                    b.HasOne("Projekt_Programowanie.Models.MODELS.TabelaWynikow", "TabelaWynikow")
                        .WithMany("Uzytkownicy")
                        .HasForeignKey("TabelaWynikowID_Wynikow")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TabelaWynikow");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.Krzyzowka", b =>
                {
                    b.Navigation("Wyniki");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.Slowo", b =>
                {
                    b.Navigation("Pytania");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.TabelaWynikow", b =>
                {
                    b.Navigation("Uzytkownicy");
                });

            modelBuilder.Entity("Projekt_Programowanie.Models.MODELS.Wzor", b =>
                {
                    b.Navigation("Krzyzowki");
                });
#pragma warning restore 612, 618
        }
    }
}
