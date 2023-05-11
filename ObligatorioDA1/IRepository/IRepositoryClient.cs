using Domain;

namespace IRepository
{
    public interface IRepositoryClient : IRepository<Client>
    {
        Client Get(string name);
    }
}