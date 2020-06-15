using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TraCuuDiemThiTHPTQG.DAL.Models
{
    public partial class QL_DIEMContext : DbContext
    {
        public QL_DIEMContext()
        {
        }

        public QL_DIEMContext(DbContextOptions<QL_DIEMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnhThiSinh> AnhThiSinh { get; set; }
        public virtual DbSet<Diem> Diem { get; set; }
        public virtual DbSet<SoGd> SoGd { get; set; }
        public virtual DbSet<ThiSinh> ThiSinh { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5NBGHMV;Initial Catalog=QL_DIEM;Persist Security Info=True;User ID=sa;Password=10253476Aa;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnhThiSinh>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SoBaoDanh)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasColumnType("text");

                entity.HasOne(d => d.SoBaoDanhNavigation)
                    .WithMany(p => p.AnhThiSinh)
                    .HasForeignKey(d => d.SoBaoDanh)
                    .HasConstraintName("FK__AnhThiSin__SoBao__4316F928");
            });

            modelBuilder.Entity<Diem>(entity =>
            {
                entity.HasKey(e => new { e.MaDiem, e.SoBaoDanh })
                    .HasName("PK__Diem__834DE8826233B1FA");

                entity.Property(e => e.MaDiem).ValueGeneratedOnAdd();

                entity.Property(e => e.SoBaoDanh)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DiemDia).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiemGdcd)
                    .HasColumnName("DiemGDCD")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiemHoa).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiemLy).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiemNgoaiNgu).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiemSinh).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiemSu).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiemToan).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.DiemVan).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.MaSoGd)
                    .IsRequired()
                    .HasColumnName("MaSoGD")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaSoGdNavigation)
                    .WithMany(p => p.Diem)
                    .HasForeignKey(d => d.MaSoGd)
                    .HasConstraintName("FK__Diem__MaSoGD__403A8C7D");

                entity.HasOne(d => d.SoBaoDanhNavigation)
                    .WithMany(p => p.Diem)
                    .HasForeignKey(d => d.SoBaoDanh)
                    .HasConstraintName("FK__Diem__SoBaoDanh__3F466844");
            });

            modelBuilder.Entity<SoGd>(entity =>
            {
                entity.HasKey(e => e.MaSoGd)
                    .HasName("PK__SoGD__A61DE871F12A2A56");

                entity.ToTable("SoGD");

                entity.Property(e => e.MaSoGd)
                    .HasColumnName("MaSoGD")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TenSoGd)
                    .IsRequired()
                    .HasColumnName("TenSoGD")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ThiSinh>(entity =>
            {
                entity.HasKey(e => e.SoBaoDanh)
                    .HasName("PK__ThiSinh__07F88A7A370D3A0D");

                entity.Property(e => e.SoBaoDanh)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Ho)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.KhoiThi)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.QueQuan)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C917FB5CC");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
