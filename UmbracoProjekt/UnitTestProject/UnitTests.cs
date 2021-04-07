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
        List<string> serialNumbers;
        DrawRules rules;
        List<Form> forms;
        [TestInitialize]
        public void Init()
        {
            serialNumbers = new List<string>
            {
                "f425c273-bf92-4371-be30-b29654bd7047",

                "8a6a0f29-5157-448f-91c4-2092b374b93b",

                "74059605-5019-4175-af87-aa27354acb39",

                "5e51ad47-ca9b-4852-9fa2-fb5a7221b988",

                "d05baa9d-b747-4dcc-868a-3c1bd90e656d",

                "52d047ee-2af1-4d55-87f0-bc9c0bba772a",

                "927a5fba-fd64-4269-9a7d-5a721f8dce6e",

                "a1d8fda0-3b58-4097-b92a-0e731da695e0",

                "7bd2d853-13bc-4ffd-9938-46462dec37b1",

                "d91ac353-37c5-400e-b3ce-d9c51caf072a"

            };
            //Filling our objects with data, so we can use them to test the database
            a = new Form
            {
                EmailAdress = "n@g.com",
                FirstName = "Nikolaj",
                LastName = "Geisle",
                SerialNumber = "b5337fee-c6d3-402a-8a30-6d2adf5d94aa"
            };
            b = new Form
            {
                EmailAdress = "l@g.com",
                FirstName = "Lene",
                LastName = "Geisle",
                SerialNumber = "bb9ff01f-03d2-463c-a18a-f717f5c973bf"
            };
            c = new Form
            {
                EmailAdress = "f@g.com",
                FirstName = "Fie",
                LastName = "Geisle",
                SerialNumber = "a4154667-d3b9-41c7-8fc2-6f683f4310c2"
            };
            forms = new List<Form> { a, b, c };
            rules = new DrawRules(serialNumbers, forms);
        }
        [TestMethod]
        public void TestAddTwice()
        {
            Form newForm = new Form { SerialNumber = "60b60c18-23fc-4563-a192-ba1f853b44f0" };
            for (int i = 0; i < 2; i++)
            {
                if (rules.CheckRules(newForm.SerialNumber))
                {
                    forms.Add(newForm);
                }
            }
            Assert.AreEqual(5, forms.Count);
        }
        [TestMethod]
        public void TestAddingThrice()
        {
            Form newForm = new Form { SerialNumber = "de726309-d625-459b-a3e0-760f46d5e746" };
            for (int i = 0; i < 3; i++)
            {
                if (rules.CheckRules(newForm.SerialNumber))
                {
                    forms.Add(newForm);
                }
            }
            Assert.AreEqual(5, forms.Count);
        }

        [TestMethod]
        public void TestAddingSameNumber()
        {
            List<string> numbers = new List<string> {
                "f425c273-bf92-4371-be30-b29654bd7047",

                "8a6a0f29-5157-448f-91c4-2092b374b93b",

                "74059605-5019-4175-af87-aa27354acb39",

                "5e51ad47-ca9b-4852-9fa2-fb5a7221b988",

                "d05baa9d-b747-4dcc-868a-3c1bd90e656d",

                "52d047ee-2af1-4d55-87f0-bc9c0bba772a",

                "927a5fba-fd64-4269-9a7d-5a721f8dce6e",

                "a1d8fda0-3b58-4097-b92a-0e731da695e0",

                "7bd2d853-13bc-4ffd-9938-46462dec37b1",

                "d91ac353-37c5-400e-b3ce-d9c51caf072a"

            };

            foreach (var number in numbers)
            {
                if (rules.CheckRules(number))
                {
                    forms.Add(new Form());
                }
            }
            Assert.AreEqual(3, forms.Count);
        }
    }
}
