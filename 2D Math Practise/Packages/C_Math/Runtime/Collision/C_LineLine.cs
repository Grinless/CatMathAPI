using C_Math.Shapes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Math.Collision
{
    public class C_LineLineIntercept
    {
        public static bool BoundingCheck(C_Ray a, C_Ray b)
        {
            C_Seq4 aBounds = GetRayBounds(a);
            C_Seq4 bBounds = GetRayBounds(b);

            if ((aBounds.E0 < bBounds.E0 && aBounds.E2 > bBounds.E2) &&
                (aBounds.E1 < bBounds.E1 && aBounds.E3 > bBounds.E3))
                return true;
            return false;
        }

        public static C_Seq4 GetRayBounds(C_Ray ray)
        {
            float xMin = ray.origin.x;
            float yMin = ray.origin.y;
            float xMax = ray.origin.x + (ray.length * ray.direction).x;
            float yMax = ray.origin.y + (ray.length * ray.direction).y;

            return new C_Seq4(xMin, yMin, xMax, yMax);
        }

        public static void SolveForIntercepts(C_Ray ray1, C_Ray ray2, out C_P2D iPRay1, out C_P2D iPRay2)
        {
            C_P2D a = ray1.origin;
            C_P2D c = ray2.origin;
            C_V2 R = ray1.direction.Unitized;
            C_V2 S = ray2.direction.Unitized;
            C_P2D cMa = (c - a);
            float rXs = C_V2.CrossProduct(R, S);
            float t = C_V2.CrossProduct(cMa, S) / rXs;
            float u = C_V2.CrossProduct(cMa, R) / rXs;
            iPRay1 = a + (C_P2D)(t * R);
            iPRay2 = c + (C_P2D)(u * S);
        }

        public static C_P2D SolveForIntercept(C_Ray ray1, C_Ray ray2)
        {
            C_P2D a = ray1.origin;
            C_P2D c = ray2.origin;
            C_V2 R = ray1.direction.Unitized;
            C_V2 S = ray2.direction.Unitized;
            C_P2D cMa = (c - a);
            float rXs = C_V2.CrossProduct(R, S);
            float t = C_V2.CrossProduct(cMa, S) / rXs;
            return a + (C_P2D)(t * R);
        }
    }
}