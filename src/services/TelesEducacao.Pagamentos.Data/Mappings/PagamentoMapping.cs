using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelesEducacao.Pagamentos.Business;

namespace TelesEducacao.Pagamentos.Data.Mappings;

public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
{
    public void Configure(EntityTypeBuilder<Pagamento> builder)
    {
        builder.HasKey(c => c.Id);

        //transformando o objeto de valor DadosCartao em colunas na tabela Pagamento
        builder.OwnsOne(c => c.DadosCartao, dc =>
        {
            dc.Property(c => c.Nome)
                .HasColumnName("NomeCartao")
                .HasColumnType("varchar(250)");

            dc.Property(c => c.Numero)
                .HasColumnName("NumeroCartao")
                .HasColumnType("varchar(16)");

            dc.Property(c => c.Expiracao)
                .HasColumnName("ExpiracaoCartao")
                .HasColumnType("varchar(10)");

            dc.Property(c => c.Cvv)
                .HasColumnName("CvvCartao")
                .HasColumnType("varchar(4)");
        });

        // 1 : 1 => Pagamento : Transacao
        builder.HasOne(c => c.Transacao)
            .WithOne(c => c.Pagamento);
    }
}