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
            HasKey(nf => nf.Id).Property(nf => nf.Id).HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(nf => nf.NumeroNotaFiscal).HasColumnName("NumeroNotaFiscal").IsRequired();
            Property(nf => nf.Serie).HasColumnName("Serie").IsRequired();
            Property(nf => nf.NomeCliente).HasColumnName("NomeCliente").IsRequired();
            Property(nf => nf.EstadoDestino).HasColumnName("EstadoDestino").IsRequired();
            Property(nf => nf.EstadoOrigem).HasColumnName("EstadoOrigem").IsRequired();
        }
    }
}