﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDLecture_day1_homework.Model;
using TDDLecture_day1_homework.Tool;

namespace ProductTest.Tool
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void SumByGroupTest_有群未滿_numberPreGroup_is_3_accessValueFunc_is_Cost()
        {
            // arrange
            var calculator = new Calculator();
            var products = new List<Product>()
            {
                new Product {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Product {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Product {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Product {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Product {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Product {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Product {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Product {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Product {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Product {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Product {Id = 11, Cost = 11, Revenue = 21, SellPrice = 31},
            };
            var numberPreGroup = 3;
            Func<Product, int> accessValueFunc = m => m.Cost;
            var expected = new int[] { 6, 15, 24, 21 };

            // act
            var result = calculator.SumByGroup<Product>(products, numberPreGroup, accessValueFunc);
            
            // assert
            CollectionAssert.AreEqual(expected, result.ToArray());
        }

        [TestMethod()]
        public void SumByGroupTest_有群未滿_numberPreGroup_is_4_accessValueFunc_is_Revenue()
        {
            // arrange
            var calculator = new Calculator();
            var products = new List<Product>()
            {
                new Product {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Product {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Product {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Product {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Product {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Product {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Product {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Product {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Product {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Product {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Product {Id = 11, Cost = 11, Revenue = 21, SellPrice = 31},
            };
            var numberPreGroup = 4;
            Func<Product, int> accessValueFunc = m => m.Revenue;
            var expected = new int[] { 50, 66, 60 };

            // act
            var result = calculator.SumByGroup<Product>(products, numberPreGroup, accessValueFunc);
            var actual = result.ToArray();
            
            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SumByGroupTest_只有一群_SellPrice_is_SellPrice()
        {
            // arrange
            var calculator = new Calculator();
            var products = new List<Product>()
            {
                new Product {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Product {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Product {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Product {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Product {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Product {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Product {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Product {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Product {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Product {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Product {Id = 11, Cost = 11, Revenue = 21, SellPrice = 31},
            };
            var numberPreGroup = 11;
            Func<Product, int> accessValueFunc = m => m.SellPrice;
            var expected = new int[] { 286 };

            // act
            var result = calculator.SumByGroup<Product>(products, numberPreGroup, accessValueFunc);
            var actual = result.ToArray();

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SumByGroupTest_剛好組成群_SellPrice_is_Cost()
        {
            // arrange
            var calculator = new Calculator();
            var products = new List<Product>()
            {
                new Product {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Product {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Product {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Product {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Product {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Product {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Product {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Product {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Product {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Product {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
            };
            var numberPreGroup = 5;
            Func<Product, int> accessValueFunc = m => m.Cost;
            var expected = new int[] { 15,  40};

            // act
            var result = calculator.SumByGroup<Product>(products, numberPreGroup, accessValueFunc);
            var actual = result.ToArray();

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SumByGroupTest_numberPreGroup超過資料量_SellPrice_is_Cost()
        {
            // arrange
            var calculator = new Calculator();
            var products = new List<Product>()
            {
                new Product {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Product {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Product {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Product {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Product {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Product {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Product {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Product {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Product {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Product {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Product {Id = 11, Cost = 11, Revenue = 21, SellPrice = 31},
            };
            var numberPreGroup = 16;
            Func<Product, int> accessValueFunc = m => m.Cost;
            var expected = new int[] { 66 };

            // act
            var result = calculator.SumByGroup<Product>(products, numberPreGroup, accessValueFunc);
            var actual = result.ToArray();

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SumByGroupTest_輸入參數異常_無元素輸入資料()
        {
            // arrange
            var calculator = new Calculator();
            var numberPreGroup = 16;
            Func<Product, int> accessValueFunc = m => m.Cost;
            
            // act
            var actual = calculator.SumByGroup<Product>(new List<Product>(), numberPreGroup, accessValueFunc);
           
            // assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod()]
        public void SumByGroupTest_輸入參數異常_空輸入資料()
        {
            // arrange
            var calculator = new Calculator();
            var numberPreGroup = 16;
            Func<Product, int> accessValueFunc = m => m.Cost;

            // act
            var actual = calculator.SumByGroup<Product>(null, numberPreGroup, accessValueFunc);

            // assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod()]
        public void SumByGroupTest_輸入參數異常_非正數numberPreGroup()
        {
            // arrange
            var calculator = new Calculator();
            var products = new List<Product>()
            {
                new Product {Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Product {Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Product {Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Product {Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Product {Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Product {Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Product {Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Product {Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Product {Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Product {Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Product {Id = 11, Cost = 11, Revenue = 21, SellPrice = 31},
            };
            var numberPreGroup = 0;
            Func<Product, int> accessValueFunc = m => m.Cost;

            // act
            var actual = calculator.SumByGroup<Product>(products, numberPreGroup, accessValueFunc);

            // assert
            Assert.AreEqual(null, actual);
        }
    }
}