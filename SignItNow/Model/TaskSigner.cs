using SignItNow.Model.Enums;

namespace SignItNow.Model
{
	public class TaskSigner
	{
		public int Id { get; set; }
		public TaskInfo Task { get; set; }
		public User Signer { get; set; }
		public SigningStatus SigningStatus { get; set; } = SigningStatus.Очікується;
		public string TaskComment { get; set; }

		public TaskSigner Clone()
		{
			return (TaskSigner) MemberwiseClone();
		}
	}
}