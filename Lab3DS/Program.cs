using Lab3DS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Створюємо магазин
            Shop shop = new Shop();
            //Примушуємо працювати
            shop.Work();

        }
    }
}