﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data.Context;

namespace api.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api.Models.EntityModel.Addresses.Address", b =>
                {
                    b.Property<long>("PersonId")
                        .HasColumnType("bigint")
                        .HasColumnName("IdPessoa");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cidade");

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("IdCidade");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Bairro");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Endereco");

                    b.Property<string>("Line2")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("Complemento");

                    b.Property<string>("StreetNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Numero");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("Cep");

                    b.HasKey("PersonId");

                    b.ToTable("Endereco", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.BusinessTypes.BusinessType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acronym")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Sigla");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("TipoEmpresa", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.Cnaes.Cnae", b =>
                {
                    b.Property<int>("Code")
                        .HasColumnType("int")
                        .HasColumnName("Codigo");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Nome");

                    b.HasKey("Code");

                    b.ToTable("Cnae", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.Companies.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessTypeAcronym")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SiglaTipoNegocio");

                    b.Property<string>("BusinessTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoNegocio");

                    b.Property<string>("CnaeCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("CodigoCnae");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("RazaoSocial");

                    b.Property<DateTime>("SystemImplementation")
                        .HasColumnType("datetime2")
                        .HasColumnName("ImplementacaoSistema");

                    b.Property<string>("TaxDocument")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)")
                        .HasColumnName("Cnpj");

                    b.Property<string>("TradeName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("NomeFantasia");

                    b.HasKey("Id");

                    b.ToTable("Empresa", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.JuristicPersons.JuristicPerson", b =>
                {
                    b.Property<long>("PersonId")
                        .HasColumnType("bigint")
                        .HasColumnName("IdPessoa");

                    b.Property<int>("BusinessTypeId")
                        .HasColumnType("int")
                        .HasColumnName("IdTipoEmpresa");

                    b.Property<int?>("CnaeCode")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasColumnName("CodigoCnae");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("RazaoSocial");

                    b.Property<string>("TaxDocument")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)")
                        .HasColumnName("Cnpj");

                    b.Property<string>("TradeName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("NomeFantasia");

                    b.HasKey("PersonId");

                    b.HasIndex("BusinessTypeId");

                    b.HasIndex("CnaeCode");

                    b.HasIndex("TaxDocument");

                    b.ToTable("PessoaJuridica", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.NaturalPersons.NaturalPerson", b =>
                {
                    b.Property<long>("PersonId")
                        .HasColumnType("bigint")
                        .HasColumnName("IdPessoa");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)")
                        .HasColumnName("Nome");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("Genero");

                    b.Property<string>("TaxDocument")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)")
                        .HasColumnName("Cpf");

                    b.HasKey("PersonId");

                    b.HasIndex("TaxDocument");

                    b.ToTable("PessoaFisica", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.Persons.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<DateTime?>("InactivatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("InativoEm");

                    b.Property<bool>("IsEmployee")
                        .HasColumnType("bit")
                        .HasColumnName("Funcionario");

                    b.Property<bool>("IsPatient")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSuperAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("SuperAdmin");

                    b.Property<string>("Mobile")
                        .HasMaxLength(44)
                        .HasColumnType("nvarchar(44)")
                        .HasColumnName("Celular");

                    b.Property<string>("Phone")
                        .HasMaxLength(44)
                        .HasColumnType("nvarchar(44)")
                        .HasColumnName("Telefone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAtualizacao");

                    b.HasKey("Id");

                    b.HasIndex("IsEmployee");

                    b.ToTable("Pessoa", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.RoleUsers.RoleUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("HolderId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("HolderId")
                        .IsUnique()
                        .HasFilter("[HolderId] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("api.Models.EntityModel.Roles.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<long?>("CompanyId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("IdEmpresa");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Perfil", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.Users.User", b =>
                {
                    b.Property<long>("PersonId")
                        .HasColumnType("bigint")
                        .HasColumnName("IdPessoa");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Ativo");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCadastro");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("Senha");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("IdPerfil");

                    b.Property<long?>("RoleUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Password");

                    b.HasIndex("RoleUserId");

                    b.ToTable("Usuario", "cadastro");
                });

            modelBuilder.Entity("api.Models.EntityModel.Addresses.Address", b =>
                {
                    b.HasOne("api.Models.EntityModel.Persons.Person", "Person")
                        .WithOne("Address")
                        .HasForeignKey("api.Models.EntityModel.Addresses.Address", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("api.Models.EntityModel.JuristicPersons.JuristicPerson", b =>
                {
                    b.HasOne("api.Models.EntityModel.BusinessTypes.BusinessType", "BusinessType")
                        .WithMany("JuristicPersons")
                        .HasForeignKey("BusinessTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api.Models.EntityModel.Cnaes.Cnae", "Cnae")
                        .WithMany("JuristicPeople")
                        .HasForeignKey("CnaeCode")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("api.Models.EntityModel.Persons.Person", "Person")
                        .WithOne("JuristicPerson")
                        .HasForeignKey("api.Models.EntityModel.JuristicPersons.JuristicPerson", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessType");

                    b.Navigation("Cnae");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("api.Models.EntityModel.NaturalPersons.NaturalPerson", b =>
                {
                    b.HasOne("api.Models.EntityModel.Persons.Person", "Person")
                        .WithOne("NaturalPerson")
                        .HasForeignKey("api.Models.EntityModel.NaturalPersons.NaturalPerson", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("api.Models.EntityModel.RoleUsers.RoleUser", b =>
                {
                    b.HasOne("api.Models.EntityModel.Persons.Person", "Holder")
                        .WithOne("RoleUser")
                        .HasForeignKey("api.Models.EntityModel.RoleUsers.RoleUser", "HolderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("api.Models.EntityModel.Roles.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Holder");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("api.Models.EntityModel.Roles.Role", b =>
                {
                    b.HasOne("api.Models.EntityModel.Companies.Company", "Company")
                        .WithMany("Roles")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("api.Models.EntityModel.Users.User", b =>
                {
                    b.HasOne("api.Models.EntityModel.Persons.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("api.Models.EntityModel.Users.User", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.EntityModel.RoleUsers.RoleUser", "RoleUser")
                        .WithMany()
                        .HasForeignKey("RoleUserId");

                    b.Navigation("Person");

                    b.Navigation("RoleUser");
                });

            modelBuilder.Entity("api.Models.EntityModel.BusinessTypes.BusinessType", b =>
                {
                    b.Navigation("JuristicPersons");
                });

            modelBuilder.Entity("api.Models.EntityModel.Cnaes.Cnae", b =>
                {
                    b.Navigation("JuristicPeople");
                });

            modelBuilder.Entity("api.Models.EntityModel.Companies.Company", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("api.Models.EntityModel.Persons.Person", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("JuristicPerson");

                    b.Navigation("NaturalPerson");

                    b.Navigation("RoleUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.EntityModel.Roles.Role", b =>
                {
                    b.Navigation("RoleUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
