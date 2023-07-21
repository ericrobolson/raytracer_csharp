using System.IO;
using Microsoft.Maui.Graphics.Skia;

/// <summary>
/// Represents an image.
/// </summary>
public class Image
{
    private readonly SkiaBitmapExportContext bmp;

    public int Width => bmp.Width;
    public int Height => bmp.Height;

    public Image(int width, int height)
    {
        bmp = new SkiaBitmapExportContext(width, height, 1.0f);
    }

    /// <summary>
    /// Sets the pixel at the given coordinates to the given color.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="color"></param>
    public void SetPixel(int x, int y, Color color)
    {
        bmp.Bitmap.SetPixel(x, y, color.ToSKColor());
    }

    /// <summary>
    /// Returns the image as a in memory stream.
    /// </summary>
    /// <returns></returns>
    public Stream GetImageStream()
    {
        var stream = new MemoryStream();
        bmp.Bitmap.Encode(stream, SkiaSharp.SKEncodedImageFormat.Png, 100);

        return stream;
    }
}
