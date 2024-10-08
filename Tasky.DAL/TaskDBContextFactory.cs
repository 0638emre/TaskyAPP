using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tasky.DAL.Context;

namespace Tasky.DAL;

public class TaskDBContextFactory : IDesignTimeDbContextFactory<TaskDBContext>
{
    public TaskDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TaskDBContext>();
        //optionsBuilder.UseSqlServer("Server=localhost, 1433; Database=TaskyDB;User ID=sa;Password=reallyStrongPwd123;TrustServerCertificate=True;");
        
        optionsBuilder.UseSqlServer("Server=AEC;Database=TaskyDB;Integrated Security=True;TrustServerCertificate=True;");

        return new TaskDBContext(optionsBuilder.Options);
    }
}