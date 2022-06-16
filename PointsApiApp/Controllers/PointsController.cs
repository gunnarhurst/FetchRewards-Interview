using Microsoft.AspNetCore.Mvc;
using PointsApiApp.Services;

namespace PointsApiApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PointsController : ControllerBase
	{
        private readonly IPointsService _pointsService;

        public PointsController(IPointsService pointsService)
		{
            _pointsService = pointsService;
        }
		[HttpGet]
		[Route("balance")]
		public Dictionary<string, int> GetPoints()
		{
			return _pointsService.GetPoints();
		}
        [HttpPost]
		[Route("spend")]
		public Dictionary<string, int> SpendPoints([FromBody] SpendPointsRequest pointsRequest)
        {
            return _pointsService.SpendPoints(pointsRequest.Points);
        }
        [HttpPost]
		[Route("add")]
		public Point AddTransaction([FromBody] Point transaction)
        {
			return _pointsService.AddTransaction(transaction);
		}
	}
}

