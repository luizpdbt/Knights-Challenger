using KnightsChallengeApi.Domain;
using KnightsChallengeApi.Dtos;
using KnightsChallengeApi.Repository.IRepository;
using KnightsChallengeApi.Service.IService;
using KnightsChallengeApi.ViewModel;

namespace KnightsChallengeApi.Service
{
	public class ServiceKnight : IServiceKnight
	{
		private readonly IMongoRepository _repoMongo;

		public ServiceKnight(IMongoRepository repoMongo)
		{
			_repoMongo = repoMongo;
		}

		public async Task<bool> DeleteKnightAsync(Guid id)
		{
			return await _repoMongo.DeleteKnightAsync(id);
		}


		private async Task<List<DtoKnight>> ReturnListSpecifiedWarrior(bool hallsOfHero)
		{
		   return await _repoMongo.GetAllKnightHallOfHeroesAsync(hallsOfHero);	
		}

		public async Task<List<ViewModelGetKnight>> GetAllKnightsAsync(bool hallsOfHero)
		{
			//var getKnight = new List<DtoKnight>();
			var domainKnight = new KnightDomain();
			var listViewModelGetKnight = new List<ViewModelGetKnight>();

			var getKnight = await ReturnListSpecifiedWarrior(hallsOfHero);

			foreach(var item in getKnight)
			{
				var atribute = item.keyAtribute;
				var keyAtributeValue = item.attributes.GetType().GetProperty(atribute);
				var valor = Convert.ToInt32(keyAtributeValue.GetValue(item.attributes));
				var countWeapons = item.weapons.Count;
				var getEquipedWeapon = item.weapons.Where(x => x.equipped == true).First();


				var viewModel = new ViewModelGetKnight
				{
					id = item.id,
					name = item.name,
					age = domainKnight.GetAge(item.birthday),
					atack = domainKnight.AtackCalcs(valor, getEquipedWeapon.mod),
					countWeapons = countWeapons,
					atribute = atribute,
					experience =  domainKnight.ExperiencCalc(item.birthday)
				};

				listViewModelGetKnight.Add(viewModel);
			}
			return listViewModelGetKnight;
		}

		public async Task<DtoKnight> GetKnightByIdAsync(Guid id)
		{
			return await _repoMongo.GetKnightByIdAsync(id);
		}

		public async Task InsertKnight(DtoKnight knight)
		{
			knight.id = Guid.NewGuid();
			await _repoMongo.CreateKnightAsync(knight);
		}

		public async Task<bool> UpdateKnightAsync(string id, string newName)
		{
			return await _repoMongo.UpdateKnightAsync(id, newName);
		}
	}
}
