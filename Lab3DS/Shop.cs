using Lab3DS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS
{
    public class Shop
    {
        private DBContext database;

        public Shop()
        {
            //У нового магазина створюємо нову базу даних
            database = new DBContext();
        }

        //Метод 'Працювати'
        public void Work()
        {
            string username;
            int temporaryNumber = 0;

            do
            {
                //Виводимо інформацію про програму та просимо ввести юзернейм
                do
                {
                    Console.Clear();
                    Console.WriteLine("Вас вiтає Магазин.\nВведiть iм'я користувача (2-15 символiв).\nЯкщо бажаєте вийти -- введiть exit");
                    username = Console.ReadLine();
                    Console.Clear();
                    if (username == "exit")
                    {
                        Console.Clear();
                        Console.WriteLine("Магазин зачинився :с Приходьте завтра");
                        Console.ReadLine();
                        return;
                    }
                } while (username == "" || username.Length < 2 || username.Length > 15);

                //Отримуємо нашого користувача
                //Якщо такого немає, то створюється
                database.getUser(username);

                do
                {
                    //Вибір функції
                    //Основне меню
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Вiтаємо, " + username + "! " + " Ваш баланс: " + database.getUser(username).getBalance() +
                            "\nЩо бажаєте зробити?\n1. Поповнити рахунок.\n2. Перейти до покупок.\n3. Переглянути iсторiю покупок.\n4. Вийти.");
                        temporaryNumber = SafeInput.readInt();
                    } while (temporaryNumber < 1 || temporaryNumber > 4);

                    switch (temporaryNumber)
                    {
                        //Поповнення рахунку.
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Поповнення рахунку.\nВведiть бажану суму поповнення:");
                            int summ = SafeInput.readInt();
                            //Змінюємо користувачу в базі даних баланс
                            database.getUser(username).addBalance(summ);
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Для покупки введiть ID товару.");
                            Console.WriteLine("Ваш баланс: " + database.getUser(username).getBalance() + " гривень.\n");
                            outputProductsList();
                            Console.Write("\n\t\t\t\t\t\t\t\t<<Вихiд з каталогу -- 0 >>\n");
                            int index;
                            //Покупка
                            do
                            {
                                index = SafeInput.readInt();
                                if (index == 0)
                                    break;

                                Console.Clear();
                                tryBuy(database.getUser(username).getID(), index);
                                Console.WriteLine("\nДля покупки введiть ID товару.");
                                Console.WriteLine("Ваш баланс: " + database.getUser(username).getBalance() + " гривень.\n");
                                outputProductsList();
                                Console.Write("\n\t\t\t\t\t\t\t\t<<Вихiд з каталогу -- 0 >>\n");
                            } while (index != 0);
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Iсторiя покупок користувача " + username + ":");
                            database.getUserHistory(database.getUser(username).getID());
                            Console.WriteLine("Для повернення назад -- натиснiть ENTER.");
                            Console.ReadLine();
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("Дякуємо, що скористались магазином!");
                            Console.WriteLine("Для повторного входу -- натиснiть ENTER.");
                            Console.ReadLine();
                            break;
                    }
                } while (temporaryNumber != 4);
            } while (username != "exit");
        }



        //Купівля товару
        private void tryBuy(int userID, int productID)
        {
            //Якщо введено неправильно айді
            if (productID > database.Products.Count() || productID < 1)
            {
                Console.WriteLine("\t<<<УВАГА>>>\n\tПомилка! Товар не iснує!");
                return;
            }

            //Якщо товар закінчився
            if (database.Products[productID - 1].getCount() == 0)
            {
                Console.WriteLine("\t<<<УВАГА>>>\n\tПомилка! Товар закiнчився!");
                return;
            }

            //Якщо у користувача недостатньо грошей
            if (database.Products[productID - 1].getPrice() > database.Users[userID].getBalance())
            {
                Console.WriteLine("\t<<<УВАГА>>>\n\tНедостатньо коштiв! Поповнiть особистий рахунок та повторiть спробу!");
                return;
            }

            //Тепер можна і купити, якщо все в порядку
            History history = new History(userID, productID);

            //Змінюємо кількість товару і баланс
            database.Products[productID - 1].setCount(database.Products[productID - 1].getCount() - 1);
            database.Users[userID].setBalance(database.Users[userID].getBalance() - database.Products[productID - 1].getPrice());

            //Робимо запис в історію
            database.Histories.Add(history);
            database.Users[userID].addToHistory(history);
            Console.WriteLine("\t<<<HОВЕ ПОВIДОМЛЕННЯ>>>\n\tУспiшно куплено " + database.Products[productID - 1].getProductName() + "!");
        }

        //Виведення списку продуктів
        public void outputProductsList()
        {
            foreach (Product product in database.Products)
                Console.WriteLine(product.ToString());
        }

    }
}
