using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика_8
{
    class Workman : IHuman, IComparable, ICloneable // Объявляет класс Workman, реализующий интерфейсы IHuman, IComparable и ICloneable.
    {
        public string Name { get; set; } // Свойство для хранения имени работника, с автоматическим созданием методов получения и установки.
        public string Surname { get; set; } // Свойство для хранения фамилии работника.
        public string Position { get; set; } // Свойство для хранения должности работника.

        // Конструктор класса Workman, который принимает параметры для инициализации свойств объекта.
        public Workman(string initName, string initSurname, string initPosition)
        {
            Name = initName; // Инициализирует свойство Name значением параметра initName.
            Surname = initSurname; // Инициализирует свойство Surname значением параметра initSurname.
            Position = initPosition; // Инициализирует свойство Position значением параметра initPosition.
        }

        // Метод, возвращающий информацию о работнике в виде строки.
        public string EmployeeInformation()
        {
            string info = $" Фамилия: {Surname} \n Имя: {Name}  \n Должность: {Position} \n Кол-во детей: 0"; // Форматирует строку с информацией о работнике.
            return info; // Возвращает сформированную строку с информацией.
        }

        // МетодWorkmanClone создает и возвращает копию текущего объекта Workman.
        public Workman WorkmanClone()
        {
            return (Workman)this.MemberwiseClone(); // Использует метод MemberwiseClone() для создания поверхностной копии объекта.
        }

        // Метод Clone создаёт новый объект Workman, инициализируя его свойствами текущего объекта.
        public object Clone()
        {
            Workman workman = new Workman(this.Name, this.Surname, this.Position); // Создает новый объект Workman с текущими значениями свойств.
            return workman; // Возвращает новый скопированный объект.
        }

        // Метод CompareTo сравнивает текущий объект с другим объектом на основе фамилии.
        public int CompareTo(object obj)
        {
            Workman other = (Workman)obj; // Приводит переданный объект к типу Workman для сравнения.
            if (this.Surname == other.Surname) return 0; // Если фамилии одинаковы, возвращает 0 (значения равны).
            else return -1; // Если фамилии различаются, возвращает -1 (то есть текущая фамилия меньше).
        }
    }
}
