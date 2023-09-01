using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatTester : MonoBehaviour
{
    public C_M2X2 a;
    public C_M2X2 b;
    public C_M2X2 c;

    // Start is called before the first frame update
    void Start()
    {
        c = a * b;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
