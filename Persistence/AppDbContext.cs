using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;


//deriving from DbContext to create a context for the application
public class AppDbContext(DbContextOptions options) : DbContext (options)
{
    public DbSet<Activity> Activities { get; set; }
}
