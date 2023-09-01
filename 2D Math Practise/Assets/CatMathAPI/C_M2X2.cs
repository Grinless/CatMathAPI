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
    public float E00; 
    public float E01;
    public float E10;
    public float E11;

    #region Shorthand References. 
    private static C_M2X2 identity = new C_M2X2(1, 0, 1, 0);
    private static C_M2X2 zero = new C_M2X2(0, 0, 0, 0);
    public static C_M2X2 Identity => identity;
    public static C_M2X2 Zero => zero;
    #endregion

    #region Row/Column Access Properties. 
    public readonly C_Seq2 R1 => new C_Seq2(E00, E01);
    public readonly C_Seq2 R2 => new C_Seq2(E10, E11);
    public readonly C_Seq2 C1 => new C_Seq2(E00, E10);
    public readonly C_Seq2 C2 => new C_Seq2(E01, E11);
    #endregion

    #region CTORS. 
    public C_M2X2(float e00, float e01, float e10, float e11)
    {
        E00 = e00;
        E01 = e01;
        E10 = e10;
        E11 = e11;
    }
    #endregion

    public static void Copy(C_M2X2 a, ref C_M2X2 b)
    {
        b.E00 = a.E00; 
        b.E01 = a.E01; 
        b.E10 = a.E10; 
        b.E11 = a.E11;
    }

    public static C_M2X2 Transpose(C_M2X2 a)
    {
        return new C_M2X2(a.E00, a.E10, a.E01, a.E11);
    }

    public static C_V2 TRS_OP(C_Seq2 pos, C_Seq2 translation, C_Seq2 scale, float theta)
    {
        float cosT = MathF.Cos(theta * Mathf.Deg2Rad);
        float sinT = MathF.Sin(theta * Mathf.Deg2Rad);

        return new C_V2(
            (pos.E0 * scale.E0 * cosT) - (pos.E1 * scale.E0 * sinT) + (translation.E0 * 1),
            (pos.E0 * scale.E1 * sinT) + (pos.E1 * scale.E1 * cosT) + (translation.E1 * 1)
            );
    }

    public static C_V2 TRS_OP(C_V2 pos, C_V2 translation,
        C_V2 scale, float theta)
    {
        float cosT = MathF.Cos(theta * Mathf.Deg2Rad);
        float sinT = MathF.Sin(theta * Mathf.Deg2Rad);

        return new C_V2(
            (pos.x * scale.x * cosT) - (pos.y * scale.x * sinT) + (translation.x * 1),
            (pos.x * scale.y * sinT) + (pos.y * scale.y * cosT) + (translation.y * 1)
            );
    }

    public void PrintMatrix()
    {
        Debug.Log(this.ToString());
    }

    public override string ToString()
    {
        string str1 = "[{0} {1}] \n";
        string str2 = "[{0} {1}]";
        return string.Format(str1, E00, E01) +
               string.Format(str2, E10, E11) + "\n";
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

    //Unit Test this. 
    public static implicit operator C_M2X2(C_M3X3 m) =>
        new C_M2X2(m.E00, m.E01, m.E10, m.E11);

    public static bool operator ==(C_M2X2 x, C_M2X2 y)
    {
        return x.Equals(y);
    }

    public static bool operator !=(C_M2X2 x, C_M2X2 y)
    {
        return !x.Equals(y);
    }
}
