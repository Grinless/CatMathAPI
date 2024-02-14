using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PolarEquationTest : MonoBehaviour
{
    public PolarPeriod2D period;
    public int divisions;
    public Vector2[] points;

    public void OnValidate()
    {
        
    }

    public abstract void GeneratePattern();

    public void OnDrawGizmos()
    {
        foreach (Vector2 vector2 in points)
        {
            Gizmos.DrawSphere(vector2, 0.05f);
        }
    }
}
