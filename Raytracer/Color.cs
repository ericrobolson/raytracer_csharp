/// <summary>
/// Represents a color.
/// </summary>
public struct Color
{
    public readonly byte R;
    public readonly byte G;
    public readonly byte B;

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public Color(double r, double g, double b)
    {
        R = (byte)(r * 255);
        G = (byte)(g * 255);
        B = (byte)(b * 255);
    }

    public static Color operator *(Color c, double t)
    {
        return new Color(c.R * t, c.G * t, c.B * t);
    }

    public static Color operator *(double t, Color c)
    {
        return c * t;
    }

    public static Color operator +(Color c1, Color c2)
    {
        return new Color(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B);
    }

    /// <summary>
    /// Returns the color as a SkiaSharp color.
    /// </summary>
    /// <returns></returns>
    public SkiaSharp.SKColor ToSKColor()
    {
        return new SkiaSharp.SKColor(R, G, B);
    }
}
