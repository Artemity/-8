using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика_8
{
    interface IHuman // Объявляет интерфейс IHuman, который определяет пространство для классов, представляющих человека
    {
        string Name { get; set; }
        string Surname { get; set; }
    }
}
