using C_Math;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

[System.Serializable]
public struct C_V3
{
    public const float POS_INF = float.PositiveInfinity;
    public const float NEG_INFI = float.NegativeInfinity;
    public const float K_EPSILON = 1E-08f;
    public const float K_EPSILON_NORMAL_SQRT = 1E-15f;
    public float x;
    public float y;
    public float z;
    #region Shorthand References. 
    private static readonly C_V3 ONE = new(1f, 1f, 1f);
    private static readonly C_V3 ZERO = new(0f, 0f, 0f);
    private static readonly C_V3 UP = new(0f, 1f, 0f);
    private static readonly C_V3 DOWN = new(0f, -1f, 0f);
    private static readonly C_V3 FWD = new(0f, 0f, 1f);
    private static readonly C_V3 BACK = new(0f, 0f, -1f);
    private static readonly C_V3 RIGHT = new(1f, 0f, 0f);
    private static readonly C_V3 LEFT = new(-1f, 0f, 0f);
    private static readonly C_V3 POSINF = new(POS_INF, POS_INF, POS_INF);
    private static readonly C_V3 NEGINF = new(NEG_INFI, NEG_INFI, NEG_INFI);
    
    /// <summary>
    /// Shorthand for a vector with all components set to zero (0.0F, 0.0F, 0.0F). 
    /// </summary>
    public static C_V3 Zero => ZERO;

    /// <summary>
    /// Shorthand for a vector with all component set to (1.0F, 1.0F, 1.0F). 
    /// </summary>
    public static C_V3 One => ONE;

    /// <summary>
    /// Shorthand for a vector with all components set to (0.0F, 1.0F, 0.0F). 
    /// </summary>
    public static C_V3 Up => UP;

    /// <summary>
    /// Shorthand for a vector with all components set to (0.0F, -1.0F, 0.0F). 
    /// </summary>
    public static C_V3 Down => DOWN;

    /// <summary>
    /// Shorthand for a vector with all components set to (-1.0F, 0.0F, 0.0F). 
    /// </summary>
    public static C_V3 Left => LEFT;

    /// <summary>
    /// Shorthand for a vector with all components set to (1.0F, 0.0F, 0.0F). 
    /// </summary>
    public static C_V3 Right => RIGHT;

    /// <summary>
    /// Shorthand for a vector with all components set to (0.0F, 0.0F, 1.0F). 
    /// </summary>
    public static C_V3 Forward => FWD;

    /// <summary>
    /// Shorthand for a vector with all components set to (0.0F, 0.0F, -1.0F). 
    /// </summary>
    public static C_V3 Backward => BACK;

    /// <summary>
    /// Shorthand for a vector with all components set to 
    /// (float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity). 
    /// </summary>
    public static C_V3 PositiveInfinity => POSINF;

    /// <summary>
    /// Shorthand for a vector with all components set to 
    /// (float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity). 
    /// </summary>
    public static C_V3 NegativeInfinity => NEGINF;
    #endregion
    
    /// <summary>
    /// Returns the magnitude of the vector without square rooting the value. 
    /// </summary>
    public readonly float FastMagnitude => x * x + y * y + z * z;
    
    /// <summary>
    /// Returns the magnitude of the vector. 
    /// </summary>
    public readonly float Magnitude => Mathf.Sqrt(FastMagnitude);
    
    /// <summary>
    /// Returns the vector with a length of one. 
    /// </summary>
    public C_V3 Normalized
    {
        get
        {
            float num = Magnitude;
            if (num > K_EPSILON)
            {
                return new(x / Magnitude, y / Magnitude, z / Magnitude);

            }
            else
            {
                return Zero; 
            }
        }
    }

    #region CTORS. 
    public C_V3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public C_V3(Vector2 vec) : this(vec.x, vec.y, 0) { }
    public C_V3(Vector2 vec, float z) : this(vec.x, vec.y, z) { }
    public C_V3(Vector3 vec) : this(vec.x, vec.y, vec.z) { }
    #endregion

    #region Utilities. 
    /// <summary>
    /// Copy the component values from vector a to vector b. 
    /// </summary>
    /// <param name="b"> The vector to copy component values to. </param>
    /// <param name="a"> The vector to copy component values from. </param>
    public static void CopyTo(C_V3 a, ref C_V3 b) =>
        b.Set(a.x, a.y, a.z);

