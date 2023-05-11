using System;
using System.Drawing;
using BusinessLogicExceptions;
using ValidationService;

namespace Domain
{
    public class Model
    {
        private string _name;
        public bool WantPreview;
        public Bitmap Preview = null;
        public DateTime CreatedAt = DateTime.Now;

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

        public Shape Shape { get; set; }

        public Material Material { get; set; }

        public string OwnerName { get; set; }

        private void ThrowEmptyName()
        {
            throw new NameException("Model name can't be empty");
        }

        private void ThrowHasTrailingSpaces()
        {
            throw new NameException("Model name can't have trailing spaces");
        }
    }
}