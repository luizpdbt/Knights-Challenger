using KnightsChallengeApi.Context;
using KnightsChallengeApi.Dtos;
using KnightsChallengeApi.Repository.IRepository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace KnightsChallengeApi.Repository
{
	public class MongoRepository: IMongoRepository
	{
		private readonly IMongoCollection<DtoKnight> _knightCollection;

		public MongoRepository(IOptions<MongoDbSettings> knightStoreDatabaseSettings)
		{
			var mongoClient = new MongoClient(
			knightStoreDatabaseSettings.Value.ConnectionString);

			var mongoDatabase = mongoClient.GetDatabase(
			knightStoreDatabaseSettings.Value.DatabaseName);


			_knightCollection = mongoDatabase.GetCollection<DtoKnight>(
			knightStoreDatabaseSettings.Value.HeroesCollectionName);
		}

		


		public async Task<List<DtoKnight>> GetAllKnightHallOfHeroesAsync(bool hallofheroes)
		{
			return await _knightCollection.Find(x => x.hallofheroes == hallofheroes).ToListAsync();
		}

		public async Task<DtoKnight> GetKnightByIdAsync(Guid id)
		{
			return await _knightCollection.Find(knight => knight.id == id).FirstOrDefaultAsync();
		}

		public async Task CreateKnightAsync(DtoKnight knight)
		{
		    await _knightCollection.InsertOneAsync(knight);
		}

		public async Task<bool> UpdateKnightAsync(string id,string newName)
		{
			var guid = Guid.Parse(id);

			var getKnightToChange = await GetKnightByIdAsync(guid);

			getKnightToChange.name = newName;

			var result = await _knightCollection.ReplaceOneAsync(k => k.id == guid, getKnightToChange);
			return result.IsAcknowledged && result.ModifiedCount > 0;
		}

		public async Task<bool> DeleteKnightAsync(Guid id)
		{
			var getKnightToChange = await GetKnightByIdAsync(id);
			getKnightToChange.hallofheroes = true;

			var result = await _knightCollection.ReplaceOneAsync(k => k.id == id, getKnightToChange);
			return result.IsAcknowledged && result.ModifiedCount > 0;
		}
	}
}
