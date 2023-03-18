using System.Reflection.Emit;
using GameStore_MVC.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStore_MVC.Data
{
	public partial class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }

		public virtual DbSet<Game> Games { get; set; }
		public virtual DbSet<GameDev> GameDevs { get; set; }
		public virtual DbSet <Order> Orders { get; set; }
		public virtual DbSet <Customer> Customers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("name=ConnectionStrings:GSLocal");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>(entity =>
			{
				entity.ToTable("Customers", "dev");

				entity.Property(e => e.Email).HasMaxLength(100);

				entity.Property(e => e.Name).HasMaxLength(100);
			});

			modelBuilder.Entity<Game>(entity =>
			{
				entity.ToTable("Games", "dev");

				entity.Property(e => e.Title).HasMaxLength(100);
			});

			modelBuilder.Entity<Order>(entity =>
			{
				entity.ToTable("Orders", "dev");

				entity.Property(e => e.DateOfOrder).HasColumnType("datetime");

				entity.HasOne(d => d.Customer)
					.WithMany(p => p.Orders)
					.HasForeignKey(d => d.CustomerId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Transacti__Custo__3E52440B");

				entity.HasOne(d => d.Game)
					.WithMany(p => p.Orders)
					.HasForeignKey(d => d.GameId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__Transacti__Produ__3D5E1FD2");
			});

			OnModelCreatingPartial(modelBuilder);

			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Name = "Admin",
					NormalizedName = "ADMIN"
				}
				);
		}
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

		public DbSet<GameStore_MVC.Models.GameStoreViewModels.CustomerVM.CustomerDetail>? CustomerDetail { get; set; }
		public DbSet<GameStore_MVC.Models.GameStoreViewModels.CustomerVM.CustomerEdit>? CustomerEdit { get; set; }
	}
}