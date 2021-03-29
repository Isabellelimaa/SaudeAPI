using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaudeAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endrco",
                columns: table => new
                {
                    CdEndrco = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NmPais = table.Column<string>(maxLength: 100, nullable: true),
                    NmEstado = table.Column<string>(maxLength: 100, nullable: true),
                    NmCidade = table.Column<string>(maxLength: 150, nullable: true),
                    NmBairro = table.Column<string>(maxLength: 100, nullable: true),
                    NmRua = table.Column<string>(maxLength: 200, nullable: true),
                    NrNumero = table.Column<int>(maxLength: 10, nullable: false),
                    DcComplmnto = table.Column<string>(maxLength: 200, nullable: true),
                    DcCep = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endrco", x => x.CdEndrco);
                });

            migrationBuilder.CreateTable(
                name: "Enfrmdade",
                columns: table => new
                {
                    CdEnfrmdade = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NmEnfrmdade = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfrmdade", x => x.CdEnfrmdade);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    CdExame = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NmExame = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.CdExame);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    CdLog = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdUsuario = table.Column<int>(nullable: true),
                    DcLog = table.Column<string>(maxLength: 200, nullable: true),
                    DtLog = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.CdLog);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    CdPaciente = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NmPaciente = table.Column<string>(maxLength: 150, nullable: true),
                    DcCpf = table.Column<string>(maxLength: 15, nullable: true),
                    DcRg = table.Column<string>(maxLength: 10, nullable: true),
                    CdUsuarioRgst = table.Column<int>(nullable: false),
                    DtRgst = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.CdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Refrncia",
                columns: table => new
                {
                    CdRefrncia = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NmRefrncia = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refrncia", x => x.CdRefrncia);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    CdStatus = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NmStatus = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.CdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Hsptal",
                columns: table => new
                {
                    CdHsptal = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NmHsptal = table.Column<string>(maxLength: 255, nullable: true),
                    CdEndrco = table.Column<int>(nullable: false),
                    DcTlfone = table.Column<string>(maxLength: 15, nullable: true),
                    QtLeito = table.Column<int>(maxLength: 10, nullable: false),
                    IcAtivo = table.Column<string>(nullable: false),
                    EndrcoCdEndrco = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hsptal", x => x.CdHsptal);
                    table.ForeignKey(
                        name: "FK_Hsptal_Endrco_EndrcoCdEndrco",
                        column: x => x.EndrcoCdEndrco,
                        principalTable: "Endrco",
                        principalColumn: "CdEndrco",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefrnciaEnfrmdade",
                columns: table => new
                {
                    CdRefrnciaEnfrmdade = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdRefrncia = table.Column<int>(nullable: false),
                    CdEnfrmdade = table.Column<int>(nullable: false),
                    RefrnciaCdRefrncia = table.Column<int>(nullable: true),
                    EnfrmdadeCdEnfrmdade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefrnciaEnfrmdade", x => x.CdRefrnciaEnfrmdade);
                    table.ForeignKey(
                        name: "FK_RefrnciaEnfrmdade_Enfrmdade_EnfrmdadeCdEnfrmdade",
                        column: x => x.EnfrmdadeCdEnfrmdade,
                        principalTable: "Enfrmdade",
                        principalColumn: "CdEnfrmdade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RefrnciaEnfrmdade_Refrncia_RefrnciaCdRefrncia",
                        column: x => x.RefrnciaCdRefrncia,
                        principalTable: "Refrncia",
                        principalColumn: "CdRefrncia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slctcao",
                columns: table => new
                {
                    CdSlctcao = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdPaciente = table.Column<int>(nullable: false),
                    CdStatus = table.Column<int>(nullable: false),
                    DcMotivo = table.Column<string>(maxLength: 255, nullable: true),
                    CdUsuarioRgst = table.Column<int>(nullable: false),
                    DtRgst = table.Column<DateTime>(nullable: false),
                    StatusCdStatus = table.Column<int>(nullable: true),
                    PacienteCdPaciente = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slctcao", x => x.CdSlctcao);
                    table.ForeignKey(
                        name: "FK_Slctcao_Paciente_PacienteCdPaciente",
                        column: x => x.PacienteCdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "CdPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Slctcao_Status_StatusCdStatus",
                        column: x => x.StatusCdStatus,
                        principalTable: "Status",
                        principalColumn: "CdStatus",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HsptalRefrncia",
                columns: table => new
                {
                    CdHsptalRefrncia = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdHsptal = table.Column<int>(nullable: false),
                    CdRefrncia = table.Column<int>(nullable: false),
                    HsptalCdHsptal = table.Column<int>(nullable: true),
                    RefrnciaCdRefrncia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HsptalRefrncia", x => x.CdHsptalRefrncia);
                    table.ForeignKey(
                        name: "FK_HsptalRefrncia_Hsptal_HsptalCdHsptal",
                        column: x => x.HsptalCdHsptal,
                        principalTable: "Hsptal",
                        principalColumn: "CdHsptal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HsptalRefrncia_Refrncia_RefrnciaCdRefrncia",
                        column: x => x.RefrnciaCdRefrncia,
                        principalTable: "Refrncia",
                        principalColumn: "CdRefrncia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    CdUsuario = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DcLogin = table.Column<string>(maxLength: 50, nullable: true),
                    DcSenha = table.Column<string>(maxLength: 255, nullable: true),
                    DcEmail = table.Column<string>(maxLength: 150, nullable: true),
                    CdHsptal = table.Column<int>(nullable: false),
                    DcTokencel = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.CdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Hsptal_CdHsptal",
                        column: x => x.CdHsptal,
                        principalTable: "Hsptal",
                        principalColumn: "CdHsptal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlctcaoEnfrmdade",
                columns: table => new
                {
                    CdSlctcaoEnfrmdade = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdSlctcao = table.Column<int>(nullable: false),
                    CdEnfrmdade = table.Column<int>(nullable: false),
                    SlctcaoCdSlctcao = table.Column<int>(nullable: true),
                    EnfrmdadeCdEnfrmdade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlctcaoEnfrmdade", x => x.CdSlctcaoEnfrmdade);
                    table.ForeignKey(
                        name: "FK_SlctcaoEnfrmdade_Enfrmdade_EnfrmdadeCdEnfrmdade",
                        column: x => x.EnfrmdadeCdEnfrmdade,
                        principalTable: "Enfrmdade",
                        principalColumn: "CdEnfrmdade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SlctcaoEnfrmdade_Slctcao_SlctcaoCdSlctcao",
                        column: x => x.SlctcaoCdSlctcao,
                        principalTable: "Slctcao",
                        principalColumn: "CdSlctcao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SlctcaoExame",
                columns: table => new
                {
                    CdSlctcaoExame = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdSlctcao = table.Column<int>(nullable: false),
                    CdExame = table.Column<int>(nullable: false),
                    SlctcaoCdSlctcao = table.Column<int>(nullable: true),
                    ExameCdExame = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlctcaoExame", x => x.CdSlctcaoExame);
                    table.ForeignKey(
                        name: "FK_SlctcaoExame_Exame_ExameCdExame",
                        column: x => x.ExameCdExame,
                        principalTable: "Exame",
                        principalColumn: "CdExame",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SlctcaoExame_Slctcao_SlctcaoCdSlctcao",
                        column: x => x.SlctcaoCdSlctcao,
                        principalTable: "Slctcao",
                        principalColumn: "CdSlctcao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SlctcaoObs",
                columns: table => new
                {
                    CdSlctcaoObs = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdSlctcao = table.Column<int>(nullable: false),
                    DcObs = table.Column<string>(maxLength: 255, nullable: true),
                    CdUsuario = table.Column<int>(nullable: false),
                    DtRgst = table.Column<DateTime>(nullable: false),
                    SlctcaoCdSlctcao = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlctcaoObs", x => x.CdSlctcaoObs);
                    table.ForeignKey(
                        name: "FK_SlctcaoObs_Slctcao_SlctcaoCdSlctcao",
                        column: x => x.SlctcaoCdSlctcao,
                        principalTable: "Slctcao",
                        principalColumn: "CdSlctcao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hsptal_EndrcoCdEndrco",
                table: "Hsptal",
                column: "EndrcoCdEndrco");

            migrationBuilder.CreateIndex(
                name: "IX_HsptalRefrncia_HsptalCdHsptal",
                table: "HsptalRefrncia",
                column: "HsptalCdHsptal");

            migrationBuilder.CreateIndex(
                name: "IX_HsptalRefrncia_RefrnciaCdRefrncia",
                table: "HsptalRefrncia",
                column: "RefrnciaCdRefrncia");

            migrationBuilder.CreateIndex(
                name: "IX_RefrnciaEnfrmdade_EnfrmdadeCdEnfrmdade",
                table: "RefrnciaEnfrmdade",
                column: "EnfrmdadeCdEnfrmdade");

            migrationBuilder.CreateIndex(
                name: "IX_RefrnciaEnfrmdade_RefrnciaCdRefrncia",
                table: "RefrnciaEnfrmdade",
                column: "RefrnciaCdRefrncia");

            migrationBuilder.CreateIndex(
                name: "IX_Slctcao_PacienteCdPaciente",
                table: "Slctcao",
                column: "PacienteCdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Slctcao_StatusCdStatus",
                table: "Slctcao",
                column: "StatusCdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_SlctcaoEnfrmdade_EnfrmdadeCdEnfrmdade",
                table: "SlctcaoEnfrmdade",
                column: "EnfrmdadeCdEnfrmdade");

            migrationBuilder.CreateIndex(
                name: "IX_SlctcaoEnfrmdade_SlctcaoCdSlctcao",
                table: "SlctcaoEnfrmdade",
                column: "SlctcaoCdSlctcao");

            migrationBuilder.CreateIndex(
                name: "IX_SlctcaoExame_ExameCdExame",
                table: "SlctcaoExame",
                column: "ExameCdExame");

            migrationBuilder.CreateIndex(
                name: "IX_SlctcaoExame_SlctcaoCdSlctcao",
                table: "SlctcaoExame",
                column: "SlctcaoCdSlctcao");

            migrationBuilder.CreateIndex(
                name: "IX_SlctcaoObs_SlctcaoCdSlctcao",
                table: "SlctcaoObs",
                column: "SlctcaoCdSlctcao");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CdHsptal",
                table: "Usuario",
                column: "CdHsptal",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HsptalRefrncia");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "RefrnciaEnfrmdade");

            migrationBuilder.DropTable(
                name: "SlctcaoEnfrmdade");

            migrationBuilder.DropTable(
                name: "SlctcaoExame");

            migrationBuilder.DropTable(
                name: "SlctcaoObs");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Refrncia");

            migrationBuilder.DropTable(
                name: "Enfrmdade");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "Slctcao");

            migrationBuilder.DropTable(
                name: "Hsptal");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Endrco");
        }
    }
}
