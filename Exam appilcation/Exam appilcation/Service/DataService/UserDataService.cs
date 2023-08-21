using Exam_appilcation.Models;
using Exam_appilcation.Service;
using Microsoft.EntityFrameworkCore;


namespace TCBApp.Services.DataService;

public class UserDataService : IUserDataService
{
    private DbContext _context;
    public UserDataService(DbContext dbContext)
    {
        _context = dbContext;
    }
    public IQueryable<User> GetAll()
    {
        return this._context.Set<User>();
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        return await this.GetAll().
            FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User> AddAsync(User entity)
    {
        var entityEntry = await this._context.
            Set<User>().
            AddAsync(entity);
        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<User> UpdateAsync(User entity)
    {
        var entityEntry = this._context
            .Set<User>()
            .Update(entity);

        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<User> RemoveAsync(User entity)
    {
        var entityEntry = this._context
            .Set<User>()
            .Remove(entity);

        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<User> RemoveAsync(long id)
    {
        var entity = await this.GetByIdAsync(id);
        if (entity is User data)
            return await this.RemoveAsync(data);

        return null;
    }
}