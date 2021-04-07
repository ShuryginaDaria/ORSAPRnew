using System;
using System.Runtime.InteropServices;
using Box.Model;
using Kompas6API5;
using Kompas6Constants3D;
using Kompas6Constants;
using System.Collections.Generic;

namespace Box.KompasWrapper
{
    public class Builder
    {
        /// <summary>
        ///     Хранит ссылку на экземпляр Компас 3Д
        /// </summary>
        private KompasObject _kompasObject;

        /// <summary>
        /// Модель коробки
        /// </summary>
        public PlaneParameters Box { get; set; }

        /// <summary>
        ///     Запуск KOMPAS
        /// </summary>
        public void StartKompas()
        {
            if (_kompasObject == null)
            {
                var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompasObject = (KompasObject) Activator.CreateInstance(kompasType);
            }

            if (_kompasObject != null)
            {
                var retry = true;
                short tried = 0;
                while (retry)
                {
                    try
                    {
                        tried++;
                        _kompasObject.Visible = true;
                        retry = false;
                    }
                    catch (COMException)
                    {
                        var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                        _kompasObject =
                            (KompasObject) Activator.CreateInstance(kompasType);

                        if (tried > 3)
                        {
                            retry = false;
                        }
                    }
                }

                _kompasObject.ActivateControllerAPI();
            }
        }

        /// <summary>
        /// Строит коробку
        /// </summary>
        public void BuildBox()
        {
            // Создаём новую модель в компасе 
            var document = (ksDocument3D)_kompasObject.Document3D();
            document.Create();
            // Получаем корневой элемент в дереве элементов
            var rootPart = (ksPart)document.GetPart((short)Part_Type.pTop_Part);
            // Теперь нужна базовая плоскость XY
            var planeXy = (ksEntity)rootPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            // Теперь построим основание
            var bottomSketch = (ksEntity)rootPart.NewEntity((short)Obj3dType.o3d_sketch);
            // Получаем параметры эскиза
            var bottomDefinition = (ksSketchDefinition)bottomSketch.GetDefinition();
            // Назначаем координаты
            bottomDefinition.SetPlane(planeXy);
            // Открываем эскиз для редактирования
            bottomSketch.Create();
            var edited = (ksDocument2D)bottomDefinition.BeginEdit();
            
            // Нижний левый край
            var lowerLeftX = -(Box.Length / 2);
            var lowerLeftY = -(Box.Width / 2);
            
            // Строим прямоугольник
            CreateRectangle(edited, lowerLeftX, lowerLeftY, Box.Length, Box.Width);
            bottomDefinition.EndEdit();

            // Основание сделали, теперь выдавливаем
            var baseExtrusion = Extrude(Box.Height, rootPart, bottomSketch);

            // Подсчёт нижних левых краёв для каждого из отсеков
            var space1lowerX = -PlaneParameters.ThicknessCompartment
                              - Box.LengthCompartment;
            var space1lowerY = lowerLeftY + PlaneParameters.Thickness;

            var space2lowerX = PlaneParameters.ThicknessCompartment / 2;
            var space2lowerY = lowerLeftY + PlaneParameters.Thickness;

            var space3lowerX = -PlaneParameters.ThicknessCompartment
                               - Box.LengthCompartment;
            var space3lowerY = lowerLeftY
                               + PlaneParameters.Thickness
                               + Box.WidthCompartment
                               + PlaneParameters.ThicknessCompartment;

            var space4lowerX = PlaneParameters.ThicknessCompartment / 2;
            var space4lowerY = lowerLeftY
                               + PlaneParameters.Thickness
                               + Box.WidthCompartment
                               + PlaneParameters.ThicknessCompartment;


            // Записываем их в список из кортежей типа <double, double>
            var spacePoints = new List<Tuple<double, double>>()          
            {
                new Tuple<double, double>(space1lowerX, space1lowerY),
                new Tuple<double, double>(space2lowerX, space2lowerY),
                new Tuple<double, double>(space3lowerX, space3lowerY),
                new Tuple<double, double>(space4lowerX, space4lowerY)
            };
            
            // Делаем для них эскизы
            for (int i = 0; i < 4; i++)
            {
                var sketch = (ksEntity)rootPart.NewEntity((short)Obj3dType.o3d_sketch);
                // Получаем параметры эскиза
                var definition = (ksSketchDefinition)sketch.GetDefinition();
                // Назначаем координаты
                definition.SetPlane(planeXy);
                // Открываем эскиз для редактирования
                sketch.Create();
                var edit = (ksDocument2D)definition.BeginEdit();
                // Строим прямоугольник
                CreateRectangle(edit, spacePoints[i].Item1, spacePoints[i].Item2, 
                    Box.LengthCompartment, Box.WidthCompartment);
                definition.EndEdit();
                // Вырезаем выдавливанием на высоту коробки минус толщину внешней стенки
                ExtrudeToCut(Box.Height - PlaneParameters.Thickness, rootPart, sketch);
            }
        }

