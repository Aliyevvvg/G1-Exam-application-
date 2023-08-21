using Exam_appilcation.Models;
using Exam_appilcation.Service;
using Microsoft.EntityFrameworkCore;

namespace TCBApp.Services.DataService;

public class StudentDataService:IStudent
{
    private DbContext _context;
    public StudentDataService(DbContext dbContext)
    {
        _context = dbContext;
    }
    public IQueryable<Student> GetAll()
    {
        return this._context.Set<Student>();
    }

    public async Task<Student?> GetByIdAsync(long id)
    {
        return await this.GetAll().
            FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Student> AddAsync(Student entity)
    {
        var entityEntry = await this._context.
            Set<Student>().
            AddAsync(entity);
        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<Student> UpdateAsync(Student entity)
    {
        var entityEntry = this._context
            .Set<Student>()
            .Update(entity);

        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<Student> RemoveAsync(Student entity)
    {
        var entityEntry = this._context
            .Set<Student>()
            .Remove(entity);

        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<Student> RemoveAsync(long id)
    {
        var entity = await this.GetByIdAsync(id);
        if (entity is Student data)
            return await this.RemoveAsync(data);

        return null;
    }
}