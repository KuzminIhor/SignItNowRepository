using System.Collections.Generic;
using SignItNow.Model.Enums;

namespace SignItNow.Model
{
	public class TaskInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public TaskStatus TaskStatus { get; set; } = TaskStatus.Обробляється;
		public int? DocumentInfoId { get; set; }
		public DocumentInfo Document { get; set; }
		public User TaskCreator { get; set; }
		public List<TaskSigner> Signers { get; set; } = new List<TaskSigner>();

		public TaskInfo Clone()
		{
			return (TaskInfo) MemberwiseClone();
		}
	}
}