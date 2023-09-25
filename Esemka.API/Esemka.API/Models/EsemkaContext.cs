using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Esemka.Models;

public partial class EsemkaContext : DbContext
{
    public EsemkaContext()
    {
    }

    public EsemkaContext(DbContextOptions<EsemkaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ekskul> Ekskuls { get; set; }

    public virtual DbSet<EkskulMember> EkskulMembers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("EsemkaDB");
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=Esemka; Trusted_connection=True; TrustServerCertificate=True");
    //}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ekskul>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ekskul__3214EC275938DA19");

            entity.ToTable("Ekskul");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Day)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IconName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EkskulMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EkskulMe__3214EC273157F2CA");

            entity.ToTable("EkskulMember");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EkskulId).HasColumnName("EkskulID");
            entity.Property(e => e.JoinDate).HasColumnType("datetime");
            entity.Property(e => e.Position)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Ekskul).WithMany(p => p.EkskulMembers)
                .HasForeignKey(d => d.EkskulId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EkskulID_Member_Ekskul");

            entity.HasOne(d => d.User).WithMany(p => p.EkskulMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserID_Member_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC27C86DACEB");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fullname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
