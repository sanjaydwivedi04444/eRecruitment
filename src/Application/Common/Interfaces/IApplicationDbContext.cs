using eRecruitment.Domain.Entities;

namespace eRecruitment.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<Job> Jobs { get; }
    DbSet<Company> Companies { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
