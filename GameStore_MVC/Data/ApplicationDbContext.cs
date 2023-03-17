using GameStore_MVC.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStore_MVC.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }

		public virtual DbSet<Game> Games { get; set; }
		public virtual DbSet<GameDev> GameDevs { get; set; }
		public virtual DbSet <Order> Orders { get; set; }
		public virtual DbSet <AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Name = "Admin",
					NormalizedName = "ADMIN"
				}
				);
		}
	}
}