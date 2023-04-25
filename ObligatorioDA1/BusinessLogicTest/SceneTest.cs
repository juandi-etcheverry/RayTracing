using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain;
using BusinessLogic;

namespace BusinessLogicTest
{
    [TestClass]
    public class SceneTest
    {
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();


        [TestInitialize]
        public void SetUp()
        {
            Client newClient = new Client()
            {
                Name = "NewName",
                Password = "ValidPassword1"
            };
            _clientLogic.AddClient(newClient);
            _clientLogic.InitializeSession(newClient);

            Shape newShape = new Sphere()
            {
                Name = "NewSphere",
                Radius = 5,
            };
            _shapeLogic.AddShape(newShape);

            Material newMaterial = new Material()
            {
                Name = "NewMaterial",
                Color = (100, 54, 6),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(newMaterial);

            Model newModel = new PositionedModel()
            {
                Name = "NewModel",
                Shape = newShape,
                Material = newMaterial,
                Coordinates = (0, 5, 2)
            };
            _modelLogic.Add(newModel);

        }

        [TestMethod]
        public void Create_Scene_OK_Test()
        {
        }
    }
}
