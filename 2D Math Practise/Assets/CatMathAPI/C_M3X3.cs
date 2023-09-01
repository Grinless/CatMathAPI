using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public struct C_M3X3
{
    public float E00, E01, E02;
    public float E10, E11, E12;
    public float E20, E21, E22;

    #region Shorthand Refs. 
    private static C_M2X2 identity = new C_M2X2(1, 0, 1, 0);
    private static C_M2X2 zero = new C_M2X2(0, 0, 0, 0);
    public static C_M2X2 Identity => identity;
    public static C_M2X2 Zero => zero;
    #endregion

    public C_Seq3 R1
    {
        get => new C_Seq3(E00, E01, E02);
        set
        {
            E00 = value.E0;
            E01 = value.E1;
            E02 = value.E2;
        }
    }

    public C_Seq3 R2
    {
        get => new C_Seq3(E10, E11, E12);
        set
        {
            E10 = value.E0;
            E11 = value.E1;
            E12 = value.E2;
        }
    }

    public C_Seq3 R3
    {
        get => new C_Seq3(E20, E21, E22);
        set
        {
            E20 = value.E0;
            E21 = value.E1;
            E22 = value.E2;
        }
    }

    public C_Seq3 C1
    {
        get => new C_Seq3(E00, E10, E20);
        set
        {
            E00 = value.E0;
            E10 = value.E1;
            E20 = value.E2;
        }
    }

    public C_Seq3 C2
    {
        get => new C_Seq3(E01, E11, E21);
        set
        {
            E01 = value.E0;
            E11 = value.E1;
            E21 = value.E2;
        }
    }

    public C_Seq3 C3
    {
        get => new C_Seq3(E02, E12, E22);
        set
        {
            E02 = value.E0;
            E12 = value.E1;
            E22 = value.E2;
        }
    }

    public C_M3X3(float E00, float E01, float E02, float E10,
        float E11, float E12, float E20, float E21, float E22)
    {
        this.E00 = E00;
        this.E01 = E01;
        this.E02 = E02;
        this.E10 = E10;
        this.E11 = E11;
        this.E12 = E12;
        this.E20 = E20;
        this.E21 = E21;
        this.E22 = E22;
    }

    public static void Copy(C_M3X3 a, ref C_M3X3 b)
    {
        b.E00 = a.E00;
        b.E01 = a.E01;
        b.E10 = a.E10;
        b.E11 = a.E11;

        b.E00 = a.E00;
        b.E01 = a.E01;
        b.E02 = a.E02;
        b.E10 = a.E10;
        b.E11 = a.E11;
        b.E12 = a.E12;
        b.E20 = a.E20;
        b.E21 = a.E21;
        b.E22 = a.E22;
    }

    public void Transpose()
    {
        C_M3X3.Transpose(ref this);
    }

    public static void Transpose(ref C_M3X3 a)
    {
        C_Seq3 r1 = a.R1;
        C_Seq3 r2 = a.R2;
        C_Seq3 r3 = a.R3;

        a.C1 = r1; 
        a.C2 = r2;
        a.C3 = r3;
    }

    public void PrintMatrix()
    {
        Debug.Log(this.ToString());
    }

    public override string ToString()
    {
        string str1 = "[{0} {1} {3}]";
        string str2 = "[{0} {1} {3}}";
        string str3 = "[{0} {1} {3}}";
        return string.Format(str1, E00, E01, E02) +
               string.Format(str2, E10, E11, E12) + "\n" +
               string.Format(str3, E20, E21, E22) + "\n";
    }

    public static C_M3X3 TranslationMatrixX(float x)
    {
        return TranslationMatrix(x, 0);
    }

    public static C_M3X3 TranslationMatrixY(float y)
    {
        return TranslationMatrix(0, y);
    }

    public static C_M3X3 TranslationMatrix(float x, float y)
    {
        return new C_M3X3(
            1, 0, x,
            0, 1, y,
            0, 0, 1
            );
    }

    public static C_M3X3 GetScaleMatrixX(float x)
    {
        return GetScaleMatrix(x, 1);
    }

    public static C_M3X3 GetScaleMatrixY(float y)
    {
        return GetScaleMatrix(1, y);
    }

    public static C_M3X3 GetScaleMatrix(float x, float y)
    {
        return new C_M3X3(
            x *1,      0,     0,
               0,  y * 1,     0,
               0,      0,     1
            );
    }

    public static C_M3X3 RotationMatrix(
        float theta1, float theta2, float theta3)
    {
        //Calculate repeated values. 
        float a = -MathF.Sin(theta1) * MathF.Sin(theta2);
        float b = MathF.Sin(theta1) * MathF.Sin(theta3);
        float c = MathF.Cos(theta1) * MathF.Cos(theta3);

        /////////////
        //Calculate Matrix. 
        ////////////

        return new(
                MathF.Cos(theta2) * MathF.Cos(theta3),
                (a * MathF.Cos(theta3)) + (MathF.Cos(theta1) * MathF.Sin(theta3)),
                (c * MathF.Sin(theta1)) + b
                ,
                -MathF.Cos(theta2) * MathF.Sin(theta3),
                a + c,
                (-b * MathF.Cos(theta1)) - b
                ,
                -MathF.Sin(theta2),
                -MathF.Sin(theta1) * MathF.Cos(theta2),
                MathF.Cos(theta1) * MathF.Cos(theta2)
            );
    }

    public static C_M3X3 RotationMatrix(float angle)
    {
        float angleR = angle * Mathf.Deg2Rad;

        return new(
             Mathf.Cos(angleR), Mathf.Sin(angleR), 0,
            -Mathf.Sin(angleR), Mathf.Cos(angleR), 0,
                             0,                 0, 1
            );
    }

    public static C_M3X3 ReflectionMatrix(int signX, int signY)
    {
        return new(
            signX * 1,         0, 0,
                    0, signY * 1, 0,
                    0,         0, 1
            );
    }

    public static C_M3X3 ShearMatrix(float shearX, float shearY)
    {
        return new(
            1,      shearY, 0,
            shearX,      1, 0,
            0,           0, 1
            );
    }

    public static C_M3X3 operator *(float lhs, C_M3X3 rhs)
    {
        return new C_M3X3(
            lhs * rhs.E00, lhs * rhs.E01, lhs * rhs.E02,
            lhs * rhs.E10, lhs * rhs.E11, lhs * rhs.E12,
            lhs * rhs.E20, lhs * rhs.E21, lhs * rhs.E22
            );
    }

    public static C_M3X3 operator *(C_M3X3 lhs, C_M3X3 rhs)
    {
        float E00 = lhs.E00 * rhs.E00 + lhs.E01 * rhs.E10 + lhs.E02 * rhs.E20;
        float E10 = lhs.E10 * rhs.E00 + lhs.E11 * rhs.E10 + lhs.E12 * rhs.E20;
        float E20 = lhs.E20 * rhs.E00 + lhs.E21 * rhs.E10 + lhs.E22 * rhs.E20;

        float E01 = lhs.E00 * rhs.E01 + lhs.E01 * rhs.E11 + lhs.E02 * rhs.E21; 
        float E11 = lhs.E10 * rhs.E01 + lhs.E11 * rhs.E11 + lhs.E12 * rhs.E21; 
        float E21 = lhs.E20 * rhs.E01 + lhs.E21 * rhs.E11 + lhs.E22 * rhs.E21; 
        
        float E02 = lhs.E00 * rhs.E02 + lhs.E01 * rhs.E12 + lhs.E02 * rhs.E22; 
        float E12 = lhs.E10 * rhs.E02 + lhs.E11 * rhs.E12 + lhs.E12 * rhs.E22; 
        float E22 = lhs.E20 * rhs.E02 + lhs.E21 * rhs.E12 + lhs.E22 * rhs.E22; 

        return new C_M3X3(
            E00, E01, E02,
            E10, E11, E12, 
            E20, E21, E22
            );
    }

    public static C_M3X3 operator +(C_M3X3 lhs, C_M3X3 rhs)
    {
        return new C_M3X3(
            lhs.E00 + rhs.E00, lhs.E10 + rhs.E10, lhs.E02 + rhs.E02,
            lhs.E10 + rhs.E10, lhs.E11 + rhs.E11, lhs.E12 + rhs.E12,
            lhs.E20 + rhs.E20, lhs.E21 + rhs.E21, lhs.E22 + rhs.E22
            );
    }

    public static C_M3X3 operator -(C_M3X3 lhs, C_M3X3 rhs)
    {
        return lhs + (-1.0F * rhs);
    }

    public override bool Equals(object obj)
    {
        C_M3X3 objInst;

        if ((obj is C_M2X2))
        {
            objInst = (C_M3X3)obj;

            return (
                R1.E0 == objInst.R1.E0 &&
                R1.E1 == objInst.R1.E1 &&
                R1.E2 == objInst.R2.E2 &&
                R2.E0 == objInst.R2.E0 &&
                R2.E1 == objInst.R2.E1 &&
                R2.E2 == objInst.R2.E2 &&
                R3.E0 == objInst.R3.E0 &&
                R3.E1 == objInst.R3.E1 &&
                R3.E2 == objInst.R3.E2 
                );
        }

        return false;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + R1.GetHashCode();
        hash = hash * 23 + R2.GetHashCode();
        hash = hash * 23 + R3.GetHashCode();
        hash = hash * 23 + C1.GetHashCode();
        hash = hash * 23 + C2.GetHashCode();
        hash = hash * 23 + C3.GetHashCode();
        return hash;
    }

    public static bool operator ==(C_M3X3 x, C_M3X3 y)
    {
        return x.Equals(y);
    }

    public static bool operator !=(C_M3X3 x, C_M3X3 y)
    {
        return !x.Equals(y);
    }
}