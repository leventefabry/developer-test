using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Contracts.Requests;
using Taxually.TechnicalTest.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VatRegistrationController(IVatRegistrationServiceHandler vatRegistrationServiceHandler) : ControllerBase
{
	/// <summary>
	/// Registers a company for a VAT number in a given country
	/// </summary>
	[HttpPost]
	public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
	{
		var result = await vatRegistrationServiceHandler.RegisterVatAsync(request);
		return result.IsSuccess ?  NoContent() : BadRequest(result.Error);
	}
}