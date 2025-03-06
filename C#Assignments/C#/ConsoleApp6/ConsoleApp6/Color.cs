namespace ConsoleApp6;


public class Color
{
    private int _red;
    private int _green;
    private int _blue;
    private int _alpha;

    public Color(int red, int green, int blue, int alpha)
    {
        _red = ValidateColor(red);
        _green = ValidateColor(green);
        _blue = ValidateColor(blue);
        _alpha = ValidateColor(alpha);
    }

    public Color(int red, int green, int blue) : this(red, green, blue, 255) { }

    public int Red
    {
        get => _red;
        set => _red = ValidateColor(value);
    }

    public int Green
    {
        get => _green;
        set => _green = ValidateColor(value);
    }

    public int Blue
    {
        get => _blue;
        set => _blue = ValidateColor(value);
    }

    public int Alpha
    {
        get => _alpha;
        set => _alpha = ValidateColor(value);
    }

    private int ValidateColor(int value)
    {
        return Math.Clamp(value, 0, 255);
    }

    public int GetGrayscale()
    {
        return (_red + _green + _blue) / 3;
    }

    public override string ToString()
    {
        return $"Red: {Red}, Green: {Green}, Blue: {Blue}, Alpha: {Alpha}";
    }
}