namespace Game.Common;

public static class Rules
{
    public const String RulesOfGame = "Rules of game:\n" +
        "\t1. User must input an odd number (≥ 3) non-repeating strings\n" +
        "\t2. These passed strings are moves (for example, Rock Paper \n" +
        "\t   Scissors or Rock Paper Scissors Lizard Spock or 1 2 3 4 5 6 7 8 9 \n" +
        "\t   or A B C D E F G etc.)\n" +
        "\t3. Half of the next moves in the circle wins, half of the \n" +
        "\t   previous moves in the circle lose (the semantics of the strings-moves \n" +
        "\t   is not important, computer and user play by the rules build upon the \n" +
        "\t   moves order the user used, even if the stone loses to scissors in its \n" +
        "\t   order—the contents of the strings-moves are not important).\n" +
        "\t4. For understanding scheme look at the table below\n" +
        "GOOD LUCK MY FRIEND!!!";
}
