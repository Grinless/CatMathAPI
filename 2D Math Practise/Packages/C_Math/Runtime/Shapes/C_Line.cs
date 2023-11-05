using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO:Rework to fit into vertex based shape construction patterns. 
namespace C_Math.Shapes
{
    public struct C_Line
    {
        public Vector2 min;
        public Vector2 max;

        #region Properties.
        
        public float MinX =>
            min.x;
        
        public float MaxX =>
            max.x;
        
        public float MinY =>
            min.y;
        
        public float MaxY =>
            max.y;
        
        public Vector2 XBounds => new Vector2(MinX, MaxX);
        
        public Vector2 YBounds => new Vector2(MinY, MaxY);
        #endregion

        public C_Line(Vector2 min, Vector2 max)
        {
            this.min = min; this.max = max;
        }

        public static Vector2[] GetLineDivisions(float number, Vector2 origin, Vector2 end)
        {
            List<Vector2> points = new List<Vector2>();
            points.Add(origin);
            Vector2 pos = origin;
            Vector2 step = new Vector2(
                (end.x - origin.x) / (number - 1),
                (end.y - origin.y) / (number - 1));

            for (int i = 0; i < number - 1; i++)
            {
                points.Add(pos);
                pos += step;
            }
            points.Add(end);
            return points.ToArray();
        }
    }
}
