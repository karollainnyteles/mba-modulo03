using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelesEducacao.Alunos.Domain;

namespace TelesEducacao.Alunos.Data.Mappings;

public class CertificadoMapping : IEntityTypeConfiguration<Certificado>
{
    public void Configure(EntityTypeBuilder<Certificado> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.DataEmissao)
            .IsRequired();

        builder.HasOne(c => c.Matricula)
            .WithMany(m => m.Certificados)
            .HasForeignKey(c => c.MatriculaId);
    }
}