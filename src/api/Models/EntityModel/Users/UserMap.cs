using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Users
{
    public static class UserMap
    {
        public static void Map(this EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Usuario", "cadastro");

            entity.HasKey(p => p.PersonId);
            entity.HasIndex(p => p.Email).IsUnique();

            entity.Property(p => p.Email).HasColumnName("Email");
            entity.Property(p => p.PersonId).HasColumnName("IdPessoa");
            entity.Property(p => p.RoleId).HasColumnName("IdPerfil");
            entity.Property(p => p.Active).HasColumnName("Ativo").IsRequired().HasDefaultValue(true);
            entity.Property(p => p.CreatedAt).HasColumnName("DataCadastro").IsRequired();
            entity.Property(p => p.Password).HasColumnName("Senha").HasMaxLength(120);

            entity.HasIndex(p => p.Email);
            entity.HasIndex(p => p.Password);
        }
    }
}