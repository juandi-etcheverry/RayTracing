using BusinessLogic;
using BusinessLogicExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace BusinessLogicTest
{
    [TestClass]
    public class ModelTest
    {
        private Client _client;
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();

        [TestInitialize]
        public void LoginClients_CreateShapes_Create_Materials()
        {
            _client = new Client()
            {
                Name = "NewClient",
                Password = "NewPassword1"
            };
            _clientLogic.AddClient(_client);
            _clientLogic.InitializeSession(_client);

            Shape sphere1 = new Sphere()
            {
                Name = "New Sphere 1",
                Radius = 3
            };
            Shape sphere2 = new Sphere()
            {
                Name = "New Sphere 2",
                Radius = 3
            };
            _shapeLogic.AddShape(sphere1);
            _shapeLogic.AddShape(sphere2);

            Material material1 = new Material()
            {
                Name = "New Material 1",
                Color = (0, 0, 0),
                Type = MaterialType.Lambertian
            };
            Material material2 = new Material()
            {
                Name = "New Material 2",
                Color = (190, 2, 42),
                Type = MaterialType.Lambertian
            };
            _materialLogic.Add(material1);
            _materialLogic.Add(material2);
        }

        [TestCleanup]
        public void CleanUpTests()
        {
            if (_clientLogic.GetLoggedClient() != null) _clientLogic.Logout();
            _clientLogic.GetClients().Clear();
            _shapeLogic.GetShapes().Clear();
            _materialLogic.GetAll().Clear();
            _materialLogic.GetAll().Clear();
        }


        [TestMethod]
        public void Model_ValidMaterial_OK_Test()
        {
            Model model = new Model()
            {
                Name = "New Model",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };

            Assert.AreEqual("New Model", model.Name);
        }

        [TestMethod]
        public void AddModel_Valid_Owner_Test_OK()
        {
            Model model = new Model()
            {
                Name = "Modelius",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };
            _modelLogic.Add(model);

            Assert.AreEqual(_client.Name, model.OwnerName);
        }

        [TestMethod]
        public void AddModel_NotLogged_Test_FAIL()
        {
            Model model = new Model()
            {
                Name = "Modelius",
                Shape = _shapeLogic.GetShape("New Sphere 1"),
                Material = _materialLogic.Get("New Material 1")
            };
            _clientLogic.Logout();

            Assert.ThrowsException<SessionException>(() => _modelLogic.Add(model));
        }

        [TestMethod]
        public void Model_EmptyName_Fail_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                Model model = new Model()
                {
                    Name = "",
                    Shape = _shapeLogic.GetShape("New Sphere 1"),
                    Material = _materialLogic.Get("New Material 1")
                };
            });
        }

        [TestMethod]
        public void Model_NameTrailingSpaces_Fail_Test()
        {
            Assert.ThrowsException<NameException>(() =>
            {
                Model model = new Model()
                {
                    Name = " Incorrect Model",
                    Shape = _shapeLogic.GetShape("New Sphere 1"),
                    Material = _materialLogic.Get("New Material 1")
                };
            });
        }
    }
}
