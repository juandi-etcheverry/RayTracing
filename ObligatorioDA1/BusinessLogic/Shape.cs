using System.Net.Http;

namespace BusinessLogic
{
    public class Shape
    {
        private string _name { get; set; }
        public string Name { get; set; }
        public string Owner {  get;  private set; }

        public bool AreNamesEqual(Shape other) 
        {
            return this.Name == other.Name;
        }
        public void ThrowNameExists() 
        {
            throw new UniqueNameException ("Shape name already exists");
        }
        public void ThrowEmptyName()
        {
            throw new EmptyNameException("Shape Name can't be empty");
        }
    }
}