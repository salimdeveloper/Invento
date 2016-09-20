using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Strado.InVento.Core.Interfaces;
using Strado.InVento.Controllers;
using Strado.InVento.Tests.Extenstions;

namespace Strado.InVento.Tests.Controllers
{
    [TestClass]
    public class BrandsControllerTests
    {
        private BrandsController _brandsController;
        private Mock<IBrandsRepository> _mockBrandsReposiory;
        private string _userId = "1";
        private string _userName = "user1@domain.com";
        [TestInitialize]
        public void TestInitialize()
        {

            _mockBrandsReposiory = new Mock<IBrandsRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Brands).Returns(_mockBrandsReposiory.Object);

            _brandsController = new BrandsController(mockUoW.Object);
            _brandsController.MockCurrentUser(_userId, _userName);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
