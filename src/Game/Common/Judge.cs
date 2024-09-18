using System.Text;
using System;

namespace Game.Common;

public static class Judge
{
    private const String UserWon = "You won!";
    private const String ComputerWon = "Computer won!";
    private const String Draw = "Draw";
    private static String _result;
    private static Int32 _usersMove;
    private static Int32 _computersMove;

    public static String DefineWinner(String usersMove, String computersMove, String[] inputs)
    {
        _usersMove = GetItemIndex(inputs, usersMove);
        _computersMove = GetItemIndex(inputs, computersMove);

        var half = Helper.CalculateHalfOfInputs(inputs.Length);

        Boolean IsWinner = _usersMove > _computersMove && _usersMove <= _computersMove + half ||
                 _computersMove > _usersMove && _usersMove >= 0 &&
                 _usersMove <= (_computersMove + half) - inputs.Length;


        if (_usersMove == _computersMove)
        {
            _result = Draw;
        }
        else if (IsWinner)
        {
            _result = UserWon;
        }
        else
        {
            _result = ComputerWon;
        }

        return _result;
    }

    private static Int32 GetItemIndex(String[] sequence, String item)
    {
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i] == item)
                return i;
        }

        return -1;
    }
}