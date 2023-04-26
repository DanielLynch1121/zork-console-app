using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zork_console_app
{
    internal class DDoS : IHack
    {
        public string Name { get; } = "DDoS";
        public int Damage { get; } = 15;
    }
}
