using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public struct C_M2X2
{
    /// <summary>
    /// The float value of the first row first column. 
    /// </summary>
    public float E00;
    /// <summary>
    /// The float value of the first row second column. 
    /// </summary>
    public float E01;
    /// <summary>
    /// The float value of the second row first column. 
    /// </summary>
    public float E10;
    /// <summary>
    /// The float value of the second row second column. 
    /// </summary>
    public float E11;

    #region Shorthand References. 
    private static C_M2X2 identity = new C_M2X2(1, 0, 1, 0);
    private static C_M2X2 zero = new C_M2X2(0, 0, 0, 0);
    private static C_M2X2 rot90C = new C_M2X2(0, 1, -1, 0);
    private static C_M2X2 rot90CC = new C_M2X2(0, -1, 1, 0);

    /// <summary>
    /// Returns a C_M2X2 with diagonal elements set to 1. 
    /// </summary>
    public static C_M2X2 Identity => identity;
    
    /// <summary>
    /// Returns a C_M2X2 with all elements set to 0. 
    /// </summary>
    public static C_M2X2 Zero => zero;
    
    /// <summary>
    /// Returns a C_M2X2 representing a clockwise 90 degree rotation. 
    /// </summary>
    public static C_M2X2 Rot90C => rot90C;

    /// <summary>
    /// Returns a C_M2X2 representing a counter-clockwise 90 degree rotation. 
    /// </summary>
    public static C_M2X2 Rot90CC => rot90CC;
    #endregion

    #region Row/Column Access Properties. 
    /// <summary>
    /// Returns the elements held in the first row of the matrix 
    /// </summary>
    public C_Seq2 R1
    {
        get => new C_Seq2(E00, E01);
        set
        {
            E00 = value.E0;
            E01 = value.E1;
        }
    }

    /// <summary>
    /// Returns the elements held in the second row of the matrix 
    /// </summary>
    public C_Seq2 R2
    {
        get => new C_Seq2(E10, E11);
        set
        {
            E10 = value.E0;
            E11 = value.E1;
        }
    }

    /// <summary>
    /// Returns the elements held in the first column of the matrix 
    /// </summary>
    public C_Seq2 C1
    {
        get => new C_Seq2(E00, E10);
        set
        {
            E00 = value.E0;
            E10 = value.E1;
        }
    }

    /// <summary>
    /// Returns the elements held in the second column of the matrix 
    /// </summary>
    public C_Seq2 C2
    {
        get => new C_Seq2(E01, E11);
        set
        {
            E01 = value.E0;
            E11 = value.E1;
        }
    }
    #endregion

    #region Math Properties. 

    /// <summary>
    /// Returns the determinant of the C_M2X2. 
    /// </summary>
    public float Determinant =>
        E00 * E11 - E10 * E01;

    /// <summary>
    /// Returns the Adjoint C_M2X2. 
    /// </summary>
    public C_M2X2 Adjoint => new C_M2X2(
             E11, -E01,
            -E10, E00
            );

    #endregion

    #region CTORS. 
    /// <summary>
    /// Create a C_M2X2 matrix. 
    /// </summary>
    /// <param name="e00"> The float value of the first row first column.   </param>
    /// <param name="e01"> The float value of the first row second column.  </param>
    /// <param name="e10"> The float value of the second row first column.  </param>
    /// <param name="e11"> The float value of the second row second column. </param>
    public C_M2X2(float e00, float e01, float e10, float e11)
    {
        E00 = e00;
        E01 = e01;
        E10 = e10;
        E11 = e11;
    }
    #endregion

    /// <summary>
    /// Returns vector v rotated 90 degrees counter-clockwise. 
    /// </summary>
    /// <param name="v"> The vector to rotate. </param>
    public static Vector2 RotateCC90(Vector2 v) => Rot90CC * v;
    public static C_V2 RotateCC90(C_V2 v) => Rot90CC * v;

    /// <summary>
    /// Returns vector v rotated 90 degrees clockwise. 
    /// </summary>
    /// <param name="v"> The vector to rotate. </param>
    public static Vector2 RotateC90(Vector2 v) => Rot90C * v;
    public static C_V2 RotateC90(C_V2 v) => Rot90C * v;

    /// <summary>
    /// Interchange C_M2X2 a's rows with columns.  
    /// </summary>
    /// <param name="a"> The C_M2X2 to transpose.</param>
    public void Transpose() => Transpose(ref this);

    /// <summary>
    /// Interchange C_M2X2 a's rows with columns.  
    /// </summary>
    /// <param name="a"> The C_M2X2 to transpose.</param>
    public static void Transpose(ref C_M2X2 a)
    {
        C_Seq2 _a = a.R1;
        C_Seq2 _b = a.R2;
        a.C1 = _a;
        a.C2 = _b;
    }

    /// <summary>
    /// Returns the inverse C_M2X2 of this C_M2X2 if defined.
    /// If the inverse cannot be generated, returns zero matrix. 
    /// </summary>
    public readonly C_M2X2 Inverse()
    {
        C_M2X2 copy = C_M2X2.Zero;
        C_M2X2.Copy(this, ref copy);

        float det = copy.Determinant;

        //If the det is zero the inverse does not exist. 
        if (det == 0)
            return C_M2X2.Zero;

        //Calculate the inverse matrix and return. 
        return (1 / det) * copy.Adjoint;

    }

    #region Utility Functions. 
    /// <summary>
    /// Copy the elements of the first matrix to the second. 
    /// </summary>
    /// <param name="a"> The C_M2X2 matrix to copy. </param>
    /// <param name="b"> The reciving C_M2X2 instance. </param>
    public static void Copy(C_M2X2 a, ref C_M2X2 b)
    {
        b.E00 = a.E00;
        b.E01 = a.E01;
        b.E10 = a.E10;
        b.E11 = a.E11;
    }

    /// <summary>
    /// Print the matrix to using Unity Engines built in debugger. 
    /// </summary>
    public void PrintMatrix()
    {
        Debug.Log(this.ToString());
    }

    /// <summary>
    /// Retrive the C_M2X2 formatted as a string. 
    /// </summary>
    /// <returns> String formatted copy of the matrix. </returns>
    public override string ToString()
    {
        return "[" + E00 + ", " + E01 + "] \n" 
             + "[" + E10 + ", " + E11 + "]";
    }

    public override bool Equals(object obj)
    {
        C_M2X2 objInst;

        if ((obj is C_M2X2))
        {
            objInst = (C_M2X2)obj;

            return (
                R1.E0 == objInst.R1.E0 &&
                R1.E1 == objInst.R1.E1 &&
                R2.E0 == objInst.R2.E0 &&
                R2.E1 == objInst.R2.E1
                );
        }

        return false;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + R1.GetHashCode();
        hash = hash * 23 + R2.GetHashCode();
        hash = hash * 23 + C1.GetHashCode();
        hash = hash * 23 + C2.GetHashCode();
        return hash;
    }
    #endregion

    #region Operators. 
    public static C_M2X2 operator *(float scalar, C_M2X2 rhs)
    {
        C_M2X2 r = new C_M2X2(
            scalar * rhs.E00,
            scalar * rhs.E01,
            scalar * rhs.E10,
            scalar * rhs.E11
            );
        return r;
    }

    public static C_M2X2 operator *(C_M2X2 lhs, C_M2X2 rhs)
    {
        C_M2X2 r = new C_M2X2(
            lhs.E00 * rhs.E00 + lhs.E01 * rhs.E10,
            lhs.E00 * rhs.E01 + lhs.E01 * rhs.E11,
            lhs.E10 * rhs.E00 + lhs.E11 * rhs.E10,
            lhs.E10 * rhs.E01 + lhs.E11 * rhs.E11
            );
        //r.E00 = a.E00 * b.E00 + a.E01 * b.E10;
        //r.E10 = a.E10 * b.E00 + a.E11 * b.E10;
        //r.E01 = a.E00 * b.E01 + a.E01 * b.E11;
        //r.E11 = a.E10 * b.E01 + a.E11 * b.E11;
        return r;
    }

    public static Vector2 operator *(C_M2X2 lhs, Vector2 rhs)
    {
        return new Vector2(
            lhs.E00 * rhs.x + lhs.E01 * rhs.y,
            lhs.E10 * rhs.x + lhs.E11 * rhs.y
            ); 
    }

    public static Vector2[] operator *(C_M2X2 lhs, Vector2[] rhs)
    {
        Vector2[] points = new Vector2[rhs.Length];

        for (int i = 0; i < rhs.Length; i++)
        {
            points[i] = lhs * rhs[i];
        }
        return points; 
    }

    public static C_V2 operator *(C_M2X2 lhs, C_V2 rhs)
    {
        return new C_V2(
            lhs.E00 * rhs.x + lhs.E01 * rhs.y,
            lhs.E10 * rhs.x + lhs.E11 * rhs.y
            );
    }

    public static C_V2[] operator *(C_M2X2 lhs, C_V2[] rhs)
    {
        C_V2[] points = new C_V2[rhs.Length];

        for (int i = 0; i < rhs.Length; i++)
        {
            points[i] = lhs * rhs[i];
        }
        return points;
    }

    public static C_M2X2 operator +(C_M2X2 lhs, C_M2X2 rhs)
    {
        C_M2X2 r = new C_M2X2();
        r.E00 = lhs.E00 + rhs.E00;
        r.E01 = lhs.E01 + rhs.E01;
        r.E10 = lhs.E10 + rhs.E10;
        r.E11 = lhs.E11 + rhs.E11;
        return r;
    }

    public static C_M2X2 operator -(C_M2X2 lhs, C_M2X2 rhs)
    {
        C_M2X2 r = new C_M2X2();
        r.E00 = lhs.E00 - rhs.E00;
        r.E01 = lhs.E01 - rhs.E01;
        r.E10 = lhs.E10 - rhs.E10;
        r.E11 = lhs.E11 - rhs.E11;
        return r;
    }

    //TODO:Unit Test this. 
    public static implicit operator C_M2X2(C_M3X3 m) =>
        new C_M2X2(m.E00, m.E01, m.E10, m.E11);

    public static bool operator ==(C_M2X2 x, C_M2X2 y)
    {
        return (x.C1 == y.C1 && x.C2 == y.C2);
    }

    public static bool operator !=(C_M2X2 x, C_M2X2 y)
    {
        return !x.Equals(y);
    }
    #endregion
}
