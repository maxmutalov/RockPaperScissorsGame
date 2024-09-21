namespace Game.Common;

#pragma warning disable CS8600, CS8602, CS8603, CS8604, CS8618
public static class GameStarter
{
    private static String _computersMove;
    private static String[]? _moves;
    private static String[] _newMoves;

    public static void Start(String[] args)
    {
        _moves = args;

        while (true)
        {
            if (CheckForErrors(_moves))
            {
                if (SuggestPlayAgain())
                {
                    PlayAgain();
                    continue;
                }
            }

            DisplayHMAC(_moves);

            DisplayVariants(_moves);

            DisplayResult();

            if (SuggestPlayAgain())
                PlayAgain();
        }
    }

    private static void DisplayResult()
    {
        string usersMove = UserMove(_moves);

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Your move: {usersMove}\n");
        Console.WriteLine($"Computers move: {_computersMove}");
        Console.ResetColor();

        Console.WriteLine("\n" + new String('-', 80) + "\n");
        String winnerResult = Judge.DefineWinner(usersMove, _computersMove, _moves);

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"{new String('*', 20)}   {winnerResult}   {new String('*', 20)}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nHMAC key: {KeyGenerator.GeneratedKey}");
        Console.ResetColor();

        Console.WriteLine("\n" + new String('-', 80));
    }

    private static Boolean SuggestPlayAgain()
    {
        while (true)
        {
            Console.WriteLine("\nWould you like to play again?");
            Console.WriteLine("\n\t1 - Yes\n\t2 - No");
            Console.Write("\nEnter your answer: ");
            String answer = Console.ReadLine();

            if (answer == "1")
            {
                return true;
            }
            else if (answer == "2")
            {
                Environment.Exit(0);
            }
            else if (answer != "1" & answer != "2")
            {
                Console.WriteLine("\n" + new String('-', 80));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nFor \"Yes\" enter \"1\", for \"No\" enter \"2\"");
                Console.ResetColor();
                Console.WriteLine("\n" + new String('-', 80));
                continue;
            }
        }
    }

    private static void PlayAgain()
    {
        Console.WriteLine("\n" + new String('-', 80) + "\n");
        Console.Write("Enter moves for playing: ");
        _newMoves = Console.ReadLine().Trim().ToLower().Split(' ');
        Console.WriteLine("\n" + new String('-', 80) + "\n");

        _moves = _newMoves;
    }

    private static Boolean CheckForErrors(String[] sequence)
    {
        if (sequence == null || sequence.Contains(""))
        {
            Console.WriteLine("\n" + new String('-', 80) + "\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Rules.NullOrEmpty);
            Console.ResetColor();
            Console.WriteLine("\n" + new String('-', 80));
            return true;
        }
        else if (CheckTheLettersCount(sequence))
        {
            Console.WriteLine("\n" + new String('-', 80) + "\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Rules.CountOfLettersMoreThanOrEqualTo3);
            Console.ResetColor();
            Console.WriteLine("\n" + new String('-', 80));
            return true;
        }
        else if (CheckIfThereAreEqualItems(sequence))
        {
            Console.WriteLine("\n" + new String('-', 80) + "\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Rules.EqualItems);
            Console.ResetColor();
            Console.WriteLine("\n" + new String('-', 80));
            return true;
        }
        else if (sequence.Length < 3 ||
                 sequence.Length % 2 == 0)
        {
            Console.WriteLine("\n" + new String('-', 80) + "\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Rules.OddAndMoreThanOrEqualTo3);
            Console.ResetColor();
            Console.WriteLine("\n" + new String('-', 80));
            return true;
        }

        return false;
    }

    private static Boolean CheckTheLettersCount(String[] sequence)
    {
        Boolean result = false;

        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i].Length < 3)
            {
                result = true;
                break;
            }
        }

        return result;
    }

    private static String UserMove(String[] sequence)
    {
        String usersMove;
        do
        {
            Console.Write("Enter your move: ");
            usersMove = Console.ReadLine();

            for (int i = 0; i < sequence.Length; i++)
            {
                if (usersMove == $"{i + 1}")
                {
                    usersMove = sequence[i];
                    Console.WriteLine("\n" + new String('-', 80) + "\n");
                    break;
                }
                else if (usersMove == "?")
                {
                    Console.WriteLine("\n" + new String('-', 80) + "\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Rules.RulesOfGame);
                    Helper.DisplayHelperTable(sequence);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\nPress any key to continue...\n");
                    Console.ReadKey();
                    Console.ResetColor();
                    Console.WriteLine("\n" + new String('-', 80) + "\n");
                    break;
                }
                else if (usersMove == "0")
                {
                    Environment.Exit(0);
                }
            }
        } while (usersMove == "?");

        return usersMove;
    }

    private static void DisplayVariants(String[] moves)
    {
        Console.WriteLine("\n" + new String('-', 80) + "\n");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Available moves:\n");

        for (int i = 0; i < moves.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {moves[i]}");
        }

        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");
        Console.ResetColor();
        Console.WriteLine("\n" + new String('-', 80) + "\n");
    }

    private static void DisplayHMAC(String[] moves)
    {
        _computersMove = Computer.Move(moves);

        KeyGenerator.GenerateKey();

        var hmac = KeyGenerator.GenerateHMAC(_computersMove);

        Console.WriteLine("\n" + new String('-', 80) + "\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"HMAC: {hmac}");
        Console.ResetColor();
    }

    private static Boolean CheckIfThereAreEqualItems(String[] sequence)
    {
        for (int i = 0; i < sequence.Length; i++)
        {
            for (int j = i + 1; j < sequence.Length; j++)
            {
                if (sequence[i] == sequence[j])
                {
                    return true;
                }
            }
        }

        return false;
    }
}
