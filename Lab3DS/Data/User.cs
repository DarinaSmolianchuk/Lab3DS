using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS.Data
{
    public class User
    {
        //Генератор айдішок
        private static int numberOfUsers = 0;
        private int ID { get; set; }

        //Ім'я, баланс та історія покупок
        private string name { get; set; }
        private int balance = 0;
        private List<History> histories{ get; set; }

        //Геттери і сеттери
        public int getID() { return ID; }
        public string getName() { return name; }
        public int getBalance() { return balance; }
        public List<History> getHistories() { return histories; }
        public void setBalance(int balance)
        {
            if (balance < 0)
                return;
            else
                this.balance = balance;
        }

        public void addToHistory(History history)
        {
            histories.Add(history);
        }

        public User(string name) 
        {
            ID = numberOfUsers++;
            this.name = name;
            histories = new List<History>();
        }

        //Метод зміни балансу
        public void addBalance(int plusBalance) 
        {
            if (plusBalance > 0)
                balance += plusBalance;
        }
    }
}
