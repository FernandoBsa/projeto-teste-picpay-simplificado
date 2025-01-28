using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Domain.Entity;

namespace PicPaySimplificado.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CarteiraEntity> Carteiras { get; set; }

        public DbSet<TransferenciaEntity> Transferencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarteiraEntity>()
                .HasIndex(w => new { w.CPFCNPJ, w.Email })
                .IsUnique();


            modelBuilder.Entity<CarteiraEntity>()
                .Property(t => t.SaldoConta)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<CarteiraEntity>()
                .Property(w => w.UserType)
                .HasConversion<string>();

            modelBuilder.Entity<TransferenciaEntity>()
                .HasKey(t => t.IdTransferencia);

            modelBuilder.Entity<TransferenciaEntity>()
                .HasOne(t => t.Sender)
                .WithMany()
                .HasForeignKey(t => t.SenderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transaction_Sender");

            modelBuilder.Entity<TransferenciaEntity>()
                .Property(t => t.Valor)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<TransferenciaEntity>()
                .HasOne(t => t.Receiver)
                .WithMany()
                .HasForeignKey(t => t.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transaction_Reciver");
        }
    }
}
