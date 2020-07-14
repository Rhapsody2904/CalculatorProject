/*Author: Milda Willoughby
 * Class: Calculator
 * Purpose: Creates a calculator object. Constructor takes two doubles and a char and enables user to perform
 *          simple mathematical equations (+,-,/,*).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Project
{
    class Calculator
    {
        double op1, op2;
        char action;

        //Constructor
        public Calculator(double a, double b, char x)
        {
            op1 = a;
            op2 = b;
            action = x;
        }

        //Method that calls the approriate calculation method based on the operator
        public double calculate()
        {
            double result;

            switch (action)
            {
                case '+':
                  result = add();
                    break;
                case '-':
                   result = subtract();
                    break;
                case '*':
                   result = multiply();
                    break;
                default:
                   result = divide();
                    break;
            }

            return result;
        }

        //private methods for handling the math

        private double add()
        {
            return op1 + op2;
        }

        private double subtract()
        {
            return op1 - op2;
        }

        private double multiply()
        {
            return op1 * op2;
        }

        private double divide()
        {
            return op1 / op2;
        }
    }
}
