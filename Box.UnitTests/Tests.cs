using System;
using Box.Model;
using NUnit.Framework;

namespace Box.UnitTests
{
    [TestFixture]
    public class Tests
    {
        [Test(Description = "Позитивный тест создания модели коробки")]
        public void ConstructorPositiveTest()
        {
            Assert.DoesNotThrow(() => 
            { 
                var plane = new PlaneParameters(1200, 700, 300, 
                560, 310);
                
            }, "Модель выдала ошибку на стандартные значения");
        }

        [Test(Description = "Позитивный тест геттера длины")]
        public void LengthPositiveTest()
        {
            var plane = new PlaneParameters(1200, 700, 300, 
                560, 310);
            Assert.AreEqual(plane.Length, 1200, "Геттер длины вернул неверное значение");
        }
        
        //TODO: Duplication
        [Test(Description = "Негативный тест создания модели коробки: " +
                            "слишком большая длина")]
        public void TooHighLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var plane = new PlaneParameters(10000, 700, 300, 
                    560, 310);
            },
                "Удалось присвоить слишком большую длину");
        }
        
        //TODO: Duplication
        [TestCase(1, 700, TestName = "Негативный тест создания модели коробки: " +
                            "слишком малая длина")]
        public void TooLowLength(double length, double width)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var plane = new PlaneParameters(length, width, 300, 
                    560, 310);
            },
                "Удалось присвоить слишком малую длину");
        }
        
        [Test(Description = "Позитивный тест геттера ширины")]
        public void WidthPositiveTest()
        {
            var plane = new PlaneParameters(1200, 700, 300, 
                560, 310);
            Assert.AreEqual(plane.Width, 700, "Геттер ширины вернул неверное значение");
        }
        
        [Test(Description = "Негативный тест создания модели коробки: " +
                            "слишком большая ширина")]
        public void TooHighWidth()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var plane = new PlaneParameters(1200, 7000, 300, 
                    560, 310);
            },
                "Удалось присвоить слишком большую ширину");
        }
        
        [Test(Description = "Негативный тест создания модели коробки: " +
                            "слишком малая ширина")]
        public void TooLowWidth()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var plane = new PlaneParameters(1200, 70, 300, 
                    560, 310);
            },
                "Удалось присвоить слишком малую ширину");
        }
        
        [Test(Description = "Позитивный тест геттера высоты")]
        public void HeightPositiveTest()
        {
            var plane = new PlaneParameters(1200, 700, 300, 
                560, 310);
            Assert.AreEqual(plane.Height, 300, "Геттер высоты вернул неверное значение");
        }
        
        [Test(Description = "Негативный тест создания модели коробки: " +
                            "слишком большая высота")]
        public void TooHighHeight()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var plane = new PlaneParameters(1200, 700, 3000, 
                        560, 310);
                },
                "Удалось присвоить слишком большую высоту");
        }
        
        [Test(Description = "Негативный тест создания модели коробки: " +
                            "слишком малая высота")]
        public void TooLowHeight()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var plane = new PlaneParameters(1200, 700, 30, 
                        560, 310);
                },
                "Удалось присвоить слишком малую высоту");
        }
        
        [Test(Description = "Позитивный тест геттера длины отсека")]
        public void LengthCompartmentPositiveTest()
        {
            var plane = new PlaneParameters(1200, 700, 300, 
                560, 310);
            Assert.AreEqual(plane.LengthCompartment, 560, "Геттер длины отсека вернул неверное значение");
        }
        
        [Test(Description = "Негативный тест создания модели коробки: " +
                            "слишком большая длина отсека")]
        public void TooHighLengthCompartment()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var plane = new PlaneParameters(1200, 700, 300, 
                        5600, 310);
                },
                "Удалось присвоить слишком большую длину отсека");
        }
        
        [Test(Description = "Негативный тест создания модели коробки: " +
                            "слишком малая длина отсека")]
        public void TooLowLengthCompartment()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var plane = new PlaneParameters(1200, 700, 30, 
                        56, 310);
                },
                "Удалось присвоить слишком малую длину отсека");
        }
        
        [Test(Description = "Позитивный тест геттера ширины отсека")]
        public void WidthCompartmentPositiveTest()
        {
            var plane = new PlaneParameters(1200, 700, 300, 
                560, 310);
            Assert.AreEqual(plane.WidthCompartment, 310, "Геттер ширины отсека вернул неверное значение");
        }
        
        [Test(Description = "Негативный тест создания модели коробки: " +
                            "слишком большая ширина отсека")]
        public void TooHighWidthCompartment()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var plane = new PlaneParameters(1200, 700, 300, 
                        560, 3100);
                },
                "Удалось присвоить слишком большую ширину отсека");
        }
        
        [Test(Description = "Негативный тест создания модели коробки: " +
                            "слишком малая ширина отсека")]
        public void TooLowWidthCompartment()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var plane = new PlaneParameters(1200, 700, 30, 
                        560, 31);
                },
                "Удалось присвоить слишком малую длину отсека");
        }

        [Test(Description = "Негативный тест создания модели коробки: " +
                            "половина ширины меньше или равна ширине отсека")]
        public void HalfOfWidthIsLessOrEqualsToWidthCompartment()
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    var plane = new PlaneParameters(1200, 700, 300, 
                        560, 460);
                },
                "Удалось присвоить слишком малую ширину");
        }
        
        [Test(Description = "Негативный тест создания модели коробки: " +
                            "половина длины меньше или равна длине отсека")]
        public void HalfOfLengthIsLessOrEqualsToLengthCompartment()
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    var plane = new PlaneParameters(1200, 700, 300, 
                        710, 310);
                },
                "Удалось присвоить слишком малую длину");
        }
    }
}