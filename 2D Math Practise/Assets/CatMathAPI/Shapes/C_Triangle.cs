using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C_Math.Shapes
{
    [System.Serializable]
    public struct C_Triangle : IShape
    {
        [SerializeField]
        private Vector2 _translation;
        [SerializeField]
        private Vector2 _scale;
        [SerializeField]
        private float _orientation;

        public Vector2 Position
        {
            get => _translation;
            set => _translation = value;
        }

        public Vector2 Scale
        {
            get => _scale;
            set => _scale = value;
        }

        public float Orientation
        {
            get => _orientation;
            set => _orientation = value;
        }

        public Vector2[] GetShapeVerts =>
            new Vector2[3]
            {
                new Vector2(0, 0.5f),
                new Vector2(-0.5f, 0),
                new Vector2(0.5f, 0),
            };

        public Vector2[] GetTransformedVerts
        {
            get
            {
                C_M3X3 matrix = C_M3X3.TRS_Matrix(_translation, _scale, _orientation);
                Vector2[] initalVerts = GetShapeVerts;
                return matrix * initalVerts;
            }
        }

        public IShape GetShape => this;

        public Vector2[] GetSides
        {
            get
            {
                Vector2[] verts = GetTransformedVerts;

                return new Vector2[]
                {
                (verts[1] - verts[0]),
                (verts[2] - verts[1]),
                (verts[0] - verts[2])
                };
            }
        }

        public float[] GetLengths
        {
            get
            {
                Vector2[] verts = GetSides;

                return new float[]
                {
                verts[0].magnitude,
                verts[1].magnitude,
                verts[2].magnitude,
                };
            }
        }

        public Vector2[] GetUnitizedSides
        {
            get
            {
                Vector2[] s = GetSides;
                Vector2[] norms = new Vector2[s.Length];

                for (int i = 0; i < s.Length; i++)
                {
                    norms[i] = s[i].normalized;
                }
                return norms;
            }
        }

        public Vector2[] GetMidpoints
        {
            get
            {
                Vector2[] vert = GetTransformedVerts;
                Vector2[] sides = GetUnitizedSides;
                float[] lengths = GetLengths;

                return new Vector2[]
                {
                vert[0] + (sides[0] * (lengths[0] / 2)),
                vert[1] + (sides[1] * (lengths[1] / 2)),
                vert[2] + (sides[2] * (lengths[2] / 2))
                };
            }
        }

        public Vector2[] GetNormals
        {
            get
            {
                Vector2[] sides = GetSides;
                float[] lengths = GetLengths;
                Vector2[] normals = new Vector2[sides.Length];

                for (int i = 0; i < sides.Length; i++)
                    normals[i] = (sides[i].normalized * (lengths[i] / 2)).normalized;

                return C_M2X2.Rot90C * normals; 
            }
        }

        public C_Triangle(Vector2 position, Vector2 scale, float orientation)
        {
            _translation = position;
            _scale = scale;
            _orientation = orientation;
        }
    }
}
