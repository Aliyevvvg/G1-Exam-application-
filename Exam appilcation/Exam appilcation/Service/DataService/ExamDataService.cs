using Exam_appilcation.Models;
using Exam_appilcation.Service;
using Microsoft.EntityFrameworkCore;

namespace TCBApp.Services.DataService;

public class ExamDataService:IExam
{
    private DbContext _context;
    public ExamDataService(DbContext dbContext)
    {
        _context = dbContext;
    }
    public IQueryable<Exam> GetAll()
    {
        return this._context.Set<Exam>();
    }

    public async Task<Exam?> GetByIdAsync(long id)
    {
        return await this.GetAll().
            FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Exam> AddAsync(Exam entity)
    {
        var entityEntry = await this._context.
            Set<Exam>().
            AddAsync(entity);
        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<Exam> UpdateAsync(Exam entity)
    {
        var entityEntry = this._context
            .Set<Exam>()
            .Update(entity);

        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<Exam> RemoveAsync(Exam entity)
    {
        var entityEntry = this._context
            .Set<Exam>()
            .Remove(entity);

        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<Exam> RemoveAsync(long id)
    {
        var entity = await this.GetByIdAsync(id);
        if (entity is Exam data)
            return await this.RemoveAsync(data);

        return null;
    }
}