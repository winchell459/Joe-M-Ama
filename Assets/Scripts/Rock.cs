using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : BoardPiece
{
    public override bool ValidMove(Vector2Int moveSquare)
    {
        BoardSquare[,] boardSquares = FindObjectOfType<Board>().boardSquares;
        if (boardSquares[moveSquare.x, moveSquare.y] == null) return true;
        else return false;
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
