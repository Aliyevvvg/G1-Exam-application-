using Exam_appilcation.Configurations;
using Exam_appilcation.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam_appilcation.Service;

public class DataContext:DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Examiner> Examiners { get; set; }

    public DataContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies();
        optionsBuilder.UseNpgsql(Settings.DBConnection);
        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ExamBot");


        modelBuilder
            .Entity<User>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Client>()
            .HasKey(x => x.Id);
        modelBuilder
            .Entity<Client>()
            .HasOne(x => x.User)
            .WithOne(x => x.Client)
            .HasForeignKey<Client>(x=>x.UserId);
        


        modelBuilder.
            Entity<Student>().
            HasKey(x => x.Id);
        
        modelBuilder.
            Entity<Student>().
            HasOne(x => x.User_).
            WithOne(x => x.Student).
            HasForeignKey<User>(x => x.Id);

        modelBuilder.
            Entity<Exam>().
            HasKey(x => x.Id);

        modelBuilder.
            Entity<Exam>().
            HasOne(x => x.Examiner).
            WithOne(e => e.Exam).
            HasForeignKey<Exam>(x => x.Examiner_id);

        modelBuilder.
            Entity<Exam>().
            HasMany(x => x.Students).
            WithOne(x => x.Exam).
            HasForeignKey(x=>x.Exam_id);

        
        modelBuilder.
            Entity<Examiner>().
            HasKey(x => x.Id);
        
        modelBuilder.
            Entity<Examiner>().
            HasOne(x => x.Exam).
            WithOne(x => x.Examiner)
            .HasForeignKey<Exam>(examiner => examiner.Examiner_id);



    }
    

}