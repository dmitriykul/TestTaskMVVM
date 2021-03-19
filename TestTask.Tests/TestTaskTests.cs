using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestTask.Models;

namespace TestTask.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Calculate_2and2and2and1and1_6returned()
        {
            // arrange
            double expected = 6;
            // act
            FunctionModel LinFunc = new FunctionModel("Линейная",
                new List<double> { 1, 2, 3, 4, 5 },
                (a, b, c, x, y) => a * x + b * 1 + c);
            LinFunc.A = 2;
            LinFunc.B = 2;
            LinFunc.C = 2;
            double actual = LinFunc.Function(1, 1);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Calculate_2and2and2and1and1_24returned()
        {
            // arrange
            double expected = 24;
            // act
            FunctionModel QuadFunc = new FunctionModel("Квадратичная",
                new List<double> { 10, 20, 30, 40, 50 },
                (a, b, c, x, y) => a * Math.Pow(x, 2) + b * Math.Pow(y, 1) + c);
            QuadFunc.A = 2;
            QuadFunc.B = 2;
            QuadFunc.C = 20;
            double actual = QuadFunc.Function(1, 1);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Calculate_2and2and2and1and1_204returned()
        {
            // arrange
            double expected = 204;
            // act
            FunctionModel CubeFunc = new FunctionModel("Кубическая",
                new List<double> { 100, 200, 300, 400, 500 },
                (a, b, c, x, y) => a * Math.Pow(x, 3) + b * Math.Pow(y, 2) + c);
            CubeFunc.A = 2;
            CubeFunc.B = 2;
            CubeFunc.C = 200;
            double actual = CubeFunc.Function(1, 1);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Calculate_2and2and2and1and1_2004returned()
        {
            // arrange
            double expected = 2004;
            // act
            FunctionModel FourFunc = new FunctionModel("4-ой степени",
                new List<double> { 1000, 2000, 3000, 4000, 5000 },
                (a, b, c, x, y) => a * Math.Pow(x, 4) + b * Math.Pow(y, 3) + c);
            FourFunc.A = 2;
            FourFunc.B = 2;
            FourFunc.C = 2000;
            double actual = FourFunc.Function(1, 1);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Calculate_2and2and2and1and1_20004returned()
        {
            // arrange
            double Expected = 20004;
            // act
            FunctionModel FiveFunc = new FunctionModel("5-ой степени",
                new List<double> { 10000, 20000, 30000, 40000, 50000 },
                (a, b, c, x, y) => a * Math.Pow(x, 5) + b * Math.Pow(y, 4) + c);
            FiveFunc.A = 2;
            FiveFunc.B = 2;
            FiveFunc.C = 20000;
            double Actual = FiveFunc.Function(1, 1);
            // assert
            Assert.AreEqual(Expected, Actual);
        }
    }
}