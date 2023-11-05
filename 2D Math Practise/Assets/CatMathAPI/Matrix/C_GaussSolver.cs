using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class C_GaussSolver
{

    //public static void GaussSolver2X2(C_Matrix2X2 m, C_Seq2 values)
    //{
    //    C_Matrix2X2G M = new C_Matrix2X2G(m, values);
    //    float[][] matrix; 

    //    if(!SolvableCheck(ref M))
    //    {
    //        Debug.Log("Cannot complete Gauss Op, returning Zero Matrix");
    //        //return C_Matrix2X2.Identity;
    //    }
        
    //    M.PrintMatrix();

    //    ////Setup the matrix. 
    //    //matrix = new float[][]
    //    //{
    //    //    { M.R1.E0, M.R1.E1, M.R1.E2},
    //    //    { M.R2.E0}
    //    //};
    //}

    //private static bool SolvableCheck(ref C_Matrix2X2G m)
    //{
    //    //Check if solvable. 
    //    if (!(m.R1.E0 != 0 && m.R2.E1 != 0))
    //    {
    //        m.Interchange(); 
    //        if (!(m.R1.E0 != 0 && m.R2.E1 != 0))
    //        {
    //            //Then the augmented matrix has no solutions. 
    //            return false; 
    //        }
    //    }
    //    return true;
    //}
}
