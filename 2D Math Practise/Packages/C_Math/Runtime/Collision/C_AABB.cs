using C_Math.Shapes;
using UnityEngine;

namespace C_Math.Collision
{
    public static class C_AABB
    {
        //TODO: TEST THIS FUNCTION. 
        public static bool AABBCollisionCheck(C_Rect a, C_Rect b)
        {
            Vector2 minA = a.Min;
            Vector2 maxA = a.Max;
            Vector2 minB = b.Min;
            Vector2 maxB = b.Max;

            if ((minA.x < minB.x && maxA.x > maxB.x) &&
                (minA.y < minB.y && maxA.y > minB.y))
            {
                return true;
            }
            return false;
        }
    }
}


