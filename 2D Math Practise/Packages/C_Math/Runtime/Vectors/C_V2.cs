using C_Math;
using UnityEngine;

[System.Serializable]
public struct C_ParametricLine
{
    public C_P2D origin;
    public C_V2 vector;
    public float length;

    public C_V2 PointOnVec(float time)
    {
        return origin + (C_P2D)(time * vector.Unitized);
    }

    public void DrawLine()
    {
        Gizmos.color = Color.grey;
        Vector3 endpoint = (Vector3)PointOnVec(length);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, endpoint);
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(origin, 0.08f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(endpoint, 0.08f);
    }

    public void DrawPointAtTime(float time)
    {
        Vector3 newVec = (Vector3)PointOnVec(time);
        Gizmos.DrawLine(origin, origin + newVec);
    }
}

[System.Serializable]
public partial struct C_V2
{
    #region Constants/Readonly.

    static readonly C_V2 one = new(1.0F, 1.0F);

    static readonly C_V2 zero = new(0.0F, 0.0F);

    static readonly C_V2 up = new(0.0F, 1.0F);

    static readonly C_V2 down = new(0.0F, -1.0F);

    static readonly C_V2 right = new(1.0F, 0.0F);

    static readonly C_V2 left = new(-1.0F, 0.0F);

    static readonly C_V2 pos_inf = new(float.PositiveInfinity, float.PositiveInfinity);

    static readonly C_V2 neg_inf = new(float.NegativeInfinity, float.NegativeInfinity);
    #endregion

    #region Fields. 
    /// <summary>
    /// The X component of the vector. 
    /// </summary>
    public float x;

    /// <summary>
    /// The Y componet of the vector. 
    /// </summary>
    public float y;
    #endregion

    #region Properties. 
    #region Shorthands. 
    /// <summary>
    /// Shorthand for new Vec2(1f, 1f). 
    /// </summary>
    public static C_V2 One => one;

    /// <summary>
    /// Shorthand for new Vec2(0f, 0f). 
    /// </summary>
    public static C_V2 Zero => zero;

    /// <summary>
    /// Shorthand for new Vec2(0f, 1f). 
    /// </summary>
    public static C_V2 Up => up;

    /// <summary>
    /// Shorthand for new Vec2(0f, -1f). 
    /// </summary>
    public static C_V2 Down => down;

    /// <summary>
    /// Shorthand for new Vec2(-1f, 0f). 
    /// </summary>
    public static C_V2 Left => left;

    /// <summary>
    /// Shorthand for new Vec2(1f, 0f). 
    /// </summary>
    public static C_V2 Right => right;

    /// <summary>
    /// Shorthand for new Vec2(float.PositiveInfinity, float.PositiveInfinity). 
    /// </summary>
    public static C_V2 PositiveInfinity => pos_inf;

    /// <summary>
    /// Shorthand for new Vec2(float.NegativeInfinity, float.NegativeInfinity). 
    /// </summary>
    public static C_V2 NegativeInfinity => neg_inf;
    #endregion

    /// <summary>
    /// Returns the square magnitude of the vector for quick comparisons. 
    /// </summary>
    public readonly float FastMagnitude => x * x + y * y;

    /// <summary>
    /// Returns the magnitude of the vector (a = SQRT(x * x + y * y).
    /// </summary>
    public readonly float Magnitude => Mathf.Sqrt(FastMagnitude);

    /// <summary>
    /// Returns the magnitude of the vector (a = SQRT(x * x + y * y) halved.
    /// </summary>
    public readonly float HalfMagnitude => Mathf.Sqrt(FastMagnitude) / 2;

    /// <summary>
    /// Returns a vector half the length of the inital vector. 
    /// </summary>
    public readonly C_V2 MidpointVec => HalfMagnitude * Unitized;

    /// <summary>
    /// Returns this vector with a magnitude of one.  
    /// </summary>
    public readonly C_V2 Unitized => new C_V2(x / Magnitude, y / Magnitude);

    /// <summary>
    /// Returns the clockwise normal of the vector. 
    /// </summary>
    public readonly C_V2 NormalCW => C_M2X2.Rot90CW * this;

    /// <summary>
    /// Returns the clockwise normal of the vector. 
    /// </summary>
    public readonly C_V2 NormalCCW => C_M2X2.Rot90CCW * this;
    #endregion

    #region CTOR. 
    /// <summary>
    /// CTOR: Creates a new C_Vec2 with passed in parameters. 
    /// </summary>
    /// <param name="x"> The X component of the vector. </param>
    /// <param name="y"> The Y component of the vector. </param>
    public C_V2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// CTOR: Creates a new C_Vec2 with passed in parameters. 
    /// </summary>
    /// <param name="vec"> The Vector2 containing elements to populate the C_Vec2. </param>
    public C_V2(Vector2 vec)
    {
        this.x = vec.x;
        this.y = vec.y;
    }

    /// <summary>
    /// CTOR: Creates a new C_Vec2 with passed in parameters. 
    /// </summary>
    /// <param name="vec"> The Vector3 containing elements to populate the C_Vec2. </param>
    public C_V2(Vector3 vec)
    {
        this.x = vec.x;
        this.y = vec.y;
    }
    #endregion

