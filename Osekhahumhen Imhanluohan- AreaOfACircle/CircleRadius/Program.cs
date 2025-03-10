namespace MyFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double pi = Math.PI;

            Console.WriteLine("What is the radius of the circle");
            string radius = Console.ReadLine();
            double r = double.Parse(radius);
            double squareRadius = Math.Pow(r,2);
            double output = pi * squareRadius;
            Console.WriteLine(output);
        }
    }
}
