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
    public class UnitTests
    {
        Form a, b, c;
        [TestInitialize]
        public void Init()
        {
            //Filling our objects with data, so we can use them to test the database
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
        }
        [TestMethod]
        public void TestAddTwice()
        {
            
        }
        [TestMethod]
        public void TestAddingRules()
        {
            
        }
    }
}
