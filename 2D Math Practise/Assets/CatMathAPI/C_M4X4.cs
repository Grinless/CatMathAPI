using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public struct C_M4X4
{
    //private const string ROW_ACCESS_ID_ERROR =
    //"C_Matrix3x3 does not define rows outside the range [0, 2].";

    //private const string COLUMN_ACCESS_ID_ERROR =
    //"C_Matrix3x3 does not define columns outside the range [0, 2].";

    //private C_Seq4 _C0;
    //private C_Seq4 _C1;
    //private C_Seq4 _C2;
    //private C_Seq4 _C3;

    //public readonly C_Seq4 C0 => _C0; 
    //public readonly C_Seq4 C1 => _C1; 
    //public readonly C_Seq4 C2 => _C2; 
    //public readonly C_Seq4 C3 => _C3; 

    //public readonly C_Seq4 R0 => new C_Seq4(_C0.E0, _C1.E0, _C2.E0, _C3.E0);
    //public readonly C_Seq4 R1 => new C_Seq4(_C0.E1, _C1.E1, _C2.E1, _C3.E1);
    //public readonly C_Seq4 R2 => new C_Seq4(_C0.E2, _C1.E2, _C2.E2, _C3.E2);
    //public readonly C_Seq4 R3 => new C_Seq4(_C0.E3, _C1.E3, _C2.E3, _C3.E3);

    //public C_M4X4 Zero =>
    //new C_M4X4(
    //    C_Seq4.Zero,
    //    C_Seq4.Zero,
    //    C_Seq4.Zero,
    //    C_Seq4.Zero
    //    );

    //public C_M4X4 Identity =>
    //    new C_M4X4(
    //        C_Seq4.SeqX,
    //        C_Seq4.SeqY,
    //        C_Seq4.SeqZ,
    //        C_Seq4.SeqW
    //        );

    //public C_M4X4(C_Seq4 x, C_Seq4 y, C_Seq4 z, C_Seq4 w)
    //{
    //    this._C0 = x;
    //    this._C1 = y;
    //    this._C2 = z;
    //    this._C3 = w;
    //}

    //#region Multiplication Functions.

    //#endregion

    //public static C_Matrix3X3 Transpose(C_Matrix3X3 a)
    //{
    //    return new(
    //        a.GetRow(0),
    //        a.GetRow(1),
    //        a.GetRow(2)
    //        );
    //}

    //#region Affine Transformation Matrices. 

    //#region Translation Matrix Functions. 
    //public static C_M4X4 TranslationMatrixX(float x)
    //{
    //    return TranslationMatrix(x, 0, 0);
    //}

    //public static C_M4X4 TranslationMatrixY(float y)
    //{
    //    return TranslationMatrix(0, y, 0);
    //}

    //public static C_M4X4 TranslationMatrixZ(float z)
    //{
    //    return TranslationMatrix(0, 0, z);
    //}

    //public static C_M4X4 TranslationMatrix(float x, float y, float z)
    //{
    //    return new C_M4X4(
    //        new(1, 0, 0, 0),
    //        new(0, 1, 0, 0),
    //        new(0, 0, 1, 0),
    //        new(x, y, z, 1)
    //        );
    //}
    //#endregion

    //#region Scale Matrix Functions.
    //public static C_M4X4 GetScaleMatrixX(float x)
    //{
    //    return GetScaleMatrix(x, 1, 1);
    //}

    //public static C_M4X4 GetScaleMatrixY(float y)
    //{
    //    return GetScaleMatrix(1, y, 1);
    //}

    //public static C_M4X4 GetScaleMatrixZ(float z)
    //{
    //    return GetScaleMatrix(1, 1, z);
    //}

    //public static C_M4X4 GetScaleMatrix(float x, float y, float z)
    //{
    //    return new C_M4X4(
    //        x * C_Seq4.SeqX,
    //        y * C_Seq4.SeqY,
    //        z * C_Seq4.SeqZ,
    //        C_Seq4.SeqW
    //        );
    //}
    //#endregion

    //public static C_Matrix3X3 RotationMatrixX(float angle)
    //{
    //    float angleR = angle * Mathf.Deg2Rad;

    //    return new(
    //        new(Mathf.Cos(angleR), Mathf.Sin(angleR), 0),
    //        new(-Mathf.Sin(angleR), Mathf.Cos(angleR), 0),
    //        C_Seq3.SeqZ
    //        );
    //}

    //public static C_Matrix3X3 RotationMatrixY(float angle)
    //{
    //    float angleR = angle * Mathf.Deg2Rad;

    //    return new(
    //        new(Mathf.Cos(angleR), Mathf.Sin(angleR), 0),
    //        new(-Mathf.Sin(angleR), Mathf.Cos(angleR), 0),
    //        C_Seq3.SeqZ
    //        );
    //}

    //public static C_Matrix3X3 RotationMatrixZ(float angle)
    //{
    //    float angleR = angle * Mathf.Deg2Rad;

    //    return new(
    //        new(Mathf.Cos(angleR), Mathf.Sin(angleR), 0),
    //        new(-Mathf.Sin(angleR), Mathf.Cos(angleR), 0),
    //        C_Seq3.SeqZ
    //        );
    //}

    //public static C_Matrix3X3 RotationMatrix(
    //float t1, float t2, float t3)
    //{
    //    //Calculate repeated values. 
    //    float a = -MathF.Sin(t1) * MathF.Sin(t2);
    //    float b = MathF.Sin(t1) * MathF.Sin(t3);
    //    float c = MathF.Cos(t1) * MathF.Cos(t3);

    //    /////////////
    //    //Calculate individual elements. 
    //    ////////////

    //    //X column. 
    //    float x1 = MathF.Cos(t2) * MathF.Cos(t3);
    //    float x2 = (a * MathF.Cos(t3)) + (MathF.Cos(t1) * MathF.Sin(t3));
    //    float x3 = (c * MathF.Sin(t1)) + b;

    //    //Y column.
    //    float y1 = -MathF.Cos(t2) * MathF.Sin(t3);
    //    float y2 = a + c;
    //    float y3 = (-b * MathF.Cos(t1)) - b;

    //    //z Column.
    //    float z1 = -MathF.Sin(t2);
    //    float z2 = -MathF.Sin(t1) * MathF.Cos(t2);
    //    float z3 = MathF.Cos(t1) * MathF.Cos(t2);

    //    return new(new(x1, x2, x3), new(y1, y2, y3), new(z1, z2, z3));
    //}

    //public static C_Matrix3X3 RotationMatrix(float angle)
    //{
    //    float angleR = angle * Mathf.Deg2Rad;

    //    return new(
    //        new(Mathf.Cos(angleR), Mathf.Sin(angleR), 0),
    //        new(-Mathf.Sin(angleR), Mathf.Cos(angleR), 0),
    //        C_Seq3.SeqZ
    //        );
    //}

    //public static C_Matrix3X3 ReflectionMatrix(int signX, int signY)
    //{
    //    return new(
    //        new(signX * 1, 0, 0),
    //        new(0, signY * 1, 0),
    //        new(0, 0, 1)
    //        );
    //}

    //public static C_Matrix3X3 ShearMatrix(float shearX, float shearY)
    //{
    //    return new(
    //        new(1, shearY, 0),
    //        new(shearX, 1, 0),
    //        C_Seq3.SeqZ
    //        );
    //}

    //#endregion

    //#region Accessor Functions. 

    //public float GetElement(int row, int column)
    //{
    //    switch (column)
    //    {
    //        case 0:
    //            return _C0.GetElement(row);
    //        case 1:
    //            return _C1.GetElement(row);
    //        case 2:
    //            return C2.GetElement(row);
    //        case 3:
    //            return _C3.GetElement(row);
    //        default:
    //            Debug.Break();
    //            return float.NaN;
    //    }
    //}

    //#endregion


}
