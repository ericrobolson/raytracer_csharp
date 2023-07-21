using System;

namespace RaytracerEngine;

/// <summary>
/// Represents a vector with three components.
/// </summary>
public struct Vec3
{
    public readonly double X;
    public readonly double Y;
    public readonly double Z;

    public Vec3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// Negates the vector.
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Vec3 operator -(Vec3 v)
    {
        return new Vec3(-v.X, -v.Y, -v.Z);
    }

    /// <summary>
    /// Adds two vectors together.
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    public static Vec3 operator +(Vec3 v1, Vec3 v2)
    {
        return new Vec3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    /// <summary>
    /// Multiplies a vector by a double.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Vec3 operator *(Vec3 v, double t)
    {
        return new Vec3(v.X * t, v.Y * t, v.Z * t);
    }

    /// <summary>
    /// Multiplies a vector by a double.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Vec3 operator *(double t, Vec3 v)
    {
        return v * t;
    }

    /// <summary>
    /// Multiplies two vectors together.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vec3 operator *(Vec3 a, Vec3 b)
    {
        return new Vec3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    }

    /// <summary>
    /// Adds two vectors together.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Vec3 operator +(Vec3 v, double t)
    {
        return new Vec3(v.X + t, v.Y + t, v.Z + t);
    }

    /// <summary>
    /// Subtracts two vectors.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Vec3 operator -(Vec3 a, Vec3 b)
    {
        return new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    /// <summary>
    /// Divides a vector by a double.
    /// </summary>
    /// <param name="v"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Vec3 operator /(Vec3 v, double t)
    {
        if (t == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }

        return new Vec3(v.X / t, v.Y / t, v.Z / t);
    }

    /// <summary>
    /// Returns the dot product of two vectors.
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public Vec3 Dot(Vec3 v)
    {
        return new Vec3(X * v.X, Y * v.Y, Z * v.Z);
    }

    /// <summary>
    /// Returns the cross product of two vectors.
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public Vec3 Cross(Vec3 v)
    {
        return new Vec3(Y * v.Z - Z * v.Y, Z * v.X - X * v.Z, X * v.Y - Y * v.X);
    }

    /// <summary>
    /// Returns the unit vector of a vector.
    /// </summary>
    /// <returns></returns>
    public Vec3 UnitVector()
    {
        return this / Length();
    }

    /// <summary>
    /// Returns the length of a vector.
    /// </summary>
    /// <returns></returns>
    public double Length()
    {
        return Math.Sqrt(LengthSquared());
    }

    /// <summary>
    /// Returns the squared length of a vector.
    /// </summary>
    /// <returns></returns>
    public double LengthSquared()
    {
        return X * X + Y * Y + Z * Z;
    }
}
