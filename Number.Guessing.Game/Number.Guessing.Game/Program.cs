internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Number Guessing Game!\r\nI'm thinking of a number between 1 and 100.\r\n");
        Console.WriteLine("Please select the difficulty level:");
        Console.WriteLine("1. Easy (10 chances)\r\n2. Medium (5 chances)\r\n3. Hard (3 chances) \r\n");
        var isValidChoice = false;
        while (!isValidChoice) 
        {
            Console.Write("Enter your choice: ");
            string? userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int result))
            {
                if(result > 0 && result <= 3)
                {
                    isValidChoice = true;
                    SelectedLevel(result);
                }
                else
                {
                    Console.Write("Option value incorrect!! \r\n");
                }
            }
            else
            {
                Console.Write("Option value incorrect!! \r\n");
            }
        }
    }

    private static void SelectedLevel(int level)
    {
        switch (level)
        {
            case 1:
                Console.Write("Great! You have selected the Easy difficulty level. \r\n");
                Console.Write("Let's start the game! \r\n");
                GuessNumber(10);
                break;
            case 2:
                Console.Write("Great! You have selected the Medium difficulty level. \r\n");
                Console.Write("Let's start the game! \r\n");
                GuessNumber(5);
                break;
            case 3:
                Console.Write("Great! You have selected the Hard difficulty level.! \r\n");
                Console.Write("Let's start the game! \r\n");
                GuessNumber(3);
                break;
        }
    }

    private static void GuessNumber(int chances)
    {
        bool numberRight = false;
        var random = new Random();
        var numberToGuess = random.Next(1, 100);
        int attempts = 0;

        do
        {            
            Console.Write("Enter your guess: ");
            string? userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int guessedNumber))
            {
                chances--;
                attempts++;
                if (numberToGuess == guessedNumber)
                {
                    numberRight = true;
                    Console.WriteLine($"Congratulations! You guessed the correct number in {attempts} attempts.\r\n");
                }
                else if (numberToGuess > guessedNumber)
                {
                    Console.WriteLine($"Incorrect! The number is greater than {guessedNumber}.\r\n");
                }
                else if (numberToGuess < guessedNumber)
                {
                    Console.WriteLine($"Incorrect! The number is less than {guessedNumber}.\r\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid integer.\r\n");
            }

            if (chances == 0 && !numberRight)
            {
                Console.WriteLine("Oh! You finished all your attempts\r\n");
                break;
            }
        } while (!numberRight);
    }

}