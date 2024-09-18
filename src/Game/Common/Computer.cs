namespace Game.Common;

public static class Computer
{
    private readonly static Random _random = new Random();
    private static Int32 _randomNumber;

    public static String Move(String[] inputs)
    {
        _randomNumber = _random.Next(0, inputs.Length);

        return inputs[_randomNumber];
    }
}
