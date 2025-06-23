# Bài tập thực hành với Cursor - .NET Core Clean Architecture

## 🎯 Mục tiêu
Áp dụng kiến thức từ hướng dẫn vào dự án thực tế của bạn.

## 📋 Bài tập 1: Khám phá cấu trúc dự án

### Bước 1: Hiểu Clean Architecture
1. **Mở từng project** và đọc file `.csproj`
2. **Tìm hiểu dependency** giữa các project
3. **Vẽ sơ đồ** Clean Architecture

### Bước 2: Sử dụng Cursor Navigation
```bash
# Thực hành các phím tắt:
Ctrl + Click    # Jump to definition
Ctrl + Shift + O # Go to symbol  
Ctrl + T        # Go to file
Ctrl + Shift + F # Search across project
```

### Bài tập:
1. Tìm tất cả file có chứa từ "Controller"
2. Tìm interface bắt đầu bằng "I"
3. Tìm class kết thúc bằng "Service"
4. Tìm tất cả Entity class

## 📋 Bài tập 2: Dependency Injection

### Bước 1: Tìm hiểu DI Container
1. **Mở file `Program.cs`** trong project chính
2. **Tìm tất cả `services.AddScoped`**
3. **Tìm tất cả `services.AddTransient`**
4. **Tìm tất cả `services.AddSingleton`**

### Bước 2: Hiểu Interface và Implementation
1. **Chọn một service** đã đăng ký
2. **Ctrl + Click** vào interface để xem definition
3. **Tìm implementation** của interface đó
4. **Hiểu cách DI hoạt động**

### Bài tập thực hành:
```csharp
// Tìm và hiểu pattern này:
services.AddScoped<IUserService, UserService>();
services.AddScoped<IProductRepository, ProductRepository>();
```

## 📋 Bài tập 3: Repository Pattern

### Bước 1: Tìm hiểu Repository
1. **Tìm interface `IRepository<T>`**
2. **Tìm implementation** trong Data.EF project
3. **Hiểu Generic Repository pattern**

### Bước 2: Sử dụng Tab Completion
```csharp
// Thử gõ và sử dụng tab completion:
public class ProductService
{
    private readonly IRepository<Product> _repository;
    
    public ProductService(IRepository<Product> repository)
    {
        _repository = repository;
    }
    
    // Gõ "Get" và dùng tab completion
    public async Task<Product> GetByIdAsync(int id)
    {
        // Gõ "_repository." và xem các method có sẵn
        return await _repository.GetByIdAsync(id);
    }
}
```

## 📋 Bài tập 4: API Controller

### Bước 1: Tạo Controller mới
1. **Tạo file `TestController.cs`** trong Controllers folder
2. **Sử dụng tab completion** để gõ:

```csharp
[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    
    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello from Test Controller!");
    }
}
```

### Bước 2: Thực hành với AI
**Hỏi AI**: "Giải thích cho tôi từng attribute trong Controller này và tại sao cần chúng?"

## 📋 Bài tập 5: Entity và DbContext

### Bước 1: Tìm hiểu Entity
1. **Tìm các Entity class** trong Data project
2. **Hiểu Data Annotations** như `[Required]`, `[MaxLength]`
3. **Tìm hiểu Navigation Properties**

### Bước 2: Tạo Entity mới
```csharp
// Sử dụng tab completion để tạo Entity
public class Category
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    // Navigation property
    public virtual ICollection<Product> Products { get; set; }
}
```

## 📋 Bài tập 6: Service Layer

### Bước 1: Tìm hiểu Service Pattern
1. **Tìm các Service interface** trong Application project
2. **Tìm các Service implementation**
3. **Hiểu Business Logic layer**

### Bước 2: Tạo Service mới
```csharp
// Interface
public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
    Task<Category> CreateAsync(Category category);
}

// Implementation
public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _repository;
    
    public CategoryService(IRepository<Category> repository)
    {
        _repository = repository;
    }
    
    // Implement các method
}
```

## 📋 Bài tập 7: Error Handling

### Bước 1: Tìm hiểu Exception Handling
1. **Tìm try-catch blocks** trong code
2. **Tìm custom exceptions**
3. **Hiểu global exception handling**

### Bước 2: Thực hành Debug
1. **Tạo lỗi cố ý** trong code
2. **Đọc error message** cẩn thận
3. **Sử dụng AI để hỏi**: "Tại sao lỗi này xảy ra và cách fix?"

## 📋 Bài tập 8: Unit Testing

### Bước 1: Tìm hiểu Test Project
1. **Tìm test files** trong solution
2. **Hiểu test structure**
3. **Tìm hiểu mocking**

### Bước 2: Viết Test đơn giản
```csharp
[TestClass]
public class CategoryServiceTests
{
    private Mock<IRepository<Category>> _mockRepository;
    private CategoryService _service;
    
    [TestInitialize]
    public void Setup()
    {
        _mockRepository = new Mock<IRepository<Category>>();
        _service = new CategoryService(_mockRepository.Object);
    }
    
    [TestMethod]
    public async Task GetByIdAsync_ShouldReturnCategory_WhenExists()
    {
        // Arrange
        var category = new Category { Id = 1, Name = "Test" };
        _mockRepository.Setup(r => r.GetByIdAsync(1))
                      .ReturnsAsync(category);
        
        // Act
        var result = await _service.GetByIdAsync(1);
        
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Test", result.Name);
    }
}
```

## 🎯 Mục tiêu hoàn thành

### Tuần 1:
- [ ] Hoàn thành Bài tập 1-2
- [ ] Hiểu cấu trúc Clean Architecture
- [ ] Thành thạo navigation trong Cursor

### Tuần 2:
- [ ] Hoàn thành Bài tập 3-4
- [ ] Tạo được API endpoint
- [ ] Hiểu Repository pattern

### Tuần 3:
- [ ] Hoàn thành Bài tập 5-6
- [ ] Tạo Entity và Service
- [ ] Hiểu Dependency Injection

### Tuần 4:
- [ ] Hoàn thành Bài tập 7-8
- [ ] Viết Unit Test
- [ ] Debug độc lập

## 💡 Tips khi làm bài tập

1. **Sử dụng tab completion có ý thức**
2. **Đọc error message cẩn thận**
3. **Hỏi AI khi gặp khó khăn**
4. **Commit code thường xuyên**
5. **Viết comment giải thích**

## 🆘 Khi gặp khó khăn

1. **Đọc documentation** trước
2. **Search Stack Overflow**
3. **Hỏi AI với câu hỏi cụ thể**
4. **Debug step by step**
5. **Nghỉ ngơi và thử lại**

---

**Lưu ý**: Làm từng bài tập một cách cẩn thận, đừng vội vàng. Mục tiêu là hiểu sâu, không phải hoàn thành nhanh! 