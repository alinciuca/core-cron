using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Cron.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public DbSet<Service> Service { get; set; }
		public DbSet<Heartbeat> Heartbeat { get; set; }
		public DbQuery<ServiceView> ServiceView{get;set;}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			string suId = Guid.NewGuid().ToString();
			builder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = suId,
				UserName = "su@a.co",
				NormalizedUserName = "SU@A.CO",
				NormalizedEmail = "SU@A.CO",
				Email = "su@a.co",
				EmailConfirmed = true,
				PasswordHash = "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==",
				SecurityStamp = "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA",
				LockoutEnabled = false,
			});

			string roleId = Guid.NewGuid().ToString();
			builder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = roleId,
				Name = "Admin",
				NormalizedName = "ADMIN",
			});

			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = roleId,
				UserId = suId
			});

			builder.Entity<Service>(entity =>
			{
				entity.HasKey(s => s.ServiceId);
				entity.Property(s => s.RowVersion).IsRequired().IsRowVersion();
				entity.Property(s => s.DateAdded).IsRequired(true);
				entity.Property(s => s.ServiceName).HasMaxLength(500).IsUnicode(false).IsRequired();
				entity.Property(s => s.ServiceIdentifier).HasMaxLength(40).IsUnicode(false).IsRequired();
				entity.HasIndex("ServiceName", "ServiceIdentifier").HasName("UK_ServiceName_ServiceIdentifier").IsUnique();
			});

			builder.Entity<Heartbeat>(entity =>
			{
				entity.HasKey(s => s.HeartbeatId);
				entity.HasOne(s => s.Service);
				entity.Property(s => s.RowVersion).IsRequired().IsRowVersion();
				entity.Property(s => s.ServiceId).IsRequired();
				entity.Property(s => s.LastUpdate).IsRequired();
			});

			builder.Query<ServiceView>().ToView("vw_Service");
		}
	}
}
