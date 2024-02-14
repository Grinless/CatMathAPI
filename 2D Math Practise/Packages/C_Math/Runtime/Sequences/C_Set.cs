using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Math.Set
{
    [System.Serializable]
    public struct C_Set
    {
        public float[] values;
        
        public int SetLength => values.Length;

        public C_Set Intersection(C_Set b)
        {
            List<float> union = new List<float>();
            float value;

            for (int i = 0; i < values.Length; i++)
            {
                value = values[i];
                for (int j = 0; j < b.values.Length; j++)
                {
                    if(value == b.values[j])
                    {
                        union.Add(b.values[j]);
                    }
                }
            }

            return new C_Set() { values = union.ToArray() };
        }

        public C_Set Union(C_Set b)
        {
            List<float> union = new List<float>();
            union.AddRange(values);
            union.AddRange(b.values);
            union = union.Distinct().ToList();

            return new C_Set() { values = union.ToArray() };
        }

        public C_Set Compliment(C_Set superSet)
        {
            List<float> _values = superSet.values.ToList();
            List<float> _Remainder = new List<float>();

            for (int i = 0; i < _values.Count; i++)
            {
                bool matched = false;
                for (int j = 0; j < values.Length; j++)
                {
                    if (_values[i] == j)
                    {
                        matched = true;
                    }
                }

                if (matched == false)
                {
                    _Remainder.Add(_values[i]);
                }
            }

            return new C_Set() { values = _Remainder.ToArray() };
            
        }
    }
}
