using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS.Data
{
    public class SafeInput
    {
        //Клас для введення чисел без помилок
        public static int readInt()
        {
            int? data = null;
            do
            {
                string line = Console.ReadLine().Trim();
                try
                {
                    data = int.Parse(line);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неправильно введено!");
                };
            } while (data == null);
            return (int)data;
        }
    }
}
