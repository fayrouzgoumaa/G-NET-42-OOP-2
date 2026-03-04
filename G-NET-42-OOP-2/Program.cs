using System;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace G_NET_42_OOP_2
{
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double Area
        {
            get { return Width * Height; }
        }
    }
    public enum TicketType
    {
        Standard = 0,
        VIP = 1,
        IMAX = 2
    }
    public struct SeatLocation
    {
        public char Row { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return $"Row: {Row}, Seat: {Number}";
        }
    }

    public class Ticket
    {
        private static int ticketCounter = 0;

        private string movieName;
        private TicketType type;
        private SeatLocation seat;
        private double price;

        public string MovieName
        {
            get { return movieName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    movieName = value;
            }
        }

        public TicketType Type
        {
            get { return type; }
            set { type = value; }
        }

        public SeatLocation Seat
        {
            get { return seat; }
            set { seat = value; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
            }
        }
        public double PriceAfterTax
        {
            get { return price * 1.14; }
        }
        public int TicketId { get; }

        public Ticket(string movieName, TicketType type, SeatLocation seat, double price)
        {
            ticketCounter++;
            TicketId = ticketCounter;

            MovieName = movieName;
            Type = type;
            Seat = seat;
            Price = price;
        }
        public static int GetTotalTicketsSold()
        {
            return ticketCounter;
        }
    }
    public class Cinema
    {
        private Ticket[] tickets = new Ticket[20];

        // Indexer
        public Ticket this[int index]
        {
            get
            {
                if (index >= 0 && index < tickets.Length)
                    return tickets[index];
                return null;
            }
            set
            {
                if (index >= 0 && index < tickets.Length)
                    tickets[index] = value;
            }
        }
        public bool AddTicket(Ticket t)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = t;
                    return true;
                }
            }
            return false;
        }
        public Ticket GetMovieByName(string movieName)
        {
            foreach (var ticket in tickets)
            {
                if (ticket != null && ticket.MovieName.Equals(movieName, StringComparison.OrdinalIgnoreCase))
                    return ticket;
            }
            return null;
        }
    }
    public static class BookingHelper
    {
        private static int bookingCounter = 0;

        public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
        {
            double total = numberOfTickets * pricePerTicket;

            if (numberOfTickets >= 5)
                return total * 0.9;   // 10% discount

            return total;
        }

        public static string GenerateBookingReference()
        {
            bookingCounter++;
            return $"BK-{bookingCounter}";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1
            //a-
            //    Public fields
            //    No validation in Withdraw
            //b- How to fix it
            //    Make fields private
            //     Use properties
            //    Add validation in Withdraw
            //c) Why Public Fields Are Bad Practice
            //    Breaks encapsulation
            //    Breaks encapsulation
            //    Hard to maintain

            #endregion
            #region Q2
            //-Field
            //    Variable inside class
            //    -Stores data
            //    Usually private
            //    No built-in validation
            //-Property
            //    Provides controlled access to field
            //    Uses get and set
            //    Can contain logic
            //Can a Property Contain Logic ?
            //         Yes.
            Rectangle r = new Rectangle { Width = 5, Height = 4 };
            Console.WriteLine(r.Area);  // 20
            #endregion
            #region Q3
            //    a) What is this[int index] called? 
            //            It is called an Indexer in C#.

            //    Purpose:
            //            An indexer allows an object to be accessed like an array.
            //    b) What happens if someone writes register[10] = "Ali";?
            //            It will throw >> IndexOutOfRangeException Because index 10 does not exist.
            //   How to make it safer?
            //         add validation inside the indexer:
            //c) Can a class have more than one indexer?
            //    Yes
            #endregion
            #region Q4
            //    a- The static keyword means the variable belongs to the class itself, not to individual objects.
            //   - There is only one copy of TotalOrders
            //    It is shared between all objects
            //        it is accessed using the class name :
            //b) No
            //Why?

            //Because:
            //    Item is an instance field
            //    Static methods belong to the class, not to a specific object
            //    Static methods do not know which object’s Item to access
            #endregion
            Cinema cinema = new Cinema();

            Console.WriteLine("========== Ticket Booking ==========\n");

            // Enter 3 Tickets
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter data for Ticket {i + 1}:");

                Console.Write("Movie Name: ");
                string name = Console.ReadLine();

                Console.Write("Ticket Type (0-Standard, 1-VIP, 2-IMAX): ");
                int typeInput = int.Parse(Console.ReadLine());
                TicketType type = (TicketType)typeInput;

                Console.Write("Seat Row (A-Z): ");
                char row = char.Parse(Console.ReadLine().ToUpper());

                Console.Write("Seat Number: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                SeatLocation seat = new SeatLocation
                {
                    Row = row,
                    Number = number
                };

                Ticket ticket = new Ticket(name, type, seat, price);
                cinema.AddTicket(ticket);

                Console.WriteLine();
            }

            // Print Tickets
            Console.WriteLine("\n----- All Tickets -----\n");

            for (int i = 0; i < 3; i++)
            {
                Ticket t = cinema[i];

                if (t != null)
                {
                    Console.WriteLine($"Ticket ID: {t.TicketId}");
                    Console.WriteLine($"Movie Name: {t.MovieName}");
                    Console.WriteLine($"Type: {t.Type}");
                    Console.WriteLine($"Seat: {t.Seat}");
                    Console.WriteLine($"Price: {t.Price}");
                    Console.WriteLine($"Price After Tax: {t.PriceAfterTax:F2}");
                    Console.WriteLine("----------------------------");
                }
            }

            // Search Movie
            Console.Write("\nEnter movie name to search: ");
            string searchName = Console.ReadLine();

            Ticket found = cinema.GetMovieByName(searchName);

            if (found != null)
                Console.WriteLine($"Movie found! Ticket ID: {found.TicketId}");
            else
                Console.WriteLine("Movie not found.");

            // Total tickets sold
            Console.WriteLine($"\nTotal Tickets Sold: {Ticket.GetTotalTicketsSold()}");

            // Generate booking references
            Console.WriteLine("\nGenerated Booking References:");
            Console.WriteLine(BookingHelper.GenerateBookingReference());
            Console.WriteLine(BookingHelper.GenerateBookingReference());

            // Group discount
            double discounted = BookingHelper.CalcGroupDiscount(5, 80);
            Console.WriteLine($"\nGroup price for 5 tickets at 80 EGP each: {discounted} EGP");
        }
    }
}
