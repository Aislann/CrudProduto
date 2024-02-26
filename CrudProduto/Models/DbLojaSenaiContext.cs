using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudProduto.Models
{
    public partial class DbLojaSenaiContext : DbContext
    {
        public DbLojaSenaiContext()
        {
        }

        public DbLojaSenaiContext(DbContextOptions<DbLojaSenaiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Fornecedor> Fornecedors { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240C0FD35A08");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categoria");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor)
                    .HasName("PK__Forneced__CBE1227C3E397D68");

                entity.ToTable("Fornecedor");

                entity.Property(e => e.IdFornecedor).HasColumnName("idFornecedor");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__5EEDF7C3679DB06E");

                entity.ToTable("Produto");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdFornecedor).HasColumnName("idFornecedor");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Produto__idCateg__3A81B327");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK__Produto__idForne__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
