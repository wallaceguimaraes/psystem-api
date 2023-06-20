using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class CreateInitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cadastro");

            migrationBuilder.CreateTable(
                name: "Cnae",
                schema: "cadastro",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cnae", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFantasia = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    CodigoCnae = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    TipoNegocio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiglaTipoNegocio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImplementacaoSistema = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(44)", maxLength: 44, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(44)", maxLength: 44, nullable: true),
                    IsPatient = table.Column<bool>(type: "bit", nullable: false),
                    Funcionario = table.Column<bool>(type: "bit", nullable: false),
                    SuperAdmin = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    InativoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmpresa",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                schema: "cadastro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IdEmpresa = table.Column<long>(type: "bigint", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perfil_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalSchema: "cadastro",
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                schema: "cadastro",
                columns: table => new
                {
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    IdCidade = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdPessoa);
                    table.ForeignKey(
                        name: "FK_Endereco_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalSchema: "cadastro",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                schema: "cadastro",
                columns: table => new
                {
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.IdPessoa);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalSchema: "cadastro",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                schema: "cadastro",
                columns: table => new
                {
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    IdTipoEmpresa = table.Column<int>(type: "int", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    CodigoCnae = table.Column<int>(type: "int", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.IdPessoa);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Cnae_CodigoCnae",
                        column: x => x.CodigoCnae,
                        principalSchema: "cadastro",
                        principalTable: "Cnae",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalSchema: "cadastro",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_TipoEmpresa_IdTipoEmpresa",
                        column: x => x.IdTipoEmpresa,
                        principalSchema: "cadastro",
                        principalTable: "TipoEmpresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolderId = table.Column<long>(type: "bigint", nullable: true),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleUser_Perfil_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "cadastro",
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Pessoa_HolderId",
                        column: x => x.HolderId,
                        principalSchema: "cadastro",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "cadastro",
                columns: table => new
                {
                    IdPessoa = table.Column<long>(type: "bigint", nullable: false),
                    IdPerfil = table.Column<long>(type: "bigint", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdPessoa);
                    table.ForeignKey(
                        name: "FK_Usuario_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalSchema: "cadastro",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_RoleUser_RoleUserId",
                        column: x => x.RoleUserId,
                        principalTable: "RoleUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_IdEmpresa",
                schema: "cadastro",
                table: "Perfil",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Funcionario",
                schema: "cadastro",
                table: "Pessoa",
                column: "Funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaFisica_Cpf",
                schema: "cadastro",
                table: "PessoaFisica",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_Cnpj",
                schema: "cadastro",
                table: "PessoaJuridica",
                column: "Cnpj");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_CodigoCnae",
                schema: "cadastro",
                table: "PessoaJuridica",
                column: "CodigoCnae");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_IdTipoEmpresa",
                schema: "cadastro",
                table: "PessoaJuridica",
                column: "IdTipoEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_HolderId",
                table: "RoleUser",
                column: "HolderId",
                unique: true,
                filter: "[HolderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_RoleId",
                table: "RoleUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                schema: "cadastro",
                table: "Usuario",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RoleUserId",
                schema: "cadastro",
                table: "Usuario",
                column: "RoleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Senha",
                schema: "cadastro",
                table: "Usuario",
                column: "Senha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "PessoaFisica",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "PessoaJuridica",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "Cnae",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "TipoEmpresa",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "Perfil",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "cadastro");

            migrationBuilder.DropTable(
                name: "Empresa",
                schema: "cadastro");
        }
    }
}
