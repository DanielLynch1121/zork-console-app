using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zork_console_app
{
    internal class Doomsday : IHack
    {
        public string Name { get; } = "Doomsday";
        public int Damage { get; } = 20;
    }
}
