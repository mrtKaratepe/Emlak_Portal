using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ltd.NA.Emlak.Domain.Tests
{
    /// <summary>
    /// Summary description for AdressTests
    /// </summary>
    [TestClass]
    public class AdressTests
    {
        public AdressTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void IsTheRequiredBlanksFilled()
        {
            Address adress = Address.Create("Address Line 1 Goes Here",12345,"City Goes Here","Country Goes Here");

            Assert.IsTrue(adress.AddressLine1 == "Address Line 1 Goes Here");
            Assert.IsTrue(adress.number == 12345);
            Assert.IsTrue(adress.city == "City Goes Here");
            Assert.IsTrue(adress.country == "Country Goes Here");

        }
    }
}