    #region General Math Functions. 
    /// <summary>
    /// Returns a C_Vec2 with the smallest components of the two vectors. 
    /// </summary>
    /// <param name="rhs"> The first C_Vec2. </param>
    /// <param name="lhs"> The second C_Vec2. </param>
    /// <returns> C_Vec2. </returns>
    public static C_V2 Min(C_V2 rhs, C_V2 lhs) =>
        new C_V2(
            (rhs.x <= lhs.x) ? rhs.x : lhs.x,
            (rhs.y <= lhs.y) ? rhs.y : lhs.y
            );

    /// <summary>
    /// Returns a C_Vec2 with the greater components of the two vectors. 
    /// </summary>
    /// <param name="lhs"> The first C_Vec2. </param>
    /// <param name="rhs"> The second C_Vec2. </param>
    public static C_V2 Max(C_V2 lhs, C_V2 rhs) =>
        new C_V2(
            (rhs.x >= lhs.x) ? rhs.x : lhs.x,
            (rhs.y >= lhs.y) ? rhs.y : lhs.y
            );

    /// <summary>
    /// Returns a C_Vec2 where the orignal component values are clamped to the provided range. 
    /// </summary>
    /// <param name="a"> The C_Vec to clamp. </param>
    /// <param name="range"> The range [min, max] to clamp components within. </param>
    public static C_V2 Clamp(C_V2 a, C_V2 range) => Clamp(a, range, range);

    /// <summary>
    /// Returns a C_Vec2 where the orignal component values are clamped to the provided ranges. 
    /// </summary>
    /// <param name="a"> The C_Vec to clamp. </param>
    /// <param name="rangeX"> The range [min, max] to clamp X component by. </param>
    /// <param name="rangeY"> The range [min, max] to clamp X component by. </param>
    public static C_V2 Clamp(C_V2 a, C_V2 rangeX, C_V2 rangeY) =>
        new C_V2(
            C_MathF.Clamp(a.x, rangeX.x, rangeX.y),
            C_MathF.Clamp(a.y, rangeY.x, rangeY.y)
            );

    /// <summary>
    /// Returns a C_Vec2 with positively signed components. 
    /// </summary>
    /// <param name="initalVec"> The inital vector. </param>
    public static C_V2 Abs(C_V2 initalVec) =>
        new C_V2(C_MathF.Abs(initalVec.x), C_MathF.Abs(initalVec.y));

    /// <summary>
    /// Set the magnitude of this C_Vec2 to 1. 
    /// </summary>
    public void Unitize() =>
        Set(Unitized.x, Unitized.y);
    #endregion

    #region Muliplication Functions. 
    /// <summary>
    /// Returns the dot product the two C_Vec2. 
    /// </summary>
    /// <param name="lhs">The left hand side C_Vec2. </param>
    /// <param name="rhs">The right hand side C_Vec2. </param>
    public static float DotProduct(C_V2 lhs, C_V2 rhs) =>
        ((lhs.x * rhs.x) + (lhs.y * rhs.y));

    /// <summary>
    /// Return the dot Product of two vectors.
    /// Output: 0 Facing inverse directions. 
    ///         1 Facing the same direction. 
    ///         (0, 1) another angle. 
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static float NormDotProduct(C_V2 lhs, C_V2 rhs) =>
        DotProduct(lhs.Unitized, rhs.Unitized);

    /// <summary>
    /// Returns the Cross product of two C_Vec2s. 
    /// </summary>
    /// <param name="lhs"> The left hand side C_Vec2 of the operation.</param>
    /// <param name="rhs"> The right hand side C_Vec2 of the operation.</param>
    public static float CrossProduct(C_V2 lhs, C_V2 rhs) =>
        lhs.x * rhs.y - lhs.y * rhs.x;
    #endregion

    #region Angular Functions. 
    ///// <summary>
    ///// Get the angle between lhs and rhs. 
    ///// </summary>
    ///// <returns> float angle in radians. </returns>
    public static float AngleBetweenRad(C_V2 a, C_V2 b)
    {
        double numerator = a.x * b.x + a.y * b.y;
        double denominator = a.Magnitude * b.Magnitude;
        return Mathf.Acos((float)(numerator / denominator));
    }

    ///// <summary>
    ///// Get the angle between lhs and rhs. 
    ///// </summary>
    ///// <returns> float angle in degrees. </returns>
    public static float AngleBetweenDeg(C_V2 a, C_V2 b)
    {
        return (float)(AngleBetweenRad(a, b) * C_MathF.Rad2Deg);
    }

    #endregion

    #region Projection Functions. 
    /// <summary>
    /// Returns the orthogonal projection of A onto B. 
    /// </summary>
    /// <param name="A"> The vector to project. </param>
    /// <param name="B"> The vector projected onto. </param>
    /// <returns> The vector projection of A onto B as a C_Vec2. </returns>
    public static C_V2 ProjectionAB(C_V2 A, C_V2 B)
    {
        float numerator = DotProduct(A, B);
        float denominator = (B.Magnitude * B.Magnitude);
        return (numerator / denominator) * B;
    }

