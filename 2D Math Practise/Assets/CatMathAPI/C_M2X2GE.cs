using UnityEngine;
/// <summary>
/// Lightweight Matrix class for Gaussian Elimination. 
/// </summary>
[System.Serializable]
public struct C_M2X2GE
{
    public float E00;
    public float E01;
    public float E10;
    public float E11;
    public float V1;
    public float V2; 

    public readonly C_Seq2 R1 => new C_Seq2(E00, E01);
    public readonly C_Seq2 R2 => new C_Seq2(E10, E11);
    public readonly C_Seq2 C1 => new C_Seq2(E00, E10);
    public readonly C_Seq2 C2 => new C_Seq2(E01, E11);

    public C_M2X2GE(float e00, float e01, float e10, float e11)
    {
        E00 = e00;
        E01 = e01;
        E10 = e10;
        E11 = e11;
        V1 = 0; 
        V2 = 0;
    }

    public static void Copy(C_M2X2 a, ref C_M2X2GE b)
    {
        b.E00 = a.E00;
        b.E01 = a.E01;
        b.E10 = a.E10;
        b.E11 = a.E11;
    }

    public static void Copy(C_M2X2GE a, ref C_M2X2 b)
    {
        b.E00 = a.E00;
        b.E01 = a.E01;
        b.E10 = a.E10;
        b.E11 = a.E11;
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

    public static C_M2X2GE operator *(float scalar, C_M2X2GE rhs)
    {
        C_M2X2GE r = new C_M2X2GE(
            scalar * rhs.E00,
            scalar * rhs.E01,
            scalar * rhs.E10,
            scalar * rhs.E11
            );
        return r;
    }

    public static C_M2X2GE operator *(C_M2X2GE lhs, C_M2X2GE rhs)
    {
        C_M2X2GE r = new C_M2X2GE(
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

    public static C_M2X2GE operator +(C_M2X2GE lhs, C_M2X2GE rhs)
    {
        C_M2X2GE r = new C_M2X2GE();
        r.E00 = lhs.E00 + rhs.E00;
        r.E01 = lhs.E01 + rhs.E01;
        r.E10 = lhs.E10 + rhs.E10;
        r.E11 = lhs.E11 + rhs.E11;
        return r;
    }

    public static C_M2X2GE operator -(C_M2X2GE lhs, C_M2X2GE rhs)
    {
        return lhs + (-1.0F * rhs);
    }

    public override bool Equals(object obj)
    {
        C_M2X2GE objInst;

        if ((obj is C_M2X2GE))
        {
            objInst = (C_M2X2GE)obj;

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

    public static bool operator ==(C_M2X2GE x, C_M2X2GE y)
    {
        return x.Equals(y);
    }

    public static bool operator !=(C_M2X2GE x, C_M2X2GE y)
    {
        return !x.Equals(y);
    }
}