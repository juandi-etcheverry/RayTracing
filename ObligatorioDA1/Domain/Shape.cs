using BusinessLogic.Utils;
using BusinessLogicExceptions;

namespace Domain
{
    public class Shape
    {
        private string _name { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (value.IsEmpty()) ThrowEmptyName();
                if (value.HasTrailingSpaces()) ThrowHasTrailingSpaces();
                _name = value;
            }
        }

        public string Owner { get; private set; }

        public bool AreNamesEqual(Shape other)
        {
            return this.Name == other.Name;
        }
        public void ThrowNameExists()
        {
            throw new NameException("Shape name already exists");
        }
        public void ThrowEmptyName()
        {
            throw new NameException("Shape Name can't be empty");
        }
        public void ThrowHasTrailingSpaces()
        {
            throw new NameException("Shape Name can't have trailing spaces");
        }
        public void ThrowNotInList()
        {
            throw new NotFoundException("The shape is not in list");
        }
        public virtual void SpecificShapeValidator() { }

    }
}