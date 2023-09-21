using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = 0;
        Console.WriteLine("Enter a list of umbers, type 0 when finished.");
        do {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0){
                numbers.Add(number);
            }
            
        } while (number != 0);
        Console.WriteLine($"The sum of the numbers is {numbers.Sum()}");
        Console.WriteLine($"The average of the numbers is {Math.Round(numbers.Average(), 3)}");
        Console.WriteLine($"The largest number is {numbers.Max()}");
        Console.WriteLine($"The smallest positive number is {numbers.Where(n => n > 0).Min()}");
        numbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach (int num in numbers) {
            Console.WriteLine($"{num} ");
        }
        
    }
}