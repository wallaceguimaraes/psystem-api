using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Cnaes
{
    public static class CnaeMap
    {
        public static void Map(this EntityTypeBuilder<Cnae> entity)
        {
            entity.ToTable("Cnae", "cadastro");
            entity.HasKey(p => p.Code);

            entity.Property(p => p.Code).HasColumnName("Codigo").ValueGeneratedNever();
            entity.Property(p => p.Name).HasColumnName("Nome").HasMaxLength(200);
        }
    }
}