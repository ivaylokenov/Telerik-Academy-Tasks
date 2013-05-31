using System;
using System.Collections;

class ShuntingYard
{
    static readonly string[] Numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ".", "~" };
    static readonly string[] Operators = { "+", "-", "*", "/" };

    // checks if a character is number
    static bool IsNumber(string character)
    {
        bool charIsNumber = false;

        for (int i = 0; i < Numbers.Length; i++)
        {
            if (Numbers[i] == character)
            {
                charIsNumber = true;
            }
        }

        return charIsNumber;
    }

    // checks if a character is operator
    static bool IsOperator(string character)
    {
        bool charIsOperator = false;

        for (int i = 0; i < Operators.Length; i++)
        {
            if (Operators[i] == character)
            {
                charIsOperator = true;
            }
        }

        return charIsOperator;
    }

    // checks precedence of two operators
    static int Precedence(string operatorChar)
    {
        if (operatorChar == "+" || operatorChar == "-")
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    // converts to decimal from string
    static decimal ConvertToDecimal(string input)
    {
        string output = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '~')
            {
                output += "-";
            }
            else
            {
                output += input[i];
            }
        }

        decimal result = decimal.Parse(output);
        return result;
    }

    // adds ( ) to functions
    static string AddPar(string input)
    {
        string[] separatedString = input.Split(' ');
        string result = string.Empty;
        bool isFunction = false;
        int leftCount = 0;
        int rightCount = 0;

        for (int i = 0; i < separatedString.Length; i++)
        {
            if (separatedString[i] == "ln" || separatedString[i] == "sqrt" || separatedString[i] == "pow")
            {
                isFunction = true;
                result += " ( ";
            }

            if (isFunction && separatedString[i] == "(")
            {
                leftCount++;
            }

            if (isFunction && separatedString[i] == ")")
            {
                rightCount++;
            }

            result += separatedString[i] + " ";

            if (isFunction && rightCount == leftCount && leftCount != 0)
            {
                isFunction = false;
                leftCount = 0;
                rightCount = 0;
                result += " ) ";
            }
        }

        return result;
    }

    static void Main()
    {
        Console.Title = "Calculator";

        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("This program calculates a math expression");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Available commands:");
        Console.WriteLine();
        Console.WriteLine("Positivie real numbers:     5.4 4 .6 ");
        Console.WriteLine("Negative real numbers:      ~5.4 ~4 ~.6 (written with ~ instead of -)");
        Console.WriteLine("Arithmetic operations:      + - * /");
        Console.WriteLine("Mathematical functions:     ln(x) sqrt(x) pow(x,y)");
        Console.WriteLine("Brackets:                   ( )");
        Console.WriteLine();

        Stack operators = new Stack();
        Queue output = new Queue();

        Console.Write("Input: ");
        string input = Console.ReadLine();
        input += "    ";

        string convertedInput = input[0].ToString();
        string previousChar = " ";
        string currentChar = " ";

        if (IsNumber(input[0].ToString()))
        {
            previousChar = "number";
        }

        if (IsOperator(input[0].ToString()))
        {
            previousChar = "operator";
        }

        // convert the input to have spaces
        for (int i = 1; i < input.Length - 4; i++)
        {
            if (input[i].ToString() == ",")
            {
                currentChar = "comma";
            }

            if (IsNumber(input[i].ToString()))
            {
                currentChar = "number";
            }

            if (IsOperator(input[i].ToString()))
            {
                currentChar = "operator";
            }

            if (input[i].ToString() == "(" || input[i].ToString() == ")")
            {
                currentChar = " ";
                convertedInput += " ";
            }

            if (input[i].ToString() == " ")
            {
                currentChar = " ";
            }

            if (input[i].ToString() + input[i + 1].ToString() == "ln")
            {
                currentChar = "function";
                convertedInput += " ln ";
                i += 2;
            }

            if (input[i].ToString() + input[i + 1].ToString() + input[i + 2].ToString() + input[i + 3].ToString() == "sqrt")
            {
                currentChar = "function";
                convertedInput += " sqrt ";
                i += 4;
            }

            if (input[i].ToString() + input[i + 1].ToString() + input[i + 2].ToString() + input[i + 3].ToString() == "sqrt")
            {
                currentChar = "function";
                convertedInput += " sqrt ";
                i += 4;
            }

            if (input[i].ToString() + input[i + 1].ToString() + input[i + 2].ToString() == "pow")
            {
                currentChar = "function";
                convertedInput += " pow ";
                i += 3;
            }

            if (currentChar == previousChar)
            {
                convertedInput += input[i];
            }
            else if (input[i].ToString() == " ")
            {
                currentChar = " ";
                convertedInput += " " + input[i];
            }
            else
            {
                convertedInput += " " + input[i];
            }

            previousChar = currentChar;
        }

        convertedInput = AddPar(convertedInput);

        // Console.WriteLine(convertedInput);

        // separate the input into tokens
        string[] separatedInput = convertedInput.Split(' ');
        object current;

        // convert to RPN
        for (int i = 0; i < separatedInput.Length; i++)
        {
            if (separatedInput[i] == string.Empty)
            {
                continue;
            }
            else if (IsNumber(separatedInput[i].Substring(0, 1))) 
            {
                // add number to output
                output.Enqueue(separatedInput[i]);
            }
            else if (separatedInput[i] == "ln" || separatedInput[i] == "sqrt" || separatedInput[i] == "pow")
            {
                // add function to stack
                operators.Push(separatedInput[i]);
            }
            else if (separatedInput[i] == ",")
            {
                if (operators.Contains("(") && operators.Count != 0)
                {
                    while (operators.Peek() != "(")
                    {
                        current = operators.Pop();
                        output.Enqueue(current);

                        // i++;
                    }
                }
                else
                {
                    Console.WriteLine("Separator ',' was misplaced or parentheses () were mismatched");
                    return;
                }
            }
            else if (IsOperator(separatedInput[i].Substring(0, 1)))
            {
                if (operators.Count != 0)
                {
                    string currentOperator = operators.Peek().ToString();
                    int firstOperatorPrecedence = Precedence(separatedInput[i]);
                    int secondOperatorPrecedence = Precedence(operators.Peek().ToString());
                    bool isTrue = IsOperator(currentOperator) && (firstOperatorPrecedence <= secondOperatorPrecedence);
                    while (isTrue && operators.Count != 0)
                    {
                        current = operators.Pop();
                        output.Enqueue(current);
                        if (operators.Count == 0)
                        {
                            break;
                        }

                        // i++;
                        currentOperator = operators.Peek().ToString();
                        firstOperatorPrecedence = Precedence(separatedInput[i]);
                        secondOperatorPrecedence = Precedence(operators.Peek().ToString());
                        isTrue = IsOperator(currentOperator) && (firstOperatorPrecedence <= secondOperatorPrecedence);
                    }
                }

                operators.Push(separatedInput[i]);
            }
            else if (separatedInput[i] == "(")
            {
                operators.Push("(");
            }
            else if (separatedInput[i] == ")")
            {
                if (operators.Contains("(") && operators.Count != 0)
                {
                    while (operators.Peek() != "(")
                    {
                        current = operators.Pop();
                        output.Enqueue(current);

                        // i++;
                    }

                    if (operators.Count != 0)
                    {
                        current = operators.Pop();
                    }

                    if (operators.Count != 0)
                    {
                        while (operators.Peek() == "ln" || operators.Peek() == "sqrt" || operators.Peek() == "pow")
                        {
                            current = operators.Pop();
                            output.Enqueue(current);

                            // i++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Parentheses () were mismatched.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }
        }

        while (operators.Count != 0)
        {
            if (operators.Peek() == "(" || operators.Peek() == ")")
            {
                Console.WriteLine("Parentheses () were mismatched.");
                return;
            }
            else
            {
                current = operators.Pop();
                output.Enqueue(current);
            }
        }

        // print RPN
        string rpv = string.Empty;
        while (output.Count != 0)
        {
            rpv += output.Dequeue() + " ";
        }

        // Console.WriteLine(RPV);
        string[] separatedRPV = rpv.Split(' ');

        Stack calculations = new Stack();

        for (int i = 0; i < separatedRPV.Length; i++)
        {
            if (separatedRPV[i] == string.Empty)
            {
                continue;
            }

            if (IsNumber(separatedRPV[i].Substring(0, 1)) || separatedRPV[i].Substring(0, 1) == ".")
            {
                calculations.Push(separatedRPV[i]);
            }

            if (IsOperator(separatedRPV[i]))
            {
                decimal firstNumber = 0;
                decimal secondNumber = 0;
                try
                {
                    firstNumber = ConvertToDecimal(calculations.Pop().ToString());
                    secondNumber = ConvertToDecimal(calculations.Pop().ToString());
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Result is too big to fit in decimal, try with smaller numbers!");
                    return;
                }

                decimal result = 0;
                if (separatedRPV[i] == "+")
                {
                    try
                    {
                        result = firstNumber + secondNumber;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Result is too big to fit in decimal, try with smaller numbers!");
                        return;
                    }
                }

                if (separatedRPV[i] == "-")
                {
                    try
                    {
                        result = secondNumber - firstNumber;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Result is too big to fit in decimal, try with smaller numbers!");
                        return;
                    }
                }

                if (separatedRPV[i] == "*")
                {
                    try
                    {
                        result = firstNumber * secondNumber;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Result is too big to fit in decimal, try with smaller numbers!");
                        return;
                    }
                }

                if (separatedRPV[i] == "/")
                {
                    try
                    {
                        result = secondNumber / firstNumber;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Result is too big to fit in decimal, try with smaller numbers!");
                        return;
                    }
                }

                calculations.Push(result.ToString());
            }

            if (separatedRPV[i] == "ln")
            {
                try
                {
                    decimal result = 0;
                    decimal number = ConvertToDecimal(calculations.Pop().ToString());
                    result = (decimal)Math.Log((double)number);
                    calculations.Push(result);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Result is too big to fit in decimal, try with smaller numbers!");
                    return;
                }
            }

            if (separatedRPV[i] == "sqrt")
            {
                try
                {
                    decimal result = 0;
                    decimal number = ConvertToDecimal(calculations.Pop().ToString());
                    result = (decimal)Math.Sqrt((double)number);
                    calculations.Push(result);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Result is too big to fit in decimal, try with smaller numbers!");
                    return;
                }
            }

            if (separatedRPV[i] == "pow")
            {
                try
                {
                    decimal firstNumber = ConvertToDecimal(calculations.Pop().ToString());
                    decimal secondNumber = ConvertToDecimal(calculations.Pop().ToString());
                    decimal result = 0;
                    result = (decimal)Math.Pow((double)secondNumber, (double)firstNumber);
                    calculations.Push(result);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Result is too big to fit in decimal, try with smaller numbers!");
                    return;
                }
            }
        }

        try
        {
            Console.Write("\n\rResult: ");
            Console.WriteLine(calculations.Pop());
            Console.WriteLine();
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Invalid input!");
            Console.WriteLine();
        }
    }
}
