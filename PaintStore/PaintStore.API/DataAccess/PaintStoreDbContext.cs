using System;
using Microsoft.EntityFrameworkCore;
using PaintStore.Model;
using PaintStore.Model.Models;

namespace PaintStore.API.Database;

public class PaintStoreDbContext: DbContext
{
    public DbSet<PaintProduct> PaintProducts { get;set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems {get; set;}

    public DbSet<User> Users { get; set; }
    public PaintStoreDbContext(DbContextOptions<PaintStoreDbContext> dbContextOptions):base(dbContextOptions)
    {      
    }
}
