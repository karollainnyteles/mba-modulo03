using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TelesEducacao.Alunos.Domain;
using TelesEducacao.Core.Data;

namespace TelesEducacao.Alunos.Data.Repository;

public class AlunoRepository : IAlunoRepository
{
    private readonly AlunosContext _context;
    private readonly IUserService _userService;

    public AlunoRepository(AlunosContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task RegistrarAsync(string email, string senha)
    {
        var userId = await _userService.RegisterAsync(email, senha, "Aluno", CancellationToken.None);
        if (userId.HasValue)
        {
            var aluno = new Aluno(userId.Value);
            _context.Alunos.Add(aluno);
        }
    }

    public async Task<Aluno?> ObterPorUserIdAsync(Guid userId)
    {
        return await _context.Alunos.FirstOrDefaultAsync(a => a.UserId == userId);
    }

    public async Task<IEnumerable<Aluno>> ObterTodosAsync()
    {
        return await _context.Alunos.ToListAsync();
    }

    public void AdicionarMatriculaAsync(Guid alunoId, Guid cursoId)
    {
        var matricula = new Matricula(alunoId, cursoId);
        _context.Add(matricula);
    }

    public async Task<IEnumerable<Matricula>> ObterMatriculasPorAlunoIdAsync(Guid alunoId)
    {
        return await _context.Matriculas
             .AsNoTracking()
             .Where(m => m.AlunoId == alunoId)
             .ToListAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

public interface IUserService
{
    Task<Guid?> RegisterAsync(string email, string senha, string roleName, CancellationToken cancellationToken);

    Task<Guid?> LoginAsync(string email, string senha, CancellationToken cancellationToken);
}

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<Guid?> RegisterAsync(string email, string senha, string roleName, CancellationToken cancellationToken)
    {
        var identityUser = new IdentityUser
        {
            Email = email,
            UserName = email,
        };

        var result = await _userManager.CreateAsync(identityUser, senha);
        if (result.Succeeded)
        {
            await AddRoleToUser(identityUser, "Aluno");
            return Guid.Parse(identityUser.Id);
        }
        return null;
    }

    public async Task<Guid?> LoginAsync(string email, string senha, CancellationToken cancellationToken)
    {
        var result = await _signInManager.PasswordSignInAsync(email, senha, false, true);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                return Guid.Parse(user.Id);
            }
        }
        return null;
    }

    private async Task AddRoleToUser(IdentityUser user, string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role != null)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }
    }
}