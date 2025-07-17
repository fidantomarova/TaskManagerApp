﻿using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Models;

namespace TaskManagerApp.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
