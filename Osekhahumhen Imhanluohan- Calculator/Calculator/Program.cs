namespace MyFirstApp
{
    class Program
    {
        /// <summary>
        /// Simple Calculator: Models a simple calculator
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("What is the first number");
            string firstNumber = Console.ReadLine();

            Console.WriteLine("What is the second number");
            string secondNumber = Console.ReadLine();

            Console.WriteLine("What is the operator");
            char op = Console.ReadKey().KeyChar;

            double first = double.Parse(firstNumber);
            double second = double.Parse(secondNumber);

            double result = 0;

            if (op == '+')
            {
                result = first + second;
            }
            else if (op == '-')
            {
                result = first - second;
            }
            else if (op == '*')
            {
                result = first * second;
            }
            else if (op == '/')
            {
                result = first / second;
            }
            else
            {
                Console.WriteLine($"{op} is invalid");
            }

            Console.WriteLine($"Result: {result}");
        }
    }
}

