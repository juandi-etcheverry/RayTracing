using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphicsEngineTest
{
    [TestClass]
    internal class GraphicsEngineTest
    {
        private Scene BaseScene;

        [TestInitialize]
        public void ArrangeGraphicsEngineData()
        {
            Material grass = new Material()
            {
                Name = "Grass",
                OwnerName = "Juandi",
                Color = (14, 255, 0)
            };
            Sphere globe = new Sphere()
            {
                Name = "Earth",
                OwnerName = "Juandi",
                Radius = 5
            };
            Model globeModel = new Model()
            {
                Material = grass,
                Shape = globe,
                Name = "Globe",
                OwnerName = "Juandi",
                WantPreview = false
            };
            BaseScene = new Scene()
            {
                Name = "Base Scene",
                OwnerName = "Juandi"
            };
            BaseScene.AddPositionedModel(globeModel, (0, -5, -1));
        }
    }
}
