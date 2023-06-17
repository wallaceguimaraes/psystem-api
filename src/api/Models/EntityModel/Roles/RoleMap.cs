using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Roles
{
    public static class RoleMap
    {
        public static void Map(this EntityTypeBuilder<Role> entity)
        {
            entity.ToTable("Perfil", "cadastro");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd().UseMySqlIdentityColumn();
            entity.Property(p => p.CreatedAt).HasColumnName("DataCadastro").IsRequired();
            entity.Property(p => p.CompanyId).HasColumnName("IdEmpresa").IsRequired();
            entity.Property(p => p.Name).HasColumnName("Nome").HasMaxLength(80).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Active).HasColumnName("Ativo").IsRequired();
            entity.HasOne(p => p.Company).WithMany(p => p.Roles).HasForeignKey(p => p.CompanyId);
        }
    }
}