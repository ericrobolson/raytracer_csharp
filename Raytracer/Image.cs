using System.IO;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;

public class Image
{
    private readonly SkiaBitmapExportContext bmp;

    public int Width => bmp.Width;
    public int Height => bmp.Height;

    public Image(int width, int height)
    {
        bmp = new SkiaBitmapExportContext(width, height, 1.0f);
        ICanvas canvas = bmp.Canvas;
        canvas.FillColor = Colors.White;

        for (int x = 0; x < bmp.Width; x++)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                var color = new SkiaSharp.SKColor(
                    (byte)(x * 255 / bmp.Width),
                    (byte)(y * 255 / bmp.Height),
                    128
                );
                bmp.Bitmap.SetPixel(x, y, color);
            }
        }
    }

    public Stream GetImageStream()
    {
        var stream = new MemoryStream();
        bmp.Bitmap.Encode(stream, SkiaSharp.SKEncodedImageFormat.Png, 100);

        return stream;
    }
}
