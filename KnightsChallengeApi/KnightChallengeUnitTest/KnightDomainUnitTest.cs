using KnightsChallengeApi.Domain;

namespace KnightChallengeUnitTest
{
	public class KnightDomainUnitTest
	{
		private KnightDomain knight;

		[SetUp]
		public void Setup()
		{
			knight = new KnightDomain();
		}

		[TestCase(15,-1,40)]
		[TestCase(20,20,90)]
		public void AtackCalcs_Returns_CorrectValue(int keyAttribute,int modEquipeWeapon, int expected)
		{

			if (modEquipeWeapon < 0)
			{
				// Assert
				Assert.Throws<Exception>(() => knight.AtackCalcs(keyAttribute,modEquipeWeapon));
			}
			else
			{
				// Arrange & Act
				int result = knight.AtackCalcs(keyAttribute, modEquipeWeapon);

				// Assert
				Assert.AreEqual(expected, result);
			}

		}

		[TestCase("1994-01-01",2033)]
		[TestCase("2019-01-01", 0)]
		public void ExperiencCalc_Returns_CorrectValue(string age,double experience)
		{
			// Act
			double result = knight.ExperiencCalc(age);
			// Assert
			Assert.AreEqual(experience, result);
		}

		[TestCase("1994-01-01","30")]
		public void GetAge_Returns_CorrectValue(string data,string age)
		{
			// Act
			string result = knight.GetAge(data);

			// Assert
			Assert.AreEqual(age, result);
		}

		[TestCase(8, -2)]
		[TestCase(10, -1)]
		[TestCase(12, 0)]
		[TestCase(15, 1)]
		[TestCase(18, 2)]
		[TestCase(20, 3)]
		public void CalcsRangeMod_Returns_CorrectValue(int keyAttribute, int expectedMod)
		{
			// Act
			int result = knight.CalcsRangeMod(keyAttribute);

			// Assert
			Assert.AreEqual(expectedMod, result);
		}

		[Test]
		public void CalcsRangeMod_Throws_Exception_When_KeyAttribute_OutOfRange()
		{
			// Arrange
			int keyAttribute = 21; // Valor fora do intervalo

			// Act & Assert
			Assert.Throws<Exception>(() => knight.CalcsRangeMod(keyAttribute));
		}
	}
}