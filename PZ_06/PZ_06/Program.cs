namespace PZ_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];
            Random rnd = new Random();  
            int MaxElement = array[0];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-15,15);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            for(int i = 0; i < array.Length; i++)
            {
              
                if(MaxElement < array[i])
                {
                    MaxElement = array[i];
                    
                }
            } 
            Console.WriteLine("Наибольший элемент в массиве: " + MaxElement);
            for(int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) > MaxElement)
                {
                    Console.WriteLine("Число которое больше по модулю максимального значения в массиве: " + array[i]);
                }
            }
            Console.WriteLine();
           
        }
    }
}