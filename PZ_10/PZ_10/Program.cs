namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string currentNumber = "";

            foreach (char character in text)
            {
                if (char.IsDigit(character))
                {
                    currentNumber += character;
                }
                else if (!string.IsNullOrEmpty(currentNumber))
                {
                    Console.WriteLine($"{currentNumber} ");
                    currentNumber = "";
                }
            }

            if (!string.IsNullOrEmpty(currentNumber))
            {
                Console.WriteLine(currentNumber);
            }

           
        }
    }
}