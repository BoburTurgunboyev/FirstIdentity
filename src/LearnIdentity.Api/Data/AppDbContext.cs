﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnIdentity.Api.Data;

public class AppDbContext :IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedRoles(builder);
    }

    private static void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole() { Name ="Admin",ConcurrencyStamp ="1",NormalizedName ="Admin"},
            new IdentityRole() { Name ="User",ConcurrencyStamp ="2",NormalizedName ="User"},
            new IdentityRole() { Name ="My",ConcurrencyStamp ="3",NormalizedName ="My"}

            );
    }
}
