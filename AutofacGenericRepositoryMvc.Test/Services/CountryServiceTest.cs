using System;
using System.Collections.Generic;
using AutofacGenericRepositoryMvc.Model.Concrete;
using AutofacGenericRepositoryMvc.Repository.Interfaces;
using AutofacGenericRepositoryMvc.Service.Concrete;
using AutofacGenericRepositoryMvc.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AutofacGenericRepositoryMvc.Test.Services
{
    [TestClass]
    public class CountryServiceTest
    {
        private Mock<ICountryRepository> _mockRepository;
        private ICountryService _service;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private List<Country> listCountry;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<ICountryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _service = new CountryService(_mockUnitOfWork.Object, _mockRepository.Object);
            listCountry = new List<Country>()
            {
                new Country() {Id = 1, Name = "US"},
                new Country() {Id = 2, Name = "India"},
                new Country() {Id = 3, Name = "Russia"}
            };
        }
        
        [TestMethod]
        public void Country_Get_All()
        {
            // Arrange
            _mockRepository.Setup(x => x.GetAll()).Returns(listCountry);

            // Act
            List<Country> results = _service.GetAll() as List<Country>;

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        public void Can_Add_Country()
        {
            // Arrange
            int Id = 1;
            Country emp = new Country() {Name = "UK"};
            _mockRepository.Setup(m => m.Add(emp)).Returns((Country e) =>
            {
                e.Id = Id;
                return e;
            });

            // Act
            _service.Create(emp);

            // Assert
            Assert.AreEqual(Id, emp.Id);
            _mockUnitOfWork.Verify(m => m.Commit(), Times.Once);
        }
    }
}
