using api.Models.EntityModel.Persons;
using api.Models.EntityModel.RoleUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Roles
{
    public static class RoleUserMap
    {
        public static void Map(this EntityTypeBuilder<RoleUser> entity)
        {
            entity.ToTable("PerfilUsuario", "cadastro");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).ValueGeneratedOnAdd().UseMySqlIdentityColumn();
            entity.Property(p => p.HolderId).HasColumnName("IdTitular");
            entity.Property(p => p.RoleId).HasColumnName("IdPerfil");
            entity.HasOne(p => p.Holder).WithOne(p => p.RoleUser).HasForeignKey<Person>(p => p.RoleUser);
            entity.HasOne(p => p.Role).WithMany(p => p.RoleUsers).HasForeignKey(p => p.RoleId);

        }
    }
}