using Draw;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using UmbracoProjekt.Controllers;
using UmbracoProjekt.Models;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private SerialNumberRepo numbers = new SerialNumberRepo();
        private Mock<DbSet<Form>> mockSet = new Mock<DbSet<Form>>();
        private Mock<FormDataContext> mockContext = new Mock<FormDataContext>();
        FormController controller;
        Form a, b, c;
        [TestInitialize]
        public void Init()
        {
            //Filling our objects with data, so we can use them to test the database
            mockContext.Setup(m => m.Forms).Returns(mockSet.Object);
            a = new Form
            {
                EmailAdress = "n@g.com",
                FirstName = "Nikolaj",
                LastName = "Geisle",
                SerialNumber = "1"
            };
            b = new Form
            {
                EmailAdress = "l@g.com",
                FirstName = "Lene",
                LastName = "Geisle",
                SerialNumber = "1"
            };
            c = new Form
            {
                EmailAdress = "f@g.com",
                FirstName = "Fie",
                LastName = "Geisle",
                SerialNumber = "1"
            };
            controller = new FormController(mockContext.Object, numbers);
        }
        [TestMethod]
        public void TestAddTwice()
        {
            //Create 2 forms in the database
            controller.Create(a);
            controller.Create(b);
            //Verify that Add was called to the database exactly 2 times
            mockSet.Verify(m => m.Add(It.IsAny<Form>()), Times.Exactly(2));
            //Verify that SaveChanges is called 2 times.
            mockContext.Verify(m => m.SaveChanges(), Times.Exactly(2));
        }
        [TestMethod]
        public void TestAddingRules()
        {
            mockContext.Setup(m => m.Forms).Returns(mockSet.Object);
            controller.Create(a);
            controller.Create(b);
            controller.Create(c);
            mockSet.Verify(m => m.Add(It.IsAny<Form>()), Times.Exactly(2));
            mockContext.Verify(m => m.SaveChanges(), Times.Exactly(2));
        }
    }
}
