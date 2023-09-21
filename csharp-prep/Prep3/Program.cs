using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    { 
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess = int.MaxValue;
        int guessCount = 0;
        bool keepPlaying = true;

        while (keepPlaying) {
            do {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
                if (guess > magicNumber) {
                    Console.WriteLine("Lower");
                } else if (guess < magicNumber) {
                    Console.WriteLine("Higher");
                } else {
                    Console.WriteLine("You guessed it!");
                    if (guessCount == 1) {
                        Console.WriteLine($"It only took you 1 guess? Wow!");
                    } else {
                        Console.WriteLine($"It took you {guessCount} guesses.");
                        Console.Write("Would you like to play again? (y/n) ");
                        string playAgain = Console.ReadLine().ToLower();
                        if (playAgain == "n") {
                            keepPlaying = false;
                        } else {
                            magicNumber = randomGenerator.Next(1, 101);
                            guessCount = 0;
                        }
                    }
                    
                }
            } while (guess != magicNumber);
        }
        
            }
}