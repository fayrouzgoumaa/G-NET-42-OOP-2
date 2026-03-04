using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
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
        }
    }
}
