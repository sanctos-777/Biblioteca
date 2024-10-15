 using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.ORM;

public partial class BilbliotecaContext : DbContext
{
    internal object Emprestimo;

    public BilbliotecaContext()
    {
    }

    public BilbliotecaContext(DbContextOptions<BilbliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCategoria> TbCategorias { get; set; }

    public virtual DbSet<TbEmprestimo> TbEmprestimos { get; set; }

    public virtual DbSet<TbFuncionario> TbFuncionarios { get; set; }

    public virtual DbSet<TbLivro> TbLivros { get; set; }

    public virtual DbSet<TbMembro> TbMembros { get; set; }

    public virtual DbSet<TbReserva> TbReservas { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }
    public object TbCategoria { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAB205_23\\SQLEXPRESS;Database=Bilblioteca;User Id=adminTarde;Password=admin;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCategoria>(entity =>
        {
            entity.ToTable("TB_CATEGORIAS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbEmprestimo>(entity =>
        {
            entity.ToTable("TB_EMPRESTIMOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataDevolucao)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DataEmprestimo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fklivro).HasColumnName("FKLivro");
            entity.Property(e => e.Fkmembro).HasColumnName("FKMembro");

            entity.HasOne(d => d.FklivroNavigation).WithMany(p => p.TbEmprestimos)
                .HasForeignKey(d => d.Fklivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_EMPRESTIMOS_TB_LIVROS");

            entity.HasOne(d => d.FkmembroNavigation).WithMany(p => p.TbEmprestimos)
                .HasForeignKey(d => d.Fkmembro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_EMPRESTIMOS_TB_MEMBROS");
        });

        modelBuilder.Entity<TbFuncionario>(entity =>
        {
            entity.ToTable("TB_FUNCIONARIOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbLivro>(entity =>
        {
            entity.ToTable("TB_LIVROS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Disponibilidade)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Fkcategoria).HasColumnName("FKCategoria");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FkcategoriaNavigation).WithMany(p => p.TbLivros)
                .HasForeignKey(d => d.Fkcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_LIVROS_TB_CATEGORIAS1");
        });

        modelBuilder.Entity<TbMembro>(entity =>
        {
            entity.ToTable("TB_MEMBROS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoMembro)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbReserva>(entity =>
        {
            entity.ToTable("TB_RESERVAS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataReserva)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fklivro).HasColumnName("FKLivro");
            entity.Property(e => e.Fkmembro).HasColumnName("FKMembro");

            entity.HasOne(d => d.FklivroNavigation).WithMany(p => p.TbReservas)
                .HasForeignKey(d => d.Fklivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_RESERVAS_TB_LIVROS");

            entity.HasOne(d => d.FkmembroNavigation).WithMany(p => p.TbReservas)
                .HasForeignKey(d => d.Fkmembro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_RESERVAS_TB_MEMBROS");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.ToTable("TB_USUARIO");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
