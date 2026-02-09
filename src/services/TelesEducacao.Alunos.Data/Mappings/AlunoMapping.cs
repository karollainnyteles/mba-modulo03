using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelesEducacao.Alunos.Domain;

namespace TelesEducacao.Alunos.Data.Mappings;

public class AlunoMapping : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(p => p.UserId).IsRequired();
        builder.Property(p => p.Ativo).HasDefaultValue(true);
    }
}