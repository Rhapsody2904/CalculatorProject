/*Author: Milda Willoughby
 * Program: driver for Project one
 * Purpose: instantiates the ParseAndValidate and Calculator objects. Performs simple calculations (+,-,/,*) with two numbers.
 *          Has some error checking and handling. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isDone = false;
            double op1 = 0;
            double op2 = 0;
            char x = '~';
            String input;
            bool isValid = false;
            do
            {
                do
                {
                    Console.WriteLine("Please enter the mathematical calculation you want to complete or enter 0 to quit:");
                    Console.Write("Input: ");
                    input = Console.ReadLine();

                    if (input.Length > 0)
                    {
                        if (input.Equals("0"))
                        {
                            isDone = true;
                            System.Environment.Exit(0);
                        }

                        //validate input and parse out the operator and operands
                        ParseAndValidate equation = new ParseAndValidate(input);
                        isValid = equation.validate(); //check if imput was valid

                        //check for division by 0
                        if (isValid)
                        {
                            op1 = equation.getOperand1();
                            op2 = equation.getOperand2();
                            x = equation.getOperator();
                            if (op2 == 0 && x == '/')
                            {
                                Console.WriteLine("Division by zero not allowed.");
                                isValid = false;
                            }
                        }
                    }
                } while (!isValid);

                //create a calculator object and perform calculation
                if (isValid)
                {
                    Calculator a = new Calculator(op1, op2, x);
                    Console.WriteLine(input + " = " + a.calculate());
                    isValid = false; //reset for next entry
                }
            } while (!isDone);
  
        }
    }
}
