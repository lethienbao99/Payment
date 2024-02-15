using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Payment.Domain.Entities;

public partial class PaymentContext : DbContext
{
    public PaymentContext()
    {
    }

    public PaymentContext(DbContextOptions<PaymentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Merchant> Merchants { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentDestination> PaymentDestinations { get; set; }

    public virtual DbSet<PaymentNotification> PaymentNotifications { get; set; }

    public virtual DbSet<PaymentSignature> PaymentSignatures { get; set; }

    public virtual DbSet<PaymentTransaction> PaymentTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PaymentDB;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Merchant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Merchant__3214EC07E6617C1B");

            entity.ToTable("Merchant");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.MerchantIpnUrl).HasMaxLength(250);
            entity.Property(e => e.MerchantName).HasMaxLength(50);
            entity.Property(e => e.MerchantReturnUrl).HasMaxLength(250);
            entity.Property(e => e.MerchantWebLink).HasMaxLength(250);
            entity.Property(e => e.SerectKey).HasMaxLength(50);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3214EC071C987700");

            entity.ToTable("Payment");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.MerchantId).HasMaxLength(50);
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.PaymentContent).HasMaxLength(250);
            entity.Property(e => e.PaymentCurrency).HasMaxLength(50);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentDestinationId).HasMaxLength(50);
            entity.Property(e => e.PaymentLanguage).HasMaxLength(10);
            entity.Property(e => e.PaymentLastMessage).HasMaxLength(250);
            entity.Property(e => e.PaymentRefId).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(20);
            entity.Property(e => e.RequiredAmount).HasColumnType("decimal(19, 2)");

            entity.HasOne(d => d.Merchant).WithMany(p => p.Payments)
                .HasForeignKey(d => d.MerchantId)
                .HasConstraintName("FK__Payment__Merchan__33D4B598");

            entity.HasOne(d => d.PaymentDestination).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentDestinationId)
                .HasConstraintName("FK__Payment__Payment__32E0915F");
        });

        modelBuilder.Entity<PaymentDestination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentD__3214EC071CEF14AC");

            entity.ToTable("PaymentDestination");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.DesLogo).HasMaxLength(250);
            entity.Property(e => e.DesName).HasMaxLength(250);
            entity.Property(e => e.DesShortName).HasMaxLength(50);
            entity.Property(e => e.ParentId).HasMaxLength(50);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_PaymentDestination_ParentID");
        });

        modelBuilder.Entity<PaymentNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentN__3214EC078A1D9815");

            entity.ToTable("PaymentNotification");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.MerchantId).HasMaxLength(50);
            entity.Property(e => e.NotiAmount).HasMaxLength(50);
            entity.Property(e => e.NotiContent).HasMaxLength(50);
            entity.Property(e => e.NotiDate).HasMaxLength(50);
            entity.Property(e => e.NotiMessage).HasMaxLength(50);
            entity.Property(e => e.NotiResDate).HasMaxLength(50);
            entity.Property(e => e.NotiSignature).HasMaxLength(50);
            entity.Property(e => e.NotiStatus).HasMaxLength(50);
            entity.Property(e => e.PaymentId).HasMaxLength(50);
            entity.Property(e => e.PaymentRefId).HasMaxLength(50);

            entity.HasOne(d => d.Merchant).WithMany(p => p.PaymentNotifications)
                .HasForeignKey(d => d.MerchantId)
                .HasConstraintName("FK__PaymentNo__Merch__44FF419A");

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentNotifications)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__PaymentNo__Payme__440B1D61");
        });

        modelBuilder.Entity<PaymentSignature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentS__3214EC07758AD836");

            entity.ToTable("PaymentSignature");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.PaymentId).HasMaxLength(50);
            entity.Property(e => e.SignAlgo).HasMaxLength(50);
            entity.Property(e => e.SignDate).HasColumnType("datetime");
            entity.Property(e => e.SignOwn).HasMaxLength(50);
            entity.Property(e => e.SignValue).HasMaxLength(500);

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentSignatures)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__PaymentSi__Payme__412EB0B6");
        });

        modelBuilder.Entity<PaymentTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentT__3214EC07B6A13815");

            entity.ToTable("PaymentTransaction");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.PaymentId).HasMaxLength(50);
            entity.Property(e => e.TranAmount).HasColumnType("decimal(19, 2)");
            entity.Property(e => e.TranDate).HasColumnType("datetime");
            entity.Property(e => e.TranMessage).HasMaxLength(250);
            entity.Property(e => e.TranPayload).HasMaxLength(500);
            entity.Property(e => e.TranStatus).HasMaxLength(20);

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentTransactions)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__PaymentTr__Payme__300424B4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
