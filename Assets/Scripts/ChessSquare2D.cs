using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessSquare2D : BoardSquare
{
    public override void PlaceBoardSquare(float x, float y)
    {
        Vector2 pos = new Vector2(x, y);
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
