using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduCoreApp.Data.Interfaces
{
	public interface IDateTracking
	{
		DateTime DateCreated { get; set; }    // Thời gian tạo
		DateTime DateModified { get; set; }   // Thời gian cập nhật
	}
}
