using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerDotnetApi.Managers;
using DockerDotnetApi.Models.BinList;
using DockerDotnetApi.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DockerDotnetApi.Controllers
{
	[ApiController]
	[Route("payment_cards_cost")]
	public class PaymentCardsCostController : ControllerBase
	{
		private readonly ILogger<PaymentCardsCostController> _logger;
		private readonly IManageBinList _binListManager;

		public PaymentCardsCostController(ILogger<PaymentCardsCostController> logger, IManageBinList binListManager)
		{
			_logger = logger;
			_binListManager = binListManager;
		}

		[HttpPost]
		public IssuerInformation Post([FromBody]CardRequest request)
		{
			return _binListManager.PaymentCardCost(request.CardNumber);
		}
	}
}
