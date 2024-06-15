using Microsoft.EntityFrameworkCore;
using WebMVCApplication.Models.EFCoreModels;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet
    // virtual 為了延遲加載（Lazy Loading）
    public virtual DbSet<TodoEFModel> Todos { get; set; }
    public virtual DbSet<UserEFModel> Users { get; set; }

}