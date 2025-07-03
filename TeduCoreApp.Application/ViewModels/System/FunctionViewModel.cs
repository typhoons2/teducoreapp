using System.ComponentModel.DataAnnotations;
using TeduCoreApp.Domain.Enums;

namespace TeduCoreApp.Application.ViewModels.System
{
    public class FunctionViewModel
    {
        public string Id { get; set; }

		[Required]
		[StringLength(128)]
		public string Name { set; get; }

		//URL
		[Required]
		[StringLength(250)]
		public string URL { set; get; }

		//ID cha
		[StringLength(128)]
		public string? ParentId { set; get; }

		//Icon CSS
		[StringLength(128)]
		public string IconCss { get; set; }

		//Thứ tự
		public int SortOrder { set; get; }

		//Trạng thái
		public Status Status { set; get; }

	}
} 