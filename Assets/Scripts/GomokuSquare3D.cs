using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GomokuSquare3D : BoardSquare
{
    public override void PlaceBoardSquare(float x, float y)
    {
        Vector3 pos = new Vector3(x, 0, y);
        transform.position = pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
