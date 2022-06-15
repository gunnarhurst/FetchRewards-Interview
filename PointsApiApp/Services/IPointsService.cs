using System;
namespace PointsApiApp.Services
{
	public interface IPointsService
	{
		List<Point> GetPoints();
		Dictionary<string, int> SpendPoints(int points);
		Point AddTransaction(Point transaction);
	}
}

