using System;
using System.Text.Json;

namespace PointsApiApp.Services
{
	public class PointsService : IPointsService
	{
		List<Point> transactions = new List<Point>();
		List<string> payers = new List<string>();

        public PointsService()
        {
			transactions.Add(new Point
			{
				Payer = "Dannon",
				Points = 1000,
				Timestamp = DateTime.UtcNow
			});
			transactions.Add(new Point
			{
				Payer = "Unilever",
				Points = 200,
				Timestamp = DateTime.UtcNow.AddMinutes(-3)
			});
			transactions.Add(new Point
			{
				Payer = "Dannon",
				Points = -200,
				Timestamp = DateTime.UtcNow.AddMinutes(-2)
			});
			transactions.Add(new Point
			{
				Payer = "Miller Coors",
				Points = 10000,
				Timestamp = DateTime.UtcNow.AddMinutes(-1)
			});
			transactions.Add(new Point
			{
				Payer = "Dannon",
				Points = 300,
				Timestamp = DateTime.UtcNow.AddMinutes(-4)
			});
			transactions = transactions.OrderBy(t => t.Timestamp).ToList();
			payers.Add("Dannon");
			payers.Add("Unilever");
			payers.Add("Miller Coors");
		}

        public List<Point> GetPoints()
		{
			return transactions.ToList<Point>();
		}

		public Point AddTransaction(Point transaction)
		{
			if (!payers.Contains(transaction.Payer))
            {
				payers.Add(transaction.Payer);
            }
			transactions.Add(transaction);
			transactions = transactions.OrderBy(t => t.Timestamp).ToList();
			return transaction;
		}

		public Dictionary<string, int> SpendPoints(int points)
		{
			var total = 0;
			Dictionary<string, int> totals = new Dictionary<string, int>();
			payers.ForEach(p =>
			{
				totals[p] = 0;
			});
			//transactions.ForEach(t =>
   //         {
			//	t.Points
			//	if (total < )
   //         });
			foreach (var transaction in transactions)
            {
				totals[transaction.Payer] += transaction.Points;
				if (total < points)
                {

                }
				

			}
			return totals;
		}


	}

}

