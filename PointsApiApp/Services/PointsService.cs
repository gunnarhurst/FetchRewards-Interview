
namespace PointsApiApp.Services
{
	public class PointsService : IPointsService
	{
		private List<Point> transactions = new List<Point>();
		private readonly List<string> payers = new List<string>();
		private Dictionary<string, int> totals;

        public Dictionary<string, int> GetPoints()
		{
			return totals;
		}

		public Point AddTransaction(Point transaction)
		{
			if (!payers.Contains(transaction.Payer))
            {
				payers.Add(transaction.Payer);
            }
			transactions.Add(transaction);
			//sort the transactions by timestamp
			transactions = transactions.OrderBy(t => t.Timestamp).ToList();
			return transaction;
		}

		public Dictionary<string, int> SpendPoints(int points)
		{
			//Check to see if param was negative.
			if (points < 0)
            {
				points = Math.Abs(points);
            }
			totals = new Dictionary<string, int>();
			//keep track of points spent
			var spentPoints = new Dictionary<string, int>();
			payers.ForEach(p =>
			{
				totals[p] = 0;
				spentPoints[p] = 0;
			});
			foreach (var transaction in transactions) 
			{
				totals[transaction.Payer] += transaction.Points;
				if (transaction.Points >= points)
				{
					spentPoints[transaction.Payer] -= points;
					totals[transaction.Payer] -= points;
					points = 0;
				}
				else
                {
					spentPoints[transaction.Payer] -= transaction.Points;
					points -= transaction.Points;
					totals[transaction.Payer] -= transaction.Points;
				}
			}
			return spentPoints;
		}


	}

}

