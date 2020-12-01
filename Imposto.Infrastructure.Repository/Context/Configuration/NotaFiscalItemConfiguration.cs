using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Imposto.Core.NotasFiscais;

namespace Imposto.Infrastructure.Repository.Context.Configuration
{
    public class NotaFiscalItemConfiguration : EntityTypeConfiguration<NotaFiscalItem>
    {
        public NotaFiscalItemConfiguration()
        {
            ToTable("NotaFiscalItem");
            HasKey(nfi => nfi.Id).Property(nfi => nfi.Id).HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(nfi => nfi.IdNotaFiscal).HasColumnName("IdNotaFiscal").IsRequired();
            Property(nfi => nfi.Cfop).HasColumnName("Cfop").IsOptional();
            Property(nfi => nfi.TipoIcms).HasColumnName("TipoIcms").IsRequired();
            Property(nfi => nfi.BaseIcms).HasColumnName("BaseIcms").IsRequired();
            Property(nfi => nfi.AliquotaIcms).HasColumnName("AliquotaIcms").IsRequired();
            Property(nfi => nfi.ValorIcms).HasColumnName("ValorIcms").IsRequired();
            Property(nfi => nfi.NomeProduto).HasColumnName("NomeProduto").IsRequired();
            Property(nfi => nfi.CodigoProduto).HasColumnName("CodigoProduto").IsRequired();
            Property(nfi => nfi.BaseIpi).HasColumnName("BaseIpi").IsRequired();
            Property(nfi => nfi.AliquotaIpi).HasColumnName("AliquotaIpi").IsRequired();
            Property(nfi => nfi.ValorIpi).HasColumnName("ValorIpi").IsRequired();
            Property(nfi => nfi.Desconto).HasColumnName("Desconto").IsRequired();

            HasRequired(nfi => nfi.NotaFiscal)
                .WithMany(nf=>nf.ItensNotaFiscal)
                .HasForeignKey(p => p.IdNotaFiscal);
        }
    }
}