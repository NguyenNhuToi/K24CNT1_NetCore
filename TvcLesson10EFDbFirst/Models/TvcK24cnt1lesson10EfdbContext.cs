using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TvcLesson10EFDbFirst.Models;

public partial class TvcK24cnt1lesson10EfdbContext : DbContext
{
    public TvcK24cnt1lesson10EfdbContext()
    {
    }

    public TvcK24cnt1lesson10EfdbContext(DbContextOptions<TvcK24cnt1lesson10EfdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TvcMember> TvcMembers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TvcK24CNT1Lesson10EFDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TvcMember>(entity =>
        {
            entity.ToTable("TvcMember");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TvcEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TvcFullName).HasMaxLength(50);
            entity.Property(e => e.TvcPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TvcPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TvcUserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
