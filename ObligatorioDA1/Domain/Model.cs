using System;
using System.Collections.Generic;
using System.Drawing;
using BusinessLogicExceptions;
using ValidationService;

namespace Domain
{
    public class Model
    {
        private string _name;
        public bool WantPreview { get; set; }
        public Bitmap Preview = null;
        public DateTime CreatedAt { get; set; }
        public int Id { get; set; }
        public Shape Shape { get; set; }
        public Material Material { get; set; }
        public Client Client { get; set; }


        public Model()
        {
            CreatedAt = DateTime.Now;
        }

        public string ModelName
        {
            get => _name;
            set
            {
                if (value.IsEmpty()) ThrowEmptyName();
                if (value.HasTrailingSpaces()) ThrowHasTrailingSpaces();
                _name = value;
            }
        }

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