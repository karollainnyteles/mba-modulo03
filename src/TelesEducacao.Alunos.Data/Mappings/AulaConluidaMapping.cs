using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelesEducacao.Alunos.Domain;

namespace TelesEducacao.Alunos.Data.Mappings;

public class AulaConluidaMapping : IEntityTypeConfiguration<AulaConluida>
{
    public void Configure(EntityTypeBuilder<AulaConluida> builder)
    {
        builder.Ignore(a => a.Id);
        builder.HasKey(a => new
        {
            a.AulaId,
            a.MatriculaId
        });
    }
}