using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Microsoft.Extensions.Logging;
using Demo.AddressManager.Data;
using AutoMapper;

namespace Demo.AddressManager.WebApi.Tests
{
    [TestClass]
    public class ContactsControllerTests
    {
        [TestInitialize]
        public void Initialise()
        {
            Mapper.Initialize(p => {
                p.CreateMap<Contact, ContactModel>().ForMember(x => x.Url, o => o.MapFrom(a => a.Id));
                p.CreateMap<ContactModel, Contact>().ForMember(x => x.Id, o => o.MapFrom(a => a.Url));
            });
        }

        [TestMethod]
        public void ContactCreate_WithValidObject_ReturnsContact()
        {
            // arrange
            var expected = GetContactTestData();
            var mockRepository = new Mock<IAddressManagerRepository>();
            var mockLogger = new Mock<ILogger<ContactsController>>();
            var controller = new ContactsController(mockRepository.Object, mockLogger.Object, Mapper.Instance);

            // act
            var result = controller.Create(expected) as ObjectResult;

            // assert
            Assert.IsNotNull(result, "Result");
            Assert.AreEqual<int?>((int)HttpStatusCode.Created, result.StatusCode, "StatusCode");
            var actual = (ContactModel)result.Value;
            Assert.AreEqual(expected.Url, actual.Url, "Contact.Url");
            Assert.AreEqual(expected.FirstName, actual.FirstName, "Contact.FirstName");
            Assert.AreEqual(expected.LastName, actual.LastName, "Contact.LastName");

        }


        [TestMethod]
        public void ContactGetAll_WhereDataExists_ReturnsContactList()
        {
            // arrange
            var expectedResult = GetContactsTestData();
            var mockRepository = new Mock<IAddressManagerRepository>();
            var mockLogger = new Mock<ILogger<ContactsController>>();
            mockRepository.Setup(x => x.GetAllContacts())
                .Returns(() => expectedResult);
            var controller = new ContactsController(mockRepository.Object, mockLogger.Object, Mapper.Instance);

            // act
            var result = controller.Get() as ObjectResult;

            // assert
            mockRepository.Verify();
            Assert.IsNotNull(result, "Result");
            CollectionAssert.AreEquivalent(expectedResult.ToList(), (ICollection)result.Value);

        }

#region Helpers

        private IQueryable<ContactModel> GetContactsTestData()
        {
            return new List<ContactModel>()
            {
                GetContactTestData(),
                GetContactTestData("2", "John", "Doe"),
                GetContactTestData("3", "Juan", "Perez"),
                GetContactTestData("4", "Fred", "Nerk"),
            }.AsQueryable();
        }

        private ContactModel GetContactTestData(string url = "1", string firstName = "Joe", string lastName = "Bloggs")
        {
            return new ContactModel() { Url = url, FirstName = firstName, LastName = lastName };
        }

        #endregion

    }
}
