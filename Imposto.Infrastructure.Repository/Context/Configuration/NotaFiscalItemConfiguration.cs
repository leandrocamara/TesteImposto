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
            HasKey(nfi => nfi.Id).Property(nfi => nfi.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(nfi => nfi.IdNotaFiscal).IsRequired();
            Property(nfi => nfi.Cfop).IsRequired();
            Property(nfi => nfi.TipoIcms).IsRequired();
            Property(nfi => nfi.BaseIcms).IsRequired();
            Property(nfi => nfi.AliquotaIcms).IsRequired();
            Property(nfi => nfi.ValorIcms).IsRequired();
            Property(nfi => nfi.NomeProduto).IsRequired();
            Property(nfi => nfi.CodigoProduto).IsRequired();

            HasRequired(nfi => nfi.NotaFiscal)
                .WithMany(nf=>nf.ItensNotaFiscal)
                .HasForeignKey(p => p.IdNotaFiscal);
        }
    }
}