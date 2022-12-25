using CEGES_Core;
using CEGES_Core.ViewModels;
using CEGES_MVC.Areas.Configuration.Controllers;
using CEGES_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CEGES_MVC
{
	public class EntrepriseController_Tests
	{

	

		[SetUp]
		public void Setup()
		{
		}


		//Les tests on �t� effectu�s sur la m�thode  Upsert_OnTooManyAnalysts_DisplayErrorAsync qui �tait d�ja pr�sente dans le projet Test..
		//Les instructions nous semblait pas trop clair, la partie "Historique" parle d'historique.. d'access et de controlleurs/vue, asns compt�
		//Que le projet Test contenait d�ja la m�thode [Upsert_OnTooManyAnalysts_DisplayErrorAsync] � croire qu'elle est a compl�t�e.
		[Test]
		public void Upsert_OnTooManyAnalysts_RedirectUpsertAsync()
		{
			//Arrange
			var _configService = new Mock<IConfigurationServices>();
			var _analyseService = new Mock<IAnalyseServices>();


			var controller = new EntrepriseController(_configService.Object, _analyseService.Object);

			var entrepriseVM = new UpsertEntrepriseVM()
			{
				Entreprise = new Entreprise
				{
					Id = 1,
					Nom = "Test Entreprise"
				},
				SelectAnalystes = new System.Collections.Generic.List<string>() { "Analyste1", "Analyste2", "Analyste3", "Analyste4", }

			};

			// Act    
			var actionResult = (RedirectToActionResult)controller.Upsert(entrepriseVM).GetAwaiter().GetResult();

			//Assert
			Assert.AreEqual("Upsert", actionResult.ActionName);


		}

		[Test]
		public void Upsert_OnNotTooManyAnalysts_RedirectDetailsAsync()
		{
			//Arrange
			var _configService = new Mock<IConfigurationServices>();
			var _analyseService = new Mock<IAnalyseServices>();


			var controller = new EntrepriseController(_configService.Object, _analyseService.Object);

			var entrepriseVM = new UpsertEntrepriseVM()
			{
				Entreprise = new Entreprise
				{
					Id = 1,
					Nom = "Test Entreprise"
				},
				SelectAnalystes = new System.Collections.Generic.List<string>() { "Analyste1", "Analyste2", "Analyste3", }

			};

			// Act    
			var actionResult = (RedirectToActionResult)controller.Upsert(entrepriseVM).GetAwaiter().GetResult();

			//Assert
			Assert.AreEqual("Details", actionResult.ActionName);
	
		}
	}
}