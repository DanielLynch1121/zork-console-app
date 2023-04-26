using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zork_console_app
{
    internal class SQLInjection : IHack
    {
        public string Name { get; } = "SQL-Injection";
        public int Damage { get; } = 10;
    }
}
