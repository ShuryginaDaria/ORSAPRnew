using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box.Model
{
    /// <summary>
    ///     Параметры коробки
    /// </summary>
    public class PlaneParameters
    {
        #region Constants

        /// <summary>
        ///     Тощина стенок коробки
        /// </summary>
        private const double Thickness = 30;

        /// <summary>
        ///     Толщина внутренних стенок отсека
        /// </summary>
        private const double ThicknessCompartment = 20;

        /// <summary>
        ///     Максимальное значение высоты
        /// </summary>
        private const double MaxHeight = 400;

        /// <summary>
        ///     Минимальное значение высоты
        /// </summary>
        private const double MinHeight = 300;

        /// <summary>
        ///     Максимальное значение ширины
        /// </summary>
        private const double MaxWidth = 1000;

        /// <summary>
        ///     Минимальное значение ширины
        /// </summary>
        private const double MinWidth = 700;

        /// <summary>
        ///     Минимальное значение длины
        /// </summary>
        private const double MinLength = 1200;

        /// <summary>
        ///     Максимальное значение длины
        /// </summary>
        private const double MaxLength = 1500;

        /// <summary>
        ///     Минимальное значение  ширины отсека
        /// </summary>
        private const double MinWidthCompartment = 310;

        /// <summary>
        ///     Максимальное значение  ширины отсека
        /// </summary>
        private const double MaxWidthCompartment = 460;

        /// <summary>
        ///     Минимальное значение  длины отсека
        /// </summary>
        private const double MinLengthCompartment = 560;

        /// <summary>
        ///     Максимальное значение  длины отсека
        /// </summary>
        private const double MaxLengthCompartment = 710;

        #endregion

        #region Private fields

        /// <summary>
        ///     Длина стенок коробки
        /// </summary>
        private double _length;

        /// <summary>
        ///     Ширина стенок коробки
        /// </summary>
        private double _width;

        /// <summary>
        ///     Высота стенок коробки
        /// </summary>
        private double _height;
                

        /// <summary>
        ///     Ширина внутренней части основания
        /// </summary>
        private double _widthCompartment;

        /// <summary>
        ///     Длина внутренней части основания
        /// </summary>
        private double _lengthCompartment;

        #endregion

        #region Properties

        /// <summary>
        ///     Высота коробки
        /// </summary>
        public double Height
        {
            get => _height;
            private set => _height =
                SetCorrectValue(ParameterType.Height, value, MaxHeight, MinHeight);
        }

        /// <summary>
        ///     Ширина коробки
        /// </summary>
        public double Width
        {
            get => _width;
            private set => _width =
                SetCorrectValue(ParameterType.Width, value, MaxWidth, MinWidth);
        }

        /// <summary>
        ///     Длина коробки
        /// </summary>
        public double Length
        {
            get => _length;
            private set => _length =
                SetCorrectValue(ParameterType.Length, value, MaxLength, MinLength);
        }

        /// <summary>
        ///     Длина отсека коробки (все отсеки одинаковы)
        /// </summary>
        public double LengthCompartment
        {
            get => _lengthCompartment;
            private set => _lengthCompartment =
                SetCorrectValue(ParameterType.LengthCompartment, value, MaxLengthCompartment, MinLengthCompartment);
        }

        /// <summary>
        ///     Ширина отсека коробки (все отсеки одинаковы)
        /// </summary>
        public double WidthCompartment
        {
            get => _widthCompartment;
            private set => _widthCompartment =
                SetCorrectValue(ParameterType.WidthCompartment, value, MaxWidthCompartment, MinWidthCompartment);
        }




        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор параметров коробки
        /// </summary>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="lengthCompartment"></param>
        /// <param name="widthCompartment"></param>

        public PlaneParameters(double length, double width, double height,
            double lengthCompartment, int widthCompartment)
        {
             Length = length;
             Width = width;
             Height = height;
             LengthCompartment = lengthCompartment;
             WidthCompartment = widthCompartment;

                       

            if (width / 2 <= widthCompartment)
            {
                throw new ArgumentException(
                    "Ширина отсека  не может быть больше половины ширины коробки");
            }

            if (length /2<= lengthCompartment)
            {
                throw new ArgumentException(
                    "Длина отсека  не может быть больше половины длины коробки ");
            }
                                                  
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Установка корректных значений параметра
        /// </summary>
        /// <param name="parameterType">Тип параметра</param>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="minValue">Минимальное значение</param>
        /// <returns></returns>
        private double SetCorrectValue(ParameterType parameterType, double value,
            double maxValue,
            double minValue)
        {
            if (value <= maxValue &&
                value >= minValue)
            {
                return value;
            }

            throw new ArgumentOutOfRangeException(parameterType +
                                                  ". Значение : " + value +
                                                  " не входит в диапазон допустимых значений для данного параметра от " +
                                                  minValue + " до " + maxValue);
        }

        #endregion
    }
}
