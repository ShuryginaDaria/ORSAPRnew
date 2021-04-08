using System;
using Box.Model;
using NUnit.Framework;

namespace Box.UnitTests
{
    [TestFixture]
    public class Tests
    {
        private const double LengthDefault = 1200;
        private const double WidthDefault = 700;
        private const double HeightDefault = 300;
        private const double LengthCompartmentDefault = 560;
        private const double WidthCompartmentDefault = 310;

        private const double LengthCompartmentMax = 710;
        private const double WidthCompartmentMax = 460;

        private const double TooHighValue = 10000;
        private const double TooLowValue = 1;

        private PlaneParameters SetDefault()
        {
            return Set(LengthDefault, WidthDefault, HeightDefault,
                LengthCompartmentDefault, WidthCompartmentDefault);
        }

        private PlaneParameters Set(double length,
            double width,
            double height,
            double lengthCompartment,
            double widthCompartment)
        {
            return new PlaneParameters(length,
                width,
                height,
                lengthCompartment,
                (int)widthCompartment);
        }

        [Test(Description = "Позитивный тест создания модели коробки")]
        public void ConstructorPositiveTest()
        {
            Assert.DoesNotThrow(() => { SetDefault(); },
                "Модель выдала ошибку на стандартные значения");
        }

        [Test(Description = "Позитивный тест геттера длины")]
        public void LengthPositiveTest()
        {
            var plane = SetDefault();
            Assert.AreEqual(plane.Length, LengthDefault,
                "Геттер длины вернул неверное значение");
        }

        [TestCase(TooHighValue, TestName =
            "Негативный тест создания модели коробки: " +
                                     "слишком большая длина")]
        [TestCase(TooLowValue, TestName = 
            "Негативный тест создания модели коробки: " +
                                "слишком малая длина")]
        public void LengthNegativeTest(double length)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Set(length, WidthDefault, HeightDefault,
                    LengthCompartmentDefault, WidthCompartmentDefault);
            },
                "Удалось присвоить неверную длину");
        }

        [Test(Description = "Позитивный тест геттера ширины")]
        public void WidthPositiveTest()
        {
            var plane = SetDefault();
            Assert.AreEqual(plane.Width, WidthDefault, 
                "Геттер ширины вернул неверное значение");
        }

        [TestCase(TooHighValue, TestName = "Негативный тест создания модели коробки: " +
                                           "слишком большая ширина")]
        [TestCase(TooLowValue, TestName = "Негативный тест создания модели коробки: " +
                                          "слишком малая ширина")]
        public void WidthNegativeTest(double width)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Set(LengthDefault, width, HeightDefault,
                    LengthCompartmentDefault, WidthCompartmentDefault);
            },
                "Удалось присвоить неверную ширину");
        }

        [Test(Description = "Позитивный тест геттера высоты")]
        public void HeightPositiveTest()
        {
            var plane = SetDefault();
            Assert.AreEqual(plane.Height, HeightDefault, 
                "Геттер высоты вернул неверное значение");
        }

        [TestCase(TooHighValue, TestName = "Негативный тест создания модели коробки: " +
                                           "слишком большая высота")]
        [TestCase(TooLowValue, TestName = "Негативный тест создания модели коробки: " +
                                          "слишком малая высота")]
        public void HeightNegativeTest(double height)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Set(LengthDefault, WidthDefault, height,
                    LengthCompartmentDefault, WidthCompartmentDefault);
            },
                "Удалось присвоить неверную высоту");
        }

        [Test(Description = "Позитивный тест геттера длины отсека")]
        public void LengthCompartmentPositiveTest()
        {
            var plane = SetDefault();
            Assert.AreEqual(plane.LengthCompartment, LengthCompartmentDefault,
                "Геттер длины отсека вернул неверное значение");
        }

        [TestCase(TooHighValue, TestName = "Негативный тест создания модели коробки: " +
                                           "слишком большая длина отсека")]
        [TestCase(TooLowValue, TestName = "Негативный тест создания модели коробки: " +
                                          "слишком малая длина отсека")]
        public void LengthCompartmentNegativeTest(double lengthCompartment)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Set(LengthDefault, WidthDefault, HeightDefault,
                    lengthCompartment, WidthCompartmentDefault);
            },
                "Удалось присвоить неверную длину отсека");
        }

        [Test(Description = "Позитивный тест геттера ширины отсека")]
        public void WidthCompartmentPositiveTest()
        {
            var plane = SetDefault();
            Assert.AreEqual(plane.WidthCompartment, WidthCompartmentDefault,
                "Геттер ширины отсека вернул неверное значение");
        }

        [TestCase(TooHighValue, TestName =
            "Негативный тест создания модели коробки: " +
                                           "слишком большая ширину отсека")]
        [TestCase(TooLowValue, TestName =
            "Негативный тест создания модели коробки: " +
                                          "слишком малая ширину отсека")]
        public void WidthCompartmentNegativeTest(double widthCompartment)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Set(LengthDefault, WidthDefault, HeightDefault,
                    LengthCompartmentDefault, widthCompartment);
            },
                "Удалось присвоить неверную ширину отсека");
        }

        [Test(Description = "Негативный тест создания модели коробки: " +
                            "половина ширины меньше или равна ширине отсека")]
        public void HalfOfWidthIsLessOrEqualsToWidthCompartment()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Set(LengthDefault, WidthDefault, HeightDefault,
                    LengthCompartmentMax, WidthCompartmentDefault);
            },
                "Удалось присвоить слишком малую ширину");
        }

        [Test(Description = "Негативный тест создания модели коробки: " +
                            "половина длины меньше или равна длине отсека")]
        public void HalfOfLengthIsLessOrEqualsToLengthCompartment()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Set(LengthDefault, WidthDefault, HeightDefault,
                    LengthCompartmentDefault, WidthCompartmentMax);
            },
                "Удалось присвоить слишком малую длину");
        }
    }
}