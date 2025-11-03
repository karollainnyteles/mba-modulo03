using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelesEducacao.Conteudos.Domain;

namespace TelesEducacao.Conteudos.Data.Mappings;

public class AulaMapping : IEntityTypeConfiguration<Aula>
{
    public void Configure(EntityTypeBuilder<Aula> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(p => p.Conteudo).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Titulo).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Duracao).IsRequired();

        builder.HasOne(c => c.Curso)
            .WithMany(c => c.Aulas)
            .HasForeignKey(c => c.CursoId);
    }
}