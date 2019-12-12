using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Paint
{
    // Группа примитивов
    public class Group
    {
        public List<Primitive> Primitives { get; }
        public string Name { get; set; }
        public bool Focused { get; set; }

        public Group(List<Primitive> InitialList, string n)
        {
            Primitives = InitialList;
            Name = n;
        }
    }
}
