using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3DS.Data
{
    public class History
    {
        //Генератор айдішок
        private static int numberOfPurchases = 0;
        private int ID { get; set; }

        //Хто купив і що саме
        private int userID { get; set; }
        private int productID { get; set; }
        private DateTime dateOfPurchase { get; set; }

        //Геттери
        public int getID() { return ID; }
        public int getUserID() { return userID; }
        public int getProductID() { return productID; }
        public DateTime getDateOfPurchase() { return dateOfPurchase; }


        //Сеттери не потрібні, бо не змінюємо інформацію в історії

        public History(int userID, int productID) 
        {
            ID = numberOfPurchases++;
            this.userID = userID;
            this.productID = productID;
            dateOfPurchase = DateTime.Now;
        }
    }
}