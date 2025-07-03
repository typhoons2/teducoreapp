using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduCoreApp.Data.Enums;
using TeduCoreApp.Data.Interfaces;
using TeduCoreApp.Infrastructure.SharedKernel;

namespace TeduCoreApp.Data.Entities
{
	// Định nghĩa lớp Blog kế thừa từ DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
	[Table("Blogs")]
	public class Blog : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
	{
		public Blog() { }

		// Khởi tạo Blog với các thông tin cần thiết
		public Blog(string name, string thumbnailImage,
		   string description, string content, bool? homeFlag, bool? hotFlag,
		   string tags, Status status, string seoPageTitle,
		   string seoAlias, string seoMetaKeyword,
		   string seoMetaDescription)
		{
			Name = name;
			Image = thumbnailImage;
			Description = description;
			Content = content;
			HomeFlag = homeFlag;
			HotFlag = hotFlag;
			Tags = tags;
			Status = status;
			SeoPageTitle = seoPageTitle;
			SeoAlias = seoAlias;
			SeoKeywords = seoMetaKeyword;
			SeoDescription = seoMetaDescription;
		}

		// Khởi tạo Blog với ID
		public Blog(int id, string name, string thumbnailImage,
			 string description, string content, bool? homeFlag, bool? hotFlag,
			 string tags, Status status, string seoPageTitle,
			 string seoAlias, string seoMetaKeyword,
			 string seoMetaDescription)
		{
			Id = id;
			Name = name;
			Image = thumbnailImage;
			Description = description;
			Content = content;
			HomeFlag = homeFlag;
			HotFlag = hotFlag;
			Tags = tags;
			Status = status;
			SeoPageTitle = seoPageTitle;
			SeoAlias = seoAlias;
			SeoKeywords = seoMetaKeyword;
			SeoDescription = seoMetaDescription;
		}

		[Required]
		[MaxLength(256)]
		public string Name { set; get; } //Tên bài viết


		[MaxLength(256)]
		public string Image { set; get; } //Đường dẫn hình ảnh

		[MaxLength(500)]
		public string Description { set; get; } //Mô tả

		public string Content { set; get; } //Nội dung

		public bool? HomeFlag { set; get; } //Hiển thị trang chủ
		public bool? HotFlag { set; get; } //Hiển thị trang hot
		public int? ViewCount { set; get; } //Số lượt xem

		public string Tags { get; set; } //Tags	

		public virtual ICollection<BlogTag> BlogTags { set; get; } //Tập hợp các tag liên quan
		public DateTime DateCreated { set; get; } //Ngày tạo
		public DateTime DateModified { set; get; } //Ngày cập nhật
		public Status Status { set; get; } //Trạng thái

		[MaxLength(256)]
		public string SeoPageTitle { set; get; } //Tiêu đề trang

		[MaxLength(256)]
		public string SeoAlias { set; get; }

		[MaxLength(256)]
		public string SeoKeywords { set; get; } //Từ khóa SEO	

		[MaxLength(256)]
		public string SeoDescription { set; get; } //Mô tả SEO
	}
}
