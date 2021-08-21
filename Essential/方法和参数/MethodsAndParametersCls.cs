using System;

namespace Essential
{
    public class MethodsAndParametersCls
    {
        public (string FirstName, string LastName, int Age) UseTupleReturnMultiValue()
        {
            string firstName = "FOO";
            string lastName = "BAR";
            int age = 18;
            return (firstName, lastName, age);
        }

        public string ExpressionBodyMethod(string firstName, string lastName) => $"{firstName}{lastName}";




    }
}