    public void Set(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    #endregion

    #region Component Modification Functions. 
    /// <summary>
    /// Returns a vector created from the smallest components of two vectors. 
    /// </summary>
    /// <param name="a"> The first vector. </param>
    /// <param name="b"> The second vector. </param>
    public static C_V3 Min(C_V3 a, C_V3 b) =>
        new(
            (a.x <= b.x) ? a.x : b.x,
            (a.y <= b.y) ? a.y : b.y,
            (a.z <= b.z) ? a.z : b.z
            );

    /// <summary>
    /// Returns a vector created from the largest components of two vectors.
    /// </summary>
    /// <param name="a">  The first vector.  </param>
    /// <param name="b"> The second vector. </param>
    /// <returns></returns>
    public static C_V3 Max(C_V3 a, C_V3 b) =>
        new(
            (a.x >= b.x) ? a.x : b.x,
            (a.y >= b.y) ? a.y : b.y,
            (a.z >= b.z) ? a.z : b.z
            );

    /// <summary>
    /// Returns a vector clamped between the provided ranges. 
    /// </summary>
    /// <param name="a"> The vector to clamp. </param>
    /// <param name="rangeX"> The range to clamp the x component by. </param>
    /// <param name="rangeY"> The range to clamp the y component by. </param>
    /// <param name="rangeZ"> The range to clamp the z component by. </param>
    public static C_V3 Clamp(C_V3 a, C_V2 rangeX, C_V2 rangeY, C_V2 rangeZ) =>
        new(
            C_MathF.Clamp(a.x, rangeX),
            C_MathF.Clamp(a.y, rangeY),
            C_MathF.Clamp(a.z, rangeZ)
            );

    /// <summary>
    /// Returns the vector with positive sign. 
    /// </summary>
    /// <param name="a"> The vector to absolute. </param>
    public static C_V3 Abs(C_V3 a) =>
        new(C_MathF.Abs(a.x), C_MathF.Abs(a.y), C_MathF.Abs(a.z));
    #endregion

    #region Normal.
    /// <summary>
    /// Normalize the vector. 
    /// </summary>
    public void Normalize()
    {
        C_V3 norm = Normalized;
        Set(norm.x, norm.y, norm.z);
    }

    /// <summary>
    /// Returns the normal vector of three points. 
    /// </summary>
    /// <param name="a"> The first point. </param>
    /// <param name="b"> The second point. </param>
    /// <param name="c"> The third point. </param>
    public C_V3 CalculateNormal(C_Point3D a, C_Point3D b, C_Point3D c) =>
        CalculateNormal(b - a, c - b);

    /// <summary>
    /// Calculate the normal 
    /// </summary>
    /// <param name="AB"></param>
    /// <param name="AC"></param>
    /// <returns></returns>
    public C_V3 CalculateNormal(C_V3 AB, C_V3 AC) =>
        CrossProduct(AB.Normalized, AC.Normalized);
    #endregion

    #region Multiplication Functions. 
    public static float DotProduct(C_V3 lhs, C_V3 rhs) =>
        (lhs.x * rhs.x) + (lhs.y * rhs.y) + (lhs.z * rhs.z);

    public static float NormDotProduct(C_V3 lhs, C_V3 rhs) =>
        DotProduct(lhs.Normalized, rhs.Normalized);

    public static C_V3 CrossProduct(C_V3 lhs, C_V3 rhs) =>
        new((lhs.y * rhs.z) - (lhs.z * rhs.y),
            (lhs.z * rhs.x) - (lhs.x * rhs.z),
            (lhs.x * rhs.y) - (lhs.y * rhs.x));

    #endregion

    public static float AngleBetween(C_V3 vec1, C_V3 vec2)
    {
        float dotProd = DotProduct(vec1, vec2);
        float magA = vec1.Magnitude; 
        float magB = vec2.Magnitude;
        float numerator = dotProd;
        float denominator = magA * magB;
        float result = numerator / denominator;
        if(denominator == 0 || numerator > K_EPSILON) { return 0; }

        return (float)(Mathf.Acos(result) * C_MathF.Rad2Deg);
    }

    public static C_V3 Distance(C_Point3D a, C_Point3D b) =>
        new(b.x - a.x, b.y - a.y, b.z - a.y);

    #region Operator Overloads. 

    public override bool Equals(object obj)
    {
        C_V3 objInst;

        if ((obj is C_V3))
        {
            objInst = (C_V3)obj;

            if (x == objInst.x && y == objInst.y)
                return true;
        }

        return false;
    }

    public override string ToString()
    {
        return "(" + x + "," + y + ")";
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + x.GetHashCode();
        hash = hash * 23 + y.GetHashCode();
        return hash;
    }

    public static implicit operator Vector2(C_V3 vec) =>
        new(vec.x, vec.y);

    public static implicit operator Vector3(C_V3 vec) =>
        new(vec.x, vec.y, vec.z);

    public static C_V3 operator +(C_V3 a, C_V3 b) =>
        new(a.x + b.x, a.y + b.y, a.z + b.z);

    public static C_V3 operator -(C_V3 a, C_V3 b) =>
        a + (-1 * b);

    public static bool operator ==(C_V3 lhs, C_V3 rhs)
    {
        return (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z);
    }

    public static bool operator !=(C_V3 lhs, C_V3 rhs)
    {
        return !(lhs.x != rhs.x && lhs.y != rhs.y && lhs.z != rhs.z);
    }

    public static C_V3 operator *(int a, C_V3 b) =>
        new(a * b.x, a * b.y, a * b.z);

    public static C_V3 operator *(float a, C_V3 b) =>
        new(a * b.x, a * b.y, a * b.z);

    public static C_V3 operator *(C_V3 a, C_V3 b) =>
    new(a.x * b.x, a.y * b.y, a.z * b.z);

    public static C_V3 operator /(C_V3 vec, float value) =>
        new(vec.x * (1 / value), vec.y * (1 / value), vec.z * (1 / value));
    #endregion
}
