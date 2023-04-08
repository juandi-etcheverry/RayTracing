namespace BusinessLogic
{
    public interface IDataEntity
    {
        bool AreNamesEqual(IDataEntity other);
        void ThrowNameExists();
    }
}