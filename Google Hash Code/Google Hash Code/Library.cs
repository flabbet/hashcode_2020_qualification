using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Hash_Code
{
    public class Library
    {
        public int AmountOfBooks { get; set; }
        public int SignupProcessTime { get; set; }
        public int ShippingCapacityPerDay { get; set; }
        public int Points { get; set; }
        public int Id { get; set; }

        public List<Book> Books { get; set; }

        public Library(int amountOfBooks, int signupProcessTime, int shippingCapacityPerDay)
        {
            AmountOfBooks = amountOfBooks;
            SignupProcessTime = signupProcessTime;
            ShippingCapacityPerDay = shippingCapacityPerDay;
        }
    }
}
