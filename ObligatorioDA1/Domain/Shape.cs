using BusinessLogicExceptions;
using ValidationService;

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

        public string OwnerName { get; set; }

        public bool AreNamesEqual(string otherName)
        {
            return _name.ToLower() == otherName.ToLower();
        }

        public bool AreNamesEqual(Shape otherShape)
        {
            return AreNamesEqual(otherShape.Name);
        }

        public static void ThrowNameExists()
        {
            throw new NameException("Shape name already exists");
        }

        public static void ThrowEmptyName()
        {
            throw new NameException("Shape Name can't be empty");
        }

        public static void ThrowHasTrailingSpaces()
        {
            throw new NameException("Shape Name can't have trailing spaces");
        }

        public static void ThrowNotFound()
        {
            throw new NotFoundException("The shape is not in list");
        }

        public static void ThrowClientNotLoggedIn()
        {
            throw new SessionException("Client not logged in");
        }

        public static void ThrowShapeReferencedByModel()
        {
            throw new AssociationException("Shape is already being used by a Model.");
        }
    }
}