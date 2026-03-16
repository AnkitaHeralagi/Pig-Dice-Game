using System;
class DiceChallenge
{
    static void Main()
    {
        Random dice = new Random();

        int totalScore = 0;
        int turnCount = 1;

        Console.WriteLine("Welcome to the Pig Dice Game!");
        Console.WriteLine("Goal: Reach 20 points.");
        Console.WriteLine("Roll the dice to gain points.");
        Console.WriteLine("If you roll 1, the turn ends and you lose the turn score.");
        Console.WriteLine("You can hold to save your points.");
        Console.WriteLine();

        // Game continues until total score reaches 20
        while (totalScore < 20)
        {
            Console.WriteLine("------ TURN " + turnCount + " ------");

            int turnScore = 0;
            bool turnOver = false;

            while (!turnOver)
            {
                string choice = GetPlayerChoice();

                if (choice == "r")
                {
                    int diceValue = RollDice(dice);
                    Console.WriteLine("Die: " + diceValue);
                    // If dice shows 1, turn ends with no points
                    if (diceValue == 1)
                    {
                        Console.WriteLine("Turn over. No score.");
                        turnScore = 0;
                        turnOver = true;
                    }
                    else
                    {
                        turnScore += diceValue;
                        Console.WriteLine("Current turn score: " + turnScore);
                    }
                }
                else
                {
                    Console.WriteLine("Score for turn: " + turnScore);
                    totalScore += turnScore;
                    Console.WriteLine("Total score: " + totalScore + " / 20");

                    if (totalScore < 20)
                    {
                        Console.WriteLine("You need " + (20 - totalScore) + " more points to win.");
                    }
                    else
                    {
                        Console.WriteLine("You reached the target score!");
                    }
                    turnOver = true;
                }
            }
            Console.WriteLine();
            turnCount++;
        }
        Console.WriteLine("You finished in " + (turnCount - 1) + " turns!");
        Console.WriteLine("Game over!");
    }
    // Method to simulate dice roll
    static int RollDice(Random dice)
    {
        int value = dice.Next(1, 7); // generates number 1 to 6
        return value;
    }
    // Method to get & validate player input
    static string GetPlayerChoice()
    {
        while (true)
        {
            Console.Write("Roll or hold? (r/h): ");
            string input = Console.ReadLine();
            // check empty input
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty.");
                continue;
            }
            input = input.Trim().ToLower();
            // allow only single character
            if (input.Length != 1)
            {
                Console.WriteLine("Please enter only one character (r or h)");
                continue;
            }
            // valid choices
            if (input == "r" || input == "h")
                return input;
            Console.WriteLine("Invalid choice. Enter 'r' to roll or 'h' to hold.");
        }
    }
}