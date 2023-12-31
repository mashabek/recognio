﻿using ApplicationCore.Persistance.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RecognitionCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Persistance;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Recognition> Recognitions => Set<Recognition>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.AddInterceptors(new AuditableEntitySaveChangesInterceptor());
        base.OnConfiguring(optionsBuilder);
    }
}