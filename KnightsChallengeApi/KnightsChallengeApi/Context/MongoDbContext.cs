using KnightsChallengeApi.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace KnightsChallengeApi.Context
{
	public class MongoDbContext
	{
		private readonly IMongoDatabase _database;

		public MongoDbContext(IOptions<MongoDbSettings> settings)
		{
			var client = new MongoClient(settings.Value.ConnectionString);
			_database = client.GetDatabase(settings.Value.DatabaseName);
		}

		public IMongoCollection<DtoKnight> Knights => _database.GetCollection<DtoKnight>("Knights");
	}
}
