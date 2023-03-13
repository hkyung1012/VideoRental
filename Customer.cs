using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoRental
{
    class Customer
    {
        public Customer(string name)
        {
            customerName = name;
        }

        public void addRental(Rental arg) { customerRental.Add(arg); }
        public string getCustomerName() { return customerName; }

        public string printReceipt()
        {
            double totalAmount = 0.0;
            int frequentRenterPoints = 0;
            StringBuilder result = new StringBuilder();

            result.AppendLine("Rental Record for" + getCustomerName());


            IEnumerator<Rental> enumerator = customerRental.GetEnumerator();

            for (; enumerator.MoveNext();)
            {
                Rental each = enumerator.Current;
                Movie movie = each.getMovie();
                int daysRented = each.getDaysRented();

                double thisAmount = getAmount(movie, daysRented);

                // Add frequent renter points
                frequentRenterPoints++;

                // Add bonus for a two day new release rental
                if ((movie.getPriceCode() == Movie.NEW_RELEASE)
                        && daysRented > 1) frequentRenterPoints++;

                // Show figures for this rental
                result.AppendFormat("{0} {1} {2} {3}{4}", "\t", movie.getTitle(), "\t", thisAmount.ToString(), "\n");
                totalAmount += thisAmount;
            }

            result.AppendLine("Amount owed is " + totalAmount);
            result.AppendLine("You earned " + frequentRenterPoints + " frequent renter points");

            return result.ToString();
        }
        public string printReceiptList()
        {
            StringBuilder result = new StringBuilder();

            IEnumerator<Rental> rentalList = customerRental.GetEnumerator();
            for (; rentalList.MoveNext() ;)
            {
                Rental each = rentalList.Current;
                Movie movie = each.getMovie();
                int daysRented = each.getDaysRented();

                double thisAmount = getAmount(movie, daysRented);

                //출력형식 : (장르 제목 대여기간 가격)
                result.AppendFormat("{0} {1} {2} {3} {4} {5} {6}{7}", movie.getPriceCode().ToString(), "\t", movie.getTitle(), "\t", daysRented.ToString(), "\t", thisAmount.ToString(), "\n");
            }
            return result.ToString();
        }
        private double getAmount(Movie movie, int daysRented)
        {
            double thisAmount = 0.0;

            switch (movie.getPriceCode())
            {
                case Movie.REGULAR:
                    thisAmount += 2.0;
                    if (daysRented > 2)
                        thisAmount += (daysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5;
                    if (daysRented > 3)
                        thisAmount += (daysRented - 3) * 1.5;
                    break;
                case Movie.COMEDY:
                    thisAmount += 3.0;
                    break;
            }
            return thisAmount;
        }

        private string customerName;
        private List<Rental> customerRental = new List<Rental>();
    }
}