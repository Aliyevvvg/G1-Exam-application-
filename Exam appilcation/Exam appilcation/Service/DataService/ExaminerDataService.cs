using Exam_appilcation.Models;
using Exam_appilcation.Service;
using Microsoft.EntityFrameworkCore;

namespace TCBApp.Services.DataService;

public class ExaminerDataService:IExaminer
{ private DbContext _context;
    public ExaminerDataService(DbContext dbContext)
    {
        _context = dbContext;
    }
    public IQueryable<Examiner> GetAll()
    {
        return this._context.Set<Examiner>();
    }

    public async Task<Examiner?> GetByIdAsync(long id)
    {
        return await this.GetAll().
            FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Examiner> AddAsync(Examiner entity)
    {
        var entityEntry = await this._context.
            Set<Examiner>().
            AddAsync(entity);
        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<Examiner> UpdateAsync(Examiner entity)
    {
        var entityEntry = this._context
            .Set<Examiner>()
            .Update(entity);

        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<Examiner> RemoveAsync(Examiner entity)
    {
        var entityEntry = this._context
            .Set<Examiner>()
            .Remove(entity);

        await this._context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<Examiner> RemoveAsync(long id)
    {
        var entity = await this.GetByIdAsync(id);
        if (entity is Examiner data)
            return await this.RemoveAsync(data);

        return null;
    }
}