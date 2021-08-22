using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential
{
    public class ClassCls
    {
        public const double PI = 3.1415926;
        public static int NextId = 42;
        public static ConsoleColor ConsoleColor = ConsoleColor.Red;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        static ClassCls()
        {
            Random randomGenerator = new Random();
            NextId = randomGenerator.Next(101, 999);
        }
        public ClassCls()
        { 
        }
        public ClassCls(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        //解构函数
        public void Deconstruct(out string firstName, out string lastName)
        {
            (firstName, lastName) = (FirstName, LastName);
        }
        public void Deconstruct(out string firstName, out string lastName, out int age)
        {
            (firstName, lastName, age) = (FirstName, LastName, 18);
        }

        public void Deconstruct(out int nextId, out ConsoleColor consoleColor, out string str, out string str1)
        {
            (nextId, consoleColor, str, str1) = (NextId, ConsoleColor, "", "");
        }


    }
}
