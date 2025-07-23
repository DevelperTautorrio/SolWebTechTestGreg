using System;
using System.Collections.Generic;
using INFRASTRUCTURE;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.DbContexts;

public partial class TechnicalTestDbContext : DbContext
{
    public TechnicalTestDbContext(DbContextOptions<TechnicalTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TechAgendaExternalContact> TechAgendaExternalContacts { get; set; }

    public virtual DbSet<TechAgendaSocialNetworkContact> TechAgendaSocialNetworkContacts { get; set; }

    public virtual DbSet<TechAgendaUser> TechAgendaUsers { get; set; }

    public virtual DbSet<TechAgendaUserRelation> TechAgendaUserRelations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TechAgendaExternalContact>(entity =>
        {
            entity.HasKey(e => e.ExtContactId).HasName("PK__Tech_Age__781CEC873A3FEC26");

            entity.ToTable("Tech_Agenda_ExternalContact");

            entity.HasIndex(e => e.Alias, "IX_ExtContact_Alias");

            entity.HasIndex(e => e.BirthDate, "IX_ExtContact_BirthDate");

            entity.HasIndex(e => e.FriendType, "IX_ExtContact_FriendType");

            entity.Property(e => e.ExtContactId).HasColumnName("ExtContactID");
            entity.Property(e => e.Alias).HasMaxLength(30);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FriendType)
                .HasMaxLength(20)
                .HasDefaultValue("Friend");
            entity.Property(e => e.MaternalSurname).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.PaternalSurname).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.TechAgendaExternalContacts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ExtContact_User");
        });

        modelBuilder.Entity<TechAgendaSocialNetworkContact>(entity =>
        {
            entity.HasKey(e => e.SocialNetworkContactId).HasName("PK__Tech_Age__A9FE85FAC83188E7");

            entity.ToTable("Tech_Agenda_SocialNetworkContact", tb => tb.HasTrigger("Tech_Agenda_TR_MaxSocialNetworks"));

            entity.HasIndex(e => e.ExternalContactId, "IX_Minimal_ExternalContactID");

            entity.HasIndex(e => new { e.ExternalContactId, e.SocialNetworkName, e.ProfileUrl }, "UC_SocialNetworkProfile").IsUnique();

            entity.Property(e => e.SocialNetworkContactId).HasColumnName("SocialNetworkContactID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExternalContactId).HasColumnName("ExternalContactID");
            entity.Property(e => e.LastUpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProfileUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ProfileURL");
            entity.Property(e => e.SocialDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SocialNetworkName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ExternalContact).WithMany(p => p.TechAgendaSocialNetworkContacts)
                .HasForeignKey(d => d.ExternalContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SocialNetworkContact_ExternalContact");
        });

        modelBuilder.Entity<TechAgendaUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Tech_Age__1788CCACB59E300C");

            entity.ToTable("Tech_Agenda_User");

            entity.HasIndex(e => e.Email, "IX_Tech_Agenda_User_Email");

            entity.HasIndex(e => e.Nickname, "IX_Tech_Agenda_User_Nickname");

            entity.HasIndex(e => e.UserId, "IX_Tech_Agenda_User_UserID");

            entity.HasIndex(e => e.Email, "UQ__Tech_Age__A9D1053492F2E2E0").IsUnique();

            entity.HasIndex(e => e.Nickname, "UQ__Tech_Age__CC6CD17E6221A8EE").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Biography).HasMaxLength(500);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastConnection).HasColumnType("datetime");
            entity.Property(e => e.MaternalSurname).HasMaxLength(50);
            entity.Property(e => e.Nickname).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PaternalSurname).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.ProfilePicture).HasMaxLength(255);
            entity.Property(e => e.RecoveryToken).HasMaxLength(255);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TokenExpiration).HasColumnType("datetime");
            entity.Property(e => e.UserRole)
                .HasMaxLength(20)
                .HasDefaultValue("User");
        });

        modelBuilder.Entity<TechAgendaUserRelation>(entity =>
        {
            entity.HasKey(e => e.RelationId).HasName("PK__Tech_Age__E2DA16956D66DD9D");

            entity.ToTable("Tech_Agenda_UserRelations");

            entity.HasIndex(e => new { e.ReceiverId, e.RelationStatus }, "IX_Tech_Agenda_UserRelations_Receiver");

            entity.HasIndex(e => new { e.SenderId, e.RelationStatus }, "IX_Tech_Agenda_UserRelations_Sender");

            entity.HasIndex(e => new { e.SenderId, e.ReceiverId }, "UQ_Sender_Receiver").IsUnique();

            entity.Property(e => e.RelationId).HasColumnName("RelationID");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsFavorite).HasDefaultValue(false);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");
            entity.Property(e => e.RelationStatus)
                .HasMaxLength(15)
                .HasDefaultValue("Pending");
            entity.Property(e => e.RelationshipType)
                .HasMaxLength(20)
                .HasDefaultValue("Friend");
            entity.Property(e => e.SenderId).HasColumnName("SenderID");

            entity.HasOne(d => d.Receiver).WithMany(p => p.TechAgendaUserRelationReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tech_Agen__Recei__5EBF139D");

            entity.HasOne(d => d.Sender).WithMany(p => p.TechAgendaUserRelationSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tech_Agen__Sende__5DCAEF64");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
