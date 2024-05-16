using KnightsChallengeApi.Dtos;
using KnightsChallengeApi.ViewModel;

namespace KnightsChallengeApi.Service.IService
{
	public interface IServiceKnight
	{
		Task InsertKnight(DtoKnight knight);

		Task<List<ViewModelGetKnight>> GetAllKnightsAsync(bool hallsOfHero);

		Task<DtoKnight> GetKnightByIdAsync(Guid id);

		Task<bool> UpdateKnightAsync(string id, string newName);
		Task<bool> DeleteKnightAsync(Guid id);
	}
}
