


using Microsoft.EntityFrameworkCore;

namespace MedvisionApi.Models;

public partial class MedvisiondbContext : DbContext
{
    public MedvisiondbContext()
    {
    }

    public MedvisiondbContext(DbContextOptions<MedvisiondbContext> options)
        : base(options)
    {
    }

 

    public virtual DbSet<Commentaire> Commentaires { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:med");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
               new User { Id = 1, Email = "chrifa.bahrouni@gmail.com", Name = " chrifa bahrouni", Phone = "99828278", Password = "123456", PhotoUrl = "https://www.google.com" }

               );
        modelBuilder.Entity<User>().HasData(
         new User { Id = 2, Email = "chrifa.bahrouni123@gmail.com", Name = " chrifa ", Phone = "99828278", Password = "123456", PhotoUrl = "https://www.google.com" }

         );
        modelBuilder.Entity<User>().HasData(
      new User { Id = 3, Email = "islem@gmail.com", Name = " Islem", Phone = "99828278", Password = "123456", PhotoUrl = "https://www.google.com" }

      );
        modelBuilder.Entity<Post>().HasData(
    new Post { Id = 3, Description = "islem@gmail.com", Countlike = 0, Countshare = 0, Countcomment = 0, Time = 123456 , Reserve=  0 , UserId=1 }

    ); 
        modelBuilder.Entity<Commentaire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0730598A5F");

            entity.ToTable("Commentaire");

            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.Time)
                .HasMaxLength(50)
                .HasColumnName("time");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Commentaires)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_comment");

            entity.HasOne(d => d.User).WithMany(p => p.Commentaires)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_comment");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC075430816A");

            entity.ToTable("Notification");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Content).HasColumnName("content");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notif_User");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Photo__3214EC070614F55D");

            entity.ToTable("Photo");

            entity.Property(e => e.Fullpath)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("fullpath");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("url");

            entity.HasOne(d => d.Post).WithMany(p => p.Photos)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_photo");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC078C3BB587");

            entity.ToTable("Post");

            entity.Property(e => e.Countcomment).HasColumnName("countcomment");
            entity.Property(e => e.Countlike).HasColumnName("countlike");
            entity.Property(e => e.Countshare).HasColumnName("countshare");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Reserve).HasColumnName("reserve");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC076E48FD4E");

            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(9)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
