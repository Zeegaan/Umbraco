using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using UmbracoProjekt.Controllers;
using UmbracoProjekt.Models;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        public SerialNumberRepo numbers = new SerialNumberRepo();
        public Mock<DbSet<Form>> mockSet = new Mock<DbSet<Form>>();
        public Mock<FormDataContext> mockContext = new Mock<FormDataContext>();
        [TestInitialize]
        public void Init()
        {
            mockContext.Setup(m => m.Forms).Returns(mockSet.Object);
            //Arrange
            
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
