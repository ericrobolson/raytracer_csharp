namespace RaytracerEngine;

/// <summary>
/// A ray in 3D space.
/// </summary>
public struct Ray
{
    public Vec3 Origin { get; }
    public Vec3 Direction { get; }

    public Ray()
        : this(new Vec3(0, 0, 0), new Vec3(0, 0, 0)) { }

    public Ray(Vec3 origin, Vec3 direction)
    {
        Origin = origin;
        Direction = direction;
    }

    /// <summary>
    /// Returns the point at t along the ray.
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public Vec3 At(double t)
    {
        return Origin + (Direction * t);
    }
}
