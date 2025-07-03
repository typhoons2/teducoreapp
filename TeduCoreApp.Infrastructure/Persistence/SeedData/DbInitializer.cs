using Microsoft.AspNetCore.Identity;
using TeduCoreApp.Domain.Entities;
using TeduCoreApp.Domain.Enums;
using TeduCoreApp.Utilities.Constants;
using TeduCoreApp.Infrastructure.Identity.Entities;
using TeduCoreApp.Infrastructure.Persistence.DbContext;

namespace TeduCoreApp.Infrastructure.Persistence.SeedData
{
	// Lớp này dùng để khởi tạo dữ liệu mẫu cho database khi ứng dụng chạy lần đầu
	public class DbInitializer
	{
		private readonly AppDbContext _context; // DbContext để thao tác với database
		private UserManager<ApplicationUser> _userManager; // Quản lý user (tài khoản)
		private RoleManager<ApplicationRole> _roleManager; // Quản lý role (vai trò)

		// Inject các service cần thiết qua constructor
		public DbInitializer(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		// Phương thức Seed dùng để tạo dữ liệu mẫu nếu database chưa có dữ liệu
		public async Task Seed()
		{
			// 1. Tạo các role mặc định nếu chưa có
			if (!_roleManager.Roles.Any())
			{
				await _roleManager.CreateAsync(new ApplicationRole()
				{
					Name = "Admin",
					NormalizedName = "ADMIN",
					Description = "Top manager"
				});
				await _roleManager.CreateAsync(new ApplicationRole()
				{
					Name = "Staff",
					NormalizedName = "STAFF",
					Description = "Staff"
				});
				await _roleManager.CreateAsync(new ApplicationRole()
				{
					Name = "Customer",
					NormalizedName = "CUSTOMER",
					Description = "Customer"
				});
			}

			// 2. Tạo user admin mặc định nếu chưa có user nào
			if (!_userManager.Users.Any())
			{
				var createResult = await _userManager.CreateAsync(new ApplicationUser()
				{
					UserName = "admin",
					FullName = "Administrator",
					Email = "admin@gmail.com",
					Balance = 0,
					Avatar = "/images/default-avatar.png"
				}, "Admin123$!@#"); // Mật khẩu mặc định

				if (createResult.Succeeded)
				{
					var user = await _userManager.FindByNameAsync("admin");
					await _userManager.AddToRoleAsync(user, "Admin");
				}
				else
				{
					// Log lỗi ra để biết vì sao không tạo được user
					throw new Exception("Cannot create admin user: " + string.Join(", ", createResult.Errors.Select(e => e.Description)));
				}
			}

			// 3. Seed các chức năng (Function) nếu chưa có
			if (_context.Functions.Count() == 0)
			{
				// Thêm danh sách các chức năng (menu, quyền truy cập, ...)
				_context.Functions.AddRange(new List<Function>()
				{
					new Function() {Id = "SYSTEM", 
						Name = "System",
						ParentId = null,
						SortOrder = 1,
						Status = Status.Active,
						URL = "/",
						IconCss = "fa-desktop"  },

					new Function() {Id = "ROLE", 
						Name = "Role",
						ParentId = "SYSTEM",
						SortOrder = 1,
						Status = Status.Active,URL = "/admin/role/index",
						IconCss = "fa-home"  },

					new Function() {Id = "FUNCTION", 
						Name = "Function",
						ParentId = "SYSTEM",
						SortOrder = 2,
						Status = Status.Active,
						URL = "/admin/function/index",
						IconCss = "fa-home"  },

					new Function() {Id = "USER", 
						Name = "User",
						ParentId = "SYSTEM",
						SortOrder =3,
						Status = Status.Active,
						URL = "/admin/user/index",
						IconCss = "fa-home"  },
					new Function() {Id = "ACTIVITY", 
						Name = "Activity Log",
						ParentId = "SYSTEM",
						SortOrder = 4,
						Status = Status.Active,
						URL = "/admin/activity/index",
						IconCss = "fa-home"  },
					new Function() {Id = "ERROR", 
						Name = "Error",
						ParentId = "SYSTEM",
						SortOrder = 5,
						Status = Status.Active,
						URL = "/admin/error/index",IconCss = "fa-home"  },
					new Function() {Id = "SETTING", Name = "Setting",ParentId = "SYSTEM",SortOrder = 6,Status = Status.Active,URL = "/admin/setting/index",IconCss = "fa-home"  },
					new Function() {Id = "PRODUCT",Name = "Product",ParentId = null,SortOrder = 2,Status = Status.Active,URL = "/",IconCss = "fa-chevron-down"  },
					new Function() {Id = "PRODUCT_CATEGORY",Name = "Category",ParentId = "PRODUCT",SortOrder =1,Status = Status.Active,URL = "/admin/productcategory/index",IconCss = "fa-chevron-down"  },
					new Function() {Id = "PRODUCT_LIST",Name = "Product",ParentId = "PRODUCT",SortOrder = 2,Status = Status.Active,URL = "/admin/product/index",IconCss = "fa-chevron-down"  },
					new Function() {Id = "BILL",Name = "Order",ParentId = "PRODUCT",SortOrder = 3,Status = Status.Active,URL = "/admin/bill/index",IconCss = "fa-chevron-down"  },
					new Function() {Id = "CONTENT",Name = "Content",ParentId = null,SortOrder = 3,Status = Status.Active,URL = "/",IconCss = "fa-table"  },
					new Function() {Id = "BLOG",Name = "Blog",ParentId = "CONTENT",SortOrder = 1,Status = Status.Active,URL = "/admin/blog/index",IconCss = "fa-table"  },
					new Function() {Id = "UTILITY",Name = "Utility",ParentId = null,SortOrder = 4,Status = Status.Active,URL = "/",IconCss = "fa-clone"  },
					new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",SortOrder = 1,Status = Status.Active,URL = "/admin/footer/index",IconCss = "fa-clone"  },
					new Function() {Id = "FEEDBACK",Name = "Feedback",ParentId = "UTILITY",SortOrder = 2,Status = Status.Active,URL = "/admin/feedback/index",IconCss = "fa-clone"  },
					new Function() {Id = "ANNOUNCEMENT",Name = "Announcement",ParentId = "UTILITY",SortOrder = 3,Status = Status.Active,URL = "/admin/announcement/index",IconCss = "fa-clone"  },
					new Function() {Id = "CONTACT",Name = "Contact",ParentId = "UTILITY",SortOrder = 4,Status = Status.Active,URL = "/admin/contact/index",IconCss = "fa-clone"  },
					new Function() {Id = "SLIDE",Name = "Slide",ParentId = "UTILITY",SortOrder = 5,Status = Status.Active,URL = "/admin/slide/index",IconCss = "fa-clone"  },
					new Function() {Id = "ADVERTISMENT",Name = "Advertisement",ParentId = "UTILITY",SortOrder = 6,Status = Status.Active,URL = "/admin/advertistment/index",IconCss = "fa-clone"  },

					new Function() {Id = "REPORT",Name = "Report",ParentId = null,SortOrder = 5,Status = Status.Active,URL = "/",IconCss = "fa-bar-chart-o"  },
					new Function() {Id = "REVENUES",Name = "Revenue Report",ParentId = "REPORT",SortOrder = 1,Status = Status.Active,URL = "/admin/report/revenues",IconCss = "fa-bar-chart-o"  },
					new Function() {Id = "ACCESS",Name = "Access Report",ParentId = "REPORT",SortOrder = 2,Status = Status.Active,URL = "/admin/report/visitor",IconCss = "fa-bar-chart-o"  },
					new Function() {Id = "READER",Name = "Reader Report",ParentId = "REPORT",SortOrder = 3,Status = Status.Active,URL = "/admin/report/reader",IconCss = "fa-bar-chart-o"  },
				});
				 
			}

			// 4. Seed Footer mặc định nếu chưa có
			if (_context.Footers.Count(x => x.Id == CommonConstants.DefaultFooterId) == 0)
			{
				string content = "Footer";
				_context.Footers.Add(new Footer()
				{
					Id = CommonConstants.DefaultFooterId,
					Content = content
				});
				 
			}

			// 5. Seed bảng màu sắc (Color) nếu chưa có
			if (_context.Colors.Count() == 0)
			{
				List<Color> listColor = new List<Color>()
				{
					new Color() {Name="Black", Code="#000000" },
					new Color() {Name="White", Code="#FFFFFF"},
					new Color() {Name="Red", Code="#ff0000" },
					new Color() {Name="Blue", Code="#1000ff" },
				};
				_context.Colors.AddRange(listColor);
				 
			}

			// 6. Seed các trang quảng cáo và vị trí quảng cáo nếu chưa có
			if (_context.AdvertistmentPages.Count() == 0)
			{
				List<AdvertistmentPage> pages = new List<AdvertistmentPage>()
				{
					new AdvertistmentPage() {Id="home", Name="Home",AdvertistmentPositions = new List<AdvertistmentPosition>(){
						new AdvertistmentPosition(){Id="home-left",Name="Left Side"}
					} },
					new AdvertistmentPage() {Id="product-cate", Name="Product Category" ,
						AdvertistmentPositions = new List<AdvertistmentPosition>(){
						new AdvertistmentPosition(){Id="product-cate-left",Name="Left Side"}
					}},
					new AdvertistmentPage() {Id="product-detail", Name="Product Detail",
						AdvertistmentPositions = new List<AdvertistmentPosition>(){
						new AdvertistmentPosition(){Id="product-detail-left",Name="Left Side"}
					} },

				};
				_context.AdvertistmentPages.AddRange(pages);
				 
			}

			// 7. Seed slide/banner nếu chưa có
			if (_context.Slides.Count() == 0)
			{
				List<Slide> slides = new List<Slide>()
				{
					new Slide() {
						Name="Slide 1",
						Image="/client-side/images/slider/slide-1.jpg",
						Url="#",
						DisplayOrder = 0,
						GroupAlias = "top",
						Status = true,
						Description = "Slide 1 Description",
						Content = "<h2>Welcome to TeduShop</h2><p>Discover our latest collection</p>"
					},
					new Slide() {
						Name="Slide 2",
						Image="/client-side/images/slider/slide-2.jpg",
						Url="#",
						DisplayOrder = 1,
						GroupAlias = "top",
						Status = true,
						Description = "Slide 2 Description",
						Content = "<h2>New Arrivals</h2><p>Check out our newest products</p>"
					},
					new Slide() {
						Name="Slide 3",
						Image="/client-side/images/slider/slide-3.jpg",
						Url="#",
						DisplayOrder = 2,
						GroupAlias = "top",
						Status = true,
						Description = "Slide 3 Description",
						Content = "<h2>Special Offers</h2><p>Great deals on selected items</p>"
					},

					new Slide() {
						Name="Slide 1",
						Image="/client-side/images/brand1.png",
						Url="#",
						DisplayOrder = 1,
						GroupAlias = "brand",
						Status = true,
						Description = "Brand 1 Description",
						Content = "<h3>Brand 1</h3>"
					},
					new Slide() {
						Name="Slide 2",
						Image="/client-side/images/brand2.png",
						Url="#",
						DisplayOrder = 2,
						GroupAlias = "brand",
						Status = true,
						Description = "Brand 2 Description",
						Content = "<h3>Brand 2</h3>"
					},
					new Slide() {
						Name="Slide 3",
						Image="/client-side/images/brand3.png",
						Url="#",
						DisplayOrder = 3,
						GroupAlias = "brand",
						Status = true,
						Description = "Brand 3 Description",
						Content = "<h3>Brand 3</h3>"
					},
					new Slide() {
						Name="Slide 4",
						Image="/client-side/images/brand4.png",
						Url="#",
						DisplayOrder = 4,
						GroupAlias = "brand",
						Status = true,
						Description = "Brand 4 Description",
						Content = "<h3>Brand 4</h3>"
					},
					new Slide() {
						Name="Slide 5",
						Image="/client-side/images/brand5.png",
						Url="#",
						DisplayOrder = 5,
						GroupAlias = "brand",
						Status = true,
						Description = "Brand 5 Description",
						Content = "<h3>Brand 5</h3>"
					},
					new Slide() {
						Name="Slide 6",
						Image="/client-side/images/brand6.png",
						Url="#",
						DisplayOrder = 6,
						GroupAlias = "brand",
						Status = true,
						Description = "Brand 6 Description",
						Content = "<h3>Brand 6</h3>"
					},
					new Slide() {
						Name="Slide 7",
						Image="/client-side/images/brand7.png",
						Url="#",
						DisplayOrder = 7,
						GroupAlias = "brand",
						Status = true,
						Description = "Brand 7 Description",
						Content = "<h3>Brand 7</h3>"
					},
					new Slide() {
						Name="Slide 8",
						Image="/client-side/images/brand8.png",
						Url="#",
						DisplayOrder = 8,
						GroupAlias = "brand",
						Status = true,
						Description = "Brand 8 Description",
						Content = "<h3>Brand 8</h3>"
					},
					new Slide() {
						Name="Slide 9",
						Image="/client-side/images/brand9.png",
						Url="#",
						DisplayOrder = 9,
						GroupAlias = "brand",
						Status = true,
						Description = "Brand 9 Description",
						Content = "<h3>Brand 9</h3>"
					},
					new Slide() {
						Name="Slide 10",
						Image="/client-side/images/brand10.png",
						Url="#",
						DisplayOrder = 10,
						GroupAlias = "brand",
						Status = true,
						Description = "Brand 10 Description",
						Content = "<h3>Brand 10</h3>"
					},
					new Slide() {
						Name="Slide 11",
						Image="/client-side/images/brand11.png",
						Url="#",
						DisplayOrder = 11,
						GroupAlias = "brand",
						Status = true,
						Description = "Brand 11 Description",
						Content = "<h3>Brand 11</h3>"
					},
				};
				_context.Slides.AddRange(slides);
				 
			}

			// 8. Seed size sản phẩm nếu chưa có
			if (_context.Sizes.Count() == 0)
			{
				List<Size> listSize = new List<Size>()
				{
					new Size() { Name="XXL" },
					new Size() { Name="XL"},
					new Size() { Name="L" },
					new Size() { Name="M" },
					new Size() { Name="S" },
					new Size() { Name="XS" }
				};
				_context.Sizes.AddRange(listSize);
				 
			}

			// 9. Seed danh mục sản phẩm và sản phẩm mẫu nếu chưa có
			if (_context.ProductCategories.Count() == 0)
			{
				List<ProductCategory> listProductCategory = new List<ProductCategory>()
				{
					new ProductCategory() { 
						Name="Men's Shirts",
						SeoAlias="mens-shirts",
						ParentId = null,
						Status=Status.Active,
						SortOrder=1,
						SeoDescription = "Men's Shirts Category",
						Description = "Men's Shirts Category Description",
						SeoPageTitle = "Men's Shirts - TeduShop",
						Image = "/client-side/images/products/category/mens-shirts.jpg",
						SeoKeywords = "men shirts, mens clothing, mens fashion",
						Products = new List<Product>()
						{
							new Product(){
								Name = "Product 1",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-1",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 1 Description",
								Content = "Product 1 Content",
								HomeFlag = true,
								HotFlag = true,
								ViewCount = 0,
								Tags = "shirt,men",
								Unit = "piece",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 1 - TeduShop",
								SeoKeywords = "product 1, shirt, men",
								SeoDescription = "Product 1 Description"
							},
							new Product(){
								Name = "Product 2",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-2",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 2 Description",
								Content = "Product 2 Content",
								HomeFlag = true,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shirt,men",
								Unit = "piece",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 2 - TeduShop",
								SeoKeywords = "product 2, shirt, men",
								SeoDescription = "Product 2 Description"
							},
							new Product(){
								Name = "Product 3",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-3",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 3 Description",
								Content = "Product 3 Content",
								HomeFlag = false,
								HotFlag = true,
								ViewCount = 0,
								Tags = "shirt,men",
								Unit = "piece",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 3 - TeduShop",
								SeoKeywords = "product 3, shirt, men",
								SeoDescription = "Product 3 Description"
							},
							new Product(){
								Name = "Product 4",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-4",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 4 Description",
								Content = "Product 4 Content",
								HomeFlag = false,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shirt,men",
								Unit = "piece",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 4 - TeduShop",
								SeoKeywords = "product 4, shirt, men",
								SeoDescription = "Product 4 Description"
							},
							new Product(){
								Name = "Product 5",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-5",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 5 Description",
								Content = "Product 5 Content",
								HomeFlag = false,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shirt,men",
								Unit = "piece",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 5 - TeduShop",
								SeoKeywords = "product 5, shirt, men",
								SeoDescription = "Product 5 Description"
							},
						}
					},
					new ProductCategory() { 
						Name="Women's Shirts",
						SeoAlias="womens-shirts",
						ParentId = null,
						Status=Status.Active,
						SortOrder=2,
						SeoDescription = "Women's Shirts Category",
						Description = "Women's Shirts Category Description",
						SeoPageTitle = "Women's Shirts - TeduShop",
						Image = "/client-side/images/products/category/womens-shirts.jpg",
						SeoKeywords = "women shirts, womens clothing, womens fashion",
						Products = new List<Product>()
						{
							new Product(){
								Name = "Product 6",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-6",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 6 Description",
								Content = "Product 6 Content",
								HomeFlag = true,
								HotFlag = true,
								ViewCount = 0,
								Tags = "shirt,women",
								Unit = "piece",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 6 - TeduShop",
								SeoKeywords = "product 6, shirt, women",
								SeoDescription = "Product 6 Description"
							},
							new Product(){
								Name = "Product 7",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-7",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 7 Description",
								Content = "Product 7 Content",
								HomeFlag = true,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shirt,women",
								Unit = "piece",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 7 - TeduShop",
								SeoKeywords = "product 7, shirt, women",
								SeoDescription = "Product 7 Description"
							},
							new Product(){
								Name = "Product 8",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-8",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 8 Description",
								Content = "Product 8 Content",
								HomeFlag = false,
								HotFlag = true,
								ViewCount = 0,
								Tags = "shirt,women",
								Unit = "piece",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 8 - TeduShop",
								SeoKeywords = "product 8, shirt, women",
								SeoDescription = "Product 8 Description"
							},
							new Product(){
								Name = "Product 9",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-9",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 9 Description",
								Content = "Product 9 Content",
								HomeFlag = false,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shirt,women",
								Unit = "piece",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 9 - TeduShop",
								SeoKeywords = "product 9, shirt, women",
								SeoDescription = "Product 9 Description"
							},
							new Product(){
								Name = "Product 10",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-10",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 10 Description",
								Content = "Product 10 Content",
								HomeFlag = false,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shirt,women",
								Unit = "piece",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 10 - TeduShop",
								SeoKeywords = "product 10, shirt, women",
								SeoDescription = "Product 10 Description"
							},
						}},
					new ProductCategory() { 
						Name="Men's Shoes",
						SeoAlias="mens-shoes",
						ParentId = null,
						Status=Status.Active,
						SortOrder=3,
						SeoDescription = "Men's Shoes Category",
						Description = "Men's Shoes Category Description",
						SeoPageTitle = "Men's Shoes - TeduShop",
						Image = "/client-side/images/products/category/mens-shoes.jpg",
						SeoKeywords = "men shoes, mens footwear, mens sneakers",
						Products = new List<Product>()
						{
							new Product(){
								Name = "Product 11",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-11",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 11 Description",
								Content = "Product 11 Content",
								HomeFlag = true,
								HotFlag = true,
								ViewCount = 0,
								Tags = "shoes,men",
								Unit = "pair",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 11 - TeduShop",
								SeoKeywords = "product 11, shoes, men",
								SeoDescription = "Product 11 Description"
							},
							new Product(){
								Name = "Product 12",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-12",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 12 Description",
								Content = "Product 12 Content",
								HomeFlag = true,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shoes,men",
								Unit = "pair",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 12 - TeduShop",
								SeoKeywords = "product 12, shoes, men",
								SeoDescription = "Product 12 Description"
							},
							new Product(){
								Name = "Product 13",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-13",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 13 Description",
								Content = "Product 13 Content",
								HomeFlag = false,
								HotFlag = true,
								ViewCount = 0,
								Tags = "shoes,men",
								Unit = "pair",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 13 - TeduShop",
								SeoKeywords = "product 13, shoes, men",
								SeoDescription = "Product 13 Description"
							},
							new Product(){
								Name = "Product 14",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-14",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 14 Description",
								Content = "Product 14 Content",
								HomeFlag = false,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shoes,men",
								Unit = "pair",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 14 - TeduShop",
								SeoKeywords = "product 14, shoes, men",
								SeoDescription = "Product 14 Description"
							},
							new Product(){
								Name = "Product 15",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-15",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 15 Description",
								Content = "Product 15 Content",
								HomeFlag = false,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shoes,men",
								Unit = "pair",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 15 - TeduShop",
								SeoKeywords = "product 15, shoes, men",
								SeoDescription = "Product 15 Description"
							},
						}},
					new ProductCategory() { 
						Name="Women's Shoes",
						SeoAlias="womens-shoes",
						ParentId = null,
						Status=Status.Active,
						SortOrder=4,
						SeoDescription = "Women's Shoes Category",
						Description = "Women's Shoes Category Description",
						SeoPageTitle = "Women's Shoes - TeduShop",
						Image = "/client-side/images/products/category/womens-shoes.jpg",
						SeoKeywords = "women shoes, womens footwear, womens sneakers",
						Products = new List<Product>()
						{
							new Product(){
								Name = "Product 16",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-16",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 16 Description",
								Content = "Product 16 Content",
								HomeFlag = true,
								HotFlag = true,
								ViewCount = 0,
								Tags = "shoes,women",
								Unit = "pair",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 16 - TeduShop",
								SeoKeywords = "product 16, shoes, women",
								SeoDescription = "Product 16 Description"
							},
							new Product(){
								Name = "Product 17",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-17",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 17 Description",
								Content = "Product 17 Content",
								HomeFlag = true,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shoes,women",
								Unit = "pair",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 17 - TeduShop",
								SeoKeywords = "product 17, shoes, women",
								SeoDescription = "Product 17 Description"
							},
							new Product(){
								Name = "Product 18",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-18",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 18 Description",
								Content = "Product 18 Content",
								HomeFlag = false,
								HotFlag = true,
								ViewCount = 0,
								Tags = "shoes,women",
								Unit = "pair",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 18 - TeduShop",
								SeoKeywords = "product 18, shoes, women",
								SeoDescription = "Product 18 Description"
							},
							new Product(){
								Name = "Product 19",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-19",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 19 Description",
								Content = "Product 19 Content",
								HomeFlag = false,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shoes,women",
								Unit = "pair",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 19 - TeduShop",
								SeoKeywords = "product 19, shoes, women",
								SeoDescription = "Product 19 Description"
							},
							new Product(){
								Name = "Product 20",
								Image="/client-side/images/products/product-1.jpg",
								SeoAlias = "product-20",
								Price = 1000,
								Status = Status.Active,
								OriginalPrice = 1000,
								Description = "Product 20 Description",
								Content = "Product 20 Content",
								HomeFlag = false,
								HotFlag = false,
								ViewCount = 0,
								Tags = "shoes,women",
								Unit = "pair",
								DateCreated = DateTime.Now,
								DateModified = DateTime.Now,
								SeoPageTitle = "Product 20 - TeduShop",
								SeoKeywords = "product 20, shoes, women",
								SeoDescription = "Product 20 Description"
							},
						}}
				};
				_context.ProductCategories.AddRange(listProductCategory);
				 
			}

			// 10. Seed các cấu hình hệ thống mặc định nếu chưa có
			if (!_context.SystemConfigs.Any(x => x.Id == "HomeTitle"))
			{
				_context.SystemConfigs.Add(new SystemConfig()
				{
					Id = "HomeTitle",
					Name = "Home Title",
					Value1 = "TeduShop Home",
					Status = Status.Active
				});
			}
			if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaKeyword"))
			{
				_context.SystemConfigs.Add(new SystemConfig()
				{
					Id = "HomeMetaKeyword",
					Name = "Home Meta Keywords",
					Value1 = "TeduShop Home",
					Status = Status.Active
				});
			}
			if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaDescription"))
			{
				_context.SystemConfigs.Add(new SystemConfig()
				{
					Id = "HomeMetaDescription",
					Name = "Home Meta Description",
					Value1 = "TeduShop Home",
					Status = Status.Active
				});
			}
			_context.SaveChanges();
		}
	}
}

