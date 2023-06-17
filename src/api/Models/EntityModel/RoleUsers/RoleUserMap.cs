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
            entity.HasKey(p => new { p.HolderId, p.RoleId });
            entity.Property(p => p.HolderId).HasColumnName("IdTitular");
            entity.Property(p => p.RoleId).HasColumnName("IdPerfil");

        }
    }
}