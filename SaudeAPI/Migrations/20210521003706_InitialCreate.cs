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
                name: "Usuario",
                columns: table => new
                {
                    CdUsuario = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DcLogin = table.Column<string>(maxLength: 50, nullable: true),
                    DcSenha = table.Column<string>(maxLength: 255, nullable: true),
                    DcEmail = table.Column<string>(maxLength: 150, nullable: true),
                    DcTokencel = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.CdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "RefrnciaEnfrmdade",
                columns: table => new
                {
                    CdRefrnciaEnfrmdade = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdRefrncia = table.Column<int>(nullable: false),
                    CdEnfrmdade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefrnciaEnfrmdade", x => x.CdRefrnciaEnfrmdade);
                    table.ForeignKey(
                        name: "FK_RefrnciaEnfrmdade_Enfrmdade_CdEnfrmdade",
                        column: x => x.CdEnfrmdade,
                        principalTable: "Enfrmdade",
                        principalColumn: "CdEnfrmdade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefrnciaEnfrmdade_Refrncia_CdRefrncia",
                        column: x => x.CdRefrncia,
                        principalTable: "Refrncia",
                        principalColumn: "CdRefrncia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hsptal",
                columns: table => new
                {
                    CdHsptal = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NmHsptal = table.Column<string>(maxLength: 255, nullable: true),
                    CdUsuario = table.Column<int>(nullable: false),
                    CdEndrco = table.Column<int>(nullable: false),
                    DcTlfone = table.Column<string>(maxLength: 15, nullable: true),
                    QtLeito = table.Column<int>(maxLength: 10, nullable: false),
                    IcAtivo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hsptal", x => x.CdHsptal);
                    table.ForeignKey(
                        name: "FK_Hsptal_Endrco_CdEndrco",
                        column: x => x.CdEndrco,
                        principalTable: "Endrco",
                        principalColumn: "CdEndrco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hsptal_Usuario_CdUsuario",
                        column: x => x.CdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CdUsuario",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Log_Usuario_CdUsuario",
                        column: x => x.CdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "CdUsuario",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_Paciente_Usuario_CdUsuarioRgst",
                        column: x => x.CdUsuarioRgst,
                        principalTable: "Usuario",
                        principalColumn: "CdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HsptalRefrncia",
                columns: table => new
                {
                    CdHsptalRefrncia = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdHsptal = table.Column<int>(nullable: false),
                    CdRefrncia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HsptalRefrncia", x => x.CdHsptalRefrncia);
                    table.ForeignKey(
                        name: "FK_HsptalRefrncia_Hsptal_CdHsptal",
                        column: x => x.CdHsptal,
                        principalTable: "Hsptal",
                        principalColumn: "CdHsptal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HsptalRefrncia_Refrncia_CdRefrncia",
                        column: x => x.CdRefrncia,
                        principalTable: "Refrncia",
                        principalColumn: "CdRefrncia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slctcao",
                columns: table => new
                {
                    CdSlctcao = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdHsptal = table.Column<int>(nullable: false),
                    CdPaciente = table.Column<int>(nullable: false),
                    CdStatus = table.Column<int>(nullable: false),
                    DcMotivo = table.Column<string>(maxLength: 255, nullable: true),
                    CdUsuarioRgst = table.Column<int>(nullable: false),
                    DtRgst = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slctcao", x => x.CdSlctcao);
                    table.ForeignKey(
                        name: "FK_Slctcao_Hsptal_CdHsptal",
                        column: x => x.CdHsptal,
                        principalTable: "Hsptal",
                        principalColumn: "CdHsptal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slctcao_Paciente_CdPaciente",
                        column: x => x.CdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "CdPaciente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slctcao_Status_CdStatus",
                        column: x => x.CdStatus,
                        principalTable: "Status",
                        principalColumn: "CdStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slctcao_Usuario_CdUsuarioRgst",
                        column: x => x.CdUsuarioRgst,
                        principalTable: "Usuario",
                        principalColumn: "CdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlctcaoEnfrmdade",
                columns: table => new
                {
                    CdSlctcaoEnfrmdade = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdSlctcao = table.Column<int>(nullable: false),
                    CdEnfrmdade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlctcaoEnfrmdade", x => x.CdSlctcaoEnfrmdade);
                    table.ForeignKey(
                        name: "FK_SlctcaoEnfrmdade_Enfrmdade_CdEnfrmdade",
                        column: x => x.CdEnfrmdade,
                        principalTable: "Enfrmdade",
                        principalColumn: "CdEnfrmdade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlctcaoEnfrmdade_Slctcao_CdSlctcao",
                        column: x => x.CdSlctcao,
                        principalTable: "Slctcao",
                        principalColumn: "CdSlctcao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlctcaoExame",
                columns: table => new
                {
                    CdSlctcaoExame = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdSlctcao = table.Column<int>(nullable: false),
                    CdExame = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlctcaoExame", x => x.CdSlctcaoExame);
                    table.ForeignKey(
                        name: "FK_SlctcaoExame_Exame_CdExame",
                        column: x => x.CdExame,
                        principalTable: "Exame",
                        principalColumn: "CdExame",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlctcaoExame_Slctcao_CdSlctcao",
                        column: x => x.CdSlctcao,
                        principalTable: "Slctcao",
                        principalColumn: "CdSlctcao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlctcaoObs",
                columns: table => new
                {
                    CdSlctcaoObs = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdSlctcao = table.Column<int>(nullable: false),
                    DcObs = table.Column<string>(maxLength: 255, nullable: true),
                    CdUsuarioRgst = table.Column<int>(nullable: false),
                    DtRgst = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlctcaoObs", x => x.CdSlctcaoObs);
                    table.ForeignKey(
                        name: "FK_SlctcaoObs_Slctcao_CdSlctcao",
                        column: x => x.CdSlctcao,
                        principalTable: "Slctcao",
                        principalColumn: "CdSlctcao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlctcaoObs_Usuario_CdUsuarioRgst",
                        column: x => x.CdUsuarioRgst,
                        principalTable: "Usuario",
                        principalColumn: "CdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hsptal_CdEndrco",
                table: "Hsptal",
                column: "CdEndrco");

            migrationBuilder.CreateIndex(
                name: "IX_Hsptal_CdUsuario",
                table: "Hsptal",
                column: "CdUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HsptalRefrncia_CdHsptal",
                table: "HsptalRefrncia",
                column: "CdHsptal");

            migrationBuilder.CreateIndex(
                name: "IX_HsptalRefrncia_CdRefrncia",
                table: "HsptalRefrncia",
                column: "CdRefrncia");

            migrationBuilder.CreateIndex(
                name: "IX_Log_CdUsuario",
                table: "Log",
                column: "CdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_CdUsuarioRgst",
                table: "Paciente",
                column: "CdUsuarioRgst");

            migrationBuilder.CreateIndex(
                name: "IX_RefrnciaEnfrmdade_CdEnfrmdade",
                table: "RefrnciaEnfrmdade",
                column: "CdEnfrmdade");

            migrationBuilder.CreateIndex(
                name: "IX_RefrnciaEnfrmdade_CdRefrncia",
                table: "RefrnciaEnfrmdade",
                column: "CdRefrncia");

            migrationBuilder.CreateIndex(
                name: "IX_Slctcao_CdHsptal",
                table: "Slctcao",
                column: "CdHsptal");

            migrationBuilder.CreateIndex(
                name: "IX_Slctcao_CdPaciente",
                table: "Slctcao",
                column: "CdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Slctcao_CdStatus",
                table: "Slctcao",
                column: "CdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Slctcao_CdUsuarioRgst",
                table: "Slctcao",
                column: "CdUsuarioRgst");

            migrationBuilder.CreateIndex(
                name: "IX_SlctcaoEnfrmdade_CdEnfrmdade",
                table: "SlctcaoEnfrmdade",
                column: "CdEnfrmdade");

            migrationBuilder.CreateIndex(
                name: "IX_SlctcaoEnfrmdade_CdSlctcao",
                table: "SlctcaoEnfrmdade",
                column: "CdSlctcao");

            migrationBuilder.CreateIndex(
                name: "IX_SlctcaoExame_CdExame",
                table: "SlctcaoExame",
                column: "CdExame");

            migrationBuilder.CreateIndex(
                name: "IX_SlctcaoExame_CdSlctcao",
                table: "SlctcaoExame",
                column: "CdSlctcao");

            migrationBuilder.CreateIndex(
                name: "IX_SlctcaoObs_CdSlctcao",
                table: "SlctcaoObs",
                column: "CdSlctcao");

            migrationBuilder.CreateIndex(
                name: "IX_SlctcaoObs_CdUsuarioRgst",
                table: "SlctcaoObs",
                column: "CdUsuarioRgst");
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

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
