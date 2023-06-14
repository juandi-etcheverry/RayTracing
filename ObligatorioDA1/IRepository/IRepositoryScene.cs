using Domain;

namespace IRepository
{
    public interface IRepositoryScene : IRepository<Scene>
    {
        Scene Get(int id);
        void AddModel(Scene scene, PositionedModel model);
        void DeleteModel(Scene scene, PositionedModel model);
        PositionedModel GetModel(Scene scene, int idModel);
    }
}