using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_lessons_app
{
    class InvalidSizeExeption : Exception
    {
        public double size;
        public InvalidSizeExeption(string message, double _size) : base(message)
        {
            size = _size;
        }
    }

    class InvalidColorExeption : Exception
    {
        public string color;
        public InvalidColorExeption(string message, string _color) : base(message)
        {
            color = _color;
        }
    }
}
