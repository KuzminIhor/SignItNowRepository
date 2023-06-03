using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Model.Enums;

namespace SignItNow.Core
{
	public class DBAppContext: DbContext
	{
		private IEncryptorDecryptor encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<TaskInfo> TaskInfos{ get; set; }
		public DbSet<DocumentInfo> DocumentInfos { get; set; }
		public DbSet<TaskSigner> TaskSigners { get; set; }

		public DBAppContext()
		{
			this.Database.EnsureCreated();
		}

		public DBAppContext(DbContextOptions dbContextOptions)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Program.SQLConnection);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(u => u.Metadata)
				.HasConversion(
					metadata => JsonConvert.SerializeObject(metadata),
					json => JsonConvert.DeserializeObject<Dictionary<string, string>>(json)
				);

			modelBuilder.Entity<TaskInfo>()
				.HasOne(t => t.Document)
				.WithOne(d => d.TaskInfo)
				.HasForeignKey<TaskInfo>(t => t.DocumentInfoId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.SetNull);

			var admin = new User()
				{Id = 1, UserName = "admin", FirstName = "admin", LastName = "admin", Password = "admin"};

			admin.UserName = encryptorDecryptor.Encrypt(admin.UserName);
			admin.FirstName = encryptorDecryptor.Encrypt(admin.FirstName);
			admin.LastName = encryptorDecryptor.Encrypt(admin.LastName);
			admin.Password = encryptorDecryptor.Encrypt(admin.Password);

			var adminRole = new Role() {Id = 1, Name = RoleName.Admin.ToString()};

			modelBuilder.Entity<Role>().HasData(new List<Role>()
			{
				adminRole,
				new Role() {Id = 2, Name = RoleName.Signer.ToString()},
				new Role() {Id = 3, Name = RoleName.SignCreator.ToString()}
			});

			modelBuilder.Entity<User>().HasData(new List<User>()
			{
				admin
			});
		}
    }
}
