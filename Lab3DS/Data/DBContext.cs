using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS.Data
{
    //Наша база даних. Саме вона відповідає за взаємодію даних
    public class DBContext
    {
        //Список всіх користувачів
        public List<User> Users { get; set; }

        //Історія покупок. Хто купив і що саме
        public List<History> Histories { get; set; }

        //Список продуктів
        public List<Product> Products { get; set; }

        //Конструктор
        public DBContext()
        {
            Users = new List<User>();
            Histories = new List<History>();
            Products = new List<Product>
            {
                new Product("Яблуко червоне", 10, 113),
                new Product("Xlaomi Note 8T", 6199, 3),
                new Product("Генератор (бенз.)", 79900, 1),
                new Product("Скретч-карта", 1000, 10),
                new Product("Коробка свiчок", 10, 34),
                new Product("Радiо радянське", 860, 9),
                new Product("Хом'ячок плюшевий", 249, 17),
                new Product("Монiтор Asus 24`", 6499, 7)
            };
        }

        //Метод для отримування користувача
        //Якщо користувач не існує -- створюємо нового і додаємо в БД.
        public User getUser(String username)
        {
            foreach (User user in Users)
            {
                if (user.getName() == username)
                    return user;
            }

            //Якщо нема, то додаємо
            Users.Add(new User(username));
            return Users[Users.Count - 1];
        }

        //Історія покупок користувача
        public void getUserHistory(int userID) 
        {
            //Якщо покупок не було
            if (Users[userID].getHistories().Count() == 0) 
            {
                Console.WriteLine("Покупок ще не було!");
                return;
            }

            //Якщо були -- виводимо
            Console.WriteLine("Зроблено " + Users[userID].getHistories().Count() + " покупок!");
            Console.WriteLine("ID:\tДата покупки:\t\tТовар:");
            foreach (History history in Histories) 
            {
                if (history.getUserID() == userID)
                    Console.WriteLine(history.getID() + ".\t" + history.getDateOfPurchase() + ".\t" + Products[history.getProductID() - 1].getProductName() + ".");
            }
        }
    }
}