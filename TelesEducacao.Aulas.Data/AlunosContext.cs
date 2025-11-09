using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TelesEducacao.Alunos.Domain;
using TelesEducacao.Core.Data;

namespace TelesEducacao.Alunos.Data;

public class AlunosContext : DbContext, IUnitOfWork
{
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //HACK: pra não setar string como varchar(max)
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                     e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}