using System;
using System.Runtime.InteropServices;
using Box.Model;
using Kompas6API5;
using Kompas6Constants3D;

namespace Box.KompasWrapper
{
    public class Builder
    {
        /// <summary>
        ///     Хранит ссылку на экземпляр Компас 3Д
        /// </summary>
        private KompasObject _kompasObject;

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