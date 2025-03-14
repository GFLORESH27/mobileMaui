using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIWebMAUI.Models;

public partial class DbAb65b9MobilemauiContext : DbContext
{
    public DbAb65b9MobilemauiContext()
    {
    }

    public DbAb65b9MobilemauiContext(DbContextOptions<DbAb65b9MobilemauiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbRegisterpet> TbRegisterpets { get; set; }

    public virtual DbSet<TbService> TbServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=sql1001.site4now.net;database=db_ab65b9_mobilemaui;uid=db_ab65b9_mobilemaui_admin;pwd=AHPn6Mmp");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<TbRegisterpet>(entity =>
        {
            entity.HasKey(e => e.IdRegisterpet).HasName("PK__tb_register");

            entity.ToTable("tb_registerpet");

            entity.Property(e => e.IdRegisterpet).HasColumnName("id_registerpet");
            entity.Property(e => e.ActiveRegister)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("active_register");
            entity.Property(e => e.DateService)
                .HasColumnType("datetime")
                .HasColumnName("date_service");
            entity.Property(e => e.IdService).HasColumnName("id_service");
            entity.Property(e => e.NamePet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name_pet");

            entity.HasOne(d => d.IdServiceNavigation).WithMany(p => p.TbRegisterpets)
                .HasForeignKey(d => d.IdService)
                .HasConstraintName("FK_tb_registerpet_tb_service");
        });

        modelBuilder.Entity<TbService>(entity =>
        {
            entity.HasKey(e => e.IdService).HasName("PK__tb_servi__D06FB5A8CCD785D0");

            entity.ToTable("tb_service");

            entity.Property(e => e.IdService).HasColumnName("id_service");
            entity.Property(e => e.ActiveService)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("active_service");
            entity.Property(e => e.NameService)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name_service");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
