using KnightsChallengeApi.Dtos;

namespace KnightsChallengeApi.Repository.IRepository
{
	public interface IMongoRepository
	{
		Task<List<DtoKnight>> GetAllKnightHallOfHeroesAsync(bool hallofheroes);
		Task<DtoKnight> GetKnightByIdAsync(Guid id);
		Task CreateKnightAsync(DtoKnight knight);
		Task<bool> UpdateKnightAsync(string id, string newName);
		Task<bool> DeleteKnightAsync(Guid id);
	}
}
