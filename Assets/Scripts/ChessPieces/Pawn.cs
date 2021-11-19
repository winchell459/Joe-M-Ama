using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    private bool firstMove = true;
    public override bool ValidMove(Vector2Int moveSquare)
    {
        bool valid = true;
        BoardSquare[,] boardSquares = FindObjectOfType<Board>().boardSquares;

        valid = ClearPath(boardSquares, moveSquare);


        
        return valid;
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
