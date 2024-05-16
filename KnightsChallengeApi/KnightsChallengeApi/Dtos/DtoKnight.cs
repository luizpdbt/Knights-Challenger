using System.ComponentModel.DataAnnotations;

namespace KnightsChallengeApi.Dtos
{
	public class DtoKnight
	{
		public Guid id { get; set; }

		[Required(ErrorMessage = $"The field name is required")]
		public string name { get; set; }


		[Required(ErrorMessage = $"The field nickname is required")]
		public string nickname { get; set; }
		
		public string birthday  { get; set; }
		public Attributes attributes { get; set; }

		[Required(ErrorMessage = $"The field keyAtribute is required")]
		public string keyAtribute { get; set; }
		public List<Weapons> weapons { get; set; }
		public bool hallofheroes { get; set; }
	}


	public class Weapons
	{
		public string name { get; set; }
		public int mod { get; set; }
		public string attr { get; set; }
		public bool equipped { get; set; }
	}

	public class Attributes
	{

		[Range(0, 20, ErrorMessage = "Strength must be between 0 and 20")]
		public int strength { get; set; }

		[Range(0, 20, ErrorMessage = "Dexterity must be between 0 and 20")]
		public int dexterity { get; set; }

		[Range(0, 20, ErrorMessage = "Constitution must be between 0 and 20")]
		public int constitution { get; set; }

		[Range(0, 20, ErrorMessage = "Intelligence must be between 0 and 20")]
		public int intelligence { get; set; }

		[Range(0, 20, ErrorMessage = "Wisdom must be between 0 and 20")]
		public int wisdom { get; set; }

		[Range(0, 20, ErrorMessage = "Charisma must be between 0 and 20")]
		public int charisma { get; set; }
	}


}
