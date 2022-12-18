using CEGES_Core;
using CEGES_Core.Exceptions;
using CEGES_Core.IRepository;
using CEGES_Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CEGES_Services_Tests
{
    public class ConfigurationServices_Tests
    {
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IEntrepriseRepository> entreprisesRepo;
        private Mock<IApplicationUserRepository> usersRepo;

        private Entreprise entrepriseTest;
        private List<ApplicationUser> analystesTest;

        private string analyste1Id = new string("28adc0c6-7e77-48b1-9d58-de29b3d1f05d");
        private string analyste2Id = new string("0d386755-54ba-4fa4-ae4a-a9dd0d12f1ac");
        private string analyste3Id = new string("e40feef3-252e-4d50-94d3-ecc185298136");
        private string analyste4Id = new string("18dfef50-f15c-4d4e-8af0-484d84493a76");

        private ApplicationUser analyste1;
        private ApplicationUser analyste2;
        private ApplicationUser analyste3;
        private ApplicationUser analyste4;



        [SetUp]
        public void Setup()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            entreprisesRepo = new Mock<IEntrepriseRepository>();
            usersRepo = new Mock<IApplicationUserRepository>();

            analyste1 = new ApplicationUser()
            {
                Id = analyste1Id,
                UserName = "Analyste 1",
                Entreprises = new List<Entreprise>()
                {
                    new Entreprise() {Id = 1}
                }

            };

            analyste2 = new ApplicationUser()
            {
                Id = analyste2Id,
                UserName = "Analyste 2",
                Entreprises = new List<Entreprise>()
                {
                    new Entreprise() {Id = 1},
                    new Entreprise() {Id = 2},
                    new Entreprise() {Id = 3}
                }
            };

            analyste3 = new ApplicationUser()
            {
                Id = analyste3Id,
                UserName = "Analyste 3",
                Entreprises = new List<Entreprise>()
                {
                    new Entreprise() {Id = 2},
                    new Entreprise() {Id = 3},
                    new Entreprise() {Id = 4}
                }
            };

            analyste4 = new ApplicationUser()
            {
                Id = analyste4Id,
                UserName = "Analyste 4"
            };

            entrepriseTest = new Entreprise()
            {
                Id = 1,
                Analystes = new List<ApplicationUser>()
                {
                    analyste1,
                    analyste2
                }
            };

            unitOfWork.Setup(u => u.Entreprises).Returns(entreprisesRepo.Object);
            unitOfWork.Setup(u => u.Users).Returns(usersRepo.Object);

        }

        [Test]
        public void EditAnalystesEntreprise_AnalystWithTooManyEntreprises_ThrowException()
        {
            // Arrange
            analystesTest = new List<ApplicationUser>() { analyste3 };
            ConfigurationServices configurationServices = new ConfigurationServices(unitOfWork.Object);

            entreprisesRepo.Setup(e => e
                .FirstOrDefaultAsync(It.IsAny<Expression<Func<Entreprise, bool>>>(), It.IsAny<string>()))
                .Returns(Task.FromResult(entrepriseTest));
            usersRepo.Setup(u => u
                .GetAllAsync(It.IsAny<Expression<Func<ApplicationUser, bool>>>(), It.IsAny<string>()))
                .Returns(Task.FromResult(analystesTest.AsEnumerable()));

            // Act & Assert
            TooManyAnalystesEntreprisesException ex = Assert.ThrowsAsync<TooManyAnalystesEntreprisesException>(
                () => configurationServices.EditAnalystesEntrepriseAsync(entrepriseTest.Id, analystesTest.Select(u => u.Id).ToList()));

        }

        [Test]
        public void EditAnalystesEntreprise_RemoveExistingAnalyst_Success()
        {
            Assert.Pass();
        }

        [Test]
        public void EditAnalystesEntreprise_AddNewAnalyst_Success()
        {
            Assert.Pass();
        }
        [Test]
        public void EditAnalystesEntreprise_KeepExistingAnalyst_Success()
        {
            Assert.Pass();
        }
    }
}