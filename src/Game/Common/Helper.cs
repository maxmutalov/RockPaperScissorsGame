using System.Text;

namespace Game.Common;

public static class Helper
{
    private static readonly StringBuilder _stringBuilder = new();
    private static Int32 _half;
    private const String title = @"v PC\User >";

    public static void DisplayHelperTable(String[] inputs)
    {
        _half = CalculateHalfOfInputs(inputs.Length);

        _stringBuilder.Append($"+{new String('-', 13)}+");

        for (int i = 0; i < inputs.Length; i++)
        {
            _stringBuilder.Append($"{new String('-', inputs[i].Length + 2)}+");
        }

        _stringBuilder.Append($"\n| {title} | ");
        _stringBuilder.AppendJoin(" | ", inputs);
        _stringBuilder.Append($" |\n+{new String('-', 13)}+");

        for (int i = 0; i < inputs.Length; i++)
        {
            _stringBuilder.Append($"{new String('-', inputs[i].Length + 2)}+");
        }

        for (int i = 0; i < inputs.Length; i++)
        {
            _stringBuilder.Append(
                $"\n| " +
                $"{inputs[i]}" +
                $"{new String(' ', 13 - (inputs[i].Length + 1))}|");

            for (int j = 0; j < inputs.Length; j++)
            {
                if (i == j)
                {
                    _stringBuilder.Append(
                        $" Draw" +
                        $"{new String(' ', (inputs[j].Length + 2) - 5)}");
                }
                else if (i < j && j <= i + _half ||
                         i > j && j >= 0 && j <= (i + _half) - inputs.Length)
                {
                    _stringBuilder.Append(
                        $" Win" +
                        $"{new String(' ', (inputs[j].Length + 2) - 4)}");
                }
                else
                {
                    _stringBuilder.Append(
                        $" Lose" +
                        $"{new String(' ', (inputs[j].Length + 2) - 5)}");
                }
                _stringBuilder.Append('|');
            }
            _stringBuilder.Append($"\n+{new String('-', 13)}+");
            for (int k = 0; k < inputs.Length; k++)
            {
                _stringBuilder.Append($"{new String('-', inputs[k].Length + 2)}+");
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(_stringBuilder.ToString());
        Console.ResetColor();
        _stringBuilder.Clear();
    }

    public static Int32 CalculateHalfOfInputs(Int32 lengthOfInputs)
    {
        Int32 half = (lengthOfInputs - 1) / 2;

        return half;
    }
}
