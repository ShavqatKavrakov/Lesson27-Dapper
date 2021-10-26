using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson27
{
    internal class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return $"{Id}. {Name} {Price}";
        }
    }
}
