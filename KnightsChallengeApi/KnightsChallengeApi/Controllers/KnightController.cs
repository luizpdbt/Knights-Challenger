using KnightsChallengeApi.Dtos;
using KnightsChallengeApi.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnightsChallengeApi.Controllers
{
	[Route("api/challanger/")]
	[ApiController]
	public class KnightController : ControllerBase
	{
		private readonly IServiceKnight _service;
		public KnightController(IServiceKnight service)
		{
			_service = service;
		}

		[Route("knight")]
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] DtoKnight dtoKnigh)
		{
			await _service.InsertKnight(dtoKnigh);
			return Ok("Knight Criado com sucesso");
		}


		[Route("knight")]
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] bool filterHallHeroes)
		{
			return Ok(await _service.GetAllKnightsAsync(filterHallHeroes));
		}

		[Route("knightById")]
		[HttpGet]
		public async Task<IActionResult> GetById([FromQuery]Guid id)
		{
			var valor = await _service.GetKnightByIdAsync(id);

			return Ok(await _service.GetKnightByIdAsync(id));
		}

		[Route("knight")]
		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery] Guid id)
		{
			return Ok(await _service.DeleteKnightAsync(id));
		}


		[Route("knight")]
		[HttpPut]
		public async Task<IActionResult> Put([FromQuery] string guid,string newName)
		{
			return Ok(await _service.UpdateKnightAsync(guid,newName));
		}
	}
}
