using System.Data;

namespace SignItNow.Services.Interfaces
{
	public interface IRenderDataTableRows
	{
		public void GetRows(DataTable dt);
	}
}