namespace RaytracerEngine;

public class Raytracer
{
    private static Color RayColor(Ray r)
    {
        Vec3 unitDirection = r.Direction.UnitVector();
        double t = 0.5 * (unitDirection.Y + 1.0);
        return (1.0 - t) * new Color(1.0, 1.0, 1.0) + t * new Color(0.5, 0.7, 1.0);
    }

    public void Draw(Image image)
    {
        var width = image.Width;
        var height = image.Height;

        // Image
        var aspectRatio = (double)width / (double)height;

        // Camera
        var viewportHeight = 2.0;
        var viewportWidth = aspectRatio * viewportHeight;
        var focalLength = 1.0;

        var origin = new Vec3(0, 0, 0);
        var horizontal = new Vec3(viewportWidth, 0, 0);
        var vertical = new Vec3(0, viewportHeight, 0);
        var lowerLeftCorner = origin - horizontal / 2 - vertical / 2 - new Vec3(0, 0, focalLength);

        for (int y = height - 1; y >= 0; --y)
        {
            for (int x = 0; x < width; ++x)
            {
                double u = (double)x / (double)(width - 1);
                double v = (double)y / (double)(height - 1);
                Ray r = new Ray(origin, lowerLeftCorner + u * horizontal + v * vertical - origin);
                Color pixelColor = RayColor(r);

                image.SetPixel(x, y, pixelColor);
            }
        }
    }
}
