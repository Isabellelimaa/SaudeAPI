﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaudeAPI.Context;

namespace SaudeAPI.Migrations
{
    [DbContext(typeof(SaudeContext))]
    partial class SaudeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasIndex("CdEndrco")
                        .IsUnique();

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

                    b.Property<int?>("HsptalCdHsptal")
                        .HasColumnType("int");

                    b.Property<int?>("RefrnciaCdRefrncia")
                        .HasColumnType("int");

                    b.HasKey("CdHsptalRefrncia");

                    b.HasIndex("HsptalCdHsptal");

                    b.HasIndex("RefrnciaCdRefrncia");

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

                    b.Property<int?>("EnfrmdadeCdEnfrmdade")
                        .HasColumnType("int");

                    b.Property<int?>("RefrnciaCdRefrncia")
                        .HasColumnType("int");

                    b.HasKey("CdRefrnciaEnfrmdade");

                    b.HasIndex("EnfrmdadeCdEnfrmdade");

                    b.HasIndex("RefrnciaCdRefrncia");

                    b.ToTable("RefrnciaEnfrmdade");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Slctcao", b =>
                {
                    b.Property<int>("CdSlctcao")
                        .ValueGeneratedOnAdd()
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

                    b.Property<int?>("PacienteCdPaciente")
                        .HasColumnType("int");

                    b.Property<int?>("StatusCdStatus")
                        .HasColumnType("int");

                    b.HasKey("CdSlctcao");

                    b.HasIndex("PacienteCdPaciente");

                    b.HasIndex("StatusCdStatus");

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

                    b.Property<int?>("EnfrmdadeCdEnfrmdade")
                        .HasColumnType("int");

                    b.Property<int?>("SlctcaoCdSlctcao")
                        .HasColumnType("int");

                    b.HasKey("CdSlctcaoEnfrmdade");

                    b.HasIndex("EnfrmdadeCdEnfrmdade");

                    b.HasIndex("SlctcaoCdSlctcao");

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

                    b.Property<int?>("ExameCdExame")
                        .HasColumnType("int");

                    b.Property<int?>("SlctcaoCdSlctcao")
                        .HasColumnType("int");

                    b.HasKey("CdSlctcaoExame");

                    b.HasIndex("ExameCdExame");

                    b.HasIndex("SlctcaoCdSlctcao");

                    b.ToTable("SlctcaoExame");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.SlctcaoObs", b =>
                {
                    b.Property<int>("CdSlctcaoObs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CdSlctcao")
                        .HasColumnType("int");

                    b.Property<int>("CdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("DcObs")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("DtRgst")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("SlctcaoCdSlctcao")
                        .HasColumnType("int");

                    b.HasKey("CdSlctcaoObs");

                    b.HasIndex("SlctcaoCdSlctcao");

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
                        .WithOne("Hsptal")
                        .HasForeignKey("SaudeAPI.Models.Db.Hsptal", "CdEndrco")
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
                        .HasForeignKey("HsptalCdHsptal");

                    b.HasOne("SaudeAPI.Models.Db.Refrncia", "Refrncia")
                        .WithMany("HsptalRefrncia")
                        .HasForeignKey("RefrnciaCdRefrncia");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.RefrnciaEnfrmdade", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Enfrmdade", "Enfrmdade")
                        .WithMany("RefrnciaEnfrmdade")
                        .HasForeignKey("EnfrmdadeCdEnfrmdade");

                    b.HasOne("SaudeAPI.Models.Db.Refrncia", "Refrncia")
                        .WithMany("RefrnciaEnfrmdade")
                        .HasForeignKey("RefrnciaCdRefrncia");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.Slctcao", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Paciente", "Paciente")
                        .WithMany("Slctcao")
                        .HasForeignKey("PacienteCdPaciente");

                    b.HasOne("SaudeAPI.Models.Db.Status", "Status")
                        .WithMany("Slctcao")
                        .HasForeignKey("StatusCdStatus");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.SlctcaoEnfrmdade", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Enfrmdade", "Enfrmdade")
                        .WithMany("SlctcaoEnfrmdade")
                        .HasForeignKey("EnfrmdadeCdEnfrmdade");

                    b.HasOne("SaudeAPI.Models.Db.Slctcao", "Slctcao")
                        .WithMany("SlctcaoEnfrmdade")
                        .HasForeignKey("SlctcaoCdSlctcao");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.SlctcaoExame", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Exame", "Exame")
                        .WithMany("SlctcaoExame")
                        .HasForeignKey("ExameCdExame");

                    b.HasOne("SaudeAPI.Models.Db.Slctcao", "Slctcao")
                        .WithMany("SlctcaoExame")
                        .HasForeignKey("SlctcaoCdSlctcao");
                });

            modelBuilder.Entity("SaudeAPI.Models.Db.SlctcaoObs", b =>
                {
                    b.HasOne("SaudeAPI.Models.Db.Slctcao", "Slctcao")
                        .WithMany("SlctcaoObs")
                        .HasForeignKey("SlctcaoCdSlctcao");
                });
#pragma warning restore 612, 618
        }
    }
}
