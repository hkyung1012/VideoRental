using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoRental
{
    class Program  
    {
        static void Main(string[] args)
        {
            Movie regular1 = new Movie("일반 1", Movie.REGULAR);
            Movie regular2 = new Movie( "일반 2", Movie.REGULAR);
            Movie newRelease1 = new Movie( "신작 1", Movie.NEW_RELEASE );
            Movie newRelease2 = new Movie( "신작 2",Movie.NEW_RELEASE );
            Movie children1 = new Movie( "어린이 1", Movie.CHILDRENS );
            Movie children2 = new Movie( "어린이 2", Movie.CHILDRENS );
            Movie comedy1 = new Movie("코미디 1", Movie.COMEDY);
            Movie comedy2 = new Movie("코미디 2", Movie.COMEDY);

            Customer customer = new Customer("고객");

            customer.addRental(new Rental( regular1, 2 ));
            customer.addRental(new Rental( regular2, 3 ));
            customer.addRental(new Rental( newRelease1, 1 ));
            customer.addRental(new Rental( newRelease2, 2 ));
            customer.addRental(new Rental( children1, 3 ));
            customer.addRental(new Rental( children2, 4 ));
            customer.addRental(new Rental( comedy1, 1 ));
            customer.addRental(new Rental( comedy2, 2 ));

            Console.WriteLine(customer.printReceipt());
            Console.WriteLine(customer.printReceiptList());
        }
    }
}
