using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeduCoreApp.Domain.Entities;
using TeduCoreApp.Domain.Interfaces;
using TeduCoreApp.Infrastructure.Configurations;
using TeduCoreApp.Infrastructure.Identity.Entities;


namespace TeduCoreApp.Infrastructure.Persistence.DbContext
{
	public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<AnnouncementUser> AnnouncementUsers { get; set; }
		public DbSet<Advertistment> Advertistments { get; set; }
		public DbSet<AdvertistmentPage> AdvertistmentPages { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<AppRole> AppRoles { get; set; }
		public DbSet<AdvertistmentPosition> AdvertistmentPositions { get; set; }
		public DbSet<Announcement> Announcements { get; set; }
		public DbSet<BillDetail> BillDetails { get; set; }
		public DbSet<Bill> Bills { get; set; }
		public DbSet<BlogTag> BlogTags { get; set; }
		public DbSet<Color> Colors { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Footer> Footers { get; set; }
		public DbSet<Feedback> Feedbacks { get; set; }
		public DbSet<Function> Functions { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Page> Pages { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<ProductQuantity> ProductQuantities { get; set; }
		public DbSet<ProductTag> ProductTags { get; set; }
		public DbSet<SystemConfig> SystemConfigs { get; set; }
		public DbSet<Size> Sizes { get; set; }
		public DbSet<Slide> Slides { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<WholePrice> WholePrices { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			#region Identity Config

			modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

			modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims")
				.HasKey(x => x.Id);

			modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

			modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
				.HasKey(x => new { x.RoleId, x.UserId });

			modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens")
			   .HasKey(x => new { x.UserId });

			modelBuilder.Entity<ApplicationUser>(b =>
			{
				b.ToTable("AppUsers");

				// Map các thuộc tính chung + set MaxLength(250) cho Description
				b.Property(u => u.FullName).HasColumnName("FullName")
											  .HasMaxLength(250);
			});
			modelBuilder.Entity<AppUser>().ToTable("AppUsers");

			// liên kết 1-1 chung PK
			modelBuilder.Entity<AppUser>()
						.HasOne<ApplicationUser>()
						.WithOne()
						.HasForeignKey<AppUser>(u => u.Id);

			// Map CỘT dùng chung – áp dụng CHO CẢ HAI entity
			string[] sharedCols = { "FullName", "BirthDay", "Balance",
						"Avatar", "Status"};

			modelBuilder.Entity<AppUser>(b =>
			{
				foreach (var col in sharedCols)
					b.Property(col).HasColumnName(col);
				b.Property(u => u.DateCreated).HasColumnName("DateCreated");   // chỉ AppUser có
				b.Property(u => u.DateModified).HasColumnName("DateModified");
			});



			modelBuilder.Entity<ApplicationUser>(b =>
			{
				foreach (var col in sharedCols)
					b.Property(col).HasColumnName(col);

			});


			modelBuilder.Entity<ApplicationRole>(b =>
			{
				b.ToTable("AppRoles");

				// Map các thuộc tính chung + set MaxLength(250) cho Description
				b.Property(r => r.Description).HasColumnName("Description")
											  .HasMaxLength(250);
				b.Property(r => r.Name).HasColumnName("Name")
											  .HasMaxLength(250);
			});

			modelBuilder.Entity<AppRole>().ToTable("AppRoles");
			modelBuilder.Entity<AppRole>()
						.HasOne<ApplicationRole>()
						.WithOne()
						.HasForeignKey<AppRole>(r => r.Id);
			string[] sharedColsRole = { "Description", "Name" };

			modelBuilder.Entity<AppRole>(b =>
			{
				foreach (var col in sharedColsRole)
					b.Property(col).HasColumnName(col);
			});

			modelBuilder.Entity<ApplicationRole>(b =>
			{
				foreach (var col in sharedColsRole)
					b.Property(col).HasColumnName(col);
			});


			#endregion Identity Config
			modelBuilder.ApplyConfiguration(new TagConfiguration());
			// Khi các cấu hình khác đã chuyển sang IEntityTypeConfiguration, thêm vào như sau:
			modelBuilder.ApplyConfiguration(new BlogTagConfiguration());
			modelBuilder.ApplyConfiguration(new ProductTagConfiguration());
			modelBuilder.ApplyConfiguration(new AdvertistmentPositionConfiguration());
			modelBuilder.ApplyConfiguration(new FooterConfiguration());
			modelBuilder.ApplyConfiguration(new ContactDetailConfiguration());
			modelBuilder.ApplyConfiguration(new FunctionConfiguration());
			modelBuilder.ApplyConfiguration(new PageConfiguration());
			modelBuilder.ApplyConfiguration(new SystemConfigConfiguration());
			modelBuilder.ApplyConfiguration(new AdvertistmentPageConfiguration());
			modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
			modelBuilder.ApplyConfiguration(new AnnouncementUserConfiguration());

			//base.OnModelCreating(modelBuilder);


		}
		public override int SaveChanges()
		{
			var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
			foreach (var item in modified)
			{
				var changedOrAddedItem = item.Entity as IDateTracking;
				if (changedOrAddedItem != null)
				{
					if (item.State == EntityState.Added)
					{
						changedOrAddedItem.DateCreated = DateTime.Now;
					}
					else
					{
						changedOrAddedItem.DateModified = DateTime.Now;
					}
				}
			}
			return base.SaveChanges();
		}
	}
}
