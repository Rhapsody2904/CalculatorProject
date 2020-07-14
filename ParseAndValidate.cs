/*Author: Milda Willoughby
 * Class: ParseAndValidate object
 * Purpose: Validates and parses out an input string. Provides methods for accessing the different components of the string.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calculator_Project
{
    class ParseAndValidate
    {
        String input;
        char[] actions = { '+', '-', '*', '/' }; //possible mathematical operations
        String[] ops = new String[2]; //stores the two operands
        char action;
        bool isValid = false; //validation flag

        //constructor
        public ParseAndValidate(String strIn)
        {
            this.input = strIn;
            parse();
        }

        //method to parse out the input string. Handles negative numbers
        private void parse()
        {
            //use regular expression to quickly validate input
            Regex rx = new Regex(@"^[\-\-]?\d+\.?\d*\s*[\*\/\+\-]{1}\s*[\-\-]?\d+\.?\d*$"); //allow to use a hyphen or minus sign
                                                                                           //for negative numbers
            //check if input matched the regex pattern
            if (rx.IsMatch(input))
            {
                    isValid = true;
            }
            else
            {
                isValid = false;
                Console.WriteLine("Error: Invalid input.");
                return; //go back to calling method for new input
            } 

            for ( int i = 0; i < input.Length; i++)
            {
                if (i == 0 && input[i].Equals('-')) //ignore the minus sign if it belongs to the first operand
                    i++;

                //get operator
                if (actions.Contains(input[i]))
                {
                    action = input[i];
                    break;
                }   
            }
            //special logic to handle subtracting negative numbers:
            if (action.Equals('-') && input.Split('-').Length-1 > 1) 
            {
                int i = 0;
                String op1 = "";
                String op2 = "";

                //check if operand1 is negative
                if (input[0].Equals('-'))
                {
                    op1 += input[i];
                    i++;   
                }
                
                //build operand1
                while(!input[i].Equals('-'))
                {
                    op1 += input[i];
                    i++;
                }

                i++; //move past operator;

                //build operand2
                while (i <= input.Length - 1)
                {
                    op2 += input[i];
                    i++;
                }

                //drop the operands into the array
                ops[0] = op1;
                ops[1] = op2;

            }
            else //if not subtracting negatives, simply split out the operands using operator as delimeter
                ops = input.Split(action);
        }

        //returns a flag on whether the input was valid or not
        public bool validate()
        {
            return isValid;
        }

        public double getOperand1()
        {
            return double.Parse(ops[0], System.Globalization.NumberStyles.AllowLeadingSign |
                                        System.Globalization.NumberStyles.AllowDecimalPoint |
                                        System.Globalization.NumberStyles.AllowTrailingWhite |
                                        System.Globalization.NumberStyles.AllowLeadingWhite);
        }

        public double getOperand2()
        {
            return double.Parse(ops[1], System.Globalization.NumberStyles.AllowLeadingSign |
                                        System.Globalization.NumberStyles.AllowDecimalPoint |
                                        System.Globalization.NumberStyles.AllowTrailingWhite |
                                        System.Globalization.NumberStyles.AllowLeadingWhite);
        }

        public char getOperator()
        {
            return action;
        }
    }
}
