
namespace PointsApiApp.Services
{
	public interface IPointsService
	{
		Dictionary<string, int> GetPoints();
		Dictionary<string, int> SpendPoints(int points);
		Point AddTransaction(Point transaction);
	}
}

