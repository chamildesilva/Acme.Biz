using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "blade hand saw";
            currentProduct.ProductVendor.CompanyName = "ABC Co";
            var expected = "Hello Saw(1): blade hand saw Available on: ";

            //act
            var actual = currentProduct.SayHello();
            
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHello_PrameterizedConstrctor()
        {
            //arrange
            var currentProduct = new Product(1, "Saw", "blade hand saw");
            //currentProduct.ProductName = "Saw";
            //currentProduct.ProductId = 1;
            //currentProduct.Description = "blade hand saw";
            var expected = "Hello Saw(1): blade hand saw Available on: ";

            //act
            var actual = currentProduct.SayHello();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_Null()
        {
            //arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            //act
            var actual = companyName;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertMetersToInchesTest()
        {
            //arrange
            var expected = 78.74;

            //act
            var actual = Product.InchesPerMeter * 2;

            //assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinimumPriceTest_Default()
        {
            //arrange
            var currentProduct = new Product();
            decimal expected = .96m;

            //act
            var actual = currentProduct.MinimumPrice;
       
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Bulk()
        {
            //arrange
            var currentProduct = new Product(1,"Bulk Product Name","");
            decimal expected = 9.99m;

            //act
            var actual = currentProduct.MinimumPrice;

            //assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void ProductNameTrim()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = " Product Space  ";
            string expected = "Product Space";

            //act
            var actual = currentProduct.ProductName;

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ProductNameLengthTooShort()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "ac";
            string expected = null;
            string expectedMessage = "Product Name must be at least 3 characters";

            //act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ProductNamelengthTooLong()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "This is a long product Name";
            string expected = null;
            string expectedMessage = "Product Nanme can not be more than 20 characters";

            //act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ProductNamelengthRight()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Correct Product";
            string expected = "Correct Product";
      
            //act
            var actual = currentProduct.ProductName;
      
            //assert
            Assert.AreEqual(expected, actual);        
        }

        [TestMethod]
        public void Category_DefaultValue()
        {
            //arrange
            var currentProduct = new Product();
            string expected = "Tools";

            //act
            var actual = currentProduct.Category;

            //assert
            Assert.AreEqual(expected, actual);   
        }

        [TestMethod]
        public void Category_NewValue()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.Category = "Garden";

            var expected = "Garden";

            //act
            var actual = currentProduct.Category;

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Sequence_DefaultValue()
        {
            //arrange
            var currentProduct = new Product();
            int expected = 1;

            //act
            int actual = currentProduct.SequenceNumber;

            //assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sequence_NewValue()
        {
            //arrange
            var currentProduct = new Product();
            currentProduct.SequenceNumber = 5;
            int expected = 5;

            //act
            var actual = currentProduct.SequenceNumber;

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ProductCode_Category_SquenceNo()
        {
            //arrange
            var currentProduct = new Product();
            string expected = "Tools-1";

            //act
            var actual = currentProduct.ProductCode;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}