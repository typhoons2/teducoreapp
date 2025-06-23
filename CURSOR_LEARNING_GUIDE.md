# Hướng dẫn sử dụng Cursor hiệu quả cho việc học code

## 🎯 Mục tiêu
Hướng dẫn cách sử dụng Cursor một cách thông minh để học code hiệu quả, đặc biệt là với dự án .NET Core Clean Architecture.

## 📚 Cấu trúc dự án của bạn
Dự án này theo mô hình Clean Architecture với các layer:
- **Presentation Layer**: `TeduCoreApp` (Web API/MVC)
- **Application Layer**: `TeduCoreApp.Application` (Business Logic)
- **Domain Layer**: `TeduCoreApp.Data` (Entities, Interfaces)
- **Infrastructure Layer**: `TeduCoreApp.Infrastructure`, `TeduCoreApp.Data.EF`, `TeduCoreApp.Utilities`

## 🚀 Cách sử dụng Cursor hiệu quả khi học

### 1. **Tab Completion - Sử dụng thông minh**

#### ✅ Nên làm:
- **Gõ 2-3 ký tự đầu** rồi dùng Tab để hoàn thiện
- **Đọc và hiểu** code được gợi ý trước khi accept
- **Chú ý documentation** trong tooltip
- **Học pattern** từ các gợi ý

#### ❌ Không nên:
- Accept tất cả gợi ý mà không đọc
- Phụ thuộc hoàn toàn vào tab completion
- Copy-paste code mà không hiểu

### 2. **AI Chat - Học từ AI**

#### Cách sử dụng hiệu quả:
```bash
# Thay vì hỏi: "Làm sao để tạo API endpoint?"
# Hãy hỏi: "Giải thích cho tôi cách tạo API endpoint trong Clean Architecture, 
# tại sao cần tách biệt Controller và Service?"
```

#### Ví dụ câu hỏi tốt:
- "Giải thích dependency injection trong .NET Core"
- "Tại sao cần Repository pattern?"
- "Cách implement Unit of Work pattern?"
- "So sánh Entity Framework vs Dapper"

### 3. **Code Navigation - Hiểu cấu trúc**

#### Sử dụng:
- **Ctrl + Click**: Jump to definition
- **Ctrl + Shift + O**: Go to symbol
- **Ctrl + T**: Go to file
- **Ctrl + Shift + F**: Search across project

#### Bài tập thực hành:
1. Tìm tất cả Controller trong project
2. Tìm interface IRepository
3. Tìm các Entity class
4. Tìm các Service implementation

### 4. **IntelliSense - Học API**

#### Khi gõ code:
- **Chờ tooltip** hiển thị documentation
- **Đọc parameter** và return type
- **Thử các overload** khác nhau
- **Học naming convention**

### 5. **Error Detection - Học từ lỗi**

#### Khi có lỗi:
- **Đọc error message** cẩn thận
- **Click vào error** để xem chi tiết
- **Thử fix lỗi** trước khi dùng AI
- **Học từ warning** và suggestion

## 🎓 Chiến lược học tập với Cursor

### Tuần 1-2: Làm quen với cấu trúc
1. **Khám phá project structure**
   - Mở từng folder và đọc README
   - Hiểu vai trò của từng project
   - Tìm hiểu dependency giữa các layer

2. **Sử dụng tab completion có ý thức**
   - Gõ chậm, đọc gợi ý
   - Tự gõ trước, dùng tab sau
   - Học từ IntelliSense

### Tuần 3-4: Hiểu sâu hơn
1. **Tạo file mới** thay vì copy-paste
2. **Viết comment** giải thích code
3. **Sử dụng AI để hỏi "tại sao"** thay vì "làm sao"

### Tuần 5-6: Thực hành nâng cao
1. **Tắt tab completion** 30 phút mỗi ngày
2. **Tự debug** trước khi hỏi AI
3. **Refactor code** với sự trợ giúp của AI

## 🔧 Cài đặt Cursor tối ưu cho học tập

### Extensions nên cài:
- **C# Dev Kit**: IntelliSense tốt hơn
- **GitLens**: Hiểu lịch sử code
- **Error Lens**: Hiển thị lỗi inline
- **Bracket Pair Colorizer**: Dễ đọc code

### Settings tối ưu:
```json
{
  "editor.suggestSelection": "first",
  "editor.acceptSuggestionOnEnter": "on",
  "editor.quickSuggestions": {
    "other": true,
    "comments": false,
    "strings": false
  },
  "editor.tabCompletion": "on"
}
```

## 📝 Bài tập thực hành

### Bài tập 1: Hiểu Dependency Injection
1. Tìm tất cả `services.AddScoped` trong `Program.cs`
2. Tìm interface và implementation tương ứng
3. Vẽ sơ đồ dependency

### Bài tập 2: Repository Pattern
1. Tìm interface `IRepository<T>`
2. Tìm implementation trong Data.EF
3. Hiểu cách sử dụng trong Service

### Bài tập 3: API Controller
1. Tạo một API endpoint mới
2. Sử dụng tab completion để gõ
3. Giải thích từng dòng code

## 🎯 Mục tiêu học tập

### Tháng 1:
- [ ] Hiểu cấu trúc Clean Architecture
- [ ] Sử dụng tab completion hiệu quả
- [ ] Tạo được API endpoint đơn giản

### Tháng 2:
- [ ] Hiểu Dependency Injection
- [ ] Implement Repository pattern
- [ ] Viết Unit Test

### Tháng 3:
- [ ] Refactor code với AI
- [ ] Debug độc lập
- [ ] Đọc và hiểu code phức tạp

## 💡 Lời khuyên quan trọng

1. **Kiên nhẫn**: Học code cần thời gian, đừng vội vàng
2. **Thực hành**: Code nhiều hơn đọc
3. **Hiểu sâu**: Đừng chỉ copy-paste
4. **Hỏi đúng**: Hỏi "tại sao" thay vì "làm sao"
5. **Tự tin**: Tin vào khả năng của mình

## 🆘 Khi gặp khó khăn

1. **Đọc error message** cẩn thận
2. **Search Google** trước khi hỏi AI
3. **Thử debug** step by step
4. **Hỏi cộng đồng** (Stack Overflow, Reddit)
5. **Nghỉ ngơi** nếu quá stress

---

**Nhớ**: Cursor là công cụ hỗ trợ, không phải thay thế việc học. Sử dụng nó một cách thông minh để trở thành developer giỏi! 