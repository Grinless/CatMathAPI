using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Incomplete: Matrix class used for solving systems of equations. 
/// --> Requires row interchange implementation. 
/// --> Requires solving implementation. 
/// --> Requries Determinant implementation. 
/// </summary>
public class C_GaussMatrix
{
    public float[][] Matrix;

    public C_GaussMatrix(C_M2X2 matrix, C_Seq2 values) {

        Matrix = new float[][]
        {
            new float[] { matrix.E00, matrix.E01, values.E0},
            new float[] { matrix.E10, matrix.E11, values.E1}
        };
    }

    public C_GaussMatrix(C_M3X3 matrix, C_Seq3 values)
    {
        Matrix = new float[][]
        {
            new float[] { matrix.E00, matrix.E01, matrix.E02, values.E0},
            new float[] { matrix.E10, matrix.E11, matrix.E12, values.E1},
            new float[] { matrix.E20, matrix.E21, matrix.E22, values.E2}
        };
    }

    public void CalculateMatrixDeterminant()
    {
    }

    public void CheckPivoting()
    {
        if (Matrix.GetLength(0) == 2 && Matrix.GetLength(1) == 1)
        {
            PivotCheck2D(); 
        }

        if(Matrix.GetLength(0) == 2 && Matrix.GetLength(1) == 2)
        {
            PivotCheck3D(); 
        }
    }

    public void PivotCheck2D()
    {
        if (Matrix[0][0] == 0)
        {
            //First pivot missing.  
        }

        if (Matrix[1][1] == 0)
        {
            //Second pivot missing. 
        }
    }

    public void PivotCheck3D()
    {
        if (Matrix[0][0] == 0)
        {
            //First pivot missing.  
        }

        if (Matrix[1][1] == 0)
        {
            //Second pivot missing. 
        }

        if (Matrix[2][2] == 0)
        {
            //Second pivot missing. 
        }
    }

    ///TODO: Implement following completion of C_M4X4. 
    
    //public C_GaussMatrix(C_M4X4 matrix, C_Seq4 values)
    //{
    //    Matrix = new float[][]
    //    {
    //        new float[] { matrix.E00, matrix.E01, matrix., values.E0},
    //        new float[] { matrix.E10, matrix.E11, values.E1},
    //    };
    //}
}
