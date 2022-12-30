using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS.Data
{
    public class Product
    {
        //Генератор айдішок. Починається 1 для кращого сприйняття користувачем в консолі
        private static int numberOfProducts = 1;
        private int ID { get; set; }
        //Назва, ціна, кількість на складі
        private string productName { get; set; }
        private int price { get; set; }
        private int count { get; set; }

        //Геттери і сеттери
        public int getID() { return ID; }
        public string getProductName() { return productName; }
        public int getPrice() { return price; }
        public int getCount() { return count; }
        public void setCount( int count ) 
        {
            if (count < 0)
                return;
            else
                this.count = count;
        }

        //Конструктор
        public Product(string productName, int price, int count)
        {
            ID = numberOfProducts++;
            //Товару на складі не може бути менше 0
            if (count >= 0)
                this.count = count;
            else
                this.count = 0;

            //Ціна не може бути нульовою
            if (price < 0)
            {
                this.count = 0;
                this.price = 0;
            }
            else
            {
                this.price = price;
            }

            this.productName = productName;
        }

        //Перевизначення функції для нормального виведення
        public override string ToString()
        {
            return ID + ". " + productName + ".\t\tЦiна: " + price + "\tгрн.\t\tКiлькiсть на складi: " + count + ".";
        }
    }
}