    /// <summary>
    /// Returns the magnitude of the projection of A onto B.
    /// </summary>
    /// <param name="A"> The vector to project. </param>
    /// <param name="B"> The vector projected onto. </param>
    /// <returns> The magnitude of the vector projection. </returns>
    public static float ProjectionABMagnitude(C_V2 A, C_V2 B)
    {
        float numerator = DotProduct(A, B);
        float denominator = B.Magnitude;
        return (numerator / denominator);
    }

    public static C_V2 Parallel(C_V2 a)
    {
        C_V2 direction = C_V2.right;
        C_V2 projectionAB = ProjectionAB(a, direction.Unitized);
        return projectionAB;
    }

    public static C_V2 Parallel(C_V2 a, C_V2 norm)
    {
        C_V2 projectionAB = ProjectionAB(a, norm.Unitized);
        return projectionAB;
    }

    public static C_V2 Perpendicular(C_V2 a)
    {
        C_V2 direction = right;
        C_V2 projectionAB = ProjectionAB(a, direction.Unitized);
        return a - projectionAB;
    }

    public static C_V2 Perpendicular(C_V2 a, C_V2 norm)
    {
        C_V2 projectionAB = ProjectionAB(a, norm.Unitized);
        return a - projectionAB;
    }

    #endregion

    public static C_V2 Reflection(C_V2 a, C_V2 normal)
    {
        float dotA = DotProduct(a, normal);
        float dotN = DotProduct(normal, normal);

        return a - ((2 * dotA / dotN) * normal);
    }

    ////TODO: Calculate C_Vec2 reflection array. 

    public static C_P2D GetLineMidpointFromPoint(C_P2D point, C_V2 vec)
    {
        return point + (C_P2D)vec.MidpointVec;
    }

    ////TODO: Create Unit Test for LerpUnclamped. 

    ///// <summary>
    ///// Interpolate a C_Vec2 Based on time. 
    ///// </summary>
    ///// <param name="initalPosition"> is the inital position to move from. </param>
    ///// <param name="Direction"> is the direction to move in. </param>
    ///// <param name="time"> The time multiplier that the vector is scaled by. </param>
    ///// <returns> Interpolated C_Vec2. </returns>
    //public static C_V2 LerpUnclamped(C_Point2D initalPosition, C_V2 Direction, float time) =>
    //    new(initalPosition.x + (Direction.x - initalPosition.x) * time,
    //        initalPosition.y + (Direction.y - initalPosition.y) * time);

    #region Utility Functions. 
    #region Setting Elements. 
    /// <summary>
    /// Set the existing components of the vector. 
    /// 
    /// --
    /// </summary>
    public void Set(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Copy the component values from vector a to vector b. 
    /// </summary>
    /// <param name="b"> The vector to copy component values to. </param>
    /// <param name="a"> The vector to copy component values from. </param>
    public static void CopyTo(C_V2 a, ref C_V2 b) =>
        b.Set(a.x, a.y);
    #endregion
    #region Equality. 
    public override bool Equals(object obj)
    {
        C_V2 objInst;

        if ((obj is C_V2))
        {
            objInst = (C_V2)obj;

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
    #endregion

    public void DrawVector(Vector2 position)
    {
        //Draw vector. 
        Gizmos.color = Color.white;
        Gizmos.DrawLine(position, (Vector3)position + (Vector3)((Vector2)this));

        //Draw parallel vector. 
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, (Vector3)position + (Vector3)Parallel(this));

        //Draw perpendicular. 
        Gizmos.color = Color.green;
        Gizmos.DrawLine(position, (Vector3)position + (Vector3)Perpendicular(this));
        Gizmos.color = Color.white;
    }
    #endregion

    #region Operators. 
    public static C_V2 operator +(C_P2D a, C_V2 b) => new C_V2(a.x + b.x, a.y + b.y);

    public static C_V2 operator +(C_V2 a, C_V2 b) => new C_V2(a.x + b.x, a.y + b.y);

    public static C_V2 operator -(C_V2 a, C_V2 b) => a + (-1 * b);

    public static C_V2 operator *(int a, C_V2 b) => new C_V2(b.x * a, b.y * a);

    public static C_V2 operator *(float a, C_V2 b) => new C_V2(b.x * a, b.y * a);

    public static bool operator ==(C_V2 lhs, C_V2 rhs) => (lhs.x == rhs.x && lhs.y == rhs.y);

    public static bool operator !=(C_V2 lhs, C_V2 rhs) => !(lhs.x != rhs.x && lhs.y != rhs.y);

    public static C_V2 operator *(C_V2 lhs, C_V2 rhs) => new C_V2(lhs.x * rhs.x, lhs.y * rhs.y);

    public static explicit operator Vector3(C_V2 vec) => new Vector3(vec.x, vec.y, 0);

    public static explicit operator Vector2(C_V2 vec) => new Vector2(vec.x, vec.y);
    #endregion
}
