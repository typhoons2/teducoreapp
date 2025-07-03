namespace TeduCoreApp.Domain.Interfaces
{
	public interface IHasSoftDelete
	{
		bool IsDeleted { get; set; }
	}
}
