# Phím tắt và Tips nhanh cho Cursor khi học code

## ⌨️ Phím tắt cơ bản

### Navigation
| Phím tắt | Chức năng | Mục đích học tập |
|----------|-----------|------------------|
| `Ctrl + Click` | Jump to definition | Hiểu code structure |
| `Ctrl + Shift + O` | Go to symbol | Tìm method/class nhanh |
| `Ctrl + T` | Go to file | Di chuyển giữa files |
| `Ctrl + Shift + F` | Search across project | Tìm pattern trong code |
| `Ctrl + G` | Go to line | Di chuyển đến dòng cụ thể |
| `Ctrl + Shift + M` | Show problems | Xem lỗi và warning |

### Editing
| Phím tắt | Chức năng | Mục đích học tập |
|----------|-----------|------------------|
| `Tab` | Accept suggestion | Sử dụng IntelliSense |
| `Ctrl + Space` | Trigger suggestion | Kích hoạt gợi ý |
| `Ctrl + /` | Toggle comment | Comment code để học |
| `Alt + Shift + F` | Format document | Học code style |
| `Ctrl + D` | Select next occurrence | Refactor nhanh |
| `Ctrl + Shift + K` | Delete line | Xóa code thử nghiệm |

### AI Features
| Phím tắt | Chức năng | Mục đích học tập |
|----------|-----------|------------------|
| `Ctrl + K` | Open AI chat | Hỏi AI khi gặp khó khăn |
| `Ctrl + L` | Chat with selection | Hỏi về code đã chọn |
| `Ctrl + I` | Inline edit | Sửa code với AI |

## 🎯 Tips sử dụng Tab Completion hiệu quả

### 1. Gõ có ý thức
```csharp
// ❌ Không nên: Gõ nhanh và accept tất cả
public class ProductService
{
    private readonly IRepository<Product> _repository;
    
    public ProductService(IRepository<Product> repository)
    {
        _repository = repository;
    }
    
    // ✅ Nên: Gõ từng ký tự và đọc gợi ý
    public async Task<Product> GetByIdAsync(int id)
    {
        // Gõ "_repository." và đọc các method có sẵn
        return await _repository.GetByIdAsync(id);
    }
}
```

### 2. Học từ IntelliSense
- **Đọc tooltip** trước khi accept
- **Chú ý parameter** và return type
- **Thử các overload** khác nhau
- **Học naming convention**

### 3. Thực hành không dùng tab
- **Tắt tab completion** 30 phút mỗi ngày
- **Tự gõ code** từ đầu
- **Luyện typing** và syntax

## 🔍 Cách tìm kiếm hiệu quả

### 1. Tìm trong project
```bash
# Tìm tất cả Controller
Ctrl + Shift + F → "Controller"

# Tìm interface
Ctrl + Shift + F → "interface I"

# Tìm Entity class
Ctrl + Shift + F → "public class" + "Entity"
```

### 2. Tìm trong file
```bash
# Tìm method
Ctrl + F → "public async"

# Tìm property
Ctrl + F → "public string"

# Tìm attribute
Ctrl + F → "["
```

## 📝 Cách sử dụng AI hiệu quả

### 1. Câu hỏi tốt
```bash
# ❌ Không tốt
"Làm sao để tạo API?"

# ✅ Tốt
"Giải thích cho tôi cách tạo API endpoint trong Clean Architecture, 
tại sao cần tách biệt Controller và Service layer?"
```

### 2. Hỏi về code cụ thể
```bash
# Chọn code và hỏi AI
Ctrl + L → "Giải thích đoạn code này làm gì và tại sao cần nó?"
```

### 3. Hỏi về lỗi
```bash
# Copy error message và hỏi
"Tại sao lỗi này xảy ra: [paste error] và cách fix?"
```

## 🎓 Chiến lược học tập với phím tắt

### Tuần 1: Làm quen
- [ ] Thành thạo `Ctrl + Click`
- [ ] Sử dụng `Ctrl + Shift + F` để tìm code
- [ ] Thực hành `Tab` completion có ý thức

### Tuần 2: Nâng cao
- [ ] Sử dụng `Ctrl + K` để hỏi AI
- [ ] Thực hành `Ctrl + L` với code selection
- [ ] Tìm hiểu `Ctrl + Shift + O`

### Tuần 3: Chuyên sâu
- [ ] Sử dụng `Ctrl + D` để refactor
- [ ] Thực hành `Alt + Shift + F` để format
- [ ] Tắt tab completion thường xuyên

## 🚀 Workflow học tập tối ưu

### 1. Khám phá code
```bash
1. Ctrl + Shift + F → Tìm pattern
2. Ctrl + Click → Jump to definition
3. Ctrl + T → Di chuyển giữa files
4. Ctrl + K → Hỏi AI về code
```

### 2. Viết code mới
```bash
1. Gõ 2-3 ký tự đầu
2. Đọc tooltip suggestion
3. Tab để accept (nếu hiểu)
4. Ctrl + / để comment giải thích
```

### 3. Debug và fix
```bash
1. Ctrl + Shift + M → Xem lỗi
2. Ctrl + Click → Jump to error
3. Đọc error message cẩn thận
4. Ctrl + K → Hỏi AI về lỗi
```

## 💡 Tips nhanh

### Khi gặp lỗi:
1. **Ctrl + Shift + M** → Xem tất cả lỗi
2. **Ctrl + Click** → Jump to lỗi
3. **Đọc error message** cẩn thận
4. **Ctrl + K** → Hỏi AI

### Khi không hiểu code:
1. **Ctrl + Click** → Jump to definition
2. **Ctrl + Shift + F** → Tìm usage
3. **Ctrl + L** → Hỏi AI về code đã chọn

### Khi muốn học pattern:
1. **Ctrl + Shift + F** → Tìm pattern trong project
2. **Ctrl + Click** → Xem implementation
3. **Ctrl + K** → Hỏi AI về pattern

## 🎯 Mục tiêu hàng ngày

### 5 phút mỗi ngày:
- [ ] Thực hành 1 phím tắt mới
- [ ] Tìm hiểu 1 pattern trong code
- [ ] Hỏi AI 1 câu hỏi về code

### 15 phút mỗi ngày:
- [ ] Tắt tab completion và tự gõ
- [ ] Debug 1 lỗi độc lập
- [ ] Đọc và hiểu 1 file code mới

### 30 phút mỗi ngày:
- [ ] Thực hành bài tập từ PRACTICE_EXERCISES.md
- [ ] Refactor code với AI
- [ ] Viết comment giải thích code

---

**Nhớ**: Phím tắt chỉ là công cụ. Mục tiêu chính là hiểu sâu và học hiệu quả! 