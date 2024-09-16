using System.Text;

namespace Game.Common;

public static class Halper
{
    private static readonly StringBuilder stringBuilder = new();
    private static Int32 half;
    private const String title = @"↓ PC\User →";

    public static void DisplayHalpTable(String[] inputs)
    {
        half = CalculateHalfOfInputs(inputs.Length);

        stringBuilder.Append($"+{new String('-', 13)}+");

        for (int i = 0; i < inputs.Length; i++)
        {
            stringBuilder.Append($"{new String('-', inputs[i].Length + 2)}+");
        }

        stringBuilder.Append($"\n| {title} | ");
        stringBuilder.AppendJoin(" | ", inputs);
        stringBuilder.Append($" |\n+{new String('-', 13)}+");

        for (int i = 0; i < inputs.Length; i++)
        {
            stringBuilder.Append($"{new String('-', inputs[i].Length + 2)}+");
        }

        for (int i = 0; i < inputs.Length; i++)
        {
            stringBuilder.Append(
                $"\n| " +
                $"{inputs[i]}" +
                $"{new String(' ', 13 - (inputs[i].Length + 1))}|");

            for (int j = 0; j < inputs.Length; j++)
            {
                if (i == j)
                {
                    stringBuilder.Append(
                        $" Draw" +
                        $"{new String(' ', (inputs[j].Length + 2) - 5)}");
                }
                else if (i + 1 < j + 1 && j + 1 <= (i + 1) + half)
                {
                    stringBuilder.Append(
                        $" Win" +
                        $"{new String(' ', (inputs[j].Length + 2) - 4)}");
                }
                else
                {
                    stringBuilder.Append(
                        $" Lose" +
                        $"{new String(' ', (inputs[j].Length + 2) - 5)}");
                }
                stringBuilder.Append('|');
            }
            stringBuilder.Append($"\n+{new String('-', 13)}+");
            for (int k = 0; k < inputs.Length; k++)
            {
                stringBuilder.Append($"{new String('-', inputs[k].Length + 2)}+");
            }
        }
    }

    private static Int32 CalculateHalfOfInputs(Int32 lengthOfInputs)
    {
        Int32 half = (lengthOfInputs - 1) / 2;

        return half;
    }
}
