namespace Game.Common;

public static class Rules
{
    public const String RulesOfGame = "Rules of the game:\n\n" +
        "\t1. User must input an odd number (> = 3) non-repeating strings\n\n" +
        "\t2. These passed strings are moves (for example, Rock Paper \n" +
        "\t   Scissors or Rock Paper Scissors Lizard Spock or 1 2 3 4 5 6 7 8 9 \n" +
        "\t   or A B C D E F G etc.)\n\n" +
        "\t3. Half of the next moves in the circle wins, half of the \n" +
        "\t   previous moves in the circle lose (the semantics of the strings-moves \n" +
        "\t   is not important, computer and user play by the rules build upon the \n" +
        "\t   moves order the user used, even if the stone loses to scissors in its \n" +
        "\t   order—the contents of the strings-moves are not important).\n\n" +
        "\t4. For understanding scheme look at the table below(Note that the \n" +
        "\t   table describes scheme where PC moves first and then user!).\n\n";

    public const String OddAndMoreThanOrEqualTo3 =
        "> Count of entered words must be more or equal to 3 and must be odd.";

    public const String NullOrEmpty =
        "> You cannot play without words please enter the words to play!";

    public const String EqualItems =
        "> You cannot enter two or more times the same word or sign.\n" +
        "> Every item of entering sequence must be unique!";
}
