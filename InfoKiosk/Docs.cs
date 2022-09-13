using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoKiosk
{
    class Docs //Класс - Документы
    {
        //Свойство - Имя
        public string Name { get; set; }

        //Свойство - Адресс 
        public string Address { get; set; }

        //Конструктор
        public Docs(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
