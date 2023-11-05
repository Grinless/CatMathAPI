using UnityEngine;

namespace C_Math.Shapes
{
    public interface IShape
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public float Orientation { get; set; }
        public Vector2[] GetShapeVerts { get; }
        public Vector2[] GetTransformedVerts { get; }

        public IShape GetShape { get; }

        public float GetWidth => Scale.x;

        public float GetHeight => Scale.y;
    }
}


