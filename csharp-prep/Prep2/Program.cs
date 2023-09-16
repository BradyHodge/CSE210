using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();
        int gradePercentageInt = int.Parse(gradePercentage);
        string letter = null;

        if (gradePercentageInt >= 90)
        {
            letter = "A";
        }
        else if (gradePercentageInt >= 80)
        {
            letter = "B";
        }
        else if (gradePercentageInt >= 70)
        {
            letter = "C";
        }
        else if (gradePercentageInt >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (gradePercentageInt % 10 >= 7 && gradePercentageInt >= 60 && gradePercentageInt < 90)
        {
            letter += "+";
        }
        else if (gradePercentageInt % 10 < 3 && gradePercentageInt >= 60)
        {
            letter += "-";
        }

        Console.WriteLine($"Your grade is {letter}.");
        if (gradePercentageInt >= 70)
        {
            Console.WriteLine("congratulations, You passed!");
        }
        else
        {
            Console.WriteLine("You did not pass, keep trying!");
        }



        // Stretch Challenge
        // Add to your code the ability to include a "+" or "-" next to the letter grade, such as B+ or A-. For each grade, you'll know it is a "+" if the last digit is >= 7. You'll know it is a minus if the last digit is < 3 and otherwise it has no sign.

        // After your logic to determine the grade letter, add another section to determine the sign. Save this sign into a variable. Then, display both the grade letter and the sign in one print statement.

        // Hint: To get the last digit, you could divide the number by 10, and get the remainder. You might refer back to the preparation material for Lesson 03 to see the operators and find the one that does division and gives you the remainder.

        // At this point, don't worry about the exceptional cases of A+, F+, or F-.

        // Recognize that there is no A+ grade, only A and A-. Add some additional logic to your program to detect this case and handle it correctly.

        // Similarly, recognize that there is no F+ or F- grades, only F. Add additional logic to your program to detect these cases and handle them correctly.
    }
}