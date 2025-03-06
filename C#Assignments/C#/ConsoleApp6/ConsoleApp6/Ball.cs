namespace ConsoleApp6;


public class Ball
{
    public int Size{get; set;}
    public Color Color{get; set;}
    private int _throwCount;

    public Ball(int size, Color color)
    {
        Size = size;
        Color = color;
        _throwCount = 0;
    }
    public Ball(int size, int red, int green, int blue):this(size, new Color(red,green,blue)){}

    public void Pop()
    {
        Size = 0;
    }

    public void Throw()
    {
        if (Size > 0)
        {
            _throwCount++;
        }
    }

    public int GetThrowCount()
    {
        return _throwCount;
    }

    public override string ToString()
    {
        return $"Size: {Size}, Color: {Color}, ThrowCount: {_throwCount}";
    }


}