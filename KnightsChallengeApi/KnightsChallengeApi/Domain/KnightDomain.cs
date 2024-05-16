namespace KnightsChallengeApi.Domain
{
	public class KnightDomain
	{
		public int AtackCalcs(int keyAtributte,int modEquipeWeapon)
		{

			if(modEquipeWeapon<0)
			{
				throw new Exception("valor de mod inaceitavel");
			}

			int mod = CalcsRangeMod(keyAtributte);

			var atack = 10 + mod * (keyAtributte) + modEquipeWeapon;

			return atack;
		}

		public double ExperiencCalc(string age)
		{
			var verifyAge = Convert.ToInt32(GetAge(age));

			if(verifyAge<7)
			{
				return 0;
			}
			else if(verifyAge>7)
			{
				return Math.Floor((verifyAge - 7) * Math.Pow(22, 1.45));
			}
			throw new Exception("O calculo da idade nao atingiu nenhum valor seja ele 0 ou resultado da formula");
		}

		public string GetAge(string age)
		{
			var convertsToDateTime = Convert.ToDateTime(age);
			var ageResult = DateTime.Now.Year - convertsToDateTime.Year;

			return ageResult.ToString();
		}

		public int CalcsRangeMod(int keyAtributte)
		{
			if(keyAtributte>=0 && keyAtributte<=8)
			{
				return -2;
			}
			else if(keyAtributte >= 9 && keyAtributte <= 10)
			{
				return -1;
			}
			else if (keyAtributte >= 11 && keyAtributte <= 12)
			{
				return 0;
			}
			else if (keyAtributte >= 13 && keyAtributte <= 15)
			{
				return 1;
			}
			else if (keyAtributte >= 16 && keyAtributte <= 18)
			{
				return 2;
			}
			else if (keyAtributte >= 19 && keyAtributte <= 20)
			{
				return 3;
			}

			throw new Exception("Nenhum valor correspondente dentro do range");
		}
	}
}
