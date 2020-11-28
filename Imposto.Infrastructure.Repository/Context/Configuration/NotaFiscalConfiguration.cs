using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Imposto.Core.NotasFiscais;

namespace Imposto.Infrastructure.Repository.Context.Configuration
{
    public class NotaFiscalConfiguration : EntityTypeConfiguration<NotaFiscal>
    {
        public NotaFiscalConfiguration()
        {
            ToTable("NotaFiscal");
            HasKey(nf => nf.Id).Property(nf => nf.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(nf => nf.NumeroNotaFiscal).IsRequired();
            Property(nf => nf.Serie).IsRequired();
            Property(nf => nf.NomeCliente).IsRequired();
            Property(nf => nf.EstadoDestino).IsRequired();
            Property(nf => nf.EstadoOrigem).IsRequired();
        }
    }
}