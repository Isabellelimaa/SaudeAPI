﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaudeAPI.Context;

namespace SaudeAPI.Migrations
{
    [DbContext(typeof(SaudeContext))]
    [Migration("20210521003706_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SaudeAPI.Models.Db.Endrco", b =>
                {
                    b.Property<int>("CdEndrco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DcCep")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("DcComplmnto")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("NmBairro")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("NmCidade")
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<string>("NmEstado")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("NmPais")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("NmRua")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<int>("NrNumero")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.HasKey("CdEndrco");

                    b.ToTable("Endrco");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Enfrmdade", b =>
                {
                    b.Property<int>("CdEnfrmdade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NmEnfrmdade")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.HasKey("CdEnfrmdade");

                    b.ToTable("Enfrmdade");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Exame", b =>
                {
                    b.Property<int>("CdExame")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NmExame")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.HasKey("CdExame");

                    b.ToTable("Exame");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Hsptal", b =>
                {
                    b.Property<int>("CdHsptal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CdEndrco")
                        .HasColumnType("int");

                    b.Property<int>("CdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("DcTlfone")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("IcAtivo")
                        .IsRequired()
                        .HasColumnType("varchar(1) CHARACTER SET utf8mb4");

                    b.Property<string>("NmHsptal")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("QtLeito")
                        .HasColumnType("int")
                        .HasMaxLength(10);

                    b.HasKey("CdHsptal");

                    b.HasIndex("CdEndrco");

                    b.HasIndex("CdUsuario")
                        .IsUnique();

                    b.ToTable("Hsptal");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.HsptalRefrncia", b =>
                {
                    b.Property<int>("CdHsptalRefrncia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CdHsptal")
                        .HasColumnType("int");

                    b.Property<int>("CdRefrncia")
                        .HasColumnType("int");

                    b.HasKey("CdHsptalRefrncia");

                    b.HasIndex("CdHsptal");

                    b.HasIndex("CdRefrncia");

                    b.ToTable("HsptalRefrncia");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Log", b =>
                {
                    b.Property<int>("CdLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("DcLog")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<DateTime>("DtLog")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CdLog");

                    b.HasIndex("CdUsuario");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Paciente", b =>
                {
                    b.Property<int>("CdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CdUsuarioRgst")
                        .HasColumnType("int");

                    b.Property<string>("DcCpf")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("DcRg")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<DateTime>("DtRgst")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NmPaciente")
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.HasKey("CdPaciente");

                    b.HasIndex("CdUsuarioRgst");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Refrncia", b =>
                {
                    b.Property<int>("CdRefrncia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NmRefrncia")
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.HasKey("CdRefrncia");

                    b.ToTable("Refrncia");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.RefrnciaEnfrmdade", b =>
                {
                    b.Property<int>("CdRefrnciaEnfrmdade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CdEnfrmdade")
                        .HasColumnType("int");

                    b.Property<int>("CdRefrncia")
                        .HasColumnType("int");

                    b.HasKey("CdRefrnciaEnfrmdade");

                    b.HasIndex("CdEnfrmdade");

                    b.HasIndex("CdRefrncia");

                    b.ToTable("RefrnciaEnfrmdade");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Slctcao", b =>
                {
                    b.Property<int>("CdSlctcao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CdHsptal")
                        .HasColumnType("int");

                    b.Property<int>("CdPaciente")
                        .HasColumnType("int");

                    b.Property<int>("CdStatus")
                        .HasColumnType("int");

                    b.Property<int>("CdUsuarioRgst")
                        .HasColumnType("int");

                    b.Property<string>("DcMotivo")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("DtRgst")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CdSlctcao");

                    b.HasIndex("CdHsptal");

                    b.HasIndex("CdPaciente");

                    b.HasIndex("CdStatus");

                    b.HasIndex("CdUsuarioRgst");

                    b.ToTable("Slctcao");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.SlctcaoEnfrmdade", b =>
                {
                    b.Property<int>("CdSlctcaoEnfrmdade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CdEnfrmdade")
                        .HasColumnType("int");

                    b.Property<int>("CdSlctcao")
                        .HasColumnType("int");

                    b.HasKey("CdSlctcaoEnfrmdade");

                    b.HasIndex("CdEnfrmdade");

                    b.HasIndex("CdSlctcao");

                    b.ToTable("SlctcaoEnfrmdade");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.SlctcaoExame", b =>
                {
                    b.Property<int>("CdSlctcaoExame")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CdExame")
                        .HasColumnType("int");

                    b.Property<int>("CdSlctcao")
                        .HasColumnType("int");

                    b.HasKey("CdSlctcaoExame");

                    b.HasIndex("CdExame");

                    b.HasIndex("CdSlctcao");

                    b.ToTable("SlctcaoExame");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.SlctcaoObs", b =>
                {
                    b.Property<int>("CdSlctcaoObs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CdSlctcao")
                        .HasColumnType("int");

                    b.Property<int>("CdUsuarioRgst")
                        .HasColumnType("int");

                    b.Property<string>("DcObs")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("DtRgst")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CdSlctcaoObs");

                    b.HasIndex("CdSlctcao");

                    b.HasIndex("CdUsuarioRgst");

                    b.ToTable("SlctcaoObs");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Status", b =>
                {
                    b.Property<int>("CdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NmStatus")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.HasKey("CdStatus");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Usuario", b =>
                {
                    b.Property<int>("CdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DcEmail")
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<string>("DcLogin")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("DcSenha")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("DcTokencel")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("CdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Hsptal", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Endrco", "Endrco")
                        .WithMany("Hsptal")
                        .HasForeignKey("CdEndrco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaudeAPI.Models.Db.Usuario", "Usuario")
                        .WithOne("Hsptal")
                        .HasForeignKey("SaudeAPI.Models.Db.Hsptal", "CdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.HsptalRefrncia", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Hsptal", "Hsptal")
                        .WithMany("HsptalRefrncia")
                        .HasForeignKey("CdHsptal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaudeAPI.Models.Db.Refrncia", "Refrncia")
                        .WithMany("HsptalRefrncia")
                        .HasForeignKey("CdRefrncia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Log", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Usuario", "Usuario")
                        .WithMany("Log")
                        .HasForeignKey("CdUsuario");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Paciente", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Usuario", "Usuario")
                        .WithMany("Paciente")
                        .HasForeignKey("CdUsuarioRgst")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.RefrnciaEnfrmdade", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Enfrmdade", "Enfrmdade")
                        .WithMany("RefrnciaEnfrmdade")
                        .HasForeignKey("CdEnfrmdade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaudeAPI.Models.Db.Refrncia", "Refrncia")
                        .WithMany("RefrnciaEnfrmdade")
                        .HasForeignKey("CdRefrncia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Slctcao", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Hsptal", "Hsptal")
                        .WithMany("Slctcao")
                        .HasForeignKey("CdHsptal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaudeAPI.Models.Db.Paciente", "Paciente")
                        .WithMany("Slctcao")
                        .HasForeignKey("CdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaudeAPI.Models.Db.Status", "Status")
                        .WithMany("Slctcao")
                        .HasForeignKey("CdStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaudeAPI.Models.Db.Usuario", "Usuario")
                        .WithMany("Slctcao")
                        .HasForeignKey("CdUsuarioRgst")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.SlctcaoEnfrmdade", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Enfrmdade", "Enfrmdade")
                        .WithMany("SlctcaoEnfrmdade")
                        .HasForeignKey("CdEnfrmdade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaudeAPI.Models.Db.Slctcao", "Slctcao")
                        .WithMany("SlctcaoEnfrmdade")
                        .HasForeignKey("CdSlctcao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.SlctcaoExame", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Exame", "Exame")
                        .WithMany("SlctcaoExame")
                        .HasForeignKey("CdExame")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaudeAPI.Models.Db.Slctcao", "Slctcao")
                        .WithMany("SlctcaoExame")
                        .HasForeignKey("CdSlctcao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.SlctcaoObs", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Slctcao", "Slctcao")
                        .WithMany("SlctcaoObs")
                        .HasForeignKey("CdSlctcao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SaudeAPI.Models.Db.Usuario", "Usuario")
                        .WithMany("SlctcaoObs")
                        .HasForeignKey("CdUsuarioRgst")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
