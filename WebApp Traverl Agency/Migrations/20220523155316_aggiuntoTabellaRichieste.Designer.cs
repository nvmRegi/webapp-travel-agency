﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp_Traverl_Agency.Data;

#nullable disable

namespace WebApp_Traverl_Agency.Migrations
{
    [DbContext(typeof(TravelContext))]
    [Migration("20220523155316_aggiuntoTabellaRichieste")]
    partial class aggiuntoTabellaRichieste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApp_Traverl_Agency.Models.PacchettoViaggio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<string>("Immagine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroDestinazioni")
                        .HasColumnType("int");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pacchetto_Viaggio");
                });

            modelBuilder.Entity("WebApp_Traverl_Agency.Models.RichiestaInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("CognomeUtente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailUtente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeUtente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacchettoViaggioId")
                        .HasColumnType("int");

                    b.Property<string>("Richiesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("PacchettoViaggioId");

                    b.ToTable("Richiesta_Informazioni");
                });

            modelBuilder.Entity("WebApp_Traverl_Agency.Models.RichiestaInfo", b =>
                {
                    b.HasOne("WebApp_Traverl_Agency.Models.PacchettoViaggio", "PacchettoViaggio")
                        .WithMany("RichiesteInfo")
                        .HasForeignKey("PacchettoViaggioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PacchettoViaggio");
                });

            modelBuilder.Entity("WebApp_Traverl_Agency.Models.PacchettoViaggio", b =>
                {
                    b.Navigation("RichiesteInfo");
                });
#pragma warning restore 612, 618
        }
    }
}