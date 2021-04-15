using System;
using Box.Model;
using NUnit.Framework;

namespace Box.UnitTests
{
    [TestFixture]
    public class ModelTests
    {
        [Test]
        [TestCase(500, 1200, 300, 310, 560,
            TestName =
                "Тест на создание объекта PlaneParameters с некорректными значениями ширины 1 ")]
        [TestCase(700, 1100, 300, 310, 560,
            TestName =
                "Тест на создание объекта PlaneParameters с некорректными значениями длины 1")]
        [TestCase(700, 1200, 200, 310, 560,
            TestName =
                "Тест на создание объекта PlaneParameters с некорректными значениями высоты 1")]
        [TestCase(700, 1200, 300, 250, 560,
            TestName =
                "Тест на создание объекта PlaneParameters с некорректными значениями ширины отсека 1")]
        [TestCase(700, 1200, 300, 310, 450,
            TestName =
                "Тест на создание объекта PlaneParameters с некорректными значениями длины отсека 1")]
        [TestCase(1200, 1200, 300, 310, 560,
            TestName =
                "Тест на создание объекта PlaneParameters с некорректными значениями ширины 2")]
        [TestCase(700, 1700, 300, 310, 560,
            TestName =
                "Тест на создание объекта PlaneParameters с некорректными значениями длины 2")]
        [TestCase(700, 1200, 500, 310, 560,
            TestName =
                "Тест на создание объекта PlaneParameters с некорректными значениями высоты 2")]
        [TestCase(700, 1200, 300, 500, 560,
            TestName =
                "Тест на создание объекта PlaneParameters с некорректными значениями ширины отсека 2")]
        [TestCase(700, 1200, 300, 310, 800,
            TestName =
                "Тест на создание объекта PlaneParameters с некорректными значениями длины отсека 2")]

        public void PlaneParameterConstructor_NegativeTest
        (double width, double length, double height, double widthCompartment,
           double lengthCompartment)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new PlaneParameters(length, width,
                height, lengthCompartment, widthCompartment));
        }

        [TestCase(700, 1200, 300, 400, 560,
            TestName =
                "Тест на создание объекта PlaneParameters  ширина отсека больше половины ширины коробки ")]
        [TestCase(700, 1200, 300, 310, 700,
            TestName =
                "Тест на создание объекта PlaneParameters с длина отсека больше половины длины коробки")]

        public void PlaneParameterConstructor1_NegativeTest
        (double width, double length, double height, double widthCompartment,
            double lengthCompartment)
        {
            Assert.Throws<ArgumentException>(() => new PlaneParameters(length, width,
                height, lengthCompartment, widthCompartment));
        }


        [Test]
        [TestCase(700, 1200, 300, 560, 320,
            TestName =
                "Тест на создание объекта PlaneParameters со значениями по умолчанию")]
        public void PlaneParameterConstructor_PositiveTest
        (double width, double length, double height, double lengthCompartment,
            double widthCompartment)
        {
            var planeParameters = new PlaneParameters(length, width,
                height, lengthCompartment, widthCompartment);

            Assert.AreEqual(length, planeParameters.Length);
            Assert.AreEqual(width, planeParameters.Width);
            Assert.AreEqual(height, planeParameters.Height);
            Assert.AreEqual(widthCompartment, planeParameters.WidthCompartment);
            Assert.AreEqual(lengthCompartment, planeParameters.LengthCompartment);
            Assert.IsInstanceOf<PlaneParameters>(planeParameters);
        }
    }
}