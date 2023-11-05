using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatTester : MonoBehaviour
{
    public C_M3X3 a;
    public C_M3X3 b;

    // Start is called before the first frame update
    void Start()
    {
        a = new C_M3X3(1, 0, 0, 0, 1, 0, 0, 0, 1);
        b = C_M3X3.Identity; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
