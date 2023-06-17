using api.Models.EntityModel.Addresses;
using api.Models.EntityModel.JuristicPersons;
using api.Models.EntityModel.NaturalPersons;
using api.Models.EntityModel.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Persons
{
    public static class PersonMap
    {
        public static void Map(this EntityTypeBuilder<Person> entity)
        {
            entity.ToTable("Pessoa", "cadastro");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).ValueGeneratedOnAdd().UseMySqlIdentityColumn();
            entity.Property(p => p.Phone).HasColumnName("Telefone").HasMaxLength(44);
            entity.Property(p => p.Mobile).HasColumnName("Celular").HasMaxLength(44);
            entity.Property(p => p.CreatedAt).HasColumnName("DataCadastro").IsRequired();
            entity.Property(p => p.IsEmployee).HasColumnName("Funcionario").IsRequired();
            entity.Property(p => p.UpdatedAt).HasColumnName("DataAtualizacao");
            entity.Property(p => p.IsSuperAdmin).HasColumnName("SuperAdmin").HasDefaultValue(false);
            entity.Property(p => p.InactivatedOn).HasColumnName("InativoEm");

            entity.HasOne(p => p.NaturalPerson).WithOne(p => p.Person).HasForeignKey<NaturalPerson>(p => p.PersonId);
            entity.HasOne(p => p.JuristicPerson).WithOne(p => p.Person).HasForeignKey<JuristicPerson>(p => p.PersonId);
            entity.HasOne(p => p.Address).WithOne(p => p.Person).HasForeignKey<Address>(p => p.PersonId);
            entity.HasOne(p => p.User).WithOne(p => p.Person).HasForeignKey<User>(p => p.PersonId);
            // entity.HasMany(p => p.Applications).WithOne(p => p.Partner).HasForeignKey(p => p.PartnerId);
            entity.HasMany(p => p.Roles).WithOne(p => p.Holder).HasForeignKey(p => p.HolderId).OnDelete(DeleteBehavior.Restrict);

            // entity.HasMany(p => p.LastPasswords).WithOne(p => p.Person).HasForeignKey(p => p.PersonId).OnDelete(DeleteBehavior.Restrict);

            // entity.Ignore(p => p.Situation);
            // entity.Ignore(p => p.OriginApplication);
            // entity.Ignore(p => p.PersonUpdateInstitution);
            // entity.Ignore(p => p.InstitutionMigrationErrors);
            entity.HasIndex(p => p.IsEmployee);

            entity.HasQueryFilter(p => p.InactivatedOn == null);
        }


    }
}