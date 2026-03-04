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
        }
    }
}
