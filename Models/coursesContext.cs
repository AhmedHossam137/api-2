using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api_2.Models;

public partial class coursesContext : DbContext
{
    public coursesContext()
    {
    }

    public coursesContext(DbContextOptions<coursesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=AHMEDHOSSAM;Initial Catalog=courses;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Command Timeout=300");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Courses__3214EC27F6370E42");

            entity.Property(e => e.ID).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