        /// <summary>
        /// Создаёт прямоугольник на плоскости
        /// </summary>
        /// <param name="sketch">Эскиз</param>
        /// <param name="x">X левого нижнего угла</param>
        /// <param name="y">Y левого нижнего угла</param>
        /// <param name="width">Длина</param>
        /// <param name="height">Ширина</param>
        private void CreateRectangle(ksDocument2D sketch, double x, double y, double width, double height)
        {
            // Получение структуры параметров прямоугольника
            var rectParams = (ksRectangleParam)_kompasObject
                .GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            // Назначение координат
            rectParams.x = x;
            rectParams.y = y;
            // Назначение высоты и ширины
            rectParams.width = width;
            rectParams.height = height;
            // Основной стиль линии
            rectParams.style = 1;
            // Построение
            sketch.ksRectangle(rectParams);
        }

        /// <summary>
        /// Выдавливает эскиз
        /// </summary>
        /// <param name="depth">Глубина</param>
        /// <param name="part">Деталь</param>
        /// <param name="sketch">Эскиз</param>
        /// <returns>Объект выдавливания в дереве построения</returns>
        private ksEntity Extrude(double depth, ksPart part, ksEntity sketch)
        {
            // Создание операции выдавливания
            var extrusionEntity = (ksEntity)part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            // Получение свойств операции
            var extrusionDefinition = (ksBossExtrusionDefinition)extrusionEntity.GetDefinition();
            // Получение структуры параметров операции
            var properties = (ksExtrusionParam)extrusionDefinition.ExtrusionParam();
            // Установка эскиза, который будем выдавливать
            extrusionDefinition.SetSketch(sketch);
            // Направление выдавливания (здесь строго обратное, но вообще, лучше расхардкодить и
            properties.direction = (int)Direction_Type.dtReverse;
            // Глубина выдавливания в обратную сторону
            properties.depthReverse = depth;
            

            // 0 - строго на глубину
            properties.typeNormal = 0;
            properties.typeReverse = 0;
            
            // Выдавливание
            extrusionEntity.Create();
            return extrusionEntity;
        }

        private ksEntity ExtrudeToCut(double depth, ksPart part, ksEntity sketch)
        {
            // Создание операции выдавливания
            var extrusionEntity = (ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            // Получение свойств операции
            var extrusionDefinition = (ksCutExtrusionDefinition)extrusionEntity.GetDefinition();
            // Получение структуры параметров операции
            var properties = (ksExtrusionParam)extrusionDefinition.ExtrusionParam();
            // Установка эскиза, который будем выдавливать
            extrusionDefinition.SetSketch(sketch);
            // Направление выдавливания
            properties.direction = (int)Direction_Type.dtNormal;
            // Глубина выдавливания прямо
            properties.depthNormal = depth;
            
            // Выдавливания в прямом и обратном направлениях
            // 0 - строго на глубину
            properties.typeNormal = 0;
            properties.typeReverse = 0;
            
            // Непосредственно выдавливание
            extrusionEntity.Create();
            return extrusionEntity;
        }

        /// <summary>
        ///     Построение одной плоскости
        /// </summary>
        /// <param name="part"></param>
        /// <param name="plane"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="thickness"></param>
        private void BuildPlane(ksPart part, ksEntity plane, double height, double width,
            double thickness)
        {
            ksEntity sketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();
            sketchDefinition.SetPlane(plane);
            sketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D document2D = sketchDefinition.BeginEdit();
            document2D.ksLineSeg(0, 0, 0, height, 1);
            document2D.ksLineSeg(0, height, width, height, 1);
            document2D.ksLineSeg(width, height, width, 0, 1);
            document2D.ksLineSeg(width, 0, 0, 0, 1);
            sketchDefinition.EndEdit();

            ///Выдавливание
            ksEntity extrude = part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
            extrudeDefinition.directionType = (short)Direction_Type.dtNormal;
            extrudeDefinition.SetSketch(sketch);
            ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
            extrudeParam.depthNormal = thickness;
            extrude.Create();
        }



    }
}