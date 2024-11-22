using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практика_8
{
    class FatherWorker : Workman, IHuman, IComparable, ICloneable // Объявляет класс FatherWorker, который наследует от класса Workman и реализует интерфейсы IHuman, IComparable и ICloneable.
    {
        public int Children { get; set; } // Свойство для хранения количества детей работника-отца с автоматическим созданием методов получения и установки.

        // Конструктор класса FatherWorker, который принимает параметры для инициализации свойств объекта.
        public FatherWorker(string initName, string initSurname, int initChildren, string initPosition)
            : base(initName, initSurname, initPosition) // Вызывает конструктор базового класса Workman для инициализации его свойств.
        {
            Children = initChildren; // Инициализирует свойство Children значением параметра initChildren.
        }

        // Переопределенный метод, возвращающий информацию о работнике-отце в виде строки.
        public new string EmployeeInformation()
        {
            string info = $" Фамилия: {Surname} \n Имя: {Name}  \n Должность: {Position} \n Кол-во детей: {Children}"; // Форматирует строку с информацией о работнике-отце.
            return info; // Возвращает сформированную строку с информацией.
        }

        // Метод WatherWorkerClone создает и возвращает копию текущего объекта FatherWorker.
        public FatherWorker WatherWorkerClone()
        {
            return (FatherWorker)this.MemberwiseClone(); // Использует метод MemberwiseClone() для создания поверхностной копии объекта.
        }

        // Метод Clone создаёт новый объект FatherWorker, инициализируя его свойствами текущего объекта.
        public new object Clone()
        {
            FatherWorker father = new FatherWorker(this.Name, this.Surname, this.Children, this.Position); // Создает новый объект FatherWorker с текущими значениями свойств.
            return father; // Возвращает новый скопированный объект.
        }
    }
}